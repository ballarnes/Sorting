using System;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] array = new int [10];

            Console.WriteLine("New array:");

            for (int i = 0; i < array.Length; i++)
            {
                array [i] = new Random().Next(1, 100);
                Console.Write($"{array [i]} ");
            }

            SelectionSort(array);
            Console.WriteLine("\nSelection Sort:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array [i]} ");
            }

            Console.WriteLine("\nNew array:");

            for (int i = 0; i < array.Length; i++)
            {
                array [i] = new Random().Next(1, 100);
                Console.Write($"{array [i]} ");
            }

            MergeSort(array);
            Console.WriteLine("\nMerge Sort:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array [i]} ");
            }
        }

        static void SelectionSort(int [] array)
        {
            // объявление переменной для хранения индекса минимального элемента
            var min = 0;

            // проходим по всему массиву
            for (var i = 0; i < array.Length - 1; i++)
            {
                // допустим что текущий элемент в цикле минимальный
                min = i;

                // в цикле сверяем его с каждым из последующих элементов массива (ищем следующий минимальный элемент)
                for (var j = i + 1; j < array.Length; j++)
                {
                    // если найденный элемент меньше min, то присваиваем индексу min новое значение
                    if (array [j] < array [min])
                    {
                        min = j;
                    }
                }

                // если был найден элемент меньше выбранного, то производим перестановку
                if (min != i)
                {
                    var temp = array [i];
                    array [i] = array [min];
                    array [min] = temp;
                }
            }
        }

        static void MergeSort(int [] array)
        {
            // если массив состоит из 1 элемента, то прекращаем деление
            if (array.Length < 2)
            {
                return;
            }

            // переменная для хранения длины половины массива
            var midPoint = array.Length / 2;

            // создаем два подмассива из половин основного
            int [] left = new int [midPoint];
            int [] right = new int [array.Length - midPoint];

            // перемещаем элементы из основного массива в подмассивы
            for (var i = 0; i < midPoint; i++)
            {
                left [i] = array [i];
            }

            for (var i = midPoint; i < array.Length; i++)
            {
                right [i - midPoint] = array [i];
            }

            // продолжаем делить массив
            MergeSort(left);
            MergeSort(right);

            // запускаем сортировку
            Merge(array, left, right);
        }

        static void Merge(int [] targetArray, int [] firstArray, int [] secondArray)
        {
            // объявляем переменные индексов массивов
            var firstArrayMinIndex = 0;
            var secondArrayMinIndex = 0;

            // объявляем переменную индекса массива для вставки
            var targetArrayMinIndex = 0;

            while (firstArrayMinIndex < firstArray.Length && secondArrayMinIndex < secondArray.Length)
            {
                // сравниваем два полученных массива (из одного элемента)
                if (firstArray [firstArrayMinIndex] <= secondArray [secondArrayMinIndex])
                {
                    // отдаем в готовый массив меньший элемент
                    targetArray [targetArrayMinIndex] = firstArray [firstArrayMinIndex];

                    // перемещаем индекс минимального элемента на 1
                    firstArrayMinIndex++;
                }
                else
                {
                    // отдаем в готовый массив меньший элемент
                    targetArray[targetArrayMinIndex] = secondArray [secondArrayMinIndex];

                    // перемещаем индекс минимального элемента на 1
                    secondArrayMinIndex++;
                }

                // перемещаем индекс для вставки на 1
                targetArrayMinIndex++;
            }

            // если в массиве остались числа, то мы перемещаем их в массив для вставки
            while (firstArrayMinIndex < firstArray.Length)
            {
                targetArray[targetArrayMinIndex] = firstArray[firstArrayMinIndex];
                firstArrayMinIndex++;
                targetArrayMinIndex++;
            }

            while (secondArrayMinIndex < secondArray.Length)
            {
                targetArray[targetArrayMinIndex] = secondArray[secondArrayMinIndex];
                secondArrayMinIndex++;
                targetArrayMinIndex++;
            }
        }
    }
}