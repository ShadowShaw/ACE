using Bussiness.Interfaces;

namespace Bussiness.ViewModels
{
    public class CategoryViewModel : IViewModel
    {
        public long? Id { get; set; }
        //public long id_shop { get; set; }  //entity.shop
        //public string description { get; set; }
        //public List<Entities.language> short_description { get; set; }
        public string LinkRewrite { get; set; }
        //public List<Entities.language> meta_title { get; set; }
        //public List<Entities.language> meta_description { get; set; }
        //public List<Entities.language> meta_keywords { get; set; }

        public string Name { get; set; }  

        public long? IdParent { get; set; }
        public long IdShopDefault { get; set; }
        public byte LevelDepth { get; set; }
        public bool IsRootCategory { get; set; }
    }
}