package org.eldarian.back

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RequestParam
import org.springframework.web.bind.annotation.RestController

@SpringBootApplication
class BackApplication

fun main(args: Array<String>) {
    runApplication<BackApplication>(*args)
}

@RestController
class LController {
    @GetMapping("/rsa2")
    fun rsa2(@RequestBody request: RsaRequest): RsaResponse {
        return generate(request.bits)
    }

    @GetMapping("/rsa")
    fun rsa(@RequestParam(value = "cap", defaultValue = "16") bits: Int): RsaResponse {
        return generate(bits)
    }
}