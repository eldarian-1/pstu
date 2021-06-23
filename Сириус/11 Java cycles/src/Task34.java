package src;

public class Task34 {
    public static class Person {
        private String name;
        private int age;
        private String address;
        private char sex;

        public Person(String name, int age, String address, char sex) {
            this.name = name;
            this.age = age;
            this.address = address;
            this.sex = sex;
        }

        public String about() {
            return String.format("%s (age: %d; address: %s; sex: %c)",
                name, age, address, sex);
        }
    }

    public static void main(String[] args) {
        Person mike = new Person("Michael", 13, "New York, Brooklin", 'm');
        System.out.println(mike.about());
    }
}