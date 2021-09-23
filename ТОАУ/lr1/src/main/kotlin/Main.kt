fun main() {
    print("Введите числа R, K, x, A, B, C, D через пробел")
    readLine()?.split(" ")?.map { it.toDouble() }.let {
        val R = it!![0].toInt()
        val K = it[1]
        val x = it[2]
        val A = it[3]
        val B = it[4]
        val C = it[5]
        val D = it[6]
        if(R == 1) {

        } else if(R == 2) {

        } else {
            throw Exception()
        }
    }
}