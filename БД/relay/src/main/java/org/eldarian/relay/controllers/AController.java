package org.eldarian.relay.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ExceptionHandler;

@Controller
public abstract class AController {
    @ExceptionHandler(Exception.class)
    public String handleException(Exception e, Model model) {
        model.addAttribute("exception", e.getMessage());
        return "general/exception";
    }
}
