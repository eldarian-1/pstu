package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.ResultList;
import org.eldarian.relay.queries.insert.*;
import org.eldarian.relay.queries.select.item.*;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
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

    @PostMapping("/insert_team_subject")
    public String insertTeamSubject(@RequestParam(name = "id") String teamId,
                                    @RequestParam(name = "subject_id") String subjectId) {
        new DataContext(new AddTeamSubjectQuery()).provide(new String[]{teamId, subjectId});
        return "redirect:/team?id=" + teamId;
    }

    @GetMapping("/start_workout")
    public String addWorkout(@RequestParam(name = "id") String teamId, Model model) {
        new DataContext(new AddResultListQuery()).provide(teamId);
        ResultList resultList = (ResultList)(new DataContext(new OpenedResultListQuery()).provide(teamId));
        model.addAttribute("resultList", resultList);
        return "redirect:/result_list?id=" + resultList.getResultListId();
    }

    @PostMapping("/insert_relay_race")
    public String insertRelayRace() {
        return "add_relay_race";
    }

}
