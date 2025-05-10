package arr;

import java.util.Scanner;

public class addValueOn_Index {
	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int x[]= new int[6];
		int y[]= new int[x.length+1];
		
		System.out.println("Enter array elements ");
		for(int j=0;j<x.length;j++) {
			x[j]=sc.nextInt();
		}
		System.out.println("Enter the Index");
		int index;
		index=sc.nextInt();
		System.out.println("Enter the Value");
		int value;
		value=sc.nextInt();
		int p=0;
		for(int i=0;i<x.length;i++) {
			if(i==index) {
				int temp=x[i];
				y[p++]=value;
				y[p++]=temp;
			}	
			else {
				y[p++]=x[i];
			}
		}
		System.out.println("Array after adding value");
		for(int j=0;j<y.length;j++) {
		System.out.println(y[j]);	
		}
		
	}
}
