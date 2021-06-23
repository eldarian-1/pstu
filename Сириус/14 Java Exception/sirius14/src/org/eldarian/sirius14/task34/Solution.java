package org.eldarian.sirius14.task34;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.ZoneId;
import java.util.Date;

import static java.lang.Math.abs;

public class Solution {
    public static void main(String[] args) throws ParseException {
        if(args.length == 0)
            return;
        SimpleDateFormat format = new SimpleDateFormat("dd.MM.yyyy");
        Date birth = format.parse(args[0]);
        Date today = new Date();
        int dif = abs(getDayOfYear(birth) - getDayOfYear(today));
        System.out.println("назад = " + dif + ", а вперед = " + (365 - dif));
    }

    public static int getDayOfYear(Date date) {
        return date.toInstant().atZone(ZoneId.systemDefault()).getDayOfYear();
    }
}
