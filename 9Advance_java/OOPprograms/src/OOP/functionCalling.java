package OOP;

import java.util.Scanner;

public class functionCalling {

	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		System.out.println("Enter two number");
		int  num=sc.nextInt();
		int  num1=sc.nextInt();

		Calc cal = new Calc();
		new Calc().getData(num,num1);//they are create two deferent 
		new Calc().showData();		//deferent memory locations

	}

}
class Calc{
	int num1,num2;
	
	void getData(int x,int y) {
		num1=x;
		num2=y;
	}
	void showData() {
		 System.out.println(num1 + num2);
	}
}
