using System;
using System.Text;
using System.Web.Script.Serialization;

namespace ColorWanted.clipboard
{
    public class ClipboardData
    {
        public string Data { get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            var json = new JavaScriptSerializer().Serialize(this);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            return base64;
        }

        public static ClipboardData Parse(string base64)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            var obj = new JavaScriptSerializer().Deserialize<ClipboardData>(json);
            return obj;
        }
    }
}
