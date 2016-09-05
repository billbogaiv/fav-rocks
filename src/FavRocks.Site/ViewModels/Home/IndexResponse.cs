namespace FavRocks.Site.ViewModels.Home
{
    public class IndexResponse
    {
        public IndexResponse()
        {
            for (var i = 0; i < Pixels.Length; i++)
            {
                Pixels[i] = new string[16];

                for (var j = 0; j < Pixels[i].Length; j++)
                {
                    Pixels[i][j] = "transparent";
                }
            }
        }

        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Color4 { get; set; }
        public string Color5 { get; set; }
        public int ImageHeight { get; set; } = 16;
        public int ImageWidth { get; set; } = 16;
        public string[][] Pixels { get; set; } = new string[16][];
    }
}
