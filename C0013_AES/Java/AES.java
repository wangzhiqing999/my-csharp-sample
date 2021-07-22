
import java.security.SecureRandom;

import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import javax.crypto.SecretKeyFactory;
import javax.crypto.SecretKey;
import javax.crypto.Cipher;


public class AES {
	
	
	public AES() {
	}
	
	
    private static final String key="1234567890123456";
    private static final String initVector  ="1234567890123456";
	
	
	//测试
	public static void main(String args[]) {

		System.out.println("key：" + key);
		System.out.println("iv："+ initVector );


		//直接将如上内容解密
		try {
		
			//待加密内容
			String str = "测试内容";
			

			byte[] result = AES.encryptAES(str);
			
			System.out.println("加密后："+new String(result));


			byte[] decryResult = AES.decryptAES(result);
			System.out.println("解密后："+new String(decryResult));
		} catch (Exception e1) {
			e1.printStackTrace();
		}

	}

	

	
	// 加密
    public static byte[] encryptAES(String data) throws Exception {
        try {
			
			IvParameterSpec iv = new IvParameterSpec(initVector.getBytes("UTF-8"));
			SecretKeySpec skeySpec = new SecretKeySpec(key.getBytes("UTF-8"), "AES");
	 
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");
			cipher.init(Cipher.ENCRYPT_MODE, skeySpec, iv);
	 
			byte[] encrypted = cipher.doFinal(data.getBytes());

            return encrypted;

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    // 解密
    public static byte[] decryptAES(byte[] encrypted1) throws Exception {
        try
        {

			IvParameterSpec iv = new IvParameterSpec(initVector.getBytes("UTF-8"));
			SecretKeySpec skeySpec = new SecretKeySpec(key.getBytes("UTF-8"), "AES");
 
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");
			cipher.init(Cipher.DECRYPT_MODE, skeySpec, iv);
			byte[] original = cipher.doFinal(encrypted1);

            
            return original;
        }
        catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }	
	
	
	
	
	
	
}