package src;

public class Task9 {

    public static void main(String[] args) {
        Dog max = new Dog();
        Dog bella = new Dog();
        Dog jack = new Dog();

        max.name = "Max";
        bella.name = "Bella";
        jack.name = "Jack";
        
        System.out.println(max.name);
        System.out.println(bella.name);
        System.out.println(jack.name);
    }

    public static class Dog {
        public String name;
    }
}