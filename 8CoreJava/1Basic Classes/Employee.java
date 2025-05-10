import java.util.*;
class Employee {
    String name;
    int age;
    float salary;

   
    Employee(String name, int age, float salary) {
        this.name = name;
        this.age = age;
        this.salary = salary;
    }

    
    void display() {
        System.out.println("Name: " + name);
        System.out.println("Age: " + age);
        System.out.println("Salary: " + salary);
    }

    public static void main(String[] args) {
      
        Employee emp = new Employee("Dipak", 23, 30023);
        
        
        emp.display();
    }
}
