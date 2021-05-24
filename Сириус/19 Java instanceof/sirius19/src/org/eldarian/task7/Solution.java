package org.eldarian.task7;

public class Solution {
    public static void main(String[] args) {
        println(new WaterBridge());
        println(new SuspensionBridge());
    }
    interface Bridge {
        int getCarsCount();
    }
    static class WaterBridge implements Bridge {
        @Override
        public int getCarsCount() {
            return 13;
        }
    }
    static class SuspensionBridge implements Bridge {
        @Override
        public int getCarsCount() {
            return 6;
        }
    }
    public static void println(Bridge bridge) {
        System.out.println(bridge.getCarsCount());
    }
}
