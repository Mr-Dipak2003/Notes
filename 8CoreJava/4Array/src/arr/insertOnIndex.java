package arr;
import java.util.Scanner;
public class insertOnIndex {
	
		public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		int x[]= new int[6];
		
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
		
		for(int j=0;j<x.length;j++) {
			if(j==index) {
				x[j]=value;
			}
		}
		
		System.out.println("Array after adding value");
		for(int j=0;j<x.length-1;j++) {
		System.out.println(x[j]);	
		}
	}

}