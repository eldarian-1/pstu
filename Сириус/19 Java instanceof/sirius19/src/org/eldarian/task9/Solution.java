package org.eldarian.task9;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.Optional;

public class Solution {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        Optional<Person> person;
        while((person = create(reader.readLine())).isPresent()){
            doWork(person.get());
        }
    }
    public static Optional<Person> create(String person) {
        return switch (person) {
            case "user" -> Optional.of(new Person.User());
            case "loser" -> Optional.of(new Person.Loser());
            case "coder" -> Optional.of(new Person.Coder());
            case "proger" -> Optional.of(new Person.Proger());
            default -> Optional.empty();
        };
    }
    public static void doWork(Person person) {
        if(person instanceof Person.User) {
            ((Person.User)person).live();
        } else if(person instanceof Person.Loser) {
            ((Person.Loser)person).doNothing();
        } else if(person instanceof Person.Coder) {
            ((Person.Coder)person).writeCode();
        } else if(person instanceof Person.Proger) {
            ((Person.Proger)person).enjoy();
        }
    }
}
