using System.Collections.Generic;

namespace FavRocks.Site.ViewModels.ColorSwatch
{
    public class IndexResponse
    {
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Color4 { get; set; }
        public string Color5 { get; set; }
        public IEnumerable<Models.ColorSwatch> ColorSwatches { get; set; } = new List<Models.ColorSwatch>();
    }
}
