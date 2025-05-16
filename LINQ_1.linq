<Query Kind="Statements" />

int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 14, 21, 28, 32, 56 };

// Весь масив
var all = from n in numbers select n;
all.Dump();


var even = from n in numbers where n % 2 == 0 select n;
even.Dump();


var odd = from n in numbers where n % 2 != 0 select n;
odd.Dump();


int threshold = 10;
var greater = from n in numbers where n > threshold select n;
greater.Dump();


int min = 10, max = 30;
var range = from n in numbers where n >= min && n <= max select n;
range.Dump();


var divisibleBy7 = from n in numbers where n % 7 == 0 orderby n select n;
divisibleBy7.Dump();


var divisibleBy8 = from n in numbers where n % 8 == 0 orderby n descending select n;
divisibleBy8.Dump();
