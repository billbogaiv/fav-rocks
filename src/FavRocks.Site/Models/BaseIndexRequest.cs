namespace FavRocks.Site.Models
{
    public abstract class BaseIndexRequest<T>
        where T : BaseIndexRequest<T>, new()
    {
        public abstract string Color1 { get; set; }
        public abstract string Color2 { get; set; }
        public abstract string Color3 { get; set; }
        public abstract string Color4 { get; set; }
        public abstract string Color5 { get; set; }
        protected const string DefaultColor  = "000000";

        public bool ContainsValidColors()
        {
            var result = true;
            uint parsedHex;

            foreach (var color in new[] { Color1, Color2, Color3, Color4, Color5 })
            {
                result = !uint.TryParse(color, System.Globalization.NumberStyles.HexNumber, null, out parsedHex)
                    ? false
                    : result;
            }

            return result;
        }

        public static T CreateRequest(
            string color1 = null,
            string color2 = null,
            string color3 = null,
            string color4 = null,
            string color5 = null)
        {
            var request = new T();

            request.Color1 = string.IsNullOrEmpty(color1)
                ? DefaultColor
                : color1.Replace("#", "");

            request.Color2 = string.IsNullOrEmpty(color2)
                ? DefaultColor
                : color2.Replace("#", "");

            request.Color3 = string.IsNullOrEmpty(color3)
                ? DefaultColor
                : color3.Replace("#", "");

            request.Color4 = string.IsNullOrEmpty(color4)
                ? DefaultColor
                : color4.Replace("#", "");

            request.Color5 = string.IsNullOrEmpty(color5)
                ? DefaultColor
                : color5.Replace("#", "");

            return request;
        }

        public void ResetColors()
        {
            var _ = new T();

            Color1 = _.Color1;
            Color2 = _.Color2;
            Color3 = _.Color3;
            Color4 = _.Color4;
            Color5 = _.Color5;
        }
    }
}
