class RevNewPatern{
public static void main(String args[])
{
	boolean flag=true;
for(int row=1;row<=5;row++)
{
for(int col=1;col<=9;col++)
{
if( (col==10-row ||col==row)||(row==1 && flag))
{
System.out.print("*");
flag=false;
}
else {
System.out.print(" ");
flag=true;
}
}
System.out.println();
}
}
}