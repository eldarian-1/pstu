package org.eldarian.task17;

import java.io.FileInputStream;
import java.util.ArrayList;
import java.util.List;

public class Solution {
    public static List<Exception> exceptions = new ArrayList<>();
    public static void main(String[] args) {
        initExceptions();
        for (Exception exception : exceptions) {
            System.out.println(exception);
        }
    }
    interface Procedure {
        void run() throws Exception;
    }
    private static void checkException(Procedure procedure) {
        try {
            procedure.run();
        } catch (Exception e) {
            exceptions.add(e);
        }
    }
    private static void initExceptions() {
        checkException(() -> {float i = 1 / 0;});
        checkException(() -> {float[] i = new float[2]; i[6] = 13;});
        checkException(() -> {List<Integer> i = null; i.add(3);});
        checkException(() -> Integer.parseInt("Hello, Sirius!"));
        checkException(() -> new FileInputStream("./not_existing_file"));
        checkException(() -> new ArrayList<Integer>().get(2));
        checkException(() -> {
            List<Object> list = new ArrayList<>();
            list.add(13);
            String result = (String)list.get(0);
        });
        checkException(() -> {int[] arr = new int[-2];});
        checkException(() -> "dgdhfgh".codePointAt(13));
        checkException(() -> Class.forName("Solution.TestClass").newInstance());
    }
}
