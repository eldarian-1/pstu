package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.*;
import org.eldarian.relay.queries.select.list.*;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.Collection;

@Controller
public class AddController extends AController {

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

    @GetMapping("/add_team_subject")
    public String addTeamSubject(@RequestParam(name = "id") String id, Model model) {
        Collection<Subject> subjects = (Collection<Subject>)
                (new DataContext(new NotIncludedTeamSubjectQuery()).provide(id));
        model.addAttribute("teamId", id);
        model.addAttribute("subjects", subjects);
        return "addition/add_team_subject";
    }

    @GetMapping("/add_relay_race")
    public String addRelayRace() {
        return "addition/add_relay_race";
    }

    @GetMapping("/add_relay_team")
    public String addRelayTeam(@RequestParam(name = "id") String relayId, Model model) {
        Collection<Team> teams = (Collection<Team>)(new DataContext(new NotIncludedRelayTeamQuery())
                .provide(relayId));
        model.addAttribute("teams", teams);
        model.addAttribute("relayId", relayId);
        return "addition/add_relay_team";
    }

    @GetMapping("/add_relay_subject")
    public String addRelaySubject(@RequestParam(name = "id") String id, Model model) {
        Collection<Subject> subjects = (Collection<Subject>)(new DataContext(new NotIncludedRelaySubjectQuery())
                .provide(id));
        model.addAttribute("subjects", subjects);
        model.addAttribute("relayId", id);
        return "addition/add_relay_subject";
    }

    @GetMapping("/add_result")
    public String addResult(@RequestParam(name = "id") String resultListId, Model model) {
        Collection<Subject> subjects = (Collection<Subject>)(new DataContext(new PossibleSubjectListQuery())
                .provide(resultListId));
        Collection<Player> players = (Collection<Player>)(new DataContext(new PossiblePlayerListQuery())
                .provide(resultListId));
        Collection<PlayerScores> scores = (Collection<PlayerScores>)(new DataContext(new PlayerScoreListQuery())
                .provide(resultListId));
        model.addAttribute("subjects", subjects);
        model.addAttribute("players", players);
        model.addAttribute("scores", scores);
        model.addAttribute("resultListId", resultListId);
        return "addition/add_result";
    }

}
