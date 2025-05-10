package arr;

import java.util.Scanner;

public class asendingAray {

	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int a[]= new int[5];		
		System.out.println("Enter array elements ");
		
		for(int j=0;j<a.length;j++) {
			a[j]=sc.nextInt();
		}
		for(int i=0;i<a.length;i++) {
			for(int j=0;j<a.length;j++) {
				if(a[i]>a[j]) {
					int temp=a[i];
					a[i]=a[j];
					a[j]=temp;
				}
			}
		}
		System.out.println("After Shorting :");
		for(int i=0;i<a.length;i++) {
			System.out.println(a[i]);
		}
		
		sc.close();
	}

}
