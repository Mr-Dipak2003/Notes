class assPtarn4re
{
    public static void main(String args[])
    {
        boolean flag=true;
        
        
        for(int row=1;row<=5;row++)
        {
            for(int col=1;col<=9;col++)
            {
                if(col >= 6 - row && col < 4 + row && flag)
                {
                    System.out.print("*");
                    flag=false;
                }
                else 
                {
                    System.out.print(" ");
                    flag=true;
                }
            }
            System.out.println();
        }

        
        for(int row=4;row>=1;row--)
        {
            for(int col=1;col<=9;col++)
            {
                if(col >= 6 - row && col < 4 + row && flag)
                {
                    System.out.print("*");
                    flag=false;
                }
                else
                {
                    System.out.print(" ");
                    flag=true;
                }
            }
            System.out.println();
        }
    }
}
