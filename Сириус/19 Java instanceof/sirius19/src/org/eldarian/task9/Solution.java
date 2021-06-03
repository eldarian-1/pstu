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
        if(person.equals("user")) {
            return Optional.of(new Person.User());
        } else if(person.equals("loser")) {
            return Optional.of(new Person.Loser());
        } else if(person.equals("coder")) {
            return Optional.of(new Person.Coder());
        } else if(person.equals("proger")) {
            return Optional.of(new Person.Proger());
        } else {
            return Optional.empty();
        }
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
