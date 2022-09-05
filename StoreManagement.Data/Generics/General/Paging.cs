namespace StoreManagement.Data.Generics.General
{
    public class Paging
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Search { get; set; }
    }
}