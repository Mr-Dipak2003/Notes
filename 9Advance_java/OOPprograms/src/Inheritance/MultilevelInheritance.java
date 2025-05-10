package Inheritance;

import java.util.*;

class Prime {
    int no;

    void setvalue(int no) {
        this.no = no;
    }

    void checkprime() {
        boolean flag = false;
        if (no == 0 || no == 1) {
            System.out.println("Number is not Prime Number");
        } else {
            for (int i = 2; i < no; i++) {
                if (no % i == 0) {
                    flag = true;
                    break;
                }
            }
            if (flag) {
                System.out.println("Number is not Prime Number");
            } else {
                System.out.println("Number is Prime Number");
            }
        }
    }
}

class Palindrome extends Prime {
    void checkPalindrome() {
        int rem, rev = 0;
        int temp = no;

        while (temp != 0) {
            rem = temp % 10;
            rev = (rev * 10) + rem;
            temp = temp / 10;
        }

        if (no == rev) {
            System.out.println("The Number is Palindrome");
        } else {
            System.out.println("The Number is Not Palindrome");
        }
    }
}


class Duck extends Palindrome{
	void checkDuck() {
		String s = String.valueOf(no);
		char ch = s.charAt(0);
		if(ch==0) {
			System.out.println("Number is not Duck Number");
		}
		else {
			int rem;
			boolean flag = false;
			while(no!=0) {
				rem=no%10;
				no = no/10;
				if(rem==0) {
					flag=true;
					break;
				}
			}
			
			if(flag) {
				System.out.println("Number is Duck Number");
			}
			else {
				System.out.println("Number is not Duck Number");
			}
		}
	}
}

public class MultilevelInheritance {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the number");
        int no = sc.nextInt();

       Duck d = new Duck();
       d.setvalue(no);
       d.checkprime();
       d.checkPalindrome();
       d.checkDuck();
    }
}

