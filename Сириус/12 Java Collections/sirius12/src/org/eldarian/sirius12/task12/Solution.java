package org.eldarian.sirius12.task12;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static int even;
    public static int odd;
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        int num = Integer.parseInt(reader.readLine());
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
