package first.pack.java;

public class Second {

	public static void main(String[] args) {
		
		for(int i=1;i<=7;i++)
		{
			for(int j=1;j<=i;j++)
			{
				if(i>=j && j+i<=8)
				System.out.print("*");
				
				
			}
			
			System.out.println();
		}


	}
}
