package OOP;

public class contructor {
	public static void main(String[] args) {
		contruct c = new contruct();
		paraContruct pC = new paraContruct(5,2);
	}

}
class contruct{
	
	contruct(){
		System.out.println("This is a default contructor");
	}
}
class paraContruct{
	paraContruct(int a,int b){
		System.out.println("This is parameter Contructor "+(a+b));
	}
}
