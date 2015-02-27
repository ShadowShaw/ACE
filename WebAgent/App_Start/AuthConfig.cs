using System;
using System.Data.Entity;
using System.Linq;
using Core.Data;
using Core.Models;
using WebMatrix.WebData;

namespace ACEAgent
{
    public static class AuthConfig
    {
        public static void InitRoles()
        {
            Database.SetInitializer<AceContext>(null);

            try
            {
                using (var context = new AceContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        //((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                    else
                    {
                        if (!context.Roles.Any())
                        {
                            Role userRole = new Role {RoleName = "user"};
                            context.Roles.Add(userRole);

                            Role adminRole = new Role {RoleName = "admin"};
                            context.Roles.Add(adminRole);

                            context.SaveChanges();
                        }
                    }
                }

                WebSecurity.InitializeDatabaseConnection("ACEContext", "UserProfile", "Id", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }

        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
