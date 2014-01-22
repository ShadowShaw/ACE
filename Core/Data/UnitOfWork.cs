using Core.Interfaces;
using Core.Models;

namespace Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        //////////////////////////////////////////////////////////////////////////
        // Entity framework repository
        //////////////////////////////////////////////////////////////////////////

        private readonly IRepository<UserProfile, int> userRepository;
        private readonly IRepository<MemberShip, int> memberShipRepository;
        //private IRepository<Role, int> userRoleRepository;
        private readonly IRepository<ACEModule, int> aceModuleRepository;
        private readonly IRepository<Payment, int> paymentRepository;
        //private IRepository<UsersInRole, int> usersInRoleRepository;
        private readonly IRepository<ModuleOrder, int> moduleOrderRepository;
        
        public UnitOfWork(ACEContext efContext)
        {
            EfContext = efContext;

            //////////////////////////////////////////////////////////////////////////
            // Entity Framework repositories
            //////////////////////////////////////////////////////////////////////////
            userRepository = new EFRepository<UserProfile>(this);
            memberShipRepository = new EFRepository<MemberShip>(this);
            //this.userRoleRepository = new EFRepository<Role>(this);
            aceModuleRepository = new EFRepository<ACEModule>(this);
            paymentRepository = new EFRepository<Payment>(this);
            //this.usersInRoleRepository = new EFRepository<UsersInRole>(this);
            moduleOrderRepository = new EFRepository<ModuleOrder>(this);
        }

        public IRepository<UserProfile, int> Users
        {
            get { return userRepository; }
        }

        public IRepository<MemberShip, int> MemberShips
        {
            get { return memberShipRepository; }
        }

        //public IRepository<Role, int> UserRoles
        //{
        //    get { return this.userRoleRepository; }
        //}

        public IRepository<ACEModule, int> ACEModules
        {
            get { return aceModuleRepository; }
        }

        public IRepository<Payment, int> Payments
        {
            get { return paymentRepository; }
        }

        public IRepository<ModuleOrder, int> ModuleOrders
        {
            get { return moduleOrderRepository; }
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
           EfContext.SaveChanges();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}

