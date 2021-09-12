import java.util.function.UnaryOperator
import kotlin.math.abs
import kotlin.math.cos
import kotlin.math.sin

fun main() {
    //task1()
    //task2()
    //task3()
    //task4()
    //task5()
    task6()
}

fun task1() {
    var x: Double
    var y: Double
    print("Введите числа x и y через пробел: ")
    try {
        readLine()
            ?.split(" ")
            ?.map { it.toDouble() }
            .let {
                x = it!!.get(0)
                y = it.get(1)
                if (x <= -1) throw IllegalArgumentException()
                if (abs(y - 0.464233027) <= 0.000000001)  throw ArithmeticException()
            }
        println((1 + sin(x + 1)) / cos(12 * y - 4))
    } catch (e: ArithmeticException) {
        println("Деление на ноль!")
    } catch (e: IllegalArgumentException) {
        println("Вычисление корня из отрицательного числа!")
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность входных данных!")
    }
}

fun task2() {
    var r1: Double
    var r2: Double
    var r3: Double
    print("Введите числа R1, R2 и R3 через пробел: ")
    try {
        readLine()
            ?.split(" ")
            ?.map {
                if (it == "0") throw ArithmeticException()
                it.toDouble()
            }
            .let {
                r1 = it!!.get(0)
                r2 = it.get(1)
                r3 = it.get(2)
            }
        println(1 / (1 / r1 + 1 / r2 + 1 / r3))
    } catch (e: ArithmeticException) {
        println("Деление на ноль!")
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность входных данных!")
    }
}

fun task3() {
    print("Введите числа x, y и z через пробел: ")
    try {
        readLine()
            ?.split(" ")
            ?.map { it.toInt() }
            .let {
                if(it?.size!! > 3) throw IllegalArgumentException()
                val i = it?.filter { it % 3 == 0 }?.size
                if (i == 2) println("Только 2 числа кратны 3")
                else println("Условие, что только два числа кратны 3, не выполняется")
            }
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность входных данных!")
    } catch (e: IllegalArgumentException) {
        println("Недостаточность входных данных!")
    }
}

fun task4() {
    val months = arrayOf("Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
        "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь")
    val dayGetter = arrayOf(31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31)
        .map {
            if (it != 0)  UnaryOperator<Int> { year: Int -> it }
            else UnaryOperator<Int> {year: Int ->
                if(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) 29 else 28
            }
        }
    print("Введите номер месяца и год через пробел: ")
    try {
        readLine()
            ?.split(" ")
            ?.map { it.toInt() }
            .let {
                val month = it!!.get(0)
                val year = it.get(1)
                println("${months[month - 1]} $year года: ${dayGetter.get(month - 1).apply(year)} дней")
            }
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность входных данных!")
    }
}

fun task5() {
    var count = 0
    var sum = 0.0
    var predicate = true
    try {
        while (predicate) {
            print("Введите ${count + 1}-число (ноль прекратит ввод): ")
            predicate = readLine()?.toDouble().let { n ->
                if (n == 0.0) {
                    if (count == 0) throw ArithmeticException()
                    return@let false
                } else {
                    ++count
                    sum += n!!
                    return@let true
                }
            }
        }
        println("Среднее арифметическое введенных чисел: ${sum / count}")
    } catch (e: Exception) {
        println("Недостаточность входных данных!") // деление на ноль тем же обоснуется
    }
}

fun task6() {
    print("Введите число N: ")
    try {
        readLine()?.toInt().let { n ->
            var cosSum = 0.0
            var sinSum = 0.0
            var multiply = 1.0
            if (n!! < 1) throw IllegalArgumentException()
            for (i in 1..n) {
                cosSum += cos(i.toDouble())
                sinSum += sin(i.toDouble())
                multiply *= cosSum / sinSum
            }
            println("Ответ: $multiply")
        }
    } catch (e: IllegalArgumentException) {
        println("N не может быть меньше 1!")
    } catch (e: Exception) {
        println("Недостаточность входных данных!")
    }
}