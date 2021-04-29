package src;

public class Task22 {

    public static void main(String[] args) {Cat.main(args);}

    public static class Cat {
        private String fullName = "без имени";

        public String getName() {
            return fullName;
        }

        public void setName(String firstName, String lastName) {
            fullName = firstName + " " + lastName;
        }

        public static void main(String[] args) {
            Cat cat = new Cat();
            System.out.println(cat.getName());
            cat.setName("Boris", "Prostoy");
            System.out.println(cat.getName());
        }
    }
}