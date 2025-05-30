package Assignment;

public class Palindrome {






	    private int number;

	   
	    public void setValue(int no) {
	        this.number = no;
	    }

	   
	    public boolean isPalin() {
	        int temp = number;
	        int reversed = 0;

	        while (temp > 0) {
	            int digit = temp % 10;
	            reversed = reversed * 10 + digit;
	            temp /= 10;
	        }

	        return number == reversed;
	    }

	    // Main method to test the class
	    public static void main(String[] args) {
	        Palindrome obj = new Palindrome();
	        obj.setValue(121);

	        if (obj.isPalin()) {
	            System.out.println("The number is a palindrome.");
	        } 
	        else {
	            System.out.println("The number is not a palindrome.");
	        }
	    }}


