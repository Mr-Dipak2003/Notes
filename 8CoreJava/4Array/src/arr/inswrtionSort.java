package arr;

public class inswrtionSort {

	public static void main(String[] args) {
		int a[]= new int[] {2,32,56,776,3,1,99,10};
		
		for(int i=0;i<a.length;i++) {
			int j=i;
			while(j>0 && a[j-1]>a[j]) {
				int temp =a[j-1];
				a[j-1]=a[j];
				a[j]=temp;
				j--;
			}
		}
		System.out.println("After Shorting :");
		for(int i=0;i<a.length;i++) {
			System.out.println(a[i]);
		}
	}

}
