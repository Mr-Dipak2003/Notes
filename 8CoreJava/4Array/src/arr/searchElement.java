package arr;

import java.util.Scanner;


public class searchElement {

	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int a[]= new int[5];
		int value;
		boolean check=false;
		System.out.println("Enter array elements ");
		
		for(int j=0;j<a.length;j++) {
			a[j]=sc.nextInt();
		}
		System.out.println("Enter Any Number for search ");
		value=sc.nextInt();
		for(int i=0;i<a.length;i++) {
			if(a[i]==value) {
				check=true;
				break;
			}
			else {
				check=false;
			}
			
		}
		if(check) {
			System.out.println("Data is found: "+value);
		}
		else {
			System.out.println("Data is not found");
		}

	}

}
