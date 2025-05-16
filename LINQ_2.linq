<Query Kind="Statements">
  <RuntimeVersion>9.0</RuntimeVersion>
</Query>

string[] cities = { "Amsterdam", "Berlin", "New York", "Rome", "Athens", "Napoli", "Neapolis", "Newark", "Oslo", "London" };


var allCities = from c in cities select c;
allCities.Dump("Весь масив міст");


int length = 6;
var citiesByLength = from c in cities where c.Length == length select c;
citiesByLength.Dump($"Міста з довжиною назви {length}");


var startsWithA = from c in cities where c.StartsWith("A") select c;
startsWithA.Dump("Починаються з A");


var endsWithM = from c in cities where c.EndsWith("m") || c.EndsWith("M") select c;
endsWithM.Dump("Закінчуються на M");

var startNEndK = from c in cities where c.StartsWith("N") && c.EndsWith("K") select c;
startNEndK.Dump("Починаються з N і закінчуються на K");


var startsWithNeDesc = (from c in cities where c.StartsWith("Ne") orderby c descending select c);
startsWithNeDesc.Dump("Починаються з Ne (за спаданням)");
