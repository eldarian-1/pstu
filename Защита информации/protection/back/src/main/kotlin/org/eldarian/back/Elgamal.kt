package org.eldarian.back

import java.math.BigInteger
import java.util.*

data class ElgamalResponse (
    val p: String,
    val g: String,
    val x: String,
    val y: String,
    val k: String,
) {
    constructor(
        p: BigInteger,
        g: BigInteger,
        x: BigInteger,
        y: BigInteger,
        k: BigInteger,
    ) : this(
        p.toString(),
        g.toString(),
        x.toString(),
        y.toString(),
        k.toString(),
    )
}

fun generateElgamal(): ElgamalResponse {
    val PK = 20
    val XG = 12
    val rnd = Random()
    val p = BigInteger.probablePrime(PK, rnd)

    var g: BigInteger
    var gcd: BigInteger
    do {
        g = BigInteger.probablePrime(XG, rnd)
        gcd = g.gcd(p)
    } while (gcd != BigInteger.ONE)

    val x = rand(rnd, XG, BigInteger.ONE, p - BigInteger.ONE)
    val y = g.modPow(x, p)
    val k = rand(rnd, PK, BigInteger.ONE, p - BigInteger.ONE)

    return ElgamalResponse(p, g, x, y, k)
}

fun rand(rnd: Random, bits: Int, low: BigInteger? = null, high: BigInteger? = null) : BigInteger {
    var result: BigInteger
    do {
        result = BigInteger(bits, rnd)
    } while((low == null || low < result) &&
        (high == null || result < high))
    return result
}