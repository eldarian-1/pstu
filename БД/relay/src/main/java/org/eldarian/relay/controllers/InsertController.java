package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class InsertController {

    @GetMapping("/insert_team")
    public String insertTeam() {
        return "add_team";
    }

    @GetMapping("/insert_player")
    public String insertPlayer() {
        return "add_player";
    }

    @GetMapping("/insert_workout")
    public String insertWorkout() {
        return "add_workout";
    }

    @GetMapping("/insert_relay_race")
    public String insertRelayRace() {
        return "add_relay_race";
    }

}
