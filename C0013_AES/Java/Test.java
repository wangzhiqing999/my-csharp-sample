

import java.util.Date;
import java.security.PublicKey;

import java.io.UnsupportedEncodingException;



public class Test {

	
	public static void main(String[] args) {  
	

		doTest("0001");

		System.out.println("--------------------");


		doTest("13000000000");
		

		


	}
	

	
	private static void doTest(String idCard) {
			
		try {  
		
			byte[] desResult = AES.encryptAES(idCard);
			
			System.out.println( "步骤1： AES 加密数据。 结果 = " +  MD5Util.getHexString(desResult)  );
			
			
			
			
			String base64Result = Base64Helper.encode(desResult);
			
			
			System.out.println( "步骤2:  AES 加密结果， Base64 编码处理。  结果 = " + base64Result );
			
			
			System.out.println();
			System.out.println("---------------------------------------");
			System.out.println("  上面是加密处理，  下面是解密处理  ");
			System.out.println("---------------------------------------");
			System.out.println();
			
			
			
			byte[] base64Array = Base64Helper.decode(base64Result);
			
			System.out.println( "步骤1： Base64 解码处理, 结果 = " +  MD5Util.getHexString(base64Array)  );
			
			
			
			
			byte[] desResult2 = AES.decryptAES(base64Array);
			
			System.out.println( "步骤2： AES 解密数据。 结果 = " +  MD5Util.getHexString(desResult2)  );
			
			
			System.out.println("最终解密结果 = " + new String(desResult2));
			
		} catch (Exception ex) {  
            ex.printStackTrace();  
        } 
		
	}
	
	
		
	
}

