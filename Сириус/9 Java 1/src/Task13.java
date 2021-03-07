package src;

public class Task13 {
    private static void print(String sentence) {
        for(int i = 0; i < 4; ++i)
            System.out.println(sentence);
    }

    public static void main(String[] args) {
        print("Java is easy to learn!");
        print("Java is object-oriented!");
        print("Java is platform-independent!");
    }
}
