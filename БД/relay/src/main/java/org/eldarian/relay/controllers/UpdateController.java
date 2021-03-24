package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.queries.select.item.*;
import org.eldarian.relay.queries.update.*;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class UpdateController extends AController {

    @PostMapping("/update_team")
    public String updateTeam(@RequestParam(name = "id") String team,
                             @RequestParam(name = "team_name") String name,
                             @RequestParam(name = "trainers") String trainers) {
        new DataContext(new UpdateTeamQuery()).provide(new String[]{team, name, trainers});
        return "redirect:/team?id=" + team;
    }

    @PostMapping("/update_player_name")
    public String updatePlayerName(@RequestParam(name = "id") String player,
                                   @RequestParam(name = "player_name") String name) {
        new DataContext(new RenamePlayerQuery()).provide(new String[]{player, name});
        return "redirect:/player?id=" + player;
    }

    @PostMapping("/update_player_team")
    public String updatePlayerTeam(@RequestParam(name = "id") String player,
                                   @RequestParam(name = "team_id") String team) {
        new DataContext(new ChangePlayerTeamQuery()).provide(new String[]{player, team});
        return "redirect:/player?id=" + player;
    }

    @GetMapping("/leave_player_team")
    public String leavePlayerTeam(@RequestParam(name = "id") String player,
                                   @RequestParam(name = "from", defaultValue = "") String from) {
        new DataContext(new ChangePlayerTeamQuery()).provide(new String[]{player, "NULL"});
        return "redirect:/" + (from.equals("") ? "player?id=" + player : from);
    }

    @PostMapping("/update_subject")
    public String updateSubject(@RequestParam(name = "id") String subject,
                                @RequestParam(name = "subject_name") String name,
                                @RequestParam(name = "subject_unit") String unit,
                                @RequestParam(name = "subject_multiplier") String multiplier) {
        new DataContext(new UpdateSubjectQuery()).provide(new String[]{subject, name, unit, multiplier});
        return "redirect:/subject?id=" + subject;
    }

    @PostMapping("/update_result")
    public String updateResult(@RequestParam(name = "result_list_id") String resultListId,
                                @RequestParam(name = "prev_player_id") String prevPlayerId,
                                @RequestParam(name = "next_player_id") String nextPlayerId,
                                @RequestParam(name = "prev_subject_id") String prevSubjectId,
                                @RequestParam(name = "next_subject_id") String nextSubjectId,
                                @RequestParam(name = "result_value") String resultValue) throws Exception {
        boolean resultIsExist = new DataContext(new ResultQuery())
                .provide(new String[]{resultListId, nextPlayerId, nextSubjectId}) != null;
        if(resultIsExist && (!nextPlayerId.equals(prevPlayerId) || !nextSubjectId.equals(prevSubjectId)))
            throw new Exception("Данный результат уже зафиксирован");
        new DataContext(new UpdateResultQuery()).provide(
                new String[]{resultListId, prevPlayerId, nextPlayerId, prevSubjectId, nextSubjectId, resultValue});
        return "redirect:/result_list?id=" + resultListId;
    }

    @GetMapping("/close_result_list")
    public String closeResultList(@RequestParam(name = "id") String resultListId) throws Exception {
        boolean isRelayTeam = (Boolean) new DataContext(new TeamParticipationQuery()).provide(resultListId);
        if(isRelayTeam) {
            int resultsCount = (Integer) new DataContext(new ResultsCountQuery()).provide(resultListId);
            int relayResultsCount = (Integer) new DataContext(new RelayResultsCountQuery()).provide(resultListId);
            if(resultsCount != relayResultsCount)
                throw new Exception("Данная команда не прошла все испытания");
        }
        new DataContext(new CloseResultListQuery()).provide(resultListId);
        return "redirect:/result_list?id=" + resultListId;
    }

    @GetMapping("/close_relay_race")
    public String closeRelayRace(@RequestParam(name = "id") String id) throws Exception {
        boolean isNotFinished = !(Boolean) new DataContext(new RelayIsFinishedQuery()).provide(id);
        if(isNotFinished)
            throw new Exception("Не все команды завершили эстафету");
        new DataContext(new CloseRelayRaceQuery()).provide(id);
        return "redirect:/relay_race?id=" + id;
    }

}
