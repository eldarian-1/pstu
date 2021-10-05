package org.eldarian.back

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

fun generateRsa(bits: Int): RsaResponse {
    val rnd = Random()
    var gcd: BigInteger
    val p = BigInteger.probablePrime(bits, rnd)
    var q: BigInteger
    var e: BigInteger

    do {
        q = BigInteger.probablePrime(bits, rnd)
    } while (p == q)

    val n: BigInteger = p.multiply(q)
    val phi: BigInteger = p.subtract(BigInteger.ONE).multiply(q.subtract(BigInteger.ONE))

    do {
        e = BigInteger.probablePrime(bits, rnd)
        gcd = e.gcd(phi)
    } while (gcd != BigInteger.ONE)

    val d: BigInteger

    var i = BigInteger.ONE
    while(true) {
        val top = i.multiply(phi).add(BigInteger.ONE)
        if(top > e && e / top.gcd(e) == BigInteger.ONE) {
            d = top.divide(e)
            break
        }
        ++i
    }

    return RsaResponse(p, q, n, e, d)
}