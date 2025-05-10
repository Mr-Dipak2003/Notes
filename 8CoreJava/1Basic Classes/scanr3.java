import java.util.*;
import java.lang.String;
class scanr3{
	
	public static void main(String args[]){
		Scanner sc = new Scanner(System.in); 
		System.out.println("Enter any String ");
		String str= sc.nextLine();
		System.out.println("You Enterd String: "+str);
		int a= str.length();
		for(int i=a-1;i>=0;i--)
		{
			System.out.print(str.charAt(i));
		}
		
	}
}