using Core.Data;
using Core.Interfaces;
using Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Bussiness
{
    public class LoginService
    {
        private UnitOfWorkProvider UoWProvider;

        public LoginService()
        {
            UoWProvider = new UnitOfWorkProvider();
        }

        public bool checkDesktopLogin(string username, string password)
        {
            bool result = false;
            if ((username != "") && (password != ""))
            {
                string HashedPassword = "";
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    var UserList = uow.Users.GetAll().Where(x => x.UserName == username);
                    if (UserList.Count() == 1)
                    {
                        var UserId = UserList.First().Id;
                        HashedPassword = uow.MemberShips.GetByID(UserId).Password;
                    }
                }

                if (DesktopLogin.VerifyHashedPassword(HashedPassword, password))
                {
                    result = true;
                }
            }
            return result;

        }
    }
}
