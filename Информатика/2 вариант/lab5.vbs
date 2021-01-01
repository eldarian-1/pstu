Option Explicit

'Конвертация массива строк в массив чисел
function ConvertArray(arr)
	dim i
	redim result(arr.Count - 1)
	for i = 0 to arr.Count - 1
		result(i) = CInt(arr(i))
	next
	ConvertArray = result
end function

'Размер массива
function SizeArr(arr)
	dim item
	SizeArr = 0
	for each item in arr
		SizeArr = SizeArr + 1
	next
end function

'Дублирование массива
function Duplication(arr)
	dim i, item
	redim result(SizeArr(arr))
	i = 0
	for each item in arr
		result(i) = item
		i = i + 1
	next
	Duplication = result
end function

'Сортировка пузырьком
function BubbleSort(arr)
	dim temp, i, j, size
	size = SizeArr(arr)
	arr = Duplication(arr)
	
	for i = 0 to size
		for j = i to size
			if arr(i) < arr(j) then
				temp = arr(i)
				arr(i) = arr(j)
				arr(j) = temp
			end if
		next
	next
	
	BubbleSort = arr
end function

'Формирование массива нечетных аргументов
function OddArguments(arr)
	dim temp, result(), i, j, k, size
	
	j = 0
	size = 0
	for each i in arr
		if j mod 2 = 0 then
			size = size + 1
		end if
		j = j + 1
	next
	
	j = 0
	k = 0
	redim result(size - 1)
	for each i in arr
		if k mod 2 = 0 then
			result(j) = arr(k)
			j = j + 1
		end if
		k = k + 1
	next
	
	OddArguments = result
end function

'определение минимума среди двух аргументов
function Min(left, right)
	if left < right then
		Min = left
	else
		Min = right
	end if
end function

'поиск минимума в массиве
function MinArg(arr)
	dim item
	MinArg = 32767
	for each item in arr
		if MinArg > item then
			MinArg = item
		end if
	next
end function

'Формирование строки вывода массива
function PrintArray(start, arr)
	dim result, item
	result = start
	for each item in arr
		result = result & item & " "
	next
	PrintArray = result
end function

'1 задание - вычисление произведения аргументов
function Multiplication(arr)
	dim item
	Multiplication = 1
	for each item in arr
		Multiplication = Multiplication * item
	next
end function

'2 задание - вывести нечетные аргументы по убыванию
function OddDescending(arr)
	OddDescending = BubbleSort(OddArguments(arr))
end function

'3 задание - получение массива минимумов в парах (мин(1,2),мин(3,4))
function PairMins(arr)
	dim temp, item, index, str
	index = 0
	str = ""
	for each item in arr
		if index mod 2 = 0 then
			temp = item
		else
			str = str & Min(temp, item) & " "
		end if
		index = index + 1
	next
	PairMins = str
end function

'4 задание - поиск максимального нечетного элемента
function MaxArg(arr)
	dim item
	MaxArg = -32768
	for each item in arr
		if MaxArg < item then
			MaxArg = item
		end if
	next
end function

'5 задание - минимальный нечетный аргумент
function MinOdd(arr)
	MinOdd = MinArg(OddArguments(arr))
end function

'Вывод 1 задания
function Task1(arr)
	Task1 = "1. Multiplication of arguments: " & Multiplication(arr)
end function

'Вывод 2 задания
function Task2(arr)
	Task2 = PrintArray("2. Odd descending: ", OddDescending(arr))
end function

'Вывод 3 задания
function Task3(arr)
	Task3 = "3. Pair minimums: " & PairMins(arr)
end function

'Вывод 4 задания
function Task4(arr)
	Task4 = "4. Max arg: " & MaxArg(arr)
end function

'Вывод 5 задания
function Task5(arr)
	Task5 = "5. Min odd arg: " & MinOdd(arr)
end function

'Точка входа
sub Main(arr)
	dim iArr
	iArr = ConvertArray(arr)
	MsgBox Task1(iArr) & vbCrLf & Task2(iArr) & vbCrLf & Task3(iArr) & vbCrLf & Task4(iArr) & vbCrLf & Task5(iArr)
end sub

'Вход
Main(Wscript.Arguments)