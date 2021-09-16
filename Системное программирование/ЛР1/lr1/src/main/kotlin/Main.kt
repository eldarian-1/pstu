import kotlin.math.ln

fun main() {
    //task1()
    //task2()
    //task3()
    task4()
}

fun task1() {
    print("Введите вещественные числа x, y, z через пробел: ")
    try {
        readLine()?.split(" ")?.map { it.toDouble() }.let { array ->
            val x = array!![0]
            val y = array[1]
            val z = array[2]
            if(z + 3 * x == 0.0 || ln(x) - z == 0.0) throw ArithmeticException()
            println("Ответ: ${(y - x) / (z + 3 * x) * (0.25 * x + y) / (ln(x) - z)}")
        }
    } catch(e: ArithmeticException) {
        println("Деление на ноль!")
    } catch (e: NumberFormatException) {
        println("Введено не число!")
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность ввода!")
    }
}

fun task2() {
    print("Введите вещественные числа a и b через пробел: ")
    try {
        readLine()?.split(" ")?.map { it.toDouble() }.let { array ->
            val a = array!![0]
            val b = array[1]
            if(a <= 0.0 || b <= 0.0) throw IllegalArgumentException()
            println("Ответ: ${
                if(a + b == 90.0) "Треугольник существует и является прямоугольным"
                else if(a + b >= 180.0) "Треугольник не существует"
                else "Треугольник существует и НЕ является прямоугольным"
            }")
        }
    } catch (e: NumberFormatException) {
        println("Введено не число!")
    } catch (e: IndexOutOfBoundsException) {
        println("Недостаточность ввода!")
    } catch(e: IllegalArgumentException) {
        println("Углы не могут быть отрицательными или равными нулю!")
    }
}

fun task3() {
    print("Введите целое число N: ")
    try {
        readLine()?.toInt().let {
            var isIncluded = false
            var n = it
            while(n != 0 && !isIncluded) {
                isIncluded = (n!! % 10) % 2 == 1
                n /= 10
            }
            println("Цифра ${if(isIncluded) "" else "НЕ "}входит в запись числа $it.")
        }
    } catch (e: NumberFormatException) {
        println("Введено не число!")
    }
}

fun task4() {
    print("Введите целое число N: ")
    try {
        readLine()?.toInt().let { n ->
            var result = 1.0
            if(n!! < 1) throw IllegalArgumentException()
            for(i in 1..n) {
                result *= 2.0 * i / (2 * i + 1)
            }
            println("$result")
        }
    } catch (e: NumberFormatException) {
        println("Введено не число!")
    } catch(e: IllegalArgumentException) {
        println("Исходные данные не верны!")
    }
}