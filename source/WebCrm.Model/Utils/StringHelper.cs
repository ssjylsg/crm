using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace WebCrm.Model
{
    public static class StringHelper
    {
        public static bool TryGuid(object value, out Guid guid)
        {
            try
            {
                guid = new Guid((value ?? string.Empty).ToString());
                return true;
            }
            catch (Exception)
            {
                guid = Guid.Empty;
                return false;
            }
        }
        public static bool IsGuid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            try
            {
                new Guid(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int ToInt(this string value, int defaultValue = 0)
        {
            int outInt;
            if (int.TryParse(value, out outInt))
            {
                return outInt;
            }
            return defaultValue;
        }
        public static bool IsInt(this string value)
        {
            int outInt;
            return int.TryParse(value, out outInt);
        }
        public static T Convert<T>(this string value) where T : struct
        {
            if (!string.IsNullOrEmpty(value))
            {

                T defaultValue;
                if (Enum.TryParse(value, out defaultValue))
                {
                    return defaultValue;
                }
            }
            return default(T);
        }

        public static string ToJson(this object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static string Md5(this string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "md5");
        }
    }
    /// <summary>
    /// Json 序列化
    /// </summary>
    public static class JsonHelper
    {
        public static string ToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
        public static T FromJson<T>(string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
        }
    }
}
