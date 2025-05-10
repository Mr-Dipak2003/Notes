package arr;

import java.util.Scanner;

public class shiftIndex {
	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int x[]= new int[6];
		
		System.out.println("Enter array elements ");
		for(int j=0;j<x.length;j++) {
			x[j]=sc.nextInt();
		}
		System.out.println("Enter the Index for Detele Element");
		int index;
		index=sc.nextInt();
		int p=0;
		for(int j=0;j<x.length;j++) {
			if(j!=index) {
				x[p++]=x[j];
			}
		}
		p=0;
		System.out.println("Array after Deleteing");
		for(int j=0;j<x.length-1;j++) {
		System.out.println(x[j]);	
		}
	}

}
