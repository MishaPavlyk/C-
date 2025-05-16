<Query Kind="Statements" />


string[] words = { "apple", "banana", "kiwi", "strawberry", "fig", "melon" };


var sortedAsc = words.OrderBy(w => w.Length);
sortedAsc.Dump("Сортування за зростанням довжини");


var sortedDesc = words.OrderByDescending(w => w.Length);
sortedDesc.Dump("Сортування за спаданням довжини");
