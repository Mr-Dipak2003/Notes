class P2 {

    public static void main(String args[]) {
        for (int col = 1; col <= 6; col++) {
            for (int row = 1; row <= 6; row++) {
                if (row >= 7 - col) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }
    }
}
