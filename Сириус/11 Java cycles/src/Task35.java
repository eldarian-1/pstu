package src;

public class Task35 {
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
        public String getName() { return name; }
        public int getAge() { return age; }
        public String getAddress() { return address; }
        public char getSex() { return sex; }
        public void setName(String name) {
            this.name = name;
        }
        public void setAge(int age) {
            this.age = age;
        }
        public void setAddress(String address) {
            this.address = address;
        }
        public void setSex(char sex) {
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
        mike.setName("Maria");
        mike.setAge(17);
        mike.setAddress("Santo Paulo");
        mike.setSex('f');
        System.out.println(mike.about());
    }
}