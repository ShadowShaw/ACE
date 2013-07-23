using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestaAccesor.Accesors
{
    public interface IRestAccesor
    {
        Entities.prestashopentity Get(int EntityId);
        //void Add(Entities.prestashopentity Entity);
        //void AddImage(int ProductId, string EntityImagePath);
        //void Update(Entities.prestashopentity Entity);
        //void Delete(Entities.prestashopentity Entity);
        List<int> GetIds();
        List<int> GetIdsPartial();
        //List<prestashopentity> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit);
        //List<prestashopentity> GetAll();
    }
}
