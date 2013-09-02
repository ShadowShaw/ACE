using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace Core.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        //////////////////////////////////////////////////////////////////////////
        // Entity framework repository
        //////////////////////////////////////////////////////////////////////////

        private IRepository<UserProfile, int> userRepository;
        private IRepository<MemberShip, int> memberShipRepository;
        //private IRepository<Role, int> userRoleRepository;
        private IRepository<ACEModule, int> aceModuleRepository;
        private IRepository<Payment, int> paymentRepository;
        //private IRepository<UsersInRole, int> usersInRoleRepository;
        private IRepository<ModuleOrder, int> moduleOrderRepository;
        
        public UnitOfWork(ACEContext ef_context)
        {
            this.EfContext = ef_context;

            //////////////////////////////////////////////////////////////////////////
            // Entity Framework repositories
            //////////////////////////////////////////////////////////////////////////
            this.userRepository = new EFRepository<UserProfile>(this);
            this.memberShipRepository = new EFRepository<MemberShip>(this);
            //this.userRoleRepository = new EFRepository<Role>(this);
            this.aceModuleRepository = new EFRepository<ACEModule>(this);
            this.paymentRepository = new EFRepository<Payment>(this);
            //this.usersInRoleRepository = new EFRepository<UsersInRole>(this);
            this.moduleOrderRepository = new EFRepository<ModuleOrder>(this);
        }

        public IRepository<UserProfile, int> Users
        {
            get { return this.userRepository; }
        }

        public IRepository<MemberShip, int> MemberShips
        {
            get { return this.memberShipRepository; }
        }

        //public IRepository<Role, int> UserRoles
        //{
        //    get { return this.userRoleRepository; }
        //}

        public IRepository<ACEModule, int> ACEModules
        {
            get { return this.aceModuleRepository; }
        }

        public IRepository<Payment, int> Payments
        {
            get { return this.paymentRepository; }
        }

        public IRepository<ModuleOrder, int> ModuleOrders
        {
            get { return this.moduleOrderRepository; }
        }

        //public IRepository<UsersInRole, int> UsersInRoles
        //{
        //    get { return this.usersInRoleRepository; }
        //}
        //////////////////////////////////////////////////////////////////////////
        // Methods & Members
        //////////////////////////////////////////////////////////////////////////

        internal ACEContext EfContext { get; private set; }

        public virtual void Commit()
        {
           this.EfContext.SaveChanges();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}

