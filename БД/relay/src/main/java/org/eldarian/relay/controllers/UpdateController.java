package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class UpdateController {

    @GetMapping("/update_team")
    public String updateTeam() {
        return "add_team";
    }

    @GetMapping("/update_player")
    public String updatePlayer() {
        return "add_player";
    }

    @GetMapping("/update_workout")
    public String updateWorkout() {
        return "add_workout";
    }

    @GetMapping("/update_relay_race")
    public String updateRelayRace() {
        return "add_relay_race";
    }

}
