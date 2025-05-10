package OOP;

import java.util.Scanner;

public class cubeCalculate {

	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		System.out.println("Enter a number");
		int  num=sc.nextInt();
		Calcube cal = new Calcube();
		cal.getData(num);
		cal.showData();

	}

}
class Calcube{
	int no;
	 void getData(int x) {
		 no=x;
		 
	 }
	 void showData() {
		 System.out.println(no*no*no);
		 
	 }
}
