import java.lang.Math.pow

fun main() {
    //task1()
    task2()
}

fun task1() {
    try {
        print("Введите x и n через пробел: ")
        readLine()?.split(" ")?.map { it.toDouble() }.let {
            val x = it!![0]
            val n = it[1].toInt()
            val x2 = x * x
            var result = 0.0
            var t = x
            var b = 1
            for (i in 1..n) {
                result += t / b
                t *= x2
                b += 2
            }
            println("Ответ: $result")
        }
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность данных!")
    }
}

fun task2() {
    try {
        print("Введите k и n через пробел: ")
        readLine()?.split(" ")?.map { it.toDouble() }.let {
            val k = it!![0]
            val n = it[1].toInt()
            if (k < 0 || n < 1) throw IllegalArgumentException()
            val f = { i: Int ->
                if(i > n) 0.0
                pow(k * i + f(i + 1), 0.5)
            }
            println("Ответ: ${f(1)}")
        }
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность данных!")
    } catch (e: IllegalArgumentException) {
        println("Нехорошие данные!")
    }
}