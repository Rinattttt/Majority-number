﻿using System;
using System.Linq;

class Program
/*
Концепция алгоритма нахождения мажоритарного числа основывается на принципе голосования, известном как алгоритм Бойера-Мура:
!Определение мажоритарного числа:
Мажоритарным считается число, которое встречается более чем в половине элементов массива.
1) Первый этап — поиск кандидата:
Алгоритм проходит по массиву и использует две переменные:
- candidate — предполагаемое мажоритарное число.
- count — счетчик, который отслеживает, сколько раз текущий candidate "голосует" за себя.

- Если count равен 0, текущий элемент становится новым кандидатом.
- Если текущий элемент совпадает с кандидатом, увеличиваем count.
- Если элемент не совпадает и count больше 0, уменьшаем count.

Этот этап позволяет определить потенциального кандидата без необходимости учета всех встречаемых чисел одновременно. Кандидат будет "выживать", если получает больше "голосов", чем теряет.

2) Второй этап — проверка кандидата:
После нахождения кандидата алгоритм делает второй проход по массиву, чтобы проверить, является ли кандидат действительно мажоритарным числом. Это делается путем подсчета, сколько раз кандидат встречается в массиве.

- Если кандидат встречается больше чем в половине элементов массива, он возвращается как результат.
- Если нет, возвращается значение, указывающее на отсутствие мажоритарного числа.
   */
{
    static void Main()
    {
        int size = 10000;// Константа 
        Random random = new Random();
        int[] numbers = new int[size];

        // Заполнение массива случайными числами от 0 до 1000
        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(0, 1001);
        }

        int majorityElement = FindMajorityElement(numbers);// В переменную вызывается метод, который принимает в качестве параметра массив и находит мажоритарное число

        if (majorityElement != -1)// Если значение не равно -1 (соотвествует условию нахорждения мажоритарного числа)
        {
            Console.WriteLine($"Мажоритарное число: {majorityElement}");// то мажоритарное число выводится на экран
        }
        else
        {
            Console.WriteLine("Мажоритарного числа нет.");// иначе выводится соответствующее сообщение об отсутствии такого числа
        }
    }

    static int FindMajorityElement(int[] nums)// Статический метод для поиска мажоритарного числа, который принимает в качестве параметра челочисленный массив
    {
        int candidate = -1; //Инициализация кандидата
        int count = 0;// Счетчик кандидатов

        // Первый этап: нахождение кандидата
        foreach (var num in nums) //Перебор элементов массива
        {
            if (count == 0) //Если счетчик нулевой
            {
                candidate = num; // то в кандидаты заносится такой элемент
                count = 1;// Счетчик увеличил значение на 1
            }
            else if (num == candidate) // Иначе же если элемент равен значению кандидата
            {
                count++;// Счетчик инкементируется
            }
            else// Иначе
            {
                count--;// счетчик декрементируется
            }
        }

        // Второй этап: проверка, является ли кандидат мажоритарным числом
        count = 0;// Инициализация счетчика
        foreach (var num in nums)// Перебор значений массива
        {
            if (num == candidate)// Если элемент удовлетворяет условию
            {
                count++;// то счетчик инкрементируется (подсчитывается количество равных значений)
            }
        }
        if (count > nums.Length / 2)// Если такие равные числа больше половины массива, то такое число можно считать МАЖОРИТАРНЫМ! 
        {
            return count;// Возврат этого самого значения
        }
        else { return -1; } // Иначе функция возвращает значение -1
        }
    }
