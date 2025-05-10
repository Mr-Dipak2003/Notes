package Inheritance;

class fruts{
	void show() {
		System.out.println("Frutes have many colors");
	}
}

class mango extends fruts{
	void showcolor() {
		System.out.println("Mango is a yellow");
	}
	
}
class apple extends fruts{
void showcolor() {
	System.out.println("Apple is a red");
	}
	
}
class strawberry extends fruts{
	
void showcolor() {
	System.out.println("strawberry is a dark-red");
		
	}
}

public class Hierarchicalinheritance {

	public static void main(String[] args) {
		
		strawberry sb= new strawberry();
		sb.show();//<------this method from parent class
		sb.showcolor();
		
		apple ap = new apple();
		ap.showcolor();
		

	}

}
