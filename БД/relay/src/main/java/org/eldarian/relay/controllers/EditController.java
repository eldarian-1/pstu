package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class EditController {

    @GetMapping("/edit_team")
    public String editTeam() {
        return "edition/add_team";
    }

    @GetMapping("/edit_player")
    public String editPlayer() {
        return "edition/add_player";
    }

    @GetMapping("/edit_workout")
    public String editWorkout() {
        return "edition/add_workout";
    }

    @GetMapping("/edit_relay_race")
    public String editRelayRace() {
        return "edition/add_relay_race";
    }

}
