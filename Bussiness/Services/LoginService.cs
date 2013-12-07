using Core;
using Core.Data;
using Core.Interfaces;
using Core.Models;
using Core.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bussiness.Services
{
    public class ACERights
    {
        public bool Pricing = false;
        public bool Consistency = false;
    }

    public class LoginService
    {
        private UnitOfWorkProvider UoWProvider;
        public UserProfile CurrentUser { get; private set;}
        public ACERights Rights;
        
        public LoginService()
        {
            UoWProvider = new UnitOfWorkProvider();
            Rights = new ACERights();
            CurrentUser = null;
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
                    this.CurrentUser = UoWProvider.CreateNew().Users.GetByID(userId);
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
                    Rights.Pricing = isModuleActive(uow.ACEModules.GetAll().Where(m => m.Name == ModuleInfo.PricingModuleName).FirstOrDefault().Id);
                    Rights.Consistency = isModuleActive(uow.ACEModules.GetAll().Where(m => m.Name == ModuleInfo.ConsistencyModuleName).FirstOrDefault().Id);
                }
            }
        }

        private bool isModuleActive(int moduleId)
        {
            bool result = false;

            if (CurrentUser != null)
            {
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    List<ModuleOrder> orders = uow.ModuleOrders.GetAll().Where(u => u.UserId == CurrentUser.Id).Where(m => m.ModuleId == moduleId).ToList();
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

        public DataGridView GetModuleInfo(DataGridView grid)
        {
            if (Logged())
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    foreach (ACEModule item in uow.ACEModules.GetAll().ToList())
                    {
                        bool active = false;
                        if (isModuleActive(item.Id))
                        {
                            active = true;
                        }
                        DateTime? date = getActiveDate(item.Id);
                        string dateInString = "";
                        if (date != null)
                        {
                            dateInString = date.ToString();
                        }

                        grid.Rows.Add(item.Name, active, dateInString);
                    }
                }
            }
            else
            {
                using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                {
                    foreach (ACEModule item in uow.ACEModules.GetAll().ToList())
                    {
                        grid.Rows.Add(item.Name, false, "");
                    }
                }
            }
                        
            return grid;
        }

        private DateTime? getActiveDate(int moduleId)
        {
            DateTime? result = null;

            if (CurrentUser != null)
            {
                using (IUnitOfWork uow = UoWProvider.CreateNew())
                {
                    List<ModuleOrder> orders = uow.ModuleOrders.GetAll().Where(u => u.UserId == CurrentUser.Id).Where(m => m.ModuleId == moduleId).ToList();
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
            CurrentUser = null;
            Rights.Consistency = false;
            Rights.Pricing = false;
        }

        public bool Logged()
        {
            bool result = false;

            if (CurrentUser != null)
            {
                result = true;
            }

            return result;
        }

    }
}
