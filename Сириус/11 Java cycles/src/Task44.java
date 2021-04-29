package src;

public class Task44 {
    public static class Friend {
        private String name;
        private int age;
        private char sex;

        public Friend(String name) {
            this.name = name;
        }

        public Friend(String name, int age) {
            this(name);
            this.age = age;
        }

        public Friend(String name, int age, char sex) {
            this(name, age);
            this.sex = sex;
        }

        public String about() {
            return String.format("%s%s", name,
                (age == 0 ? "" : String.format(" (age: %d%s)", age,
                    (sex == 0 ? "" : "; sex: " + sex))));
        }
    }

    public static void main(String[] args) {
        Friend friend = new Friend("Jack");
        System.out.println(friend.about());
        friend = new Friend("Simon", 17);
        System.out.println(friend.about());
        friend = new Friend("Saylor", 29, 'm');
        System.out.println(friend.about());
    }
}