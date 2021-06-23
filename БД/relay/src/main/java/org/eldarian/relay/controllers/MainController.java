package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.*;
import org.eldarian.relay.queries.select.item.*;
import org.eldarian.relay.queries.select.list.*;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.Collection;

@Controller
public class MainController extends AController {

    @GetMapping("/")
    public String home() {
        return "general/home";
    }

    @GetMapping("/player")
    public String player(@RequestParam(name = "id") String id, Model model) {
        Player player = (Player)(new DataContext(new PlayerQuery()).provide(id));
        Collection<Result> results = (Collection<Result>)(new DataContext(new PlayerResultListQuery()).provide(id));
        model.addAttribute("player", player);
        model.addAttribute("results", results);
        return "general/player";
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
        ResultList resultList = (ResultList)(new DataContext(new OpenedResultListQuery()).provide(id));
        Collection<Player> players = (Collection<Player>)(new DataContext(new TeamPlayerListQuery()).provide(id));
        Collection<Subject> subjects = (Collection<Subject>)
                (new DataContext(new IncludedTeamSubjectQuery()).provide(id));
        Collection<ResultList> resultLists = (Collection<ResultList>)
                (new DataContext(new ResultListsQuery()).provide(id));
        model.addAttribute("team", team);
        model.addAttribute("players", players);
        model.addAttribute("subjects", subjects);
        model.addAttribute("resultLists", resultLists);
        model.addAttribute("resultListId", resultList != null ? resultList.getResultListId() : 0);
        return "general/team";
    }

    @GetMapping("/teams")
    public String teams(Model model) {
        Collection<Team> teams = (Collection<Team>)(new DataContext(new TeamListQuery()).provide(null));
        model.addAttribute("teams", teams);
        return "general/teams";
    }

    @GetMapping("/subject")
    public String subject(@RequestParam(name = "id") String id, Model model) {
        Subject subject = (Subject)(new DataContext(new SubjectQuery()).provide(id));
        model.addAttribute("subject", subject);
        return "general/subject";
    }

    @GetMapping("/result_list")
    public String resultList(@RequestParam(name = "id") String id, Model model) {
        ResultList resultList = (ResultList)(new DataContext(new ResultListQuery()).provide(id));
        Collection<Result> results = (Collection<Result>)(new DataContext(new EventResultsQuery()).provide(id));
        model.addAttribute("resultList", resultList);
        model.addAttribute("results", results);
        return "general/result_list";
    }

    @GetMapping("/relay_race")
    public String relayRace(@RequestParam(name = "id") String id, Model model) {
        RelayRace relayRace = (RelayRace)(new DataContext(new RelayRaceQuery()).provide(id));
        Collection<RelayTeam> teams = (Collection<RelayTeam>)(new DataContext(new IncludedRelayTeamQuery())
                .provide(id));
        Collection<Subject> subjects = (Collection<Subject>)(new DataContext(new IncludedRelaySubjectQuery())
                .provide(id));
        model.addAttribute("teams", teams);
        model.addAttribute("subjects", subjects);
        model.addAttribute("relayRace", relayRace);
        return "general/relay_race";
    }

    @GetMapping("/relay_races")
    public String relayRaces(Model model) {
        Collection<RelayRace> relayRaces = (Collection<RelayRace>)(new DataContext(new RelayRaceListQuery())
                .provide(null));
        model.addAttribute("relayRaces", relayRaces);
        return "general/relay_races";
    }

    @GetMapping("/authorization")
    public String authorization() {
        return "general/authorization";
    }

}