package arr;

import java.util.Scanner;

public class findMin {
	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int x[]= new int[6];
		
		System.out.println("Enter array elements");
		for(int j=0;j<x.length;j++) {
			x[j]=sc.nextInt();
		}
		int min=x[0];
		for(int j=1;j<x.length;j++) {
			if(x[j]<min) {
				min=x[j];
			}
		}
		System.out.println("Minimum element is: "+min);
		
		for(int i=0;i<x.length;i++) {
			for(int j=i+1;j<x.length;j++) {
				
				if(x[i]>x[j]) {
					int temp=x[i];
					x[i]=x[j];
					x[j]=temp;
				
				}
			}
		}
		
			System.out.println("second Minimum element is: "+x[1]);
		
	}

}
