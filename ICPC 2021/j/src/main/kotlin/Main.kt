import java.util.*

/*fun main() {
        val sc = Scanner(System.`in`)
        val n = sc.nextInt()
        val m = sc.nextInt()
        val u = IntArray(m) {0}
        val v = IntArray(m) {0}
        for(i in 0..m) {
                u[i] = sc.nextInt()
                v[i] = sc.nextInt()
        }
        val k = sc.nextInt()
        val h = IntArray(k) {0}
        for(i in 0..k) h[i] = sc.nextInt()

        print("Hello Eldar")
}**/

fun main() {
        val sc = Scanner(System.`in`)
        val n = sc.nextInt()
        val p = Array(n) { Triple(0, 0, 0) }
        for(i in 0 until n) p[i] = Triple(i, sc.nextInt(), sc.nextInt())
        var a = p.sortedWith(compareBy({ it.second }, { -it.third }))
        for(i in 0 until n) {
                var x = 1
                a = a.sortedBy { it.second * x + it.third }
                x = a[a.size - 1].second * x + a[a.size - 1].third
                a = a.
        }
        print(a.joinToString(separator=" ", postfix = "\n", transform = { (it.first + 1).toString() }))
}