package org.eldarian.sirius13.task25;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Human {
    private String name;
    private boolean sex;
    private int age;
    private List<Human> children;

    public Human(String name, boolean sex, int age, Human... children) {
        this.name = name;
        this.sex = sex;
        this.age = age;
        this.children = new ArrayList<>();
        this.children.addAll(Arrays.asList(children));
    }

    public static void main(String[] args) {
        Human child1 = new Human("Джонни", true, 1);
        Human child2 = new Human("Фелиция", false, 4);
        Human child3 = new Human("Питер", true, 10);
        Human mother = new Human("Лана", false, 29,
                child1, child2, child3);
        Human father = new Human("Джейми", true, 32,
                child1, child2, child3);
        Human grandma1 = new Human("Алефтина", false, 47, mother);
        Human grandma2 = new Human("Мария", false, 51, father);
        Human grandfa1 = new Human("Стефан", true, 46, mother);
        Human grandfa2 = new Human("Чарльз", true, 52, father);
        System.out.println(child1 + "\n" + child2 + "\n" + child3 + "\n"
                + mother + "\n" + father + "\n" + grandma1 + "\n" + grandfa1
                + "\n" + grandma2 + "\n" + grandfa2);
    }

    public String toString() {
        String text = "";
        text += "Имя: " + this.name;
        text += ", пол: " + (this.sex ? "мужской" : "женский");
        text += ", возраст: " + this.age;
        int childCount = this.children.size();
        if (childCount > 0) {
            text += ", дети: " + this.children.get(0).name;
            for (int i = 1; i < childCount; i++) {
                Human child = this.children.get(i);
                text += ", " + child.name;
            }
        }
        return text;
    }
}
