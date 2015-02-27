using Core.Interfaces;
using Core.Models;

namespace Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        //////////////////////////////////////////////////////////////////////////
        // Entity framework repository
        //////////////////////////////////////////////////////////////////////////

        private readonly IRepository<UserProfile, int> _userRepository;
        private readonly IRepository<MemberShip, int> _memberShipRepository;
        //private IRepository<Role, int> userRoleRepository;
        private readonly IRepository<ACEModule, int> _aceModuleRepository;
        private readonly IRepository<Payment, int> _paymentRepository;
        //private IRepository<UsersInRole, int> usersInRoleRepository;
        private readonly IRepository<ModuleOrder, int> _moduleOrderRepository;
        
        public UnitOfWork(AceContext efContext)
        {
            EfContext = efContext;

            //////////////////////////////////////////////////////////////////////////
            // Entity Framework repositories
            //////////////////////////////////////////////////////////////////////////
            _userRepository = new EfRepository<UserProfile>(this);
            _memberShipRepository = new EfRepository<MemberShip>(this);
            //this.userRoleRepository = new EFRepository<Role>(this);
            _aceModuleRepository = new EfRepository<ACEModule>(this);
            _paymentRepository = new EfRepository<Payment>(this);
            //this.usersInRoleRepository = new EFRepository<UsersInRole>(this);
            _moduleOrderRepository = new EfRepository<ModuleOrder>(this);
        }

        public IRepository<UserProfile, int> Users
        {
            get { return _userRepository; }
        }

        public IRepository<MemberShip, int> MemberShips
        {
            get { return _memberShipRepository; }
        }

        //public IRepository<Role, int> UserRoles
        //{
        //    get { return this.userRoleRepository; }
        //}

        public IRepository<ACEModule, int> ACEModules
        {
            get { return _aceModuleRepository; }
        }

        public IRepository<Payment, int> Payments
        {
            get { return _paymentRepository; }
        }

        public IRepository<ModuleOrder, int> ModuleOrders
        {
            get { return _moduleOrderRepository; }
        }

        //public IRepository<UsersInRole, int> UsersInRoles
        //{
        //    get { return this.usersInRoleRepository; }
        //}
        //////////////////////////////////////////////////////////////////////////
        // Methods & Members
        //////////////////////////////////////////////////////////////////////////

        internal AceContext EfContext { get; private set; }

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

