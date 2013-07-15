using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork CreateNew();
    }

}