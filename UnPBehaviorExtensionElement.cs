using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace UnPExtension
{
    public class UnPBehaviorExtensionElement : ClientCredentialsElement
    {
        const string userNamePropertyName = "userName";

        [ConfigurationProperty(userNamePropertyName)]
        public string UserName
        {
            get { return (string)base[userNamePropertyName]; }
            set { base[userNamePropertyName] = value; }
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(UnPClientCredentials);
            }
        }

        protected override object CreateBehavior()
        {
            return new UnPClientCredentials(this.UserName);
        }
    }
}
