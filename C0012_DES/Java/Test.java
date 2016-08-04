

import java.util.Date;
import java.security.PublicKey;

import java.io.UnsupportedEncodingException;



public class Test {

	
	public static void main(String[] args) {  
	

		doTest2("230103198602230916",  "123456");
		
		System.out.println();
		System.out.println();
		System.out.println();
		
		doTest2("230103198602230916",  "1267893045");
		
		System.out.println();
		System.out.println();
		System.out.println();
		
		doTest2("230103198602230916",  "616727");
		
	}
	
	
	
	
	private static void doTest(String idCard, String pwd) {
			
		try {  
		
	
			byte [] md5 = MD5Util.string2MD5Array(idCard);
		
		
			System.out.println( "步骤1： MD5, 结果 = " +  MD5Util.getHexString(md5)  );
			
		
		
			
			byte[] desResult = DES.encrypt(pwd.getBytes(),  md5);
			
			System.out.println( "步骤2： 使用 MD5 作为 Key, 加密数据。 结果 = " +  MD5Util.getHexString(desResult)  );
			
			
			
			
			String base64Result = Base64Helper.encode(desResult);
			
			
			System.out.println( "步骤3:  DES 加密结果， Base64 编码处理。  结果 = " + base64Result );
			
			
			System.out.println();
			System.out.println("---------------------------------------");
			System.out.println("  上面是加密处理，  下面是解密处理  ");
			System.out.println("---------------------------------------");
			System.out.println();
			
			
			
			byte[] base64Array = Base64Helper.decode(base64Result);
			
			System.out.println( "步骤1： Base64 解码处理, 结果 = " +  MD5Util.getHexString(base64Array)  );
			
			
			
			
			byte[] desResult2 = DES.decrypt(base64Array,  md5);
			
			System.out.println( "步骤2： 使用 MD5 作为 Key, 解密数据。 结果 = " +  MD5Util.getHexString(desResult2)  );
			
			
			System.out.println("最终解密结果 = " + new String(desResult2));
			
		} catch (Exception ex) {  
            ex.printStackTrace();  
        } 
		
	}
	
	
	
	
	
	
	
	
	
	private static void doTest2(String idCard, String pwd) {
			
		try {  
		
	
			byte [] md5 = MD5Util.string2MD5Array(idCard);
			
			
			String md5String = MD5Util.getHexString(md5);
		
		
			System.out.println( "步骤1： MD5, 结果 = " +  md5String  );
			
		
		
			
			byte[] desResult = DES.encrypt(pwd.getBytes(),  md5String.getBytes());
			
			System.out.println( "步骤2： 使用 MD5 作为 Key, 加密数据。 结果 = " +  MD5Util.getHexString(desResult)  );
			
			
			
			
			String base64Result = Base64Helper.encode(desResult);
			
			
			System.out.println( "步骤3:  DES 加密结果， Base64 编码处理。  结果 = " + base64Result );
			
			
			System.out.println();
			System.out.println("---------------------------------------");
			System.out.println("  上面是加密处理，  下面是解密处理  ");
			System.out.println("---------------------------------------");
			System.out.println();
			
			
			
			byte[] base64Array = Base64Helper.decode(base64Result);
			
			System.out.println( "步骤1： Base64 解码处理, 结果 = " +  MD5Util.getHexString(base64Array)  );
			
			
			
			
			byte[] desResult2 = DES.decrypt(base64Array,   md5String.getBytes());
			
			System.out.println( "步骤2： 使用 MD5 作为 Key, 解密数据。 结果 = " +  MD5Util.getHexString(desResult2)  );
			
			
			System.out.println("最终解密结果 = " + new String(desResult2));
			
		} catch (Exception ex) {  
            ex.printStackTrace();  
        } 
		
	}
	
		
	
}

