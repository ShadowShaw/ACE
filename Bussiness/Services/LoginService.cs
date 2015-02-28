using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Core;
using Core.Data;
using Core.Interfaces;
using Core.Models;
using Core.Security;

namespace Bussiness.Services
{
    public class AceRights
    {
        public bool Pricing;
        public bool Consistency;
    }

    public class LoginService
    {
        private readonly UnitOfWorkProvider _uowProvider;
        public UserProfile CurrentUser { get; private set;}
        public AceRights Rights;
        
        public LoginService()
        {
            _uowProvider = new UnitOfWorkProvider();
            Rights = new AceRights();
            CurrentUser = null;
        }

        public bool CheckDesktopLogin(string username, string password)
        {
            bool result = false;
            
            if ((username != "") && (password != ""))
            {
                int userId = 0;
                string hashedPassword = "";
                using (IUnitOfWork uow = _uowProvider.CreateNew())
                {
                    var userList = uow.Users.GetAll().Where(x => x.UserName == username);
                    if (userList.Count() == 1)
                    {
                        userId = userList.First().Id;
                        hashedPassword = uow.MemberShips.GetAll().First(i => i.UserId == userId).Password;
                    }
                }

                if (DesktopLogin.VerifyHashedPassword(hashedPassword, password))
                {
                    result = true;
                    CurrentUser = _uowProvider.CreateNew().Users.GetByID(userId);
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
                using (IUnitOfWork uow = _uowProvider.CreateNew())
                {
                    ACEModule pricingModule = uow.ACEModules.GetAll().FirstOrDefault(m => m.Name == ModuleInfo.PricingModuleName);
                    if (pricingModule != null)
                    {
                        Rights.Pricing = IsModuleActive(pricingModule.Id);
                    }

                    ACEModule consistencyModule = uow.ACEModules.GetAll().FirstOrDefault(m => m.Name == ModuleInfo.ConsistencyModuleName);
                    if (consistencyModule != null)
                    {
                        Rights.Consistency = IsModuleActive(consistencyModule.Id);
                    }
                }
            }
        }

        private bool IsModuleActive(int moduleId)
        {
            bool result = false;

            if (CurrentUser != null)
            {
                using (IUnitOfWork uow = _uowProvider.CreateNew())
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
            if (IsOnline())
            {
                if (Logged())
                {
                    using (IUnitOfWork uow = new UnitOfWorkProvider().CreateNew())
                    {
                        foreach (ACEModule item in uow.ACEModules.GetAll().ToList())
                        {
                            bool active = IsModuleActive(item.Id);

                            DateTime? date = GetActiveDate(item.Id);
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
            }

            return grid;
        }

        public bool IsOnline()
        {
            try
            {
                using (WebClient client = new WebClient())
                using (Stream stream = client.OpenRead("http://www.google.com"))
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private DateTime? GetActiveDate(int moduleId)
        {
            DateTime? result = null;

            if (CurrentUser != null)
            {
                using (IUnitOfWork uow = _uowProvider.CreateNew())
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

        public void Logout()
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
