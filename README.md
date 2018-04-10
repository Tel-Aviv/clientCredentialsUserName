# clientCredentialsUserName
WCF Endpoing behavior for Username/password authentication

Out of the box, WCF provides a variety of endpoint behavior extensions. Amomg them is <clientCredentials> behavior that enables the client  to declare its credentials which will be used when performing authentication against the service. It's important to note that such <clientCredentials> should be supplied in coordination with actual binding's security mode used. 
  Because of securty resons, <clientCredentials> does not includes the option to specify username/password neither for wsHttpBings nor for basicHttpBinding (used primarily for development purpose, when username/password are passed over insecured http, not https). 
  However, for some scenarios it is very important to have some kind of such functionality. For example, WCF Router may be configured to receive the messsages over, say, basicHttpBinding and route the to the endpoint in which userName security is used. In this case, we can not expect the client to pass the username simply because it calls the WCF Router intermediary with Windows credentials, but the destination service do expect the username authentication that must to use the values for this authentocation from somewhere.
  Logically, this "somewhere" may be an SSO system that matches Windows credentials passed to WCF Router to value pairs from affiliated app, but for simplier case these pair in non-production cases may be stored in WCF configuration file. 
  Such configuration, then, should looks like:
      <system.serviceModel>
        <behaviors>
            <endpointBehaviors>
                <behavior name="UnPBehavior">
                    <clientCredentialsUserName UserName="olegk" password="xxx" />
                </behavior>
            </endpointBehaviors>
        </behaviors>
        <extensions>
            <behaviorExtensions>
                <add name="clientCredentialsUserName" type="UnPExtension.UnPBehaviorExtensionElement, UnPExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=c60a72bef01109be" />
            </behaviorExtensions>
        </extensions>

and further, when applied to client endpont:
            <endpoint address="http://nicepc/ServiceUnP/ServiceUnP.svc" behaviorConfiguration="UnPBehavior"
                binding="basicHttpBinding" bindingConfiguration="UnPBindings"
                contract="ServiceReference3.IServiceUnP" name="BasicHttpBinding_IServiceUnP" />
