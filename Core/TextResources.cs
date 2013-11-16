using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public static class TextResources
    {
        // dgConsistency view
        public const string Name = "Jméno";
        public const string Category = "Kategorie";
        public const string WholeSalePrice = "Velkoobchodní cena";
        public const string SalePrice = "Cena";
        public const string Manufacturer = "Výrobce";
        public const string ProductImage = "Obrázek produktu";
        public const string ShortDescription = "Krátký popis";
        public const string Description = "Dlouhý popis";
        public const string Weight = "Váha";
        public const string Id = "Id";
        public const string LinkButton = "Otevřít produkt";
        public const string DeleteButton = "Smazat produkt";


        //dgPricing
        public const string Supplier = "Dodavatel";

        // dgChanges view
        public const string Type = "Typ";
        public const string Field = "Pole";
        public const string Value = "Hodnota";
        public const string Confirmation = "Potvrzení";

        //button context help
        public const string hLoadProducts = "Načte databázi produktů eshopu";
        public const string hEmptyCategory = "Vypíše produkty, které nejsou přiřazeny v žádné kategorii, tedy jsou v root kategorii";
        public const string hEmptyManufacturer = "Vypíše produkty, u kterých není přiřazen žádný výrobce";
        public const string hWithoutImage = "Vypíše produkty u kterých není přiřazen žádný obrázek";
        public const string hWithoutShortDescription = "Vypíše produkty bez krátkého popisu";
        public const string hWithoutLongDescription = "Vypíše produkty bez dlouhého popisu";
        public const string hWithoutPrice = "Vypíše produkty bez maloobchodní prodejní ceny";
        public const string hWithoutWholeSalePrice = "Vypíše produkty bez velkoobchodní prodejní ceny";
        public const string hWithoutWeight = "Vypíše produkty u kterých není zadána váha";

        //modules names
        public const string PricingModuleName = "Přeceňování";
        public const string ConsistencyModuleName = "Kontrola databáze";
        public const string PricingModuleDescription = "Modul pro přeceňování eshopu.";
        public const string ConsistencyModuleDescription = "Modul sloužící pro rychlou kontrolu databáze.";
        public const decimal PricingModulePrice = 499;
        public const decimal ConsistencyModulePrice = 1;
    }
}
