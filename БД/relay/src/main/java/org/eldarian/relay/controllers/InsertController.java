package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.queries.*;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
public class InsertController {

    @PostMapping("/insert_team")
    public String insertTeam(@RequestParam(name = "team_name") String teamName,
                             @RequestParam(name = "trainers") String trainers) {
        new DataContext(new AddTeamQuery()).provide(new String[]{teamName, trainers});
        return "redirect:/teams";
    }

    @PostMapping("/insert_player")
    public String insertPlayer(@RequestParam(name = "player_name") String name) {
        new DataContext(new AddPlayerQuery()).provide(name);
        return "redirect:/players";
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
