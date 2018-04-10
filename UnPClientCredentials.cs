using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace UnPExtension
{
    public class UnPClientCredentials: ClientCredentials
    {
        private string userName;

        public UnPClientCredentials(string userName)
        {
            // Perform client credentials initialization.
            this.userName = userName;
        }

        protected UnPClientCredentials(UnPClientCredentials other)
            : base(other)
        {
            // Clone fields defined in this class.

        }

        // Return your implementation of the SecurityTokenManager.
        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            ServiceSecurityContext ctx = ServiceSecurityContext.Current;
            return new UnPCredentialsSecurityTokenManager(this);
        }

        // Implement the cloning functionality.
        protected override ClientCredentials CloneCore()
        {
            
            return new UnPClientCredentials(this);
        }
    }
}
