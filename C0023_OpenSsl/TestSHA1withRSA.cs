using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace C0023_OpenSsl
{
    class TestSHA1withRSA
    {


        /// <summary>
        /// 私钥.
        /// </summary>
        public static String privatestr = "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBALOhtU1lEYk6ILGQbqjybqFq8DRvDHZRJfZGbO2dhT+iKFCdV34ZmJXK6VGDDkbtqnknSNdsqBO7CUvYm9ddHqVaig3ZB2nm+s1FQT/+uqvFoeu10wgLEqgcoAmJhss/Urmsk/EswrMGjukDR1dPrciVRS/ZKzUuMKok6PECem9FAgMBAAECgYEArCpYF5a/6POSdD1HIpxBVmqlUMwCeMAsD0/OhSuNk8C6vREg01Z6/U6esyZWH7sYwcfaM8cLjOWd8ljofNDeVeXOgr7UsJ1fk5BO4ZbZwTZsJrX6h5Oqt4AOaSeRYMPfXSVCe+/ObVwBsXjboMeUSPuzdxP0d3RmhiioWs5KwOECQQDvfePO6OY7T5bPm0ejeee1t9w/uHnaUlLGaYzgHG1EPMH8h65G0QsLXgKrtC4VncO2nu7bab3LTNb+hYkTFzN9AkEAwAOEhCcduC4ZvUZl4ot7v43uYAuwgpqvuu3eA/XwOm2XtpICVvZws8Up56vFW5NtC8GYBQhSqFmtJPOcVh5laQJBAJqd9SCVXma2WJBKGPMi9gRs4oZFDG52LbipVmkuESE39Kmb01knBvFczW6bUhFknIFflKgVWZJSVo9WGQw5M2UCQELD9lwNTeQxA3ow9FRls83TiEOVTPbc2qXg+AXginuGh+5PrsiWQHIB6KRJsgI5rP0df8KgNj2bkPz8SCwZvaECQANLWBNr4pAatB6/9+uX061oKyl5yDJK3k1fotT9FDju7L0mxKJonQxfP3p2tNu2+Gs0j2J/VxXF2NWeksHwPZU=";


        /// <summary>
        /// 公钥.
        /// </summary>
        public static String publicstr = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCzobVNZRGJOiCxkG6o8m6havA0bwx2USX2RmztnYU/oihQnVd+GZiVyulRgw5G7ap5J0jXbKgTuwlL2JvXXR6lWooN2Qdp5vrNRUE//rqrxaHrtdMICxKoHKAJiYbLP1K5rJPxLMKzBo7pA0dXT63IlUUv2Ss1LjCqJOjxAnpvRQIDAQAB";



        /// <summary>
        /// 私钥签名.
        /// </summary>
        /// <param name="keycode"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string signWhole(String keycode, String param)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromPKCS8PrivateKey(Convert.FromBase64String(keycode));
            byte[] signatureBytes = rsa.SignData(Encoding.UTF8.GetBytes(param), new SHA1CryptoServiceProvider());
            return Convert.ToBase64String(signatureBytes);
        }


        /// <summary>
        /// 公钥验证签名.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="signature"></param>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public static bool verifyWhole(String param, String signature, String keycode)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromX509PublicKey(Convert.FromBase64String(keycode));

            byte[] sourceSign = Convert.FromBase64String(signature);


            bool result = rsa.VerifyData(Encoding.UTF8.GetBytes(param), "SHA1", sourceSign);


            return result;
        }

    }
}
