using Core.Data;
using Core.Interfaces;
using Core.Models;
using Core.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Bussiness
{
    public class ACERights
    {
        public bool Pricing = false;
        public bool Consistency = false;
    }

    public class LoginService
    {
        private UnitOfWorkProvider UoWProvider;
        public UserProfile currentUser;
        public ACERights Rights;
        
        //public bool logged;

        public LoginService()
        {
            UoWProvider = new UnitOfWorkProvider();
            Rights = new ACERights();
            currentUser = null;
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
                    this.currentUser = UoWProvider.CreateNew().Users.GetByID(userId);
                    GetRights();
                }
            }
            return result;

        }

        public void GetRights()
        {
            if (File.Exists("key.txt"))
            {
                Rights.Pricing = true;
                Rights.Consistency = true;
            }
            else
            {
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    Rights.Pricing = isModuleActive(uow.ACEModules.GetAll().Where(m => m.Name == TextResources.PricingModuleName).FirstOrDefault().Id);
                    Rights.Consistency = isModuleActive(uow.ACEModules.GetAll().Where(m => m.Name == TextResources.ConsistencyModuleName).FirstOrDefault().Id);
                }
            }
        }

        public bool isModuleActive(int moduleId)
        {
            bool result = false;

            if (currentUser != null)
            {
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    List<ModuleOrder> orders = uow.ModuleOrders.GetAll().Where(u => u.UserId == currentUser.Id).Where(m => m.ModuleId == moduleId).ToList();
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

        public DateTime? getActiveDate(int moduleId)
        {
            DateTime? result = null;

            if (currentUser != null)
            {
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    List<ModuleOrder> orders = uow.ModuleOrders.GetAll().Where(u => u.UserId == currentUser.Id).Where(m => m.ModuleId == moduleId).ToList();
                    foreach (ModuleOrder order in orders)
                    {
                        if (order.OrderDate.AddDays(30) > DateTime.Now)
                        {
                            result = order.OrderDate.AddDays(30);
                        }
                    }
                }
            }

            return result;
        }

        public void logout()
        {
            currentUser = null;
            Rights.Consistency = false;
            Rights.Pricing = false;
        }

        public bool Logged()
        {
            bool result = false;

            if (currentUser != null)
            {
                result = true;
            }

            return result;
        }

    }
}
