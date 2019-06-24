using System;

namespace LiveArt.ProductsManagement.Api.Services
{
    public class Base64Converter
    {
        public static string Base64Encode(byte[] source)
        {
            return Convert.ToBase64String(source);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
