package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class ErrorController extends AController {

    @GetMapping("/404")
    public String notFound(Model model) {
        model.addAttribute("exception", "Данная страница не существует...");
        return "general/exception";
    }
}
