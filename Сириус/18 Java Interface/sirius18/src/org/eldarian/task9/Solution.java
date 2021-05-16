package org.eldarian.task9;

public class Solution {
    interface CanMove {
        Double speed();
    }
    interface CanFly extends CanMove {
        Double speed(CanFly flown);
    }
}
