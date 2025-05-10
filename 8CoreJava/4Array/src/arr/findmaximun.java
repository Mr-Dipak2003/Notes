package arr;

import java.util.Scanner;

public class findmaximun {

	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int x[]= new int[6];
		int max=0;
		System.out.println("Enter array elements ");
		for(int j=0;j<x.length;j++) {
			x[j]=sc.nextInt();
		}
		for(int j=0;j<x.length;j++) {
			if(x[j]>max) {
				max=x[j];
			}
		}
		System.out.println("Maximum element is: "+max);
		
		for(int i=0;i<x.length;i++) {
			for(int j=i+1;j<x.length;j++) {
				if(x[i]>x[j]) {
					int temp=x[i];
					x[i]=x[j];
					x[j]=temp;
				
				}
			}
		}
//		for(int i=0;i<x.length-1;i++) {
//			if(i>x.length-1) {
//			System.out.println("second Maximum element is: "+x[i]);
//			}
//		}
		max=0; int secondmax=0;
		for(int i=0;i<x.length;i++) {
			
			
			if(max < x[i]) {
				secondmax=max;
				max=x[i];
				
			}
			
		}
		System.out.println("second Maximum element is: "+secondmax);
	}

}
