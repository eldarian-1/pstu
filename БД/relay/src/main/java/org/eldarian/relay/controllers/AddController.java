package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.Team;
import org.eldarian.relay.queries.select.TeamListQuery;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.Collection;

@Controller
public class AddController {

    @GetMapping("/add_team")
    public String addTeam() {
        return "addition/add_team";
    }

    @GetMapping("/add_player")
    public String addPlayer(Model model) {
        Collection<Team> teams = (Collection<Team>)(new DataContext(new TeamListQuery()).provide(null));
        model.addAttribute("teams", teams);
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
