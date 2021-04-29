package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.queries.delete.*;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class DeleteController extends AController {

    @GetMapping("/remove_team")
    public String deleteTeam(@RequestParam(name = "id") String id) {
        new DataContext(new RemoveTeamQuery()).provide(id);
        return "redirect:/teams";
    }

    @GetMapping("/remove_player")
    public String deletePlayer(@RequestParam(name = "id") String id) {
        new DataContext(new RemovePlayerQuery()).provide(id);
        return "redirect:/players";
    }

    @GetMapping("/remove_subject")
    public String deleteWorkout(@RequestParam(name = "id") String id) {
        new DataContext(new RemoveSubjectQuery()).provide(id);
        return "redirect:/subjects";
    }

    @GetMapping("/exclude_team_subject")
    public String deleteWorkout(@RequestParam(name = "id") String teamId,
                                @RequestParam(name = "subject_id") String subjectId) {
        new DataContext(new ExcludeTeamSubjectQuery()).provide(new String[]{teamId, subjectId});
        return "redirect:/team?id=" + teamId;
    }

    @GetMapping("/remove_result_list")
    public String removeResultList(@RequestParam(name = "id") String teamId,
                                @RequestParam(name = "result_list_id") String resultListId) {
        new DataContext(new RemoveResultListQuery()).provide(resultListId);
        return "redirect:/team?id=" + teamId;
    }

}
