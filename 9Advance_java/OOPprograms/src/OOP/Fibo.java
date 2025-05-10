package OOP;

import java.util.Scanner;

public class Fibo {
	public static void main(String[] args) {
		Scanner sc= new Scanner(System.in);
		System.out.println("Enter limit in number");
		int  limit=sc.nextInt();
		
		fib f= new fib();
		f.setLimit(limit);
		f.showFibo();

	}
}
class fib{
	int first = 0, second = 1;
	int lim;
	
	void setLimit(int limit) {
		lim=limit;
	}
	void showFibo() {
		for (int i=0;i<=lim;i++)
		{
			System.out.print(first + "\t");

            int next = first + second;
            first = second;
            second = next;
			
			
		}
		
	}
}
