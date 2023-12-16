// See https://aka.ms/new-console-template for more information


using Demo;

var island = new string[5, 5]
{
    {"X", "X", "O", "O", "O"},
    {"X", "x", "O", "O", "O"},
    {"O", "O", "0", "X", "X"},
    {"X", "X", "O", "O", "X"},
    {"X", "X", "O", "O", "O"}
};
//pattern visitor
var map = new Map();
map.PopulateMap(island,5,5);
var islands = map.CalculateIslands();
Console.WriteLine($"Number of islands in the maps are : {islands}");
 