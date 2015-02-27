using Core.Interfaces;

namespace Core.Data
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork CreateNew()
        {
            return new UnitOfWork(new AceContext());
        }
    }
}