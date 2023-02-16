// See https://aka.ms/new-console-template for more information
// string[] names; // может ссылаться на любой массив строк
// объявление размера массива
string[] names = new string[4]; 
// хранение элементов с индексами позиций
names[0] = "Kate";
names[1] = "Jack";
names[2] = "Rebecca";
names[3] = "Tom";
// перебираем имена
for (int i = 0; i < names.Length; i++)
{
 // прочитать элемент с данным индексом позиции
 Console.WriteLine(names[i]);
}