package arr;
import java.util.*;
public class sumOfArray {

	public static void main(String[] args) {
		int sum=0;
		Scanner sc= new Scanner(System.in);
		int ar[]=new int[6];
		System.out.println("Enter array elements ");
		for(int j=0;j<ar.length;j++) {
			ar[j]=sc.nextInt();
		}
		
		for(int i=0;i<ar.length;i++) {
			sum=ar[i]+sum;
							
		}
		System.out.println("Sum Of Array is: "+sum);
		sc.close();
	}

}
