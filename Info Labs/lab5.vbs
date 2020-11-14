Option Explicit

'1 задание - вычисление суммы четных элемента
function EvenSum(array)
	dim index, item
	index = 0
	EvenSum = 0
	for each item in array
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
function PairMins(array)
	dim count, result(), i
	count = array.Count \ 2
	redim result(count)
	for i = 0 to count - 1
		result(i) = Min(array(i * 2), array(i * 2 + 1))
	next
	PairMins = result
end function

'Копирование массива
function CopyArray(array)
	dim result(), i
	redim result(array.Count)
	for i = 0 to array.Count - 1
		result(i) = array(i)
	next
	CopyArray = result
end function

'3 задание - Сортировка пузырьком
function BubbleSort(array)
	dim temp, result, i, j
	result = CopyArray(array)
	for i = 0 to array.Count
		for j = i + 1 to array.Count
			if result(i) > result(j) then
				temp = result(i)
				result(i) = result(j)
				result(j) = temp
			end if
		next
	next
	BubbleSort = result
end function

'4 задание - поиск максимального нечетного элемента
function MaxNoEven(array)
	dim i
	MaxNoEven = array(0)
	for i = 2 to array.Count step 2
		if MaxNoEven < array(i) then
			MaxNoEven = array(i)
		end if
	next
end function

'5 задание - получение массива попарных делений
function PairDevs(array)
	dim count, result(), i
	count = array.Count \ 2
	redim result(count)
	for i = 0 to count - 1
		result(i) = array(i * 2) \ array(i * 2 + 1)
	next
	PairDevs = result
end function

'Вывод 1 задания
sub Task1(array)
	MsgBox "1. Even arguments summ: " & EvenSum(array)
end sub

'Формирование строк для 2 или 5 задания
function Task2or5(start, array)
	dim result, item
	result = start
	for each item in array
		result = result & item & " "
	next
	Task2or5 = result
end function

'Вывод 2 задания
sub Task2(array)
	array = PairMins(array)
	MsgBox Task2or5("2. Pair minimums: ", array)
end sub

'Вывод 3 задания
sub Task3(array)
	dim str, i, count
	array = BubbleSort(array)
	count = array.Count
	str = "3. Sorted array: "
	for i = count to 0 step -1
		str = str & array(i) & " "
	next
	MsgBox str
end sub

'Вывод 4 задания
sub Task4(array)
	MsgBox "4. Max no-even argument: " & MaxNoEven(array)
end sub

'Вывод 5 задания
sub Task5(array)
	array = PairDevs(array)
	MsgBox Task2or5("5. Pair devides: ", array)
end sub

'Точка входа
sub Main(array)
	Task1(array)
	Task2(array)
	Task3(array)
	Task4(array)
	Task5(array)
end sub

'Вход
Main(Wscript.Arguments)