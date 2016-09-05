namespace FavRocks.Site.Models.Home
{
    public class IndexRequest : BaseIndexRequest<IndexRequest>
    {
        public override string Color1 { get; set; } = "ff0000";
        public override string Color2 { get; set; } = "00ff00";
        public override string Color3 { get; set; } = "0000ff";
        public override string Color4 { get; set; } = "ffffff";
        public override string Color5 { get; set; } = "000000";
    }
}
