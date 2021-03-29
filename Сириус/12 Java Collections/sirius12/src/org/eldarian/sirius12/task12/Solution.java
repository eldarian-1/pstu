package org.eldarian.sirius12.task12;

import java.util.Scanner;

public class Solution {
    public static int even;
    public static int odd;
    public static void main(String[] args) throws Throwable {
        Scanner scan = new Scanner(System.in);
        int num = scan.nextInt();
        while(num != 0) {
            if(num % 10 % 2 == 0) {
                even++;
            }
            else {
                odd++;
            }
            num /= 10;
        }
        System.out.println(String.format("Even: %d; Odd: %d", even, odd));
    }
}
