public class ReversePattern {
    public static void main(String[] args) {
        int rows = 6; 
        
       
        for (int i = rows; i >= 1; i--) {
            
            for (int j = 1; j <= rows - i; j++) {
                System.out.print(" ");
            }
            
            for (int k = 1; k <= i; k++) {
                System.out.print("*");
            }
            
            System.out.println();
        }
    }
}
