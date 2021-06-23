package src;

public class Task40 {
    public static class Person {
        private String name;
        private int age;

        public void initialize(String name, int age) {
            this.name = name;
            this.age = age;
        }

        public String about() {
            return String.format("%s (%d)", name, age);
        }
    }

    public static void main(String[] args) {
        Person person = new Person();
        person.initialize("Mall Gibson", 56);
        System.out.println(person.about());
    }
}