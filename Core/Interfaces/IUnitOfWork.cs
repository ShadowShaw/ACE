﻿using System;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<UserProfile, int> Users { get; }
        IRepository<MemberShip, int> MemberShips { get; }
        
        IRepository<AceModule, int> AceModules { get; }
        IRepository<Payment, int> Payments { get; }
        IRepository<ModuleOrder, int> ModuleOrders { get; }
        
        // Methods
        void Commit();
    }
}