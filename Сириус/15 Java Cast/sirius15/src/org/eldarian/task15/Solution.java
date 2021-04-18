package org.eldarian.task15;

public class Solution {
    public static void main(String[] args) {
    }
    public static class Human {
        String name;
        String skinColor;
        char sex;
        int height;
        double weight;
        int age;

        public Human(String name, String skinColor, char sex,
                     int height, double weight, int age) {
            this.name = name;
            this.skinColor = skinColor;
            this.sex = sex;
            this.height = height;
            this.weight = weight;
            this.age = age;
        }
        public Human(String name, String skinColor, char sex,
                     int height, double weight) {
            this(name, skinColor, sex, height, weight, 0);
        }
        public Human(String name, String skinColor, char sex,
                     int height) {
            this(name, skinColor, sex, height, 0);
        }
        public Human(String name, String skinColor, char sex) {
            this(name, skinColor, sex, 0);
        }
        public Human(String skinColor, char sex, int height,
                     double weight, int age) {
            this(null, skinColor, sex, height, weight, age);
        }
        public Human(String skinColor, char sex, int height,
                     double weight) {
            this(skinColor, sex, height, weight, 0);
        }
        public Human(String skinColor, char sex, int height) {
            this(skinColor, sex, height, 0);
        }
        public Human(String skinColor, char sex) {
            this(skinColor, sex, 0);
        }
        public Human(char sex, int height, double weight) {
            this(null, null, sex, height, weight);
        }
        public Human(int height, double weight) {
            this(null, null, '0', height, weight);
        }
    }
}
