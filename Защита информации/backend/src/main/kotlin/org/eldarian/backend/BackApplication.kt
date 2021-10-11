package org.eldarian.backend

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RequestParam
import org.springframework.web.bind.annotation.RestController
import java.math.BigInteger
import java.util.*

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
        return generateElgamal()
    }
    @GetMapping("/des")
    fun des(): DesResponse {
        return DesResponse(BigInteger.probablePrime(32, Random()))
    }
}