using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using PriceUpdater.Models;
using Core.Data;

namespace PriceUpdater
{
    public static class AuthConfig
    {
        public static void InitRoles()
        {
            //if (System.Web.Security.Roles.RoleExists("admins") == false)
            //{
            //    System.Web.Security.Roles.CreateRole("admins");
            //}

            //if (System.Web.Security.Roles.RoleExists("users") == false)
            //{
            //    System.Web.Security.Roles.CreateRole("users");
            //}
            
            UnitOfWorkProvider uowProvider = new UnitOfWorkProvider();
            var uow = uowProvider.CreateNew();

            ACEContext ace = new ACEContext();
            //ace.Roles.Add(
            
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
