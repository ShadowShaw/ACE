using System.Collections.Generic;
using PrestaAccesor.Entities;

namespace PrestaAccesor.Accesors
{
    public interface IRestAccesor
    {
        PrestashopEntity Get(long? entityId);
        List<int> GetIds();
        List<int> GetIdsPartial();
        void Add(PrestashopEntity category);
        //void AddImage(int ProductId, string EntityImagePath);
        void Update(PrestashopEntity product);
        void Delete(PrestashopEntity product);

        //List<PrestashopEntity> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit);
        //List<PrestashopEntity> GetAll();
    }
}
