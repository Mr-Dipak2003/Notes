class assNewPatern{
	public static void main(String args[])
	{
		
		for(int row=1;row<=5;row++)
		{
			for(int col=1;col<=9;col++)
			{
				if(row>=col|| col>=10-row)
				{
					System.out.print("*");
					
				}
				else {
					System.out.print(" ");
					
				}
			}
			System.out.println();
		}
	}
}