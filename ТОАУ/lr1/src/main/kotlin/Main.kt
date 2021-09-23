fun main() {
    try {
        print("Введите тариф (1 - первый, 2 - второй): ")
        val r = readLine()
            ?.toInt()
            .takeIf { it == 1 || it == 2 }
            ?: throw Exception("Некорректный тариф!")
        print("Введите числа K, x, %s через пробел: ".format(if(r == 1) "A, B" else "C, D"))
        val s = (readLine() ?: throw Exception("Некорректный ввод!"))
            .split(" ")
            .map { it.toDouble() }
            .takeIf { it.size == 4 }
            ?.let {
                val K = it[0]
                val x = it[1]
                val t1 = it[2]
                val t2 = it[3]
                if(r == 1) {
                    if(x < K)  t1 else  t1 + (x - K) * t2
                } else {
                    if(x <= K) t1 * x else t2 * x
                }
            } ?: throw Exception("Некорректные данные!")
        println("Сумма к оплате: $s")
    } catch (e: Exception) {
        println(e.message)
    }
}