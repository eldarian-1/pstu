package org.eldarian.sirius12.task39;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> list = new ArrayList<>();
        for(int i = 0; i < 10; i++) {
            list.add(scanner.nextLine());
        }
        int i = 0;
        for(int len = 0, n = list.size();
            i < n; len = list.get(i).length(), i++) {
            if(len > list.get(i).length()) {
                break;
            }
        }
        System.out.println(i == list.size() ?
                "Строки расположены по возрастанию длины" :
                "Упорядоченность по возрастанию длины нарушается на "+i+" строке");
    }
}
