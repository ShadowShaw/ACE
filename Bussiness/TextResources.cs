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
        public const string HintLoadProducts = "Načte databázi produktů eshopu";
        public const string HintEmptyCategory = "Vypíše produkty, které nejsou přiřazeny v žádné kategorii, tedy jsou v root kategorii";
        public const string HintEmptyManufacturer = "Vypíše produkty, u kterých není přiřazen žádný výrobce";
        public const string HintWithoutImage = "Vypíše produkty u kterých není přiřazen žádný obrázek";
        public const string HintWithoutShortDescription = "Vypíše produkty bez krátkého popisu";
        public const string HintWithoutLongDescription = "Vypíše produkty bez dlouhého popisu";
        public const string HintWithoutPrice = "Vypíše produkty bez maloobchodní prodejní ceny";
        public const string HintWithoutWholeSalePrice = "Vypíše produkty bez velkoobchodní prodejní ceny";
        public const string HintWithoutWeight = "Vypíše produkty u kterých není zadána váha";
        public const string HintWithoutSupplier = "Vypíše produkty u kterých není zadán dodavatel";
        
        //consistency grid titles
        public const string TitleLoadProducts = "Načte databázi produktů eshopu";
        public const string TitleEmptyCategory = "Zobrazuji produkty s prázdnou kategorii.";
        public const string TitleEmptyManufacturer = "Vypíše produkty, u kterých není přiřazen žádný výrobce";
        public const string TitleWithoutImage = "Vypíše produkty u kterých není přiřazen žádný obrázek";
        public const string TitleWithoutShortDescription = "Vypíše produkty bez krátkého popisu";
        public const string TitleWithoutLongDescription = "Vypíše produkty bez dlouhého popisu";
        public const string TitleWithoutPrice = "Vypíše produkty bez maloobchodní prodejní ceny";
        public const string TitleWithoutWholeSalePrice = "Vypíše produkty bez velkoobchodní prodejní ceny";
        public const string TitleWithoutWeight = "Vypíše produkty u kterých není zadána váha";
        public const string TitleWithoutSupplier = "Zobrazuji produkty jenž dodavatelé již nedodávají.";
        public const string TitleEmptyDescription = "Zobrazuji produkty s prázdným krátkým popisem.";

        //label strings
        

        //message boxes
        public const string MsgEmptyConfigurationValue = "Nenalezena konfigurace připojení k eshopům. Prosím nastavte připojení.";
        public const string MsgEmptyConfigurationTitle = "Nenalezena konfigurace připojení k eshopům.";
        public const string MsgNoPriceListTitle = "Ceník není k dispozici";
        public const string MsgNoPriceListValue = "Ceník není k dispozici, otevřete ceník";
        public const string MsgDeleteEshopTitle = "Odstranit konfiguraci eshopu";
        public const string MsgDeleteEshopValue = "Chcete opravdu odstranit konfiguraci eshopu: ";
        public const string MsgDeleteProductTitle = "Odstranit produkt";
        public const string MsgDeleteProductValue = "Chcete opravdu odstranit produkt?";
        public const string MsgLoginFailedValue = "Nesprávné uživatelské jméno, či heslo.";
        public const string MsgLoginFailedTitle = "Nesprávné heslo";

    }
}
