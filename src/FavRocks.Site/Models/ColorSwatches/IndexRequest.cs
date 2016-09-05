namespace FavRocks.Site.Models.ColorSwatches
{
    public class IndexRequest : BaseIndexRequest<IndexRequest>
    {
        public override string Color1 { get; set; } = DefaultColor;
        public override string Color2 { get; set; } = DefaultColor;
        public override string Color3 { get; set; } = DefaultColor;
        public override string Color4 { get; set; } = DefaultColor;
        public override string Color5 { get; set; } = DefaultColor;

    }
}
