// Вывод сообщения
var Alert = function(str){
	WScript.Echo(str)
}

// Клонирование массива список
var ArrayClone = function(arr){
	var result = []
	for(var i = 0, n = arr.length; i < n; ++i)
		result.push(arr(i))
	return result
}

// Конвертация списка строк в список чисел
var ConvertArray = function(arr){
	var result = ArrayClone(arr)
	for(var i = 0, n = result.length; i < n; ++i)
		result[i] = parseInt(result[i])
	return result
}

// Преобразование списка в строку вывода
var PrintArray = function(arr){
	var result = ""
	for(var i = 0, n = arr.length; i < n; ++i)
		result += arr[i] + " "
	return result
}

// 1 - Попарное частное от деления аргументов (1/2, 3/4, и т.д.)
var PairDivide = function(arr){
	var result = []
	for(var i = 0, n = arr.length; i < n; i += 2)
		if(i + 1 < n)
			result.push(arr[i] / arr[i + 1])
	return result
}

// 2 - Сумма четных аргументов
var SummEven = function(arr){
	var result = 0
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 1)
			result += arr[i]
	return result
}

// 3 - Максимальный четный аргумент
var MaxEven = function(arr){
	var max = arr[1]
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 1 && arr[i] > max)
			max = arr[i]
	return max
}

// 4 - Попарная разность аргументов (1-2, 3-4, и т.д.)
var PairDiff = function(arr){
	var result = []
	for(var i = 0, n = arr.length; i < n; i += 2)
		if(i + 1 < n)
			result.push(arr[i] - arr[i + 1])
	return result
}

// 5 - Сумма всех аргументов
var SummAll = function(arr){
	var result = 0
	for(var i = 0, n = arr.length; i < n; ++i)
		result += arr[i]
	return result
}

var Task1 = function(arr){
	return "1. Pair divide: " + PairDivide(arr)
}

var Task2 = function(arr){
	return "2. Summ even: " + SummEven(arr)
}

var Task3 = function(arr){
	return "3. Max even: " + MaxEven(arr)
}

var Task4 = function(arr){
	return "4. Pair difference: " + PairDiff(arr)
}

var Task5 = function(arr){
	return "5. Summ all: " + SummAll(arr)
}

var Main = function(arr){
	var result = ""
	arr = ConvertArray(arr)
	result += Task1(arr) + "\n"
	result += Task2(arr) + "\n"
	result += Task3(arr) + "\n"
	result += Task4(arr) + "\n"
	result += Task5(arr)
	Alert(result)
}

Main(WScript.arguments)