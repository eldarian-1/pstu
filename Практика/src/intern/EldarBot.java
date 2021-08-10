package intern;

import java.util.*;
import java.io.PrintWriter;
import java.util.function.Consumer;

import appt.meta3.*;

public class EldarBot {
    private static final PrintWriter out = new PrintWriter(System.out);
    private static final int myId = 1000360;
    private static ResourceBundle mains;

    public static void main(String[] args) throws Throwable {
        int lec, task;
        if(args.length >= 3) {
            mains = ResourceBundle.getBundle(args[0], new Locale("ru", "RU"));
            lec = Integer.parseInt(args[1]);
            task = Integer.parseInt(args[2]);
        } else {
            out.println("Не хватает аргументов в командной строке:\n" +
                    "1) intern_main\n" +
                    "2) номер лекции\n" +
                    "3) Номер задания");
            out.flush();
            return;
        }
        if(lec == 1) {
            if (task == -1) {
                hello(args);
            } else if (task == 0) {
                reg();
            } else if (task == 1) {
                lec1task1();
            } else if (task == 2) {
                lec1task2();
            } else if (task == 3) {
                lec1task3();
            } else if (task == 4) {
                if (args.length >= 4) {
                    lec1task4(Integer.parseInt(args[3]));
                } else {
                    out.println("Не хватает аргумента в командной строке," +
                            " который должжен нести в себе id отеля.");
                }
            } else if (task == 5) {
                lec1task5();
            } else if (task == 6) {
                lec1task6();
            } else if (task == 7) {
                lec1task7();
            } else if (task == 8) {
                lec1task8();
            } else if (task == 9) {
                lec1task9();
            } else if (task == 10) {
                lec1task10();
            } else if (task == 11) {
                lec1task11();
            } else if (task == 12) {
                lec1task12();
            } else if (task == 13) {
                if (args.length >= 4) {
                    lec1task13(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке," +
                            " который должжен нести в себе id отеля.");
                }
            } else if (task == 14) {
                lec1task14();
            } else if (task == 15) {
                lec1task15();
            } else if (task == 16) {
                if (args.length >= 4) {
                    lec1task16(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке," +
                            " который должжен нести в себе способ выполнения программы" +
                            " (1 - условием, 2 - компаратором).");
                }
            } else if (task == 17) {
                lec1task17();
            } else if (task == 18) {
                lec1task18();
            } else if (task == 19) {
                lec1task19();
            } else if (task == 21) {
                if (args.length >= 4) {
                    lec1task21(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке: id НС номера");
                }
            } else if (task == 22) {
                if (args.length >= 4) {
                    lec1task22(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            }
        } else if(lec == 2) {
            if(task == 1) {
                lec2task1();
            } else if(task == 2) {
                if (args.length >= 4) {
                    lec2task2(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 3) {
                if (args.length >= 4) {
                    lec2task3(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 4) {
                if (args.length >= 4) {
                    lec2task4(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 5) {
                if (args.length >= 5) {
                    lec2task5(args[3], args[4]);
                } else {
                    out.println("Не хватает аргументов в командной строке:\n" +
                            "4) id отеля\n" +
                            "5) id города");
                }
            } else if(task == 6) {
                if (args.length >= 4) {
                    lec2task6(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 7) {
                lec2task7();
            } else if(task == 8) {
                if (args.length >= 4) {
                    lec2task8(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 9) {
                if (args.length >= 4) {
                    lec2task9(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 10) {
                if (args.length >= 4) {
                    lec2task10(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 11) {
                if (args.length >= 4) {
                    lec2task11(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в путь выполнения программы.");
                }
            } else if(task == 12) {
                if (args.length >= 4) {
                    lec2task12(args[3]);
                } else {
                    out.println("Не хватает аргумента в командной строке, " +
                            "который должжен нести в себе файл вывода.");
                }
            } else if(task == 13) {
                lec2task13();
            }
        }
        out.flush();
    }

    private static void hello(String[] args) {
        for(String item : args) {
            out.println(item);
        }
        out.println("Hello World by Eldarian");
    }

    private static void reg() throws Throwable {
        Obb filter = Ob0.createFilter(249);
        Ob0.addCondition(filter, 1249100098, Ob0.ComparisonType.EQ, "ciborg.brain@yandex.ru");
        Obb iam = Ob0.getSrcObs(mains, filter, 0, 0)[0];
        out.println(Ob0.getAt(iam, 1249101783));
    }

    private static String createHotel(
            String description, double space, String name, String email, String gps,
            int max_capacity, String address, long town_from_hot, String category)
            throws Throwable {
        Obb hotel = new Obb(990);
        hotel.id_user = myId;
        Ob0.addAt(hotel, 1990100063, description);
        Ob0.addAt(hotel, 1990210007, String.valueOf(space));
        Ob0.addAt(hotel, 1990410000, name);
        Ob0.addAt(hotel, 1990410010, email);
        Ob0.addAt(hotel, 1990410087, gps);
        Ob0.addAt(hotel, 1990310131, max_capacity);
        Ob0.addAt(hotel, 1990410028, address);
        Ob0.addAt(hotel, 1990100059, String.valueOf(town_from_hot));
        Ob0.addAt(hotel, 1990100061, category);
        return Ob0.addOb(mains, hotel);
    }

    private static String createHotel(
            String description, double space, String name, String email, String gps,
            int max_capacity, String address, long town_from_hot,
            String category, String descLink) throws Throwable {
        Obb hotel = new Obb(990);
        hotel.id_user = myId;
        Ob0.addAt(hotel, 1990100063, description);
        Ob0.addAt(hotel, 1990210007, String.valueOf(space));
        Ob0.addAt(hotel, 1990410000, name);
        Ob0.addAt(hotel, 1990410010, email);
        Ob0.addAt(hotel, 1990410087, gps);
        Ob0.addAt(hotel, 1990310131, max_capacity);
        Ob0.addAt(hotel, 1990410028, address);
        Ob0.addAt(hotel, 1990100059, String.valueOf(town_from_hot));
        Ob0.addAt(hotel, 1990100061, category);
        Ob0.addAt(hotel, 1990922737, descLink);
        return Ob0.addOb(mains, hotel);
    }

    private static void lec1task1() throws Throwable {
        List<String> hotelIds = new ArrayList<>(10);
        hotelIds.add(createHotel("Тихое место мегаполиса", 25.5, "Городская Лагуна",
                "hot@ma.org", "13,6", 5, "Там", 100510000863L, "5*"));
        hotelIds.add(createHotel("Норм отель", 25.5, "Морской лягушонок", "old@mpr.com",
                "13,6", 5, "Твой сон", 100539140353L, "4*"));
        hotelIds.add(createHotel("Норм отель", 25.5, "Коловрадский утенок", "paty@uk.ru",
                "13,6", 5, "Тут", 100510397198L, "3*"));
        hotelIds.add(createHotel("Не уголькам вход запрещен", 25.5, "Безумный уголек",
                "one@prison.edu", "13,6", 5, "Здесь", 100510000892L, "2*"));
        hotelIds.add(createHotel("Зарядился и ушел", 25.5, "Розетка", "pot@ded.org",
                "13,6", 5, "У электрозаправки", 100510397333L, "1*"));
        hotelIds.add(createHotel("Сееееелааааа бааа...", 25.5, "Батарейка", "shot@rat.com",
                "0,0", 5, "В твоем телефоне", 100510000826L, "5*"));
        hotelIds.add(createHotel("Полетал - отдохнул", 25.5, "Канарейка", "shprot@hat.fr",
                "13,6", 5, "В клетке", 100510000863L, "4*"));
        hotelIds.add(createHotel("Андрюша расслабит", 25.5, "У Андрейки", "kent@lenta.ru",
                "13,6", 5, "У тебя дома в твое рабочее время", 100539140353L, "3*"));
        hotelIds.add(createHotel("Сел - Лег - Уснул", 25.5, "Кровать", "sectum@uhs.uk",
                "13,6", 5, "Твой дом", 100510397198L, "2*"));
        hotelIds.add(createHotel("Спать уложат, поесть принесут", 25.5, "Заботам.нет", "season@pen.hs",
                "13,6", 5, "Там, где тебя нет", 100510000892L, "1*"));
        out.print("\n\nHotel ids:");
        for(String hotelId : hotelIds) {
            out.printf("\n%s", hotelId);
        }
    }

    private static void printHotel(int i, Obb hotel) {
        out.printf("%d. Name: %s | %s stars | email: %s, coords: %s, address: %s %s\n",
                i, Ob0.getAt(hotel, 1990410000),
                Ob0.getAt(hotel, 1990100061),
                Ob0.getAt(hotel, 1990410010),
                Ob0.getAt(hotel, 1990410087),
                Ob0.getAt(hotel, 1990100059),
                Ob0.getAt(hotel, 1990410028));
    }

    private static void lec1task2() throws Throwable {
        Obb filter = Ob0.createFilter(990);
        Ob0.addCondition(filter, 1990100061, Ob0.ComparisonType.EQ, "5*");
        Ob0.addCondition(filter, 1990210007, Ob0.ComparisonType.GT, "100");
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        out.printf("\n\nCount of hotels: %d\n\n", hotels.length);
        int i = 0;
        for(Obb hotel : hotels) {
            printHotel(++i, hotel);
        }
    }

    private static void lec1task3() throws Throwable {
        Obb filter = Ob0.createFilter(990);
        Ob0.addCondition(filter, 1990310131, Ob0.ComparisonType.GT, "50");
        Ob0.addCondition(filter, 1990310131, Ob0.ComparisonType.LT, "100");
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        out.printf("\n\nCount of hotels: %d\n\n", hotels.length);
        int i = 0;
        for(Obb hotel : hotels) {
            out.printf("%d. ID: %s | Name: %s | Capacity: %s | coords: %s\n",
                    i, hotel.id,
                    Ob0.getAt(hotel, 1990410000),
                    Ob0.getAt(hotel, 1990310131),
                    Ob0.getAt(hotel, 1990410087));
        }
    }

    private static void lec1task4(int i) throws Throwable {
        final int K = 3;
        Obb filter = Ob0.createFilter(990);
        Ob0.addCondition(filter, 1990410010, Ob0.ComparisonType.NEQ, "");
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, --i * K, K);
        out.printf("\n\nPAGE %d\n", ++i);
        int j = 0;
        for (Obb hotel : hotels) {
            printHotel(++j, hotel);
        }
    }

    private static void lec1task5() throws Throwable {
        Obb filter = Ob0.createFilter(990);
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        for(Obb hotel : hotels) {
            if(hotel.id_user == myId) {
                String hotelId = hotel.id;
                hotel.id_user = myId;
                Ob0.addAt(hotel, 1990410000, "Эльдар Миннахметов");
                Ob0.addAt(hotel, 1990410010, "ciborg.brain@yandex.ru");
                Ob0.edtOb(mains, hotel);
                out.printf("\n%s is edited", hotelId);
            }
        }
    }

    private static void lec1task6() throws Throwable {
        Obb filter = Ob0.createFilter(990);
        Ob0.addCondition(filter, 1990410000, Ob0.ComparisonType.EQ, "Эльдар Миннахметов");
        Ob0.addCondition(filter, 1990410010, Ob0.ComparisonType.EQ, "ciborg.brain@yandex.ru");
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        int i = 0;
        out.print("\n\nHotels:\n");
        for(Obb hotel : hotels) {
            printHotel(++i, hotel);
        }
    }

    private static void lec1task7() throws Throwable {
        Obb filter = Ob0.createFilter(990);
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        for(Obb hotel : hotels) {
            if(hotel.id_user == myId) {
                String hotelId = hotel.id;
                hotel.id_user = myId;
                Ob0.delOb(mains, hotelId, myId);
                out.printf("\nHotel %s is deleted", hotelId);
            }
        }
    }

    private static String yesOrNo(boolean yes) {
        return yes ? "Да" : "Нет";
    }

    private static String createDescription(
            String kvm, String receptionSafe, boolean hairdryer, String conditioner,
            boolean onMainRoad, String miniBar, boolean balcony, boolean fridge, String shower,
            String bidet, String dietaryCuisine, boolean microvawe, int bowling) throws Throwable {
        Obb desc = new Obb(240);
        desc.id_user = myId;
        Ob0.addAt(desc, 1240100946, kvm);
        Ob0.addAt(desc, 1240101606, receptionSafe);
        Ob0.addAt(desc, 1240422204, yesOrNo(hairdryer));
        Ob0.addAt(desc, 1240422948, conditioner);
        Ob0.addAt(desc, 1240422118, yesOrNo(onMainRoad));
        Ob0.addAt(desc, 1240101793, miniBar);
        Ob0.addAt(desc, 1240422218, yesOrNo(balcony));
        Ob0.addAt(desc, 1240102011, yesOrNo(fridge));
        Ob0.addAt(desc, 1240422947, shower);
        Ob0.addAt(desc, 1240101803, bidet);
        Ob0.addAt(desc, 1240422732, dietaryCuisine);
        Ob0.addAt(desc, 1240102063, yesOrNo(microvawe));
        Ob0.addAt(desc, 1240102035, bowling);
        return Ob0.addOb(mains, desc);
    }

    private static void lec1task8() throws Throwable {
        List<String> descIds = new ArrayList<>(5);
        descIds.add(createDescription("32", "Непробиваемый", true, "Bosch",
                true, "С водкой", true, true, "Ariston", "Italian",
                "Vegan", true, 4));
        descIds.add(createDescription("25", "Прочный", true, "CrioСam++",
                true, "Полный ассортимент", true, true, "Bosch", "Arabic",
                "Vegan", true, 3));
        descIds.add(createDescription("19", "Немецкий", true, "NotBad",
                true, "Пьем только виски", true, true, "Спутник V", "Euro",
                "Vegan", true, 2));
        descIds.add(createDescription("12", "Жаропрочный", true, "ColdBandit",
                false, "Шампанское", true, true, "Байкал", "Apple MacBidet",
                "Vegan", true, 5));
        descIds.add(createDescription("45", "Легковесный", true, "CoolerPro",
                false, "Мясо", true, true, "Huawei", "Яндекс.Биде",
                "Мясная диета", true, 5));
        out.print("\n\nDescription ids:");
        for(String descId : descIds) {
            out.printf("\n%s", descId);
        }
    }

    private static List<String> getMyDesc() throws Throwable {
        List<String> descIds = new ArrayList<>();
        Obb filter = Ob0.createFilter(240);
        Obb[] descs = Ob0.getSrcObs(mains, filter, 0, 0);
        for(Obb desc : descs) {
            if(desc.id_user == myId) {
                descIds.add(desc.id);
            }
        }
        return descIds;
    }

    private static void lec1task9() throws Throwable {
        List<String> descIds = getMyDesc();
        List<String> hotelIds = new ArrayList<>(5);
        hotelIds.add(createHotel("Тихое место мегаполиса", 25.5, "Городская Лагуна",
                "hot@ma.org", "13,6", 5, "Там", 100510000863L, "5*",
                descIds.get(0)));
        hotelIds.add(createHotel("Норм отель", 25.5, "Морской лягушонок", "old@mpr.com",
                "13,6", 5, "Твой сон", 100539140353L, "4*",
                descIds.get(1)));
        hotelIds.add(createHotel("Норм отель", 25.5, "Коловрадский утенок", "paty@uk.ru",
                "13,6", 5, "Тут", 100510397198L, "3*", descIds.get(2)));
        hotelIds.add(createHotel("Не уголькам вход запрещен", 25.5, "Безумный уголек",
                "one@prison.edu", "13,6", 5, "Здесь", 100510000892L,
                "2*", descIds.get(3)));
        hotelIds.add(createHotel("Зарядился и ушел", 25.5, "Розетка", "pot@ded.org",
                "13,6", 5, "У электрозаправки", 100510397333L, "1*",
                descIds.get(4)));
        out.print("\n\nHotel ids:");
        for(String hotelId : hotelIds) {
            out.printf("\n%s", hotelId);
        }
    }

    private static void printDescription(Obb desc) {
        out.printf("Area: %s\nReception Safe: %s\nHairdryer: %s\nCentral conditioner: %s\n" +
                        "Located on main road: %s\nMini-bar: %s\nBalcony: %s\n Room fridge: %s\n" +
                        "Shower: %s\nBidet: %s\nDietary cuisine: %s\nMicrovawe: %s\n" +
                        "Sports bowling: %s\n",
                Ob0.getAt(desc, 1240100946),
                Ob0.getAt(desc, 1240101606),
                Ob0.getAt(desc, 1240422204),
                Ob0.getAt(desc, 1240422948),
                Ob0.getAt(desc, 1240422118),
                Ob0.getAt(desc, 1240101793),
                Ob0.getAt(desc, 1240422218),
                Ob0.getAt(desc, 1240102011),
                Ob0.getAt(desc, 1240422947),
                Ob0.getAt(desc, 1240101803),
                Ob0.getAt(desc, 1240422732),
                Ob0.getAt(desc, 1240102063),
                Ob0.getAt(desc, 1240102035));
    }

    private static Map<String, Obb> getDescMap() throws Throwable {
        Map<String, Obb> descIds = new HashMap<>();
        Obb filter = Ob0.createFilter(240);
        Obb[] descs = Ob0.getSrcObs(mains, filter, 0, 0);
        for(Obb desc : descs) {
            if(desc.id_user == myId) {
                descIds.put(desc.id, desc);
            }
        }
        return descIds;
    }

    private static void lec1task10() throws Throwable {
        Map<String, Obb> descIds = getDescMap();
        String condition = String.join("#", descIds.keySet());
        Obb filter = Ob0.createFilter(990);
        Ob0.addCondition(filter, 1990922737, Ob0.ComparisonType.IN, condition);
        Obb[] hotels = Ob0.getSrcObs(mains, filter, 0, 0);
        int i = 0;
        out.printf("\n\nHotel count: %d\n", hotels.length);
        for(Obb hotel : hotels) {
            printHotel(++i, hotel);
            printDescription(descIds.get(Ob0.getAt(hotel, 1990922737)));
        }
    }

    private static void lec1task11() throws Throwable {
        Obb descFilter = Ob0.createFilter(240);
        Ob0.addCondition(descFilter, 1240102011, Ob0.ComparisonType.EQ, "Да");
        Ob0.addCondition(descFilter, 1240102063, Ob0.ComparisonType.EQ, "Да");
        Ob0.addCondition(descFilter, 1240422118, Ob0.ComparisonType.EQ, "Нет");
        Obb[] descs = Ob0.getSrcObs(mains, descFilter, 0, 0);
        Map<String, Obb> descMap = new HashMap<>();
        for(Obb d : descs) {
            descMap.put(d.id, d);
        }
        String hotelCondition = String.join("#", descMap.keySet());
        Obb hotelFilter = Ob0.createFilter(990);
        Ob0.addCondition(hotelFilter, 1990922737, Ob0.ComparisonType.IN, hotelCondition);
        Obb[] hotels = Ob0.getSrcObs(mains, hotelFilter, 0, 0);
        int i = 0;
        out.printf("\n\nHotel count: %d\n", hotels.length);
        for(Obb hotel : hotels) {
            printHotel(++i, hotel);
            printDescription(descMap.get(Ob0.getAt(hotel, 1990922737)));
        }
    }

    private static void lec1task12() throws Throwable {
        Obb filter = Ob0.createFilter(240);
        Obb[] descs = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        for(Obb desc : descs) {
            if(desc.id_user == myId) {
                desc.id_user = myId;
                String descId = desc.id;
                Ob0.addAt(desc, 1240102035, 5);
                Ob0.addAt(desc, 1240102011, "Да");
                Ob0.edtOb(mains, desc);
                out.printf("\n%s is edited", descId);
            }
        }
    }

    private static void lec1task13(String hotelId) throws Throwable {
        Obb hotel = Ob0.getOb(mains, hotelId);
        Obb desc = Ob0.getOb(mains, Ob0.getAt(hotel, 1990922737));
        out.printf("\n\nDescription of Hotel by id = %s\n", desc.id);
        printHotel(1, hotel);
        printDescription(desc);
    }

    private static void lec1task14() throws Throwable {
        lec1task7();
        Obb filter = Ob0.createFilter(240);
        Obb[] descs = Ob0.getSrcObs(mains, Ob0.metaconnname, filter, 0, 0);
        for(Obb desc : descs) {
            if(desc.id_user == myId) {
                String hotelId = desc.id;
                Ob0.delOb(mains, hotelId, myId);
                out.printf("\nDescription %s is deleted", hotelId);
            }
        }
    }

    private static void lec1task15() throws Throwable {
        out.println("1990100063 - 1, строка");
        out.println("1990210007 - 2, число");
        out.println("1990410000 - 4, строка");
        out.println("1990410010 - 4, строка");
        out.println("1990410087 - 4, строка");
        out.println("1990310131 - 3, целое число");
        out.println("1990410028 - 4, строка");
        out.println("1990100059 - 1, ссылка");
        out.println("1990100061 - 1, список");
        out.println("1990922737 - 9, ссылка");

        out.println("1240100946 - 1, строка");
        out.println("1240101606 - 1, строка");
        out.println("1240422204 - 4, строка да/нет");
        out.println("1240422948 - 4, строка");
        out.println("1240422118 - 4, строка да/нет");
        out.println("1240101793 - 1, строка");
        out.println("1240422218 - 4, строка да/нет");
        out.println("1240102011 - 1, строка да/нет");
        out.println("1240422947 - 4, строка");
        out.println("1240101803 - 1, строка");
        out.println("1240422732 - 4, строка");
        out.println("1240102063 - 1, строка да/нет");
        out.println("1240102035 - 1, целое число");
    }

    private static void findByIf() throws Throwable {
        Obb filter = Ob0.createFilter(4);
        long timeForFindAll = System.currentTimeMillis(), timeForOutEur = timeForFindAll;
        Obb[] countries = Ob0.getSrcObs(mains, filter, 0, 0);
        timeForFindAll = System.currentTimeMillis() - timeForFindAll;
        out.printf("\n\nВсего стран: %d\n", countries.length);
        int i = 0;
        for(Obb country : countries) {
            if(Ob0.getAt(country, 1000001).equals("EUR")) {
                out.printf("%d %s %s\n", ++i, country.id, Ob0.getAt(country, 1000000));
            }
        }
        timeForOutEur = System.currentTimeMillis() - timeForOutEur;
        out.printf("Изъятие всех стран из базы: %d ms\nПоиск по условию(EUR) + вывод: %d ms\n",
                timeForFindAll, timeForOutEur);
    }

    private static void findByComparator() throws Throwable {
        Obb filter = Ob0.createFilter(4);
        Ob0.addCondition(filter, 1000001, Ob0.ComparisonType.EQ, "EUR");
        long timeForFindByComparator = System.currentTimeMillis(), timeForOutEur = timeForFindByComparator;
        Obb[] countries = Ob0.getSrcObs(mains, filter, 0, 0);
        timeForFindByComparator = System.currentTimeMillis() - timeForFindByComparator;
        out.printf("\n\nВсего стран: %d\n", countries.length);
        int i = 0;
        for(Obb country : countries) {
            out.printf("%d %s %s\n", ++i, country.id, Ob0.getAt(country, 1000000));
        }
        timeForOutEur = System.currentTimeMillis() - timeForOutEur;
        out.printf("Поиск компаратором(EUR): %d ms\nВывод: %d ms\n",
                timeForFindByComparator, timeForOutEur);
    }

    private static void lec1task16(String finder) throws Throwable {
        if("1".equals(finder)) {
            findByIf();
        } else if("2".equals(finder)) {
            findByComparator();
        } else {
            out.println("Enter 1 or 2.");
        }
    }

    private static<T> long setTime(Consumer<T> consumer, T arg) {
        long time = System.currentTimeMillis();
        consumer.accept(arg);
        return System.currentTimeMillis() - time;
    }

    private static long putCountriesInMap(Map<String, String> map, Obb[] countries) {
        return setTime((Void) -> {
            for (Obb country : countries) {
                map.put(country.id, Ob0.getAt(country, 1000000));
            }
        }, null);
    }

    private static long outMap(Map<String, String> map, String firstLine) {
        out.print(firstLine);
        return setTime((Void) -> {
            int i = 0;
            for (String id : map.keySet()) {
                out.printf("%d %s %s\n", ++i, id, map.get(id));
            }
        }, null);
    }

    private static void lec1task17() throws Throwable {
        Obb filter = Ob0.createFilter(4);
        long timeFind = System.currentTimeMillis();
        Obb[] countries = Ob0.getSrcObs(mains, filter, 0 ,0);
        timeFind = System.currentTimeMillis() - timeFind;
        Map<String, String> hash = new HashMap<>();
        Map<String, String> tree = new TreeMap<>();
        long timeHash = putCountriesInMap(hash, countries);
        long timeTree = putCountriesInMap(tree, countries);
        long timeHashOut = outMap(hash, "\n\nHashMap out:\n");
        long timeTreeOut = outMap(tree, "\n\nTreeMap out:\n");
        out.printf("\nPut in hash: %d ms\nPut in tree: %d ms\nOut from hash: %d ms\nOut from tree: %d ms\n",
                timeHash, timeTree, timeHashOut, timeTreeOut);
    }

    private static void lec1task18() throws Throwable {
        Obb filter = Ob0.createFilter(4);
        Ob0.addCondition(filter, 1004200022, Ob0.ComparisonType.LT, "0");
        Ob0.addCondition(filter, 1004200023, Ob0.ComparisonType.GT, "0");
        Ob0.addCondition(filter, 1004200024, Ob0.ComparisonType.GT, "0");
        Obb[] countries = Ob0.getSrcObs(mains, filter, 0 ,0);
        int i = 0;
        for(Obb country : countries) {
            out.printf("\n%d %s - страна для туризма: %s",
                    ++i, Ob0.getAt(country, 1000000),
                    Ob0.getAt(country, 1000606));
        }
        out.println();
    }

    private static long putCitiesInSet(Set<String> set, Obb[] obbs) {
        return setTime((Void) -> {
            for (Obb obb : obbs) {
                set.add(obb.id);
            }
        }, null);
    }

    private static long putCitiesInMap(Map<String, String> map, Obb[] cities) {
        return setTime((Void) -> {
            for (Obb city : cities) {
                map.put(city.id, Ob0.getAt(city, 1000098));
            }
        }, null);
    }

    private static long outSet(Set<String> set, String firstLine) {
        out.print(firstLine);
        return setTime((Void) -> {
            int i = 0;
            for (String id : set) {
                out.printf("%d %s\n", ++i, id);
            }
        }, null);
    }

    private static long delSet(Set<String> set, Set<String> setFrom) {
        return setTime((Void) -> {
            for (String id : setFrom) {
                set.remove(id);
            }
        }, null);
    }

    private static long delMap(Map<String, String> map, Map<String, String> mapFrom) {
        return setTime((Void) -> {
            for (String id : mapFrom.keySet()) {
                map.remove(id);
            }
        }, null);
    }

    private static void lec1task19() throws Throwable {
        Obb filter = Ob0.createFilter(5);
        Ob0.addCondition(filter, 1000004, Ob0.ComparisonType.EQ, "100410000050");
        Obb[] cities = Ob0.getSrcObs(mains, filter, 0 ,0);
        Set<String> hash = new HashSet<>();
        Set<String> linked = new LinkedHashSet<>();
        Set<String> tree = new TreeSet<>();
        Map<String, String> hashM = new HashMap<>();
        Map<String, String> treeM = new TreeMap<>();
        long timeHash = putCitiesInSet(hash, cities);
        long timeLinked = putCitiesInSet(linked, cities);
        long timeTree = putCitiesInSet(tree, cities);
        long timeHashM = putCitiesInMap(hashM, cities);
        long timeTreeM = putCitiesInMap(treeM, cities);
        long timeOutHash = outSet(hash, "\n\nHashSet out:\n");
        long timeOutLinked = outSet(linked, "\n\nLinkedHashSet out:\n");
        long timeOutTree = outSet(tree, "\n\nTreeSet out:\n");
        long timeOutHashM = outMap(hashM, "\n\nHashMap out:\n");
        long timeOutTreeM = outMap(treeM, "\n\nTreeMap out:\n");
        long timeDelHash = delSet(hash, new HashSet<>(hash));
        long timeDelLinked = delSet(linked, new LinkedHashSet<>(linked));
        long timeDelTree = delSet(tree, new TreeSet<>(tree));
        long timeDelHashM = delMap(hashM, new HashMap<>(hashM));
        long timeDelTreeM = delMap(treeM, new TreeMap<>(treeM));
        out.printf("\nHashSet: %d ms\nLinkedHashSet: %d ms\nTreeSet: %d ms\nHashMap: %d ms\nTreeMap: %d ms\n" +
                        "out from HashSet: %d ms\nout from LinkedHashSet: %d ms\nout from TreeSet: %d ms\n" +
                        "out from HashMap: %d ms\nout from TreeMap: %d ms\ndelete from HashSet: %d ms\n" +
                        "delete from LinkedHashSet: %d ms\ndelete from TreeSet: %d ms\ndelete from HashMap: %d ms\n" +
                        "delete from TreeMap: %d ms\n",
                timeHash, timeLinked, timeTree, timeHashM, timeTreeM, timeOutHash, timeOutLinked, timeOutTree,
                timeOutHashM, timeOutTreeM, timeDelHash, timeDelLinked, timeDelTree, timeDelHashM, timeDelTreeM);
    }

    private static void lec1task21(String nsId) throws Throwable {
        PrintWriter fout = new PrintWriter("/w2/srv/bin/eminnakhmetov/n" + nsId + ".json");
        Obb filter = Ob0.createFilter(46);
        Ob0.addCondition(filter, 1000350, Ob0.ComparisonType.EQ, nsId);
        Obb[] nsNumbers = Ob0.getSrcObs(mains, filter, 0, 0);
        fout.print("[");
        for(int i = 0, n = nsNumbers.length; i < n; ++i) {
            fout.printf("{\"nm\":\"%s\",\"tp\":\"%s\"}%s",
                    Ob0.getAt(nsNumbers[i],1000348),
                    Ob0.getAt(nsNumbers[i],1046222729),
                    i < n - 1 ? "," : "");
        }
        fout.print("]");
        fout.flush();
    }

    private static void lec1task22(String file) throws Throwable {
        PrintWriter fout;
        if(file.equals("stdout")){
            fout = new PrintWriter(System.out);
        } else {
            fout = new PrintWriter(file);
        }
        Obb filter = Ob0.createFilter(89);
        Obb[] cashboxes = Ob0.getSrcObs(mains, filter, 0, 0);
        fout.print("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><CashBoxes>");
        for(Obb cashbox : cashboxes) {
            int number = Integer.parseInt(Ob0.getAt(cashbox, 1000633));
            if(number % 2 == 0) {
                fout.print("<CashBox>");
                fout.printf("<name>%s</name>", Ob0.getAt(cashbox, 1089410000));
                fout.printf("<number>%d</number>", number);
                fout.printf("<link_to_office>%s</link_to_office>", Ob0.getAt(cashbox, 1001359));
                fout.print("</CashBox>");
            }
        }
        fout.print("</CashBoxes>");
        fout.flush();
    }

    private static String createDescription(String address, String beautyShop, String roomDesc,
                                            String lift) throws Throwable {
        Obb desc = new Obb(240);
        desc.id_user = myId;
        Ob0.addAt(desc, "1240100052", address);
        Ob0.addAt(desc, "1240101601", beautyShop);
        Ob0.addAt(desc, "1240101815", roomDesc);
        Ob0.addAt(desc, "1240102031", lift);
        return Ob0.addOb(mains, desc);
    }

    private static String createHotel(String name, String rating, String desc) throws Throwable {
        Obb hotel = new Obb(26);
        hotel.id_user = myId;
        Ob0.addAt(hotel, "1000127", name);
        Ob0.addAt(hotel, "1000300", rating);
        Ob0.addAt(hotel, "1026922737", desc);
        return Ob0.addOb(mains, hotel);
    }

    /*private static String createHotel(String name, String rating, String address, String beautyShop,
                                      String roomDesc, String lift) throws Throwable {
        return createHotel(name, rating, createDescription(address, beautyShop, roomDesc, lift));
    }*/

    private static String createHotel(String name, String rating, String address, String beautyShop,
                                      String roomDesc, String lift) throws Throwable {
        Obb desc = new Obb(240);
        Obb hotel = new Obb(26);
        desc.id_user = myId;
        hotel.id_user = myId;
        Ob0.addAt(desc, "1240100052", address);
        Ob0.addAt(desc, "1240101601", beautyShop);
        Ob0.addAt(desc, "1240101815", roomDesc);
        Ob0.addAt(desc, "1240102031", lift);
        Ob0.addAt(hotel, "1000127", name);
        Ob0.addAt(hotel, "1000300", rating);
        Ob0.addAt(hotel, "1026922737", Ob0.addOb(mains, desc));
        return Ob0.addOb(mains, hotel);
    }

    private static void lec2task1() throws Throwable {
        List<String> list = new ArrayList<>(5);
        list.add(createHotel("Сигма", "5", "Сочи", "Maria",
                "классные", "5"));
        list.add(createHotel("Второй дом", "4", "Москва", "У Наташи",
                "красивые", "10"));
        list.add(createHotel("Тебе рады", "3", "Пермь", "Софья",
                "уютные", "2"));
        list.add(createHotel("Отдохни", "2", "Екатеринбург", "Анатолий",
                "чистые", "7"));
        list.add(createHotel("Поспи", "1", "Ставрополь", "BarberShop",
                "грязные", "6"));
        out.printf("\nСоздано отелей: %d\n", list.size());
        for(String id : list) {
            out.println(id);
        }
    }

    private static void lec2task2(String hotelId) throws Throwable {
        String descId = Ob0.getZn(mains, hotelId, "1026922737", 9);
        String beautyShop = Ob0.getZn(mains, descId, "1240100052", 4);
        out.printf("\nГород отеля с id %s : %s\n", hotelId, beautyShop);
    }

    private static void lec2task3(String hotelId) throws Throwable {
        String descId = Ob0.getZn(mains, hotelId, "1026922737", 9);
        String facilityLifts = Ob0.getZn(mains, descId, "1240102031", 3);
        out.printf("\nЛифт отеля с id %s : %s\n", hotelId, facilityLifts);
    }

    private static void lec2task4(String hotelId) throws Throwable {
        String descId = Ob0.getZn(mains, hotelId, "1026922737", 9);
        String hotelRoomDesc = Ob0.getZn(mains, descId, "1240101815", 12);
        out.printf("\nОписание номеров отеля с id %s : %s\n", hotelId,
                hotelRoomDesc == null ? "без описания" : hotelRoomDesc);
    }

    private static void lec2task5(String hotelId, String cityId) throws Throwable {
        Obb hotel = Ob0.getOb(mains, hotelId);
        hotel.id_user = myId;
        Ob0.addAt(hotel, "1000117", cityId);
        Ob0.edtOb(mains, hotel);
        out.printf("\nThere is hotel %s in city %s now.\n", hotelId, cityId);
    }

    private static void lec2task6(String hotelId) throws Throwable {
        String cityId = Ob0.getZn(mains, hotelId, "1000117", 9);
        String countryId = Ob0.getZn(mains, cityId, "1000004", 10);
        out.printf("\nCity ID: %s\nCountry: %s\n", cityId, Ob0.getZn(mains, countryId, "1000000", 4));
    }

    private static void lec2task7() throws Throwable {
        final String sochiId = "100520751057";
        Obb filter = Ob0.createFilter(26);
        Ob0.addCondition(filter, 1000117, Ob0.ComparisonType.EQ, sochiId);
        Ob0.addCondition(filter, 1000300, Ob0.ComparisonType.GT, "4");
        Obb[] hotels = Ob0.getSrcObs(mains, filter, 0, 0);
        out.printf("\nНайдено отелей: %d\n", hotels.length);
        for(Obb hotel : hotels) {
            out.printf("%s, %s, %s\n",
                    Ob0.getAt(hotel, "1000127"),
                    Ob0.getAt(hotel, "1000300"),
                    Ob0.getZn(mains, Ob0.getAt(hotel, "1026922737"), "1240100052", 4));
        }
    }

    private static void lec2task8(String countryId) throws Throwable {
        List<String> cities = Ob0.getZnS(mains, countryId, 1004101237, 9);
        int i = 0;
        out.printf("\nCities: %s\n", cities.size());
        for(String cityId : cities) {
            out.printf("%d. %s\n", ++i, Ob0.getZn(mains, cityId, "1000098", 1));
        }
    }

    private static ArrayList<String> getFaxes(Obb desc) {
        return new ArrayList<>(Arrays.asList(Ob0.getAts(desc, "1240100097")));
    }

    private static void setFaxes(Obb desc, ArrayList<String> faxes) throws Throwable {
        desc.id_user = myId;
        Ob0.addAts(desc, 1240100097, faxes);
        Ob0.edtOb(mains, desc);
    }

    private static void outFaxes(Obb desc) {
        out.printf("Faxes by descID %s: %s\n", desc.id, String.join(", ", getFaxes(desc)));
    }

    private static void lec2task9(String phase) throws Throwable {
        Obb[] allDescs = Ob0.getSrcObs(mains, Ob0.createFilter(240), 0, 0);
        List<Obb> myDescs = new ArrayList<>();
        for(Obb desc : allDescs) {
            if(desc.id_user == myId) {
                myDescs.add(desc);
            }
        }
        if(phase.equals("1")) {
            ArrayList<String> faxes = new ArrayList<>();
            faxes.add("2-192-35-46");
            for(Obb desc : myDescs) {
                setFaxes(desc, faxes);
                outFaxes(desc);
            }
        } else if(phase.equals("2")) {
            for(Obb desc : myDescs) {
                ArrayList<String> faxes = getFaxes(desc);
                faxes.add(0, "2-329-61-59");
                setFaxes(desc, faxes);
                outFaxes(desc);
            }
        } else if(phase.equals("3")) {
            for(Obb desc : myDescs) {
                ArrayList<String> faxes = getFaxes(desc);
                faxes.add(faxes.size(), "2-911-73-08");
                setFaxes(desc, faxes);
                outFaxes(desc);
            }
        }
    }

    private static void lec2task10(String hotelId) throws Throwable {
        String descId = Ob0.getZn(mains, hotelId, "1026922737", 9);
        List<String> faxes = Ob0.getZnS(mains, descId, 1240100097, 4);
        out.printf("\n%s\n", String.join(", ", faxes));
    }

    private static void lec2task11(String way) throws Throwable {
        final String sochiId = "100520751057";
        long time = -1;
        if(way.equals("1")) {
            time = catchTime(() -> {
                out.printf("\nГород вылета: %s\nНазвание: %s\n",
                        Ob0.getZn(mains, sochiId, "1000101", 1),
                        Ob0.getZn(mains, sochiId, "1000098", 1));
            });
        } else if(way.equals("2")) {
            time = catchTime(() -> {
                Obb sochi = Ob0.getOb(mains, sochiId);
                out.printf("\nГород вылета: %s\nНазвание: %s\n",
                        Ob0.getAt(sochi, "1000101"),
                        Ob0.getAt(sochi, "1000098"));
            });
        } else {
            out.print("\nНеверный путь выполнения программы! (Должен быть 1 или 2)\n");
        }
        if(time != -1) {
            out.printf("\nВремя выполнения программы: %d ms\n", time);
        }
    }

    private interface Procedure {
        void run() throws Throwable;
    }

    private static long catchTime(Procedure procedure) throws Throwable {
        long time = System.currentTimeMillis();
        procedure.run();
        return System.currentTimeMillis() - time;
    }

    private static long way1(String hotelId) throws Throwable {
        return catchTime(() -> {
            Obb hotel = Ob0.getOb(mains, hotelId);
            String name = Ob0.getAt(hotel, "1000127");
            String cityId = Ob0.getAt(hotel, "1000117");
            out.printf("\nНазвание: %s\nID города: %s\n", name, cityId);
        });
    }

    private static long way2(String hotelId) throws Throwable {
        return catchTime(() -> {
            String name = Ob0.getZn(mains, hotelId, "1000127", 4);
            String cityId = Ob0.getZn(mains, hotelId, "1000117", 9);
            out.printf("\nНазвание: %s\nID города: %s\n", name, cityId);
        });
    }

    private static long way3(String hotelId) throws Throwable {
        return catchTime(() -> {
            Obb hotel = Ob0.getOb(mains, hotelId);
            String name = Ob0.getAt(hotel, "1000127");
            String cityId = Ob0.getAt(hotel, "1000117");
            String descId = Ob0.getAt(hotel, "1000098");
            String rating = Ob0.getZn(mains, descId, "1000300", 3);
            out.printf("\nНазвание: %s\nID города: %s\nРейтинг: %s\n", name, cityId, rating);
        });
    }

    private static long way4(String hotelId) throws Throwable {
        return catchTime(() -> {
            String name = Ob0.getZn(mains, hotelId, "1000127", 4);
            String cityId = Ob0.getZn(mains, hotelId, "1000117", 9);
            String descId = Ob0.getZn(mains, hotelId, "1000098", 9);
            String rating = Ob0.getZn(mains, descId, "1000300", 3);
            out.printf("\nНазвание: %s\nID города: %s\nРейтинг: %s\n", name, cityId, rating);
        });
    }

    private static void lec2task12(String way) throws Throwable {
        final String hotelId = "102610084348";
        long time = -1;
        if(way.equals("1")) {
            time = way1(hotelId);
        } else if(way.equals("2")) {
            time = way2(hotelId);
        } else if(way.equals("3")) {
            time = way3(hotelId);
        } else if(way.equals("4")) {
            time = way4(hotelId);
        } else {
            out.printf("\nНекорректный способ исполнения! (должно быть от 1 до 4)\n");
            return;
        }
        out.printf("\nВремя выполнения операции: %d ms\n", time);
    }

    private static void lec2task13() throws Throwable {
        Obb[] hotels = Ob0.getSrcObs(mains, Ob0.createFilter(26), 0, 0);
        Obb[] descs = Ob0.getSrcObs(mains, Ob0.createFilter(240), 0, 0);
        Consumer<Obb[]> remover = (Obb[] obs) -> {
            for(Obb ob : obs) {
                if(ob.id_user == myId) {
                    try {
                        Ob0.delOb(mains, ob.id, myId);
                        out.printf("%s is deleted\n", ob.id);
                    } catch (Exception ex) {
                        out.println(ex.getMessage());
                    }
                }
            }
        };
        remover.accept(hotels);
        remover.accept(descs);
    }
}