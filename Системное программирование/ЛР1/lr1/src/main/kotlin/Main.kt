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
            // Start(x1, x2, x3)
            val (x, y, z) = array!!
            // p(x1, x3)
            if(z + 3 * x == 0.0 || ln(x) - z == 0.0) {
                // Stop(a)
                throw ArithmeticException()
            }
            // y := f(x1, x2, x3)
            val f = (y - x) / (z + 3 * x) * (0.25 * x + y) / (ln(x) - z)
            // Stop(y)
            println("Ответ: $f")
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
            // Start(x1, x2)
            val (a, b) = array!!
            // p1(x1, x2)
            if(a <= 0.0 || b <= 0.0) {
                // Stop(a)
                throw IllegalArgumentException()
            }
            println("Ответ: ${
                // p2(x1, x2)
                if(a + b >= 180.0) {
                    // Stop(b)
                    "Треугольник не существует"
                }
                // p3(x1, x2)
                else if(a + b == 90.0 || a == 90.0 || b == 90.0) {
                    // Stop(c)
                    "Треугольник существует и является прямоугольным"
                } else {
                    // Stop(d)
                    "Треугольник существует и НЕ является прямоугольным"
                }
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
            // Start(x)
            var n = it
            // y := a
            var isIncluded = false
            // p1(x, y)
            while(n != 0 && !isIncluded) {
                // y := f1(x)
                isIncluded = (n!! % 10) % 2 == 1
                // x := f2(x)
                n /= 10
            }
            println("Цифра ${
                // p2(y)
                if(isIncluded) {
                    // Stop(b)
                    ""
                } else {
                    // Stop(c)
                    "НЕ "
                }
            }входит в запись числа $it.")
        }
    } catch (e: NumberFormatException) {
        println("Введено не число!")
    }
}

fun task4() {
    print("Введите целое число N: ")
    try {
        readLine()?.toInt().let { n -> // Start(x)
            // y1 := a
            var result = 1.0
            // p1(x, y1)
            if(n!! < 1) {
                // Stop(b)
                throw IllegalArgumentException()
            }
            // y2 := c // здесь y2 - i, c = 0
            // p2(y2)
            for(i in 1..n) {
                // y1 := f1(y1, y2)
                result *= 2.0 * i / (2 * i + 1)
                // y2 := f2(y2) // здесь y2 - i, f2(y2) - i++
                // Язык Kotlin сам выполняет инкремент
            }
            // Stop(y1)
            println("$result")
        }
    } catch (e: NumberFormatException) {
        println("Введено не число!")
    } catch(e: IllegalArgumentException) {
        println("Исходные данные не верны!")
    }
}