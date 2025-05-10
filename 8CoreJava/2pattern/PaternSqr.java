class PaternSqr {
    public static void main(String[] args) {
        int rows = 9;
		boolean flag=true;
        
        for (int i = 1; i < rows; i++) {
            
            for (int j = 1; j <= 9; j++) {
				if(i<=j && j<=10-i&& flag)
				{
					System.out.print("*");
					flag=false;
				}
				else{
                System.out.print(" ");
				flag=true;
				
				}
            }

            
            System.out.println();
        }
    }
}
