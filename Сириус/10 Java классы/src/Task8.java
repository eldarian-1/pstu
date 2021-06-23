package src;

public class Task8 {

    public static void main(String[] args) {
        Person person = new Person();
        System.out.println("Age is: " + person.age());
        person.adjustAge(person.age());
        System.out.println("Adjusted age is: " + person.age());     
    }

    public static class Person {
        private int age = 20;

        public int age() {
            return age;
        }

        public void adjustAge(int age) {
            this.age = age + 20;
            System.out.println("Age in adjustAge() is: " + this.age);
        }
    }
}