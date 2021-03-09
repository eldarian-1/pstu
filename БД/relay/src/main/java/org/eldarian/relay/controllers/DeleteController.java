package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class DeleteController {

    @GetMapping("/delete_team")
    public String deleteTeam() {
        return "add_team";
    }

    @GetMapping("/delete_player")
    public String deletePlayer() {
        return "add_player";
    }

    @GetMapping("/delete_workout")
    public String deleteWorkout() {
        return "add_workout";
    }

    @GetMapping("/delete_relay_race")
    public String deleteRelayRace() {
        return "add_relay_race";
    }

}
