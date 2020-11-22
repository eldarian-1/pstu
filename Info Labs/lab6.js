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

// Клонирование списка в список
var ListClone = function(arr){
	var result = []
	for(var i = 0, n = arr.length; i < n; ++i)
		result.push(arr[i])
	return result
}

// Конвертация списка строк в список чисел
var ConvertArray = function(arr){
	var result = ArrayClone(arr)
	for(var i = 0, n = result.length; i < n; ++i)
		result[i] = parseInt(result[i])
	return result
}

// Сумма нечетных аргументов
var SummOdd = function(arr){
	var result = 0;
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 0)
			result += arr[i]
	return result
}

// Максимальный четный аргумент
var MaxEven = function(arr){
	var max = arr[1];
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 1 && arr[i] > max)
			max = arr[i]
	return max
}

// Максимальный аргумент
var MaxItem = function(arr){
	var max = arr[0];
	for(var i = 0, n = arr.length; i < n; ++i)
		if(arr[i] > max)
			max = arr[i]
	return max
}

// Минимальный четный аргумент
var MinEven = function(arr){
	var min = arr[1];
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 1 && arr[i] < min)
			min = arr[i]
	return min
}

// Сортировка списка
var Sorting = function(arr){
	var temp, result = ListClone(arr);
	for(var i = 0, n = result.length; i < n; ++i)
		for(var j = i; j < n; ++j)
			if(result[i] > result[j]){
				temp = result[i]
				result[i] = result[j]
				result[j] = temp
			}
	return result
}

// Отсортированные четные аргументы
var SortEven = function(arr){
	var temp = Sorting(arr)
	var result = ""
	for(var i = 0, n = temp.length; i < n; ++i)
		if(i % 2 == 1)
			result += temp[i] + " "
	return result
}

var Task1 = function(arr){
	return "1. Summ odd: " + SummOdd(arr)
}

var Task2 = function(arr){
	return "2. Max even: " + MaxEven(arr)
}

var Task3 = function(arr){
	return "3. Max item: " + MaxItem(arr)
}

var Task4 = function(arr){
	return "4. Min even: " + MinEven(arr)
}

var Task5 = function(arr){
	return "5. Sorted even: " + SortEven(arr)
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