
import java.util.*;
import java.lang.*;
import java.util.Date;
import java.security.*;
import java.security.spec.*;

import java.io.UnsupportedEncodingException;




class Rextester
{  




    /**
     * 字节流转成十六进制表示
     */
    public static String encodeHexStr(byte[] src) {
        String strHex = "";
        StringBuilder sb = new StringBuilder("");
        for (int n = 0; n < src.length; n++) {
            strHex = Integer.toHexString(src[n] & 0xFF);
            sb.append((strHex.length() == 1) ? "0" + strHex : strHex); // 每个字节由两个字符表示，位数不够，高位补0
        }
        return sb.toString().trim();
    }
    
    /**
     * 字符串转成字节流
     */
    public static byte[] hexStringToBytes(String src) {
        int m = 0, n = 0;
        int byteLen = src.length() / 2; // 每两个字符描述一个字节
        byte[] ret = new byte[byteLen];
        for (int i = 0; i < byteLen; i++) {
            m = i * 2 + 1;
            n = m + 1;
            int intVal = Integer.decode("0x" + src.substring(i * 2, m) + src.substring(m, n));
            ret[i] = Byte.valueOf((byte)intVal);
        }
        return ret;
    }






    private static char[] base64EncodeChars = new char[]{
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
            'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z', '0', '1', '2', '3',
            '4', '5', '6', '7', '8', '9', '+', '/'};
    private static byte[] base64DecodeChars = new byte[]{
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,
            52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1,
            -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1,
            -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1};
   
    public static String encode(byte[] data) {
        StringBuffer sb = new StringBuffer();
        int len = data.length;
        int i = 0;
        int b1, b2, b3;
        while (i < len) {
            b1 = data[i++] & 0xff;
            if (i == len) {
                sb.append(base64EncodeChars[b1 >>> 2]);
                sb.append(base64EncodeChars[(b1 & 0x3) << 4]);
                sb.append("==");
                break;
            }
            b2 = data[i++] & 0xff;
            if (i == len) {
                sb.append(base64EncodeChars[b1 >>> 2]);
                sb.append(base64EncodeChars[((b1 & 0x03) << 4) | ((b2 & 0xf0) >>> 4)]);
                sb.append(base64EncodeChars[(b2 & 0x0f) << 2]);
                sb.append("=");
                break;
            }
            b3 = data[i++] & 0xff;
            sb.append(base64EncodeChars[b1 >>> 2]);
            sb.append(base64EncodeChars[((b1 & 0x03) << 4) | ((b2 & 0xf0) >>> 4)]);
            sb.append(base64EncodeChars[((b2 & 0x0f) << 2) | ((b3 & 0xc0) >>> 6)]);
            sb.append(base64EncodeChars[b3 & 0x3f]);
        }
        return sb.toString();
    }
   
