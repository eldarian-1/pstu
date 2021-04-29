package src;

public class Task47 {
    public static class Rectangle {
        private int left;
        private int top;
        private int width;
        private int height;
        public Rectangle(int left, int top, int width, int height) {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
        }
        public Rectangle(int left, int top, int width) {
            this(left, top, width, width);
        }
        public Rectangle(int left, int top) {
            this(left, top, 0, 0);
        }
        public Rectangle(int left) {
            this(left, left);
        }
        public Rectangle() {
            this(10);
        }
        public Rectangle(Rectangle rect) {
            this(rect.left, rect.top, rect.width, rect.height);
        }
        public String about() {
            return left + " " + top + " " + width + " " + height;
        }
    }
    public static void main(String[] args) {
        Rectangle rectA = new Rectangle(13, 19, 30, 40);
        System.out.println(rectA.about());
        rectA = new Rectangle(6, 7, 9);
        System.out.println(rectA.about());
        rectA = new Rectangle(5, 10);
        System.out.println(rectA.about());
        rectA = new Rectangle();
        System.out.println(rectA.about());
        Rectangle rectB = new Rectangle(rectA);
        System.out.println(rectB.about());
    }
}