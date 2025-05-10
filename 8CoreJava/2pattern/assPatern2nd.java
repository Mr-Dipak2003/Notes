class assPatern2nd{
public static void main(String args[])
{
for(int row=1;row<=5;row++)
{
for(int col=1;col<=9;col++)
{
if(row<=col && row<=10-col)
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