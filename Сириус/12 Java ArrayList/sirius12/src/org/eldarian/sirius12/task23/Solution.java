package org.eldarian.sirius12.task23;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        Cat grandFather = new Cat(reader.readLine());
        Cat grandMother = new Cat(reader.readLine());
        Cat father = new Cat(reader.readLine()).setFather(grandFather);
        Cat mother = new Cat(reader.readLine()).setMother(grandMother);
        Cat son = new Cat(reader.readLine())
                .setFather(father).setMother(mother);
        Cat daughter = new Cat(reader.readLine())
                .setFather(father).setMother(mother);
        System.out.println(grandFather);
        System.out.println(grandMother);
        System.out.println(father);
        System.out.println(mother);
        System.out.println(son);
        System.out.println(daughter);
    }

    public static class Cat {
        private String name;
        private Cat mother;
        private Cat father;

        Cat(String name) {
            this.name = name;
        }

        Cat setMother(Cat parent) {
            this.mother = parent;
            return this;
        }

        Cat setFather(Cat parent) {
            this.father = parent;
            return this;
        }

        @Override
        public String toString() {
            return String.format("The cat's name is %s, %s, %s", name,
                    mother == null ? "no mother" : "mother is " + mother.name,
                    father == null ? "no father" : "father is " + father.name);
        }
    }
}
