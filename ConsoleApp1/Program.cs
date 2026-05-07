// See https://aka.ms/new-console-template for more information




using System;
using System.Numerics;
using System.Text;
using ConsoleApp1.Streams;


string a = "hello";
string b = "he" + "llo";
string c = string.Concat("he", "llo");

var cache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

Console.WriteLine(object.ReferenceEquals(a, b));
Console.WriteLine(object.ReferenceEquals(a, c));

var streamAPI = new StreamsAPI();
//streamAPI.GetEmployeeCountByCity();
//streamAPI.GetEmployeesByCity();