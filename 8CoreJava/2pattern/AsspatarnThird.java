class AsspatarnThird{

public static void main(String args[])
{
	for (int row=1;row<=6;row++){
		for(int col=1;col<=6;col++){
			if(7-col>=row)
			{
			System.out.print(" ");
			}
			else{
				
				System.out.print("*");
				
			}
		}
		System.out.println();
	}
}

}