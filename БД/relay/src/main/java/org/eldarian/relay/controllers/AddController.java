package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class AddController {

    @GetMapping("/add_team")
    public String addTeam() {
        return "addition/add_team";
    }

    @GetMapping("/add_player")
    public String addPlayer() {
        return "addition/add_player";
    }

    @GetMapping("/add_subject")
    public String addSubject() {
        return "addition/add_subject";
    }

    @GetMapping("/add_workout")
    public String addWorkout() {
        return "addition/add_workout";
    }

    @GetMapping("/add_relay_race")
    public String addRelayRace() {
        return "addition/add_relay_race";
    }

}
