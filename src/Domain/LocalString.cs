namespace Enginex.Domain
{
    public class LocalString
    {
        public LocalString(string slovak, string english)
        {
            Slovak = slovak;
            English = english;
        }

        public LocalString()
        {
            Slovak = string.Empty;
            English = string.Empty;
        }

        public static LocalString Empty { get; } = new LocalString();

        public string Slovak { get; set; }

        public string English { get; set; }
    }
}
