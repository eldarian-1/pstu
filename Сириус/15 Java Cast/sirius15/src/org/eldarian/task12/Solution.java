package org.eldarian.task12;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.List;

public class Solution {
    private static final int A = 'я' - 'а';

    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        List<Integer> numbers = new LinkedList<>();
        for(int i = 0; i < A; ++i) {
            numbers.add(0);
        }
        for(int i = 0; i < 10; ++i) {
            String temp = reader.readLine();
            for(char c : temp.toCharArray()) {
                if(c >= 'а' && c <= 'я') {
                    numbers.set(c - 'а', numbers.get(c - 'а') + 1);
                }
            }
        }
        for(int i = 0; i < A; ++i) {
            System.out.println((char)(i + 'а') + " " + numbers.get(i));
        }
    }
}
