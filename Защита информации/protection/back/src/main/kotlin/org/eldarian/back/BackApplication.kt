package org.eldarian.back

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RequestParam
import org.springframework.web.bind.annotation.RestController

@SpringBootApplication
class BackApplication

fun main(args: Array<String>) {
    runApplication<BackApplication>(*args)
}

data class Person(val name: String, val age: Int)

@RestController
class MyController {
    @GetMapping("/")
    fun main(
        @RequestParam(value = "name", defaultValue = "Eldarian") name: String,
        @RequestParam(value = "age", defaultValue = "24") age: String,
    ): Person? {
        return Person(name, age.toInt())
    }
}