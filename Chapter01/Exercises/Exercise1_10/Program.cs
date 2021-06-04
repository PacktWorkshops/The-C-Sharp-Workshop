using System;

int[] randomNumbers = { 123, 22, 53, 91, 787, 0, -23, 5 };

int[] sortedArray = BubbleSort(randomNumbers);

Console.WriteLine("Sorted:");

for (int i = 0; i < sortedArray.Length; i++)
{
    Console.Write(sortedArray[i] + " ");
}

static int[] BubbleSort(int[] array)
{
    int temp;

    // Iterate over the array
    for (int j = 0; j < array.Length - 1; j++)
    {
        // If the last j elements are already ordered, skip them
        for (int i = 0; i < array.Length - j - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                temp = array[i + 1];
                array[i + 1] = array[i];
                array[i] = temp;
            }
        }
    }

    return array;
}