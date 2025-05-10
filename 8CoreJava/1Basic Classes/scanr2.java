import java.util.*;
class scanr2{
	
	public static void main(String args[])
	{
		Scanner sc = new Scanner(System.in);  //import java.util.Scanner; this packege for scanner class
		System.out.println("Enter two integer number");
		int a = sc.nextInt();
		int b = sc.nextInt();
		System.out.println("sum of " +a+ " and "+b+" = " +(a+b));
		System.out.println("Enter float number");
		float x= sc.nextFloat();
		System.out.println("Enter any character");
		char ch= sc.next().charAt(0);
		System.out.println("Enter any string");
		String str= sc.next();
		System.out.println("Enter double");
		double db= sc.nextDouble();
		System.out.println("Enter Long number");
		double lg= sc.nextLong();
		System.out.println("==================OutPut=================");
		System.out.println("integer numbers: " +a+ " and "+b );
		System.out.println("Character is: "+ch);
		System.out.println("Float Number is: "+x);
		System.out.println("Enter String is: "+str);
		System.out.println("Double is: "+db);
		System.out.println("Long number is: "+lg);
	}
	
}