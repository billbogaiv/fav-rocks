namespace FavRocks.Site.Models.Home
{
    public class CreateRequest
    {
        public string Action { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Color4 { get; set; }
        public string Color5 { get; set; }
        public string[][] Pixels { get; set; }
    }
}
