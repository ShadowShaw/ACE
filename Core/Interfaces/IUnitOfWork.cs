using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<UserProfile, int> Users { get; }
        IRepository<MemberShip, int> MemberShips { get; }
        //IRepository<Role, int> UserRoles { get; }

        // Methods
        void Commit();
    }
}