namespace Bussiness.RePricing
{
    public enum RecordType
    {
        Product = 0
    }

    public enum FieldType
    {
        Category = 0,
        Manufacturer = 1,
        Image,
        ShortDescription,
        LongDescription,
        Price,
        Weight,
        WholesalePrice,
        Supplier
    }

    public class ChangeRecord
    {
        public RecordType Type;
        public int Id;
        public FieldType Field;
        public string OldValue;
        public string Value;
    }
}
