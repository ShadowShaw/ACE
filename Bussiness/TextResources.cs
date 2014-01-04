using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness
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
        public const string hintLoadProducts = "Načte databázi produktů eshopu";
        public const string hintEmptyCategory = "Vypíše produkty, které nejsou přiřazeny v žádné kategorii, tedy jsou v root kategorii";
        public const string hintEmptyManufacturer = "Vypíše produkty, u kterých není přiřazen žádný výrobce";
        public const string hintWithoutImage = "Vypíše produkty u kterých není přiřazen žádný obrázek";
        public const string hintWithoutShortDescription = "Vypíše produkty bez krátkého popisu";
        public const string hintWithoutLongDescription = "Vypíše produkty bez dlouhého popisu";
        public const string hintWithoutPrice = "Vypíše produkty bez maloobchodní prodejní ceny";
        public const string hintWithoutWholeSalePrice = "Vypíše produkty bez velkoobchodní prodejní ceny";
        public const string hintWithoutWeight = "Vypíše produkty u kterých není zadána váha";
        public const string hintWithoutSupplier = "Vypíše produkty u kterých není zadán dodavatel";
        
        //consistency grid titles
        public const string titleLoadProducts = "Načte databázi produktů eshopu";
        public const string titleEmptyCategory = "Zobrazuji produkty s prázdnou kategorii.";
        public const string titleEmptyManufacturer = "Vypíše produkty, u kterých není přiřazen žádný výrobce";
        public const string titleWithoutImage = "Vypíše produkty u kterých není přiřazen žádný obrázek";
        public const string titleWithoutShortDescription = "Vypíše produkty bez krátkého popisu";
        public const string titleWithoutLongDescription = "Vypíše produkty bez dlouhého popisu";
        public const string titleWithoutPrice = "Vypíše produkty bez maloobchodní prodejní ceny";
        public const string titleWithoutWholeSalePrice = "Vypíše produkty bez velkoobchodní prodejní ceny";
        public const string titleWithoutWeight = "Vypíše produkty u kterých není zadána váha";
        public const string titleWithoutSupplier = "Zobrazuji produkty jenž dodavatelé již nedodávají.";

        //label strings
        

        //message boxes
        public const string msgEmptyConfigurationValue = "Nenalezena konfigurace připojení k eshopům. Prosím nastavte připojení.";
        public const string msgEmptyConfigurationTitle = "Nenalezena konfigurace připojení k eshopům.";
        public const string msgNoPriceListTitle = "Ceník není k dispozici";
        public const string msgNoPriceListValue = "Ceník není k dispozici, otevřete ceník";
        public const string msgDeleteEshopTitle = "Odstranit konfiguraci eshopu";
        public const string msgDeleteEshopValue = "Chcete opravdu odstranit konfiguraci eshopu: ";
            
    }
}
