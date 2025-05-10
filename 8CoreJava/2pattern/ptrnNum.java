class ptrnNum{
	public static void main(String args[])
	{
		int a=1;
		for(int row=1;row<=5;row++)
		{
			for (int col=1; col<=row; col++)
			{
				System.out.print(a +" ");
				a++; 
			}
			System.out.println();
		}
	}
}