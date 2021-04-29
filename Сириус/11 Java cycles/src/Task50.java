package src;

public class Task50 {
    public static class Circle {
        public double x;
        public double y;
        public double radius;

        public Circle(double x, double y, double radius) {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public Circle(double x, double y) {
            this(x, y, 0);
        }

        public Circle(double radius) {
            this(0, 0, radius);
        }

        public Circle() {
            this(0, 0, 0);
        }
    }

    public static void about(Circle circle) {
        System.out.println(circle.x + " " + circle.y + " " + circle.radius);
    }

    public static void main(String[] args) {
        about(new Circle());
        about(new Circle(15));
        about(new Circle(30, 30));
        about(new Circle(22, 33, 19));
    }
}