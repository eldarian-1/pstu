package org.eldarian.sirius14.task25;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Solution {
    public static char[] vowels = new char[]{'а', 'я', 'у', 'ю', 'и', 'ы', 'э', 'е', 'о', 'ё'};
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String s = reader.readLine();
        List<Character> vowels = new ArrayList<>();
        List<Character> others = new ArrayList<>();
        for(char c : s.toCharArray()) {
            if(isVowel(c)) {
                vowels.add(c);
            }
            else if(c != ' ') {
                others.add(c);
            }
        }
        for(char c : vowels) {
            System.out.print(c + " ");
        }
        System.out.println();
        for(char c : others) {
            System.out.print(c + " ");
        }
        System.out.println();
    }
    public static boolean isVowel(char c) {
        c = Character.toLowerCase(c);
        for (char d : vowels) {
            if (c == d) {
                return true;
            }
        }
        return false;
    }
}
