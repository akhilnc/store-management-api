namespace StoreManagement.Data.Generics.General
{
    public class DuplicateValidation
    {
        public string Identifier { get; set; }
        public string IdentifierColumnName { get; set; } = "u_id";
        public string Value { get; set; }
        public string ColumnName { get; set; }
        public string Label { get; set; }
    }
}
