var ConvertArray = function(arr){
	var result = arr.slice(0, 3)
	for(var i = 0, n = arr.length; i < n; ++i){
		result(i) = parseInt(arr(i), 10)
		WScript.Echo(result(i))
	}
	return result
}

var SummEven = function(arr){
	var result = 0;
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 0)
			result += arr(i)
	return result
}

var MaxEven = function(arr){
	var max = 0;
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 0 && arr(i) > max)
			max = arr(i)
	return max
}

var MaxItem = function(arr){
	var max = 0;
	for(var i = 0, n = arr.length; i < n; ++i)
		if(arr(i) > max)
			max = arr(i)
	return max
}

var MinEven = function(arr){
	var min = 0;
	for(var i = 0, n = arr.length; i < n; ++i)
		if(i % 2 == 0 && arr(i) < min)
			min = arr(i)
	return min
}

var ArrayClone = function(arr){
	return arr.slice(0, arr.length)
}

var Sorting = function(arr){
	var temp, result = ArrayClone(arr);
	for(var i = 0, n = result.length; i < n; ++i)
		for(var j = i; j < n; ++j)
			if(result(i) < result(j)){
				temp = result(i)
				result(i) = result(j)
				result(j) = temp
			}
	return result
}

var SortEven = function(arr){
	var temp = Sorting(arr)
	var result = ""
	for(var i = 0, n = temp.length; i < n; ++i)
		if(i % 2 == 0)
			result += temp(i) + " "
	return result
}

var Alert = function(str){
	WScript.Echo(str)
}

var Task1 = function(arr){
	return "1. Summ even: " + SummEven(arr)
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
	ConvertArray(arr)
	var result = ""
	result += Task1(arr) + "\n"
	result += Task2(arr) + "\n"
	result += Task3(arr) + "\n"
	result += Task4(arr) + "\n"
	result += Task5(arr)
	Alert(result)
}

Main(WScript.arguments)