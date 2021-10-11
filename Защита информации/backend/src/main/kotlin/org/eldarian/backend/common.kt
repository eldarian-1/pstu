package org.eldarian.backend

import java.math.BigInteger
import java.util.*

data class RsaResponse (
    val p: String,
    val q: String,
    val n: String,
    val e: String,
    val d: String,
) {
    constructor(
        p: BigInteger,
        q: BigInteger,
        n: BigInteger,
        e: BigInteger,
        d: BigInteger,
    ) : this(
        p.toString(),
        q.toString(),
        n.toString(),
        e.toString(),
        d.toString(),
    )
}

data class ElgamalResponse (
    val p: String,
    val g: String,
    val x: String,
    val y: String,
    val k: String,
    val k_1: String,
) {
    constructor(
        p: BigInteger,
        g: BigInteger,
        x: BigInteger,
        y: BigInteger,
        k: BigInteger,
        k_1: BigInteger,
    ) : this(
        p.toString(),
        g.toString(),
        x.toString(),
        y.toString(),
        k.toString(),
        k_1.toString(),
    )
}

data class DesResponse (val key: String) {
    constructor(key: BigInteger) : this(key.toString())
}

fun generateRsa(bits: Int): RsaResponse {
    val rnd = Random()
    val p = BigInteger.probablePrime(bits, rnd)
    val q = rand(rnd, bits, true) { it == p }
    val n = p.multiply(q)
    val phi = p.subtract(BigInteger.ONE).multiply(q.subtract(BigInteger.ONE))
    val e = phi.coprime(rnd, bits)
    val d = e.multiplicative(phi)
    return RsaResponse(p, q, n, e, d)
}

fun generateElgamal(): ElgamalResponse {
    val PK = 20
    val XG = 12
    val rnd = Random()
    val p = BigInteger.probablePrime(PK, rnd)
    val g = p.coprime(rnd, XG);
    val x = randBetween(rnd, XG, false, BigInteger.ONE, p)
    val y = g.modPow(x, p)
    val k = randBetween(rnd, PK, false, BigInteger.ONE, p - BigInteger.ONE)
    val k_1 = k.multiplicative(p - BigInteger.ONE)
    return ElgamalResponse(p, g, x, y, k, k_1)
}

fun randBetween(rnd: Random, bits: Int, prime: Boolean, low: BigInteger? = null, high: BigInteger? = null) : BigInteger {
    return rand(rnd, bits, prime) { (low == null || low < it) && (high == null || it < high) }
}

fun rand(rnd: Random, bits: Int, prime: Boolean, f: (BigInteger) -> Boolean): BigInteger {
    var result: BigInteger
    do {
        if(prime) {
            result = BigInteger.probablePrime(bits, rnd)
        } else {
            result = BigInteger(bits, rnd)
        }
    } while(f(result))
    return result
}

fun BigInteger.coprime(rnd: Random, bits: Int): BigInteger {
    var r: BigInteger
    var gcd: BigInteger
    do {
        r = BigInteger.probablePrime(bits, rnd)
        gcd = this.gcd(r)
    } while (gcd != BigInteger.ONE)
    return r
}

fun BigInteger.multiplicative(mod: BigInteger): BigInteger {
    val r: BigInteger
    var i = BigInteger.ONE
    while(true) {
        val top = i.multiply(mod).add(BigInteger.ONE)
        if(top > this && this / top.gcd(this) == BigInteger.ONE) {
            r = top.divide(this)
            break
        }
        ++i
    }
    return r
}