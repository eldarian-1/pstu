package org.eldarian.sirius12.task47;

public class Solution {
    public static void main(String[] args) throws Throwable {
        Human grandFa1 = new Human("Пётр", true, 81);
        Human grandMa1 = new Human("Нина", false, 79);
        Human grandFa2 = new Human("Игорь", true, 82);
        Human grandMa2 = new Human("Полина", false, 83);
        Human father = new Human("Леонид", true, 60)
                .setFather(grandFa1).setMother(grandMa1);
        Human mother = new Human("Юлия", false, 51)
                .setFather(grandFa2).setMother(grandMa2);
        Human son1 = new Human("Ростислав", true, 32)
                .setFather(father).setMother(mother);
        Human daughter = new Human("Анастасия", false, 27)
                .setFather(father).setMother(mother);
        Human son2 = new Human("Всеволод", true, 18)
                .setFather(father).setMother(mother);
        System.out.println(son2);
        System.out.println(daughter);
        System.out.println(son1);
        System.out.println(mother);
        System.out.println(father);
        System.out.println(grandMa2);
        System.out.println(grandFa2);
        System.out.println(grandMa1);
        System.out.println(grandFa1);
    }

    public static class Human {
        private String name;
        private boolean sex;
        private int age;
        private Human father;
        private Human mother;

        public Human(String name, boolean sex, int age) {
            this.name = name;
            this.sex = sex;
            this.age = age;
        }

        public Human setMother(Human parent) {
            mother = parent;
            return this;
        }

        public Human setFather(Human parent) {
            father = parent;
            return this;
        }

        public String toString() {
            String text = "";
            text += "Имя: " + this.name;
            text += ", пол: " + (this.sex ? "мужской" : "женский");
            text += ", возраст: " + this.age;
            if (this.father != null) {
                text += ", отец: " + this.father.name;
            }
            if (this.mother != null) {
                text += ", мать: " + this.mother.name;
            }
            return text;
        }
    }
}
