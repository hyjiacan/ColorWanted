using System.Web.Script.Serialization;

namespace ColorWanted.util
{
    /// <summary>
    /// json工具类
    /// </summary>
    static class Json
    {
        private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static T Deserialize<T>(string json)
        {
            return serializer.Deserialize<T>(json);
        }
    }
}
