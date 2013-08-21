using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestaAccesor.Accesors
{
    public interface IRestAccesor
    {
        Entities.PrestashopEntity Get(long? EntityId);
        List<int> GetIds();
        List<int> GetIdsPartial();
        //void Add(Entities.prestashopentity Entity);
        //void AddImage(int ProductId, string EntityImagePath);
        void Update(Entities.PrestashopEntity Entity);
        void Delete(Entities.PrestashopEntity Entity);
        
        //List<prestashopentity> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit);
        //List<prestashopentity> GetAll();
    }
}
