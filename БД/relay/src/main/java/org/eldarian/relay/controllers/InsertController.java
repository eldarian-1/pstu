package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.queries.insert.*;
import org.eldarian.relay.queries.select.item.OpenedResultListQuery;
import org.eldarian.relay.queries.select.item.RelaySubjectQuery;
import org.eldarian.relay.queries.select.item.ResultQuery;
import org.eldarian.relay.queries.select.item.TeamSubjectQuery;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
public class InsertController extends AController {

    @PostMapping("/insert_team")
    public String insertTeam(@RequestParam(name = "team_name") String teamName,
                             @RequestParam(name = "trainers") String trainers) {
        int id = (Integer)new DataContext(new AddTeamQuery()).provide(new String[]{teamName, trainers});
        return "redirect:/team?id=" + id;
    }

    @PostMapping("/insert_player")
    public String insertPlayer(@RequestParam(name = "player_name") String name,
                               @RequestParam(name = "team_id") String team) {
        int id = (Integer)new DataContext(new AddPlayerQuery()).provide(new String[]{name, team});
        return "redirect:/player?id=" + id;
    }

    @PostMapping("/insert_subject")
    public String insertSubject(@RequestParam(name = "subject_name") String name,
                                @RequestParam(name = "subject_unit") String unit,
                                @RequestParam(name = "subject_multiplier") String multiplier) {
        int id = (Integer)new DataContext(new AddSubjectQuery()).provide(new String[]{name, unit, multiplier});
        return "redirect:/subject?id=" + id;
    }

    @PostMapping("/insert_team_subject")
    public String insertTeamSubject(@RequestParam(name = "id") String teamId,
                                    @RequestParam(name = "subject_id") String subjectId) throws Exception {
        boolean subjectIsTeam = new DataContext(new TeamSubjectQuery())
                .provide(new String[]{teamId, subjectId}) != null;
        if(subjectIsTeam)
            throw new Exception("Команда уже тренерует данную дисциплину");
        new DataContext(new AddTeamSubjectQuery()).provide(new String[]{teamId, subjectId});
        return "redirect:/team?id=" + teamId;
    }

    @GetMapping("/start_workout")
    public String addWorkout(@RequestParam(name = "id") String teamId) throws Exception {
        boolean teamIsBusy = new DataContext(new OpenedResultListQuery()).provide(teamId) == null;
        if(teamIsBusy)
            throw new Exception("Команда уже занята");
        int id = (Integer)new DataContext(new AddResultListQuery()).provide(teamId);
        return "redirect:/result_list?id=" + id;
    }

    @PostMapping("/insert_relay_race")
    public String insertRelayRace(@RequestParam(name = "relay_name") String relayName,
                                  @RequestParam(name = "team_number") String teamNumber,
                                  @RequestParam(name = "player_number") String playerNumber) {
        int id = (Integer)new DataContext(new AddRelayRaceQuery())
                .provide(new String[]{relayName, teamNumber, playerNumber});
        return "redirect:/relay_race?id=" + id;
    }

    @PostMapping("/insert_relay_team")
    public String insertRelayTeam(@RequestParam(name = "id") String relayId,
                                  @RequestParam(name = "team_id") String teamId) throws Exception {
        boolean teamIsBusy = new DataContext(new OpenedResultListQuery()).provide(teamId) == null;
        if(teamIsBusy)
            throw new Exception("Команда уже занята");
        new DataContext(new AddRelayTeamQuery()).provide(new String[]{relayId, teamId});
        return "redirect:/relay_race?id=" + relayId;
    }

    @PostMapping("/insert_relay_subject")
    public String insertRelaySubject(@RequestParam(name = "id") String relayId,
                                     @RequestParam(name = "subject_id") String subjectId) throws Exception {
        boolean subjectIsRelay = new DataContext(new RelaySubjectQuery())
                .provide(new String[]{relayId, subjectId}) != null;
        if(subjectIsRelay)
            throw new Exception("Эстафета уже включает данную дисциплину");
        new DataContext(new AddRelaySubjectQuery()).provide(new String[]{relayId, subjectId});
        return "redirect:/relay_race?id=" + relayId;
    }

    @PostMapping("/insert_result")
    public String insertResult(@RequestParam(name = "id") String resultListId,
                               @RequestParam(name = "subject_id") String subjectId,
                               @RequestParam(name = "player_id") String playerId,
                               @RequestParam(name = "result_value") String resultValue) throws Exception {
        boolean resultIsExist = new DataContext(new ResultQuery())
                .provide(new String[]{resultListId, playerId, subjectId}) != null;
        if(resultIsExist)
            throw new Exception("Данный результат уже зафиксирован");
        new DataContext(new AddResultQuery())
                .provide(new String[]{resultListId, subjectId, playerId, resultValue});
        return "redirect:/result_list?id=" + resultListId;
    }

}
