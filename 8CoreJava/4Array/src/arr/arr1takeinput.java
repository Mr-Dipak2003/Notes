package arr;

import java.util.Scanner;

public class arr1takeinput {
	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
	
	int a[]= new int[5];
	System.out.println("Enter array elements ");
	
	for(int j=0;j<a.length;j++){
		a[j]=sc.nextInt();
	}
	
	for(int i=0;i<a.length;i++) {
		System.out.println(a[i]);
	}
	}
	
}