    public static byte[] decode(String str){
    	try {
			return decodePrivate(str);
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return new byte[]{};
    }
    
    private static byte[] decodePrivate(String str) throws UnsupportedEncodingException{
        StringBuffer sb = new StringBuffer();
        byte[] data = null;
		data = str.getBytes("US-ASCII");
        int len = data.length;
        int i = 0;
        int b1, b2, b3, b4;
        while (i < len) {
           
            do {
                b1 = base64DecodeChars[data[i++]];
            } while (i < len && b1 == -1);
            if (b1 == -1) break;
           
            do {
                b2 = base64DecodeChars
                        [data[i++]];
            } while (i < len && b2 == -1);
            if (b2 == -1) break;
            sb.append((char) ((b1 << 2) | ((b2 & 0x30) >>> 4)));
           
            do {
                b3 = data[i++];
                if (b3 == 61) return sb.toString().getBytes("iso8859-1");
                b3 = base64DecodeChars[b3];
            } while (i < len && b3 == -1);
            if (b3 == -1) break;
            sb.append((char) (((b2 & 0x0f) << 4) | ((b3 & 0x3c) >>> 2)));
           
            do {
                b4 = data[i++];
                if (b4 == 61) return sb.toString().getBytes("iso8859-1");
                b4 = base64DecodeChars[b4];
            } while (i < len && b4 == -1);
            if (b4 == -1) break;
            sb.append((char) (((b3 & 0x03) << 6) | b4));
        }
        return sb.toString().getBytes("iso8859-1");
    }
	
	







public static String privatestr = "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBALOhtU1lEYk6ILGQbqjybqFq8DRvDHZRJfZGbO2dhT+iKFCdV34ZmJXK6VGDDkbtqnknSNdsqBO7CUvYm9ddHqVaig3ZB2nm+s1FQT/+uqvFoeu10wgLEqgcoAmJhss/Urmsk/EswrMGjukDR1dPrciVRS/ZKzUuMKok6PECem9FAgMBAAECgYEArCpYF5a/6POSdD1HIpxBVmqlUMwCeMAsD0/OhSuNk8C6vREg01Z6/U6esyZWH7sYwcfaM8cLjOWd8ljofNDeVeXOgr7UsJ1fk5BO4ZbZwTZsJrX6h5Oqt4AOaSeRYMPfXSVCe+/ObVwBsXjboMeUSPuzdxP0d3RmhiioWs5KwOECQQDvfePO6OY7T5bPm0ejeee1t9w/uHnaUlLGaYzgHG1EPMH8h65G0QsLXgKrtC4VncO2nu7bab3LTNb+hYkTFzN9AkEAwAOEhCcduC4ZvUZl4ot7v43uYAuwgpqvuu3eA/XwOm2XtpICVvZws8Up56vFW5NtC8GYBQhSqFmtJPOcVh5laQJBAJqd9SCVXma2WJBKGPMi9gRs4oZFDG52LbipVmkuESE39Kmb01knBvFczW6bUhFknIFflKgVWZJSVo9WGQw5M2UCQELD9lwNTeQxA3ow9FRls83TiEOVTPbc2qXg+AXginuGh+5PrsiWQHIB6KRJsgI5rP0df8KgNj2bkPz8SCwZvaECQANLWBNr4pAatB6/9+uX061oKyl5yDJK3k1fotT9FDju7L0mxKJonQxfP3p2tNu2+Gs0j2J/VxXF2NWeksHwPZU=";


public static String publicstr = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCzobVNZRGJOiCxkG6o8m6havA0bwx2USX2RmztnYU/oihQnVd+GZiVyulRgw5G7ap5J0jXbKgTuwlL2JvXXR6lWooN2Qdp5vrNRUE//rqrxaHrtdMICxKoHKAJiYbLP1K5rJPxLMKzBo7pA0dXT63IlUUv2Ss1LjCqJOjxAnpvRQIDAQAB";



public static String signWhole(String keycode, String param) {
	// 使用私钥加签
	byte[] signature = null;
	try {
		//获取privatekey
		byte[] keyByte = decode(keycode);
		KeyFactory keyfactory = KeyFactory.getInstance("RSA");
		PKCS8EncodedKeySpec encoderule = new PKCS8EncodedKeySpec(keyByte);
		PrivateKey privatekey = keyfactory.generatePrivate(encoderule);

		//用私钥给入参加签
		Signature sign = Signature.getInstance("SHA1WithRSA");
		sign.initSign(privatekey);
		sign.update(param.getBytes());

		signature = sign.sign();

	} catch (NoSuchAlgorithmException e) {
		e.printStackTrace();
	
	} catch (InvalidKeySpecException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (SignatureException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (InvalidKeyException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	//将加签后的入参转成16进制
	String terminal = encodeHexStr(signature);
	return terminal;
}





public static String signWhole256(String keycode, String param) {
	// 使用私钥加签
	byte[] signature = null;
	try {
		//获取privatekey
		byte[] keyByte = decode(keycode);
		KeyFactory keyfactory = KeyFactory.getInstance("RSA");
		PKCS8EncodedKeySpec encoderule = new PKCS8EncodedKeySpec(keyByte);
		PrivateKey privatekey = keyfactory.generatePrivate(encoderule);

		//用私钥给入参加签
		Signature sign = Signature.getInstance("SHA256WithRSA");
		sign.initSign(privatekey);
		sign.update(param.getBytes());

		signature = sign.sign();

	} catch (NoSuchAlgorithmException e) {
		e.printStackTrace();
	
	} catch (InvalidKeySpecException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (SignatureException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (InvalidKeyException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	//将加签后的入参转成16进制
	String terminal = encodeHexStr(signature);
	return terminal;
}




public static boolean verifyWhole(String param,String signature,String keycode){
	try {
		//获取公钥
		KeyFactory keyFactory=KeyFactory.getInstance("RSA");
		byte[] keyByte=decode(keycode);
		X509EncodedKeySpec encodeRule=new X509EncodedKeySpec(keyByte);
		PublicKey publicKey= keyFactory.generatePublic(encodeRule);

		//用获取到的公钥对   入参中未加签参数param 与  入参中的加签之后的参数signature 进行验签
		Signature sign=Signature.getInstance("SHA1WithRSA");
		sign.initVerify(publicKey);
		sign.update(param.getBytes());

		//将16进制码转成字符数组
		byte[] hexByte=hexStringToBytes(signature);
	   //验证签名
		return sign.verify(hexByte);

	} catch (NoSuchAlgorithmException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	
	} catch (InvalidKeySpecException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (SignatureException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (InvalidKeyException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	return false;
}
	
	
	
	
public static boolean verifyWhole256(String param,String signature,String keycode){
	try {
		//获取公钥
		KeyFactory keyFactory=KeyFactory.getInstance("RSA");
		byte[] keyByte=decode(keycode);
		X509EncodedKeySpec encodeRule=new X509EncodedKeySpec(keyByte);
		PublicKey publicKey= keyFactory.generatePublic(encodeRule);

		//用获取到的公钥对   入参中未加签参数param 与  入参中的加签之后的参数signature 进行验签
		Signature sign=Signature.getInstance("SHA256WithRSA");
		sign.initVerify(publicKey);
		sign.update(param.getBytes());

		//将16进制码转成字符数组
		byte[] hexByte=hexStringToBytes(signature);
	   //验证签名
		return sign.verify(hexByte);

	} catch (NoSuchAlgorithmException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	
	} catch (InvalidKeySpecException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (SignatureException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	} catch (InvalidKeyException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	return false;
}
	

	
	
	
	public static void main(String[] args) {  
	
		try {  
	
			String test = "1234567890,1234567890,1234567890,1234567890,1234567890";			
			String sign = signWhole(privatestr, test);
			System.out.println(sign);
			
			
			boolean result = verifyWhole(test, sign, publicstr);
			System.out.println(result);
			
			
			System.out.println("----------");
			
			
			
			sign = signWhole256(privatestr, test);			
			System.out.println(sign);

			result = verifyWhole256(test, sign, publicstr);
			System.out.println(result);

			
			
		} catch (Exception ex) {  
            ex.printStackTrace();  
        } 
		
	}
}