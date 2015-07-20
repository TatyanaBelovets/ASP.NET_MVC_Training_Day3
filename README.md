##1. Ознакомиться с материалами

Эквивалентность значений и ссылочная эквивалентость.

Дж. Рихтер CLR via C# Глава 4. Основы типов. Глава 5. Примитивные, ссылочные и значимые типы.

[Essential .NET, Volume 1: The Common Language Runtime (Chapter 3-6)] (http://stage.reflectsoftware.com/Others/Essential.NET,%20Volume%201%20The%20Common%20Language%20Runtime.pdf)

[О вреде изменяемых значимых типов](http://habrahabr.ru/post/124404/)

[StringBuilder прошлое и настоящее](http://habrahabr.ru/post/172689/)

[Кэширование объектов StringBuilder](http://sergeyteplyakov.blogspot.com/2015/04/cache-for-stringbuilder-objects.html)

##2. Составить сравнительную таблицу 
для значимых и ссылчных типов согласно пунктам: определение, возможность наследования, копирование, размещение в памяти, жизненный цикл, инициализация, особености работы с методами  класса Object и операциями проверки на равенство и неравенство, особенности при работе с массивами, особенности передачи параметров в функции по значению и т.д.

##3. Выполнить сравнение string.join vs stringbuilder.append  vs …
	
##Задание 1.

•	Разработать класс «многочлен» для работы с многочленами от одной переменной вещественного типа (в качестве внутренней стркутуры для хранения коэффициетов использовать sz-массив). 

•	Перегрузить для класса операции, допустимые для работы с многочленами.

•	Разработать unit-тесты для тестирования разработанных методов.
