package org.eldarian.task27;

public class Solution {
    public static void main(String[] args) {
        CTO cto = new CTO();
        System.out.println(cto);
    }
    public interface Businessman {
        void workHard();
    }
    public static class BusinessmanImpl implements Businessman {
        @Override
        public void workHard() {}
    }
    public static class CTO extends BusinessmanImpl {}
}
