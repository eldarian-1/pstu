package src;

public class Task11 {
    public static void main(String[] args) {
        Woman julia = new Woman();
        Woman nicol = new Woman();
        Cat marusya = new Cat();
        Dog dina = new Dog();
        Fish inoc = new Fish();
        julia.name = "Юлия";
        nicol.name = "Николь";
        marusya.name = "Маруся";
        dina.name = "Дина";
        inoc.name = "Иннокентий";
        marusya.owner = julia; dina.owner = nicol;
        System.out.println(marusya.about() + "\n");
        System.out.println(dina.about() + "\n");
        System.out.println(inoc.about() + "\n");
    }
    public static class Cat {
        public String name;
        public Woman owner;
        public String about() {
            return "Кошка: " + name + (owner == null ? "" : "\n" + owner.about());
        }
    }
    public static class Dog {
        public String name;
        public Woman owner;
        public String about() {
            return "Собака: " + name + (owner == null ? "" : "\n" + owner.about());
        }
    }
    public static class Fish {
        public String name;
        public Woman owner;
        public String about() {
            return "Рыбка: " + name + (owner == null ? "" : "\n" + owner.about());
        }
    }
    public static class Woman {
        public String name;
        public String about() {
            return "Хозяйка: " + name;
        }
    }
}