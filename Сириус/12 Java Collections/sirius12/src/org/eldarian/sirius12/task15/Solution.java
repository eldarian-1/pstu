package org.eldarian.sirius12.task15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader bis = new BufferedReader(
                new InputStreamReader(System.in));
        double weight = Double.parseDouble(bis.readLine());
        double height = Double.parseDouble(bis.readLine());
        Body.calculateMassIndex(weight, height);
    }

    public static class Body {
        public static void calculateMassIndex(double weight, double height) {
            double index = weight / height / height;
            System.out.println(index <= 18.5 ?
                    "Недовес: меньше чем 18.5"
                    : index > 18.5 && index <= 25 ?
                    "Нормальный: между 18.5 и 25"
                    : index > 25 && index <= 30 ?
                    "Избыточный: между 25 и 30" :
                    "Ожирение: 30 или больше");
        }
    }
}
