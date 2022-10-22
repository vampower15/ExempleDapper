namespace ExempleDapper.Models
{
    public class HomelandModel
    {
        public int IdBk { get; set; } = default(int);
        public string  NameBk { get; set; } = string.Empty;
        public string  WriterBk { get; set; } = string.Empty;
        public string  CategoryBk { get; set; } = string.Empty;
        public string  PublisherBk { get; set; } = string.Empty;
        public int  PageBk { get; set; } = default(int);
        public string  ReleaseDateBk { get; set; } = string.Empty;
        public int  PriceBk { get; set; } = default(int);

    }

    public class HomelandNotId
    {
        public string NameBk { get; set; } = string.Empty ;
        public string WriterBk { get; set; } = string.Empty ;
        public string CategoryBk { get; set; } = string.Empty ;
        public string PublisherBk { get; set; } = string.Empty ;
        public int PageBk { get; set; } = default(int) ;
        public string ReleaseDateBk { get; set; } = string.Empty ;
        public int PriceBk { get; set; } = default(int) ;

    }
}
