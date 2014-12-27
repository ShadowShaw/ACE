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
        public const string Reference = "Reference";

        //dgPricing
        public const string Supplier = "Dodavatel";

        // dgChanges view
        public const string Type = "Typ";
        public const string Field = "Pole";
        public const string Value = "Hodnota";
        public const string Confirmation = "Potvrzení";

        //button context help
        public const string HintLoadProducts = "Načte databázi produktů eshopu";
        public const string HintWithoutCategory = "Vypíše produkty, které nejsou přiřazeny v žádné kategorii, tedy jsou v root kategorii";
        public const string HintWithoutManufacturer = "Vypíše produkty, u kterých není přiřazen žádný výrobce";
        public const string HintWithoutImage = "Vypíše produkty u kterých není přiřazen žádný obrázek";
        public const string HintWithoutShortDescription = "Vypíše produkty bez krátkého popisu";
        public const string HintWithoutLongDescription = "Vypíše produkty bez dlouhého popisu";
        public const string HintWithoutPrice = "Vypíše produkty bez maloobchodní prodejní ceny";
        public const string HintWithoutWholeSalePrice = "Vypíše produkty bez velkoobchodní prodejní ceny";
        public const string HintWithoutWeight = "Vypíše produkty u kterých není zadána váha";
        public const string HintWithoutSupplier = "Vypíše produkty u kterých není zadán dodavatel";
        
        //consistency grid titles
        public const string GridTitleLoadProducts = "Načte databázi produktů eshopu";
        public const string GridTitleEmptyCategory = "Zobrazuji produkty s prázdnou kategorii.";
        public const string GridTitleEmptyManufacturer = "Zobrazuji produkty s prázdným výrobcem.";
        public const string GridTitleEmptyImage = "Zobrazuji produkty u kterých není přiřazen žádný obrázek";
        public const string GridTitleEmptyLongDescription = "Zobrazuji produkty s prázdným dlouhým popisem.";
        public const string GridTitleEmptyPrice = "Zobrazuji produkty bez maloobchodní ceny.";
        public const string GridTitleEmptyWholeSalePrice = "Zobrazuji produkty bez velkoobchodní ceny.";
        public const string GridTitleEmptyWeight = "Zobrazuji produkty bez udané váhy.";
        public const string GridTitleEmptySupplier = "Zobrazuji produkty bez zadaného dodavatele.";
        public const string GridTitleEmptyShortDescription = "Zobrazuji produkty s prázdným krátkým popisem.";
        public const string GridTitleWithoutAnySupplier = "Zobrazuji produkty, jenž již dodavatelé nedodávají";

        //label strings
        
        //buttons
        public const string ButtonLogout = "Odhlášení";

        // Combo boxes
        public const string ComboAnyManufacturer = "Jakýkoliv výrobce";
        public const string ComboAnySupplier = "Jakýkoliv dodavatel";

        // Status bar
        public const string StatusNoActiveEshop = "Aktivní eshop: žádný";
        public const string StatusActiveEshop = "Aktivní eshop: ";
        public const string StatusSavingChanges = "Ukladám změny, prosím čekejte...";
        public const string StatusLoadingLanguages = "Nahrávám jazyky, prosím čekejte...";
        public const string StatusLoadingManufacturers = "Nahrávám výrobce, prosím čekejte...";
        public const string StatusLoadingCategories = "Nahrávám kategorie, prosím čekejte...";
        public const string StatusLoadingProducts = "Nahrávám produkty, prosím čekejte...";
        public const string StatusLoadingSuppliers = "Nahrávám dodavatele, prosím čekejte...";
        public const string StatusRepriceInProgress = "Přeceňuji produkty, prosím čekejte...";

        // Message boxes
        public const string MsgNoChangesToSaveValue = "Nejsou žádné změny k zápisu.";
        public const string MsgNoChangesToSaveTitle = "Žádné změny";
        public const string MsgEmptyConfigurationValue = "Nenalezena konfigurace připojení k eshopu. Prosím nastavte připojení.";
        public const string MsgEmptyConfigurationTitle = "Nenalezena konfigurace připojení k eshopu.";
        public const string MsgNotOnlineValue = "Pro tuto činnosti připojte počítač do sítě internet.";
        public const string MsgNotOnlineTitle = "Nedetekováno připojení k internetu.";
        public const string MsgNoPriceListTitle = "Ceník není k dispozici";
        public const string MsgNoPriceListValue = "Ceník není k dispozici, otevřete ceník";
        public const string MsgDeleteEshopTitle = "Odstranit konfiguraci eshopu";
        public const string MsgDeleteEshopValue = "Chcete opravdu odstranit konfiguraci eshopu: ";
        public const string MsgDeleteProductTitle = "Odstranit produkt";
        public const string MsgDeleteProductValue = "Chcete opravdu odstranit produkt?";
        public const string MsgLoginFailedValue = "Nesprávné uživatelské jméno, či heslo.";
        public const string MsgLoginFailedTitle = "Nesprávné heslo";
        public const string MsgRightsErrorValue = "K této akci nemáte potřebné oprávnění. Objednejte danný modul.";
        public const string MsgRightsErrorTitle = "Chyba práv";
        public const string MsgConnectionTestPass = "Server eshopu odpovídá.";
        public const string MsgConnectionTestFail = "Server eshopu neodpovídá.";
        public const string MsgConnectionTestTitle = "Test připojení";
        public const string MsgErrorInConnectionParameters = "Před testem připojení zadejte validiní parametry.";
        public const string MsgLoginRequiredValue = "Pro použití ACE se musíte přihlásit.";
        public const string MsgLoginRequiredTitle = "Vyžadováno přihlášení";
        
        // Eshop Configuration User Control
        public const string EUCPrestaSetup = "Konfigurace eshopu ";
        public const string EUCValidUrl = "Adresa eshopu není ve správném tvaru, nebo je neplatná.";
        public const string EUCEmptyToken = "Token pro autorizaci připojení k eshopu nemůže být prázdný.";
        
    }
}
