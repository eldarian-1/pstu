package org.eldarian.relay.controllers;

import org.eldarian.relay.DataContext;
import org.eldarian.relay.entities.*;
import org.eldarian.relay.queries.select.item.*;
import org.eldarian.relay.queries.select.list.*;
import org.eldarian.relay.queries.update.CloseResultListQuery;
import org.springframework.ui.Model;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.Collection;

@Controller
public class EditController {

    @GetMapping("/edit_team")
    public String editTeam(@RequestParam(name = "id") String id, Model model) {
        Team team = (Team)(new DataContext(new TeamQuery()).provide(id));
        model.addAttribute("team", team);
        return "edition/edit_team";
    }

    @GetMapping("/rename_player")
    public String renamePlayer(@RequestParam(name = "id") String id, Model model) {
        Player player = (Player)(new DataContext(new PlayerQuery()).provide(id));
        model.addAttribute("player", player);
        return "edition/rename_player";
    }

    @GetMapping("/change_player_team")
    public String changePlayerTeam(@RequestParam(name = "id") String id, Model model) {
        Player player = (Player)(new DataContext(new PlayerQuery()).provide(id));
        Collection<Team> teams = (Collection<Team>)(new DataContext(new TeamListQuery()).provide(null));
        model.addAttribute("player", player);
        model.addAttribute("teams", teams);
        return "edition/change_player_team";
    }

    @GetMapping("/edit_subject")
    public String editSubject(@RequestParam(name = "id") String id, Model model) {
        Subject subject = (Subject)(new DataContext(new SubjectQuery()).provide(id));
        model.addAttribute("subject", subject);
        return "edition/edit_subject";
    }

    @GetMapping("/close_result_list")
    public String closeResultList(@RequestParam(name = "id") String id) {
        new DataContext(new CloseResultListQuery()).provide(id);
        return "redirect:/team?id=" + id;
    }

    @GetMapping("/edit_workout")
    public String editWorkout() {
        return "edition/add_workout";
    }

    @GetMapping("/edit_relay_race")
    public String editRelayRace() {
        return "edition/add_relay_race";
    }

}
