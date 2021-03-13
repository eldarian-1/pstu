package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.*;
import org.eldarian.relay.queries.select.item.PlayerQuery;
import org.eldarian.relay.queries.select.item.SubjectQuery;
import org.eldarian.relay.queries.select.item.TeamQuery;
import org.eldarian.relay.queries.select.list.PlayerListQuery;
import org.eldarian.relay.queries.select.list.SubjectListQuery;
import org.eldarian.relay.queries.select.list.TeamListQuery;
import org.eldarian.relay.queries.select.list.TeamPlayerListQuery;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

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
    public String subjects(Model model) {
        Collection<Subject> subjects = (Collection<Subject>)(new DataContext(new SubjectListQuery()).provide(null));
        model.addAttribute("subjects", subjects);
        return "general/subjects";
    }

    @GetMapping("/team")
    public String team(@RequestParam(name = "id") String id, Model model) {
        Team team = (Team)(new DataContext(new TeamQuery()).provide(id));
        Collection<Player> players = (Collection<Player>)(new DataContext(new TeamPlayerListQuery()).provide(id));
        model.addAttribute("team", team);
        model.addAttribute("players", players);
        return "general/team";
    }

    @GetMapping("/player")
    public String player(@RequestParam(name = "id") String id, Model model) {
        Player player = (Player)(new DataContext(new PlayerQuery()).provide(id));
        model.addAttribute("player", player);
        return "general/player";
    }

    @GetMapping("/subject")
    public String subject(@RequestParam(name = "id") String id, Model model) {
        Subject subject = (Subject)(new DataContext(new SubjectQuery()).provide(id));
        model.addAttribute("subject", subject);
        return "general/subject";
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