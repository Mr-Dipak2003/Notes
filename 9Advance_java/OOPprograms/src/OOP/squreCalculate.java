package OOP;

import java.util.Scanner;

public class squreCalculate {

	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		System.out.println("Enter a number");
		int  num=sc.nextInt();
		Squre sq = new Squre();
		sq.acceptNumber(num);
		sq.showsqure();

	}

}
class Squre{
	int no;
	void acceptNumber(int num) {
		
		no=num;
	}
void showsqure() {
		
	System.out.println(no*no);
	}
}
