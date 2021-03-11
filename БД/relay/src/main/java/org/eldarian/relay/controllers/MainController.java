package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.*;
import org.eldarian.relay.queries.*;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.Collection;

@Controller
public class MainController {

    @GetMapping("/")
    public String home() {
        return "general/home";
    }

    @GetMapping("/teams")
    public String teams(Model model) {
        Collection<Team> teams = (Collection<Team>)(new DataContext(new TeamListQuery()).provide(null));
        model.addAttribute("teams", teams);
        return "general/teams";
    }

    @GetMapping("/players")
    public String players(Model model) {
        Collection<Player> players = (Collection<Player>)(new DataContext(new PlayerListQuery()).provide(null));
        model.addAttribute("players", players);
        return "general/players";
    }

    @GetMapping("/subjects")
    public String subjects() {
        return "general/subjects";
    }

    @GetMapping("/workouts")
    public String workouts() {
        return "general/workouts";
    }

    @GetMapping("/relay_races")
    public String relayRaces() {
        return "general/relay_races";
    }

    @GetMapping("/authorization")
    public String authorization() {
        return "general/authorization";
    }

}