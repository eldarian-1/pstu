package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.queries.insert.*;
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
    public String insertPlayer(@RequestParam(name = "player_name") String name,
                               @RequestParam(name = "team_id") String team) {
        new DataContext(new AddPlayerQuery()).provide(new String[]{name, team});
        return "redirect:/players";
    }

    @PostMapping("/insert_subject")
    public String insertSubject(@RequestParam(name = "subject_name") String name,
                                @RequestParam(name = "subject_unit") String unit,
                                @RequestParam(name = "subject_multiplier") String multiplier) {
        new DataContext(new AddSubjectQuery()).provide(new String[]{name, unit, multiplier});
        return "redirect:/subjects";
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
