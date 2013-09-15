using Core.Data;
using Core.Interfaces;
using Core.Models;
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
        public string loggedUserName;
        public int loggedUserId;
        public bool logged;

        public LoginService()
        {
            UoWProvider = new UnitOfWorkProvider();
            logged = false;
        }

        public bool checkDesktopLogin(string username, string password)
        {
            bool result = false;
            
            if ((username != "") && (password != ""))
            {
                int userId = 0;
                string HashedPassword = "";
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    var UserList = uow.Users.GetAll().Where(x => x.UserName == username);
                    if (UserList.Count() == 1)
                    {
                        userId = UserList.First().Id;
                        HashedPassword = uow.MemberShips.GetByID(userId).Password;
                    }
                }

                if (DesktopLogin.VerifyHashedPassword(HashedPassword, password))
                {
                    result = true;
                    logged = true;
                    loggedUserName = username;
                    loggedUserId = userId;
                }
            }
            return result;

        }

        public bool isModuleActive(int moduleId)
        {
            bool result = false;

            if (logged)
            {
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    List<ModuleOrder> orders = uow.ModuleOrders.GetAll().Where(u => u.UserId == loggedUserId).Where(m => m.ModuleId == moduleId).ToList();
                    foreach (ModuleOrder order in orders)
                    {
                        if (order.OrderDate.AddDays(30) > DateTime.Now)
                        {
                            result = true;
                        }
                    }
                }
            }
            
            return result;
        }

        public void logout()
        {
            logged = false;
            loggedUserId = 0;
            loggedUserName = "";
        }

    }
}
