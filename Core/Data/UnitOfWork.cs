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
        private IRepository<UserRole, int> userRoleRepository;
        
        public UnitOfWork(ACEContext ef_context)
        {
            this.EfContext = ef_context;

            //////////////////////////////////////////////////////////////////////////
            // Entity Framework repositories
            //////////////////////////////////////////////////////////////////////////
            this.userRepository = new EFRepository<UserProfile>(this);
            this.memberShipRepository = new EFRepository<MemberShip>(this);
            this.userRoleRepository = new EFRepository<UserRole>(this);
        }

        public IRepository<UserProfile, int> Users
        {
            get { return this.userRepository; }
        }

        public IRepository<MemberShip, int> MemberShips
        {
            get { return this.memberShipRepository; }
        }

        public IRepository<UserRole, int> UserRoles
        {
            get { return this.userRoleRepository; }
        }
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

