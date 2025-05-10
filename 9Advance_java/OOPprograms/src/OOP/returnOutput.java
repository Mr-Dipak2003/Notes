package OOP;


class checkNumber{
	int a,b;
	void getData(int a,int b) {
		this.a=a;
		this.b=b;
		
	}
	int funCheck() {
		if(a>b) {
			return 1;
		}else 
		{
			return 0;
		}
	}
}
public class returnOutput {

	public static void main(String[] args) {
		checkNumber cn= new checkNumber();
		cn.getData(2, 4);
		int ch= cn.funCheck();
		if(ch>0) {
			System.out.println("A is Greater Than B");
		}
		else {
			System.out.println("B is Greater Than A");
		}
		
	}

}
