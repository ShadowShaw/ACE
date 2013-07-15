using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;

namespace Core.Data
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork CreateNew()
        {
            return new UnitOfWork(new ACEContext());
        }
    }
}