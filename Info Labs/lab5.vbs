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

'1 задание - вычисление суммы четных элемента
function EvenSum(arr)
	dim index, item
	index = 0
	EvenSum = 0
	for each item in arr
		index = index + 1
		if index mod 2 = 0 then
			EvenSum = EvenSum + item
		end if
	next
end function

'определение минимума
function Min(left, right)
	if left < right then
		Min = left
	else
		Min = right
	end if
end function

'2 задание - получение массива минимумов в парах (мин(1,2),мин(3,4))
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

'3 задание - Сортировка пузырьком
function BubbleSort(arr)
	dim temp, result(), i, j, size
	
	size = 0
	for each i in arr
		size = size + 1
	next
	
	j = 0
	redim result(size)
	for each i in arr
		result(j) = i
		j = j + 1
	next
	
	for i = 0 to size
		for j = i to size
			if result(i) < result(j) then
				temp = result(i)
				result(i) = result(j)
				result(j) = temp
			end if
		next
	next
	
	BubbleSort = result
end function

'4 задание - поиск максимального нечетного элемента
function MaxNoEven(arr)
	dim index, item
	MaxNoEven = -32768
	index = 0
	for each item in arr
		if index mod 2 = 0 and MaxNoEven < item then
			MaxNoEven = item
		end if
		index = index + 1
	next
end function

'5 задание - получение массива попарных делений
function PairDevs(arr)
	dim item, index, str, temp
	str = ""
	for each item in arr
		if index mod 2 = 0 then
			temp = item
		else
			str = str & (temp \ item) & " "
		end if
		index = index + 1
	next
	PairDevs = str
end function

'Вывод 1 задания
function Task1(arr)
	Task1 = "1. Even arguments summ: " & EvenSum(arr)
end function

'Формирование строк для 2 или 5 задания
function Task2or5(start, arr)
	dim result, item
	result = start
	for each item in arr
		result = result & item & " "
	next
	Task2or5 = result
end function

'Вывод 2 задания
function Task2(arr)
	dim result
	result = PairMins(arr)
	Task2 = "2. Pair minimums: " & result
end function

'Вывод 3 задания
function Task3(arr)
	dim str, item, count, result
	result = BubbleSort(arr)
	str = "3. Sorted arr: "
	for each item in result
		str = str & item & " "
	next
	Task3 = str
end function

'Вывод 4 задания
function Task4(arr)
	Task4 = "4. Max no-even argument: " & MaxNoEven(arr)
end function

'Вывод 5 задания
function Task5(arr)
	dim result
	result = PairDevs(arr)
	Task5 = "5. Pair devides: " & result
end function

'Точка входа
sub Main(arr)
	dim iArr
	iArr = ConvertArray(arr)
	MsgBox Task1(iArr) & vbCrLf & Task2(iArr) & vbCrLf & Task3(iArr) & vbCrLf & Task4(iArr) & vbCrLf & Task5(iArr)
end sub

'Вход
Main(Wscript.Arguments)