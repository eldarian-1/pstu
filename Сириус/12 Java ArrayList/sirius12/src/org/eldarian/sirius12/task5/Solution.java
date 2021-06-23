package org.eldarian.sirius12.task5;

import java.util.ArrayList;
import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        ArrayList<Integer> list = new ArrayList();
        ArrayList<Integer> three = new ArrayList();
        ArrayList<Integer> two = new ArrayList();
        ArrayList<Integer> other = new ArrayList();
        Scanner reader = new Scanner(System.in);
        for(int i = 0; i < 20; i++) {
            list.add(reader.nextInt());
        }
        for(int i = 0, n = list.size(); i < n; i++) {
            int t = list.get(i);
            if(t % 3 == 0) {
                three.add(t);
            }
            if(t % 2 == 0) {
                two.add(t);
            }
            if(t % 2 != 0 && t % 3 != 0) {
                other.add(t);
            }
        }
        printList(three);
        printList(two);
        printList(other);
    }

    public static void printList(ArrayList<Integer> list) {
        for(int i = 0, n = list.size(); i < n; i++) {
            System.out.print(list.get(i) + " ");
        }
        System.out.println();
    }
}
