package test;

public class TestJavaClass {


	public String Hello() {
		return "Hello, IKVM!";
	}

	public void throwException() throws Exception {
		throw new Exception("Hello, Exception!");
	}

	
	public byte[] getGbkByteArray(String sourceText) throws Exception {
		byte[] bytes = sourceText.getBytes("gbk");
		return bytes;
	}
	
	
	
	public static void main(String args[]) throws Exception { 
	
        System.out.println("Hello World!"); 
		
		
		
		if(args.length > 0) {
			
			TestJavaClass test = new TestJavaClass();
			byte[] bytes = test.getGbkByteArray(args[0]);
			
			for(int i=0; i<bytes.length; i++){ 
				System.out.println(bytes[i]); 
			} 
		}
    } 
	
}