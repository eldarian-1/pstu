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

@RestController
class LController {
    @GetMapping("/rsa")
    fun rsa(@RequestParam(value = "cap", defaultValue = "16") bits: Int): RsaResponse {
        return generateRsa(bits)
    }
    @GetMapping("/elgamal")
    fun elgamal(): ElgamalResponse {
        return elgamal()
    }
}