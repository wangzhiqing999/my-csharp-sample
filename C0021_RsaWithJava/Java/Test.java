

import java.util.Date;
import java.security.PublicKey;

import java.io.UnsupportedEncodingException;



public class Test {

	
	public static void main(String[] args) {  
	
		try {  
	
			String pubKeyXml3 = "<RSAKeyValue><Modulus>r6ivWiCnl7NY23RSGzskbYrjxwsbU2/is5INqNhxG3hpDv2ZIW56J5oiJBo1oJ5B3rJWfhjE4oEHbyZTZI0KWlmY3IIqPeFfS+nf7L4e6aGEk//guTZB/+b6SlS9OGLgOSuJHk2C+CmeBpuCSrvC6R/F6ItG+Rt1+EwMBqyG4T8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
			
		
			System.out.println((new Date()).toLocaleString() + ": 加载公钥中。。。");  
			PublicKey pubKey3 = RsaHelper.decodePublicKeyFromXml(pubKeyXml3);  
			
			
			String dataStr = "Data to Encrypt  这个是一个用于测试加密的文本信息！";  
			byte[] dataByteArray = dataStr.getBytes("utf-8");  
			
			System.out.println((new Date()).toLocaleString() + ": 加密中。。。"); // 加密  
			byte[] encryptedDataByteArray = RsaHelper.encryptData(dataByteArray, pubKey3);  
		
			System.out.println("encryptedData的Base64表示：" + Base64Helper.encode(encryptedDataByteArray));  
		} catch (Exception ex) {  
            ex.printStackTrace();  
        } 
		
	}
	
}

