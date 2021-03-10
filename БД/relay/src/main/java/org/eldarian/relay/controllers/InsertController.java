package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class InsertController {

    @GetMapping("/insert_team")
    public String insertTeam() {
        return "add_team";
    }

    @PostMapping("/insert_player")
    public String insertPlayer(@RequestParam(name = "player_name") String name) {
        return "redirect:http://localhost:8081/";
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
