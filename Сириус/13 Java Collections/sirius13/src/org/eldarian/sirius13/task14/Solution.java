package org.eldarian.sirius13.task14;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.ZoneId;
import java.util.*;

public class Solution {
    public static Map<String, Date> createMap() throws ParseException {
        DateFormat dateFormat = new SimpleDateFormat("d.MM.yyyy");
        Map<String, Date> map = new HashMap<>();
        map.put("Макрон", dateFormat.parse("1.03.2012"));
        map.put("Аль Капоне", dateFormat.parse("1.04.2012"));
        map.put("Сталлоне", dateFormat.parse("1.05.2012"));
        map.put("Тест Катерины", dateFormat.parse("31.05.2000"));
        map.put("Шварц", dateFormat.parse("1.06.2012"));
        map.put("Линдеманн", dateFormat.parse("1.07.2012"));
        map.put("Ньютон", dateFormat.parse("1.08.2012"));
        map.put("Трамп", dateFormat.parse("1.09.2012"));
        map.put("Гейтс", dateFormat.parse("1.10.2012"));
        map.put("Цукерберг", dateFormat.parse("1.11.2012"));
        map.put("Лейбниц", dateFormat.parse("1.12.2012"));
        return map;
    }
    public static void removeAllSummerPeople(Map<String, Date> map) {
        List<String> removed = new LinkedList<>();
        map.forEach((name, date) -> {
            LocalDate localDate = date.toInstant()
                    .atZone(ZoneId.systemDefault()).toLocalDate();
            int month = localDate.getMonthValue() - 1;
            if(month >= Calendar.JUNE && month <= Calendar.AUGUST) {
                removed.add(name);
            }
        });
        removed.forEach(map::remove);
    }
    public static void main(String[] args) throws Throwable {
        Map<String, Date> map = createMap();
        removeAllSummerPeople(map);
        map.forEach((name, date) -> System.out.println(name + " " + date));
    }
}
