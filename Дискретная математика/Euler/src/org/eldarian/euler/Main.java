package org.eldarian.euler;

import java.util.Scanner;

public class Main {

    private Main(){}

    private static int ReadInteger(String sentence){
        int number;
        Scanner in = new Scanner(System.in);
        while(true)
            try {
                System.out.print(sentence);
                number = in.nextInt();
                break;
            }
            catch(Throwable e) {
                continue;
            }
        return number;
    }

    private static boolean ReadBoolean(String sentence){
        return ReadInteger(sentence) == 0 ? false : true;
    }

    private static String IsConnection(int row, int column) {
        return String.format("Is there a connection between %c and %c? (1 - true,0 - false): ", 'A' + row, 'A' + column);
    }

    private static boolean[][] Matrix(int size) {
        boolean[][] matrix = new boolean[size][size];
        for(int i = 0; i < size; ++i) {
            for (int j = 0; j < size; ++j)
                matrix[i][j] = ReadBoolean(IsConnection(i, j));
        }
        return matrix;
    }

    private static boolean[][] FullMatrix(int size) {
        boolean[][] matrix = new boolean[size][size];
        for(int i = 0; i < size; ++i) {
            matrix[i][i] = false;
            for (int j = i + 1; j < size; ++j) {
                boolean temp = ReadBoolean(IsConnection(i, j));
                matrix[i][j] = temp;
                matrix[j][i] = temp;
            }
        }
        return matrix;
    }

    public static void main(String[] args) {
	    int size = ReadInteger("Enter the number of vertices of the graph: ");
	    //System.out.print(new EulerAlgorithm(Matrix(size)).Answer());
	    System.out.print(new EulerAlgorithm(FullMatrix(size)).Answer());
    }
}
