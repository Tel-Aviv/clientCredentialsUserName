using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace UnPExtension
{

    class UnPSecurityTokenProvider : SecurityTokenProvider
    {

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            ServiceSecurityContext ctx = ServiceSecurityContext.Current;
            return new UserNameSecurityToken("olegk", "dfnc94^*");
        }

    }

    class UnPCredentialsSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        UnPClientCredentials credentials;

        public UnPCredentialsSecurityTokenManager(UnPClientCredentials credentials)
            : base(credentials)
        {
            this.credentials = credentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement requirement)
        {
            if (requirement.TokenType == SecurityTokenTypes.UserName)
            {
                return new UnPSecurityTokenProvider();
            }
            // Return your implementation of the SecurityTokenProvider, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenProvider(requirement);
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(
            SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            // Return your implementation of the SecurityTokenAuthenticator, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            // Return your implementation of the SecurityTokenSerializer, if required.
            // This implementation delegates to the base class.
            return base.CreateSecurityTokenSerializer(version);
        }
    }
}
