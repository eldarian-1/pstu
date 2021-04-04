package org.eldarian.sirius13.task24;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.ZoneId;

public class Solution {
    public static void main(String[] args) throws Throwable {
        System.out.println(isDateOdd("13.06.2001"));
    }
    public static boolean isDateOdd(String date) throws ParseException {
        return new SimpleDateFormat("d.MM.yyyy")
                .parse(date)
                .toInstant()
                .atZone(ZoneId.systemDefault())
                .toLocalDate()
                .getDayOfYear() % 2 == 1;
    }
}
