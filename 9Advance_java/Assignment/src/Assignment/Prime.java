package Assignment;

public class Prime {


		// TODO Auto-generated method stub
		
		

		
		    private int number;

		    // Method to set the value
		    public void setValue(int no) {
		        this.number = no;
		    }

		    // Method to check if the number is prime
		    public boolean isPrime() {
		        if (number <= 1) {
		            return false;
		        }

		        for (int i = 2; i <= Math.sqrt(number); i++) {
		            if (number % i == 0) {
		                return false;
		            }
		        }

		        return true;
		    }

		   
		    public static void main(String[] args) {
		        Prime obj = new Prime();
		        obj.setValue(17);

		        if (obj.isPrime()) {
		            System.out.println("The number is a prime number.");
		        } 
		        else {
		            System.out.println("The number is not a prime number.");
		        }
		    }
		

	}


