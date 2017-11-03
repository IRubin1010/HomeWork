using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5776_01_4485_5295
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("what question you whant to cheack?");
            Console.WriteLine("1 - question 1 the random array");
            Console.WriteLine("2 - question 2 the magic square");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    question1();
                    break;
                case 2:
                    question2();
                    break;
                default:
                    break;
            }
        }

        private static void question1()
        {
            Random rand = new Random();
            int[] array = new int[100];
            int num, choise;
            bool flag = false;
            for (int i = 0; i < 100; i++) //initialization the array with random number
                array[i] = rand.Next(0, 1000);
            //for (int i = 0; i < 100; i++)   //רק בשביל הבדיקה לולאה שמדפיסה את כל המערך 
            //    Console.WriteLine(" {0}", array[i]);
            Console.WriteLine("enter your choice: ");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Guess number");
            Console.WriteLine("2 - Guessing range number");
            choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 0: // Exit
                    Console.WriteLine("Good bye");
                    break;
                case 1:
                    Console.WriteLine("enter number: ");
                    num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < 100; i++) //loop on all array
                    {
                        if (array[i] == num) // cheak if the number euqal to array[index]
                        {
                            flag = true;
                            break; //if it euqal break the loop
                        }
                    }
                    if (flag)
                        Console.WriteLine("the number exsist in the array");
                    else
                        Console.WriteLine("the number dosn't exsist in the array");
                    break;
                case 2:
                    int num1, num2;
                    int bottomRange, upRange, count = 0;
                    Console.WriteLine("enter three number with ',' between them, two for range and one that you guess");
                    string numbers = Console.ReadLine(); //input the numbers to string
                    string[] arrNumber = numbers.Split(','); //split the string input to array
                    if (arrNumber.Length < 3) { Console.WriteLine("error input"); break; } //cheack if in the input have 3 var
                    if (!int.TryParse(numbers.Split(',')[0], out num1)) { Console.WriteLine("error input"); break; }// try to put the first var to num1
                    if (!int.TryParse(numbers.Split(',')[1], out num2)) { Console.WriteLine("error input"); break; }// try to put the secound var to num2
                    if (!int.TryParse(numbers.Split(',')[2], out num)) { Console.WriteLine("error input"); break; }// try to put the third var to num
                    bottomRange = Math.Min(num1, num2); //put the min number in "bottomRange" variable
                    upRange = Math.Max(num1, num2); ////put the max number in "upRange" variable
                    for (int i = 0; i < 100; i++) //loop on all array
                    {
                        if ((array[i] >= bottomRange) && (array[i] <= upRange)) //cheak that are in the range
                            count++; //count how many number is in rang 
                    }
                    if (count == num)
                        Console.WriteLine("you guess right :-)");
                    else
                        Console.WriteLine("you worng there is {0} number in this range", count);
                    break;
                default:
                    break;
            }
        }
        private static void question2()
        {
            int[,] magicSquare = new int[5, 5];
            Console.WriteLine("enter 5*5 numbers");
            for (int i = 0; i < 5; i++) // initialize the magicsquare
            {
                for (int j = 0; j < 5; j++)
                {
                    magicSquare[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int sumFirstRow = 0, sumRow = 0, sumColomn = 0, sumSlant = 0;
            bool flag = true;
            for (int i = 0; i < 5; i++) // sum the pirst row
            {
                sumFirstRow += magicSquare[0, i];
            }
            for (int i = 0; i < 5; i++) // check the rows and colomns
            {
                for (int j = 0; j < 5; j++)
                {
                    sumRow += magicSquare[i, j];
                    sumColomn += magicSquare[j, i];
                }
                if (sumRow != sumFirstRow || sumColomn != sumFirstRow)
                {
                    flag = false;
                    break;
                }
                sumRow = 0;
                sumColomn = 0;
            }
            for (int i = 0; i < 5; i++) // check the slant
            {
                sumSlant += magicSquare[i, i];
            }
            if (sumSlant != sumFirstRow)
            {
                flag = false;
            }
            sumSlant = 0;
            int k = 4;
            for (int i = 0; i < 4; i++) // chack the reverse diagonal
            {
                sumSlant += magicSquare[i, k];
                k--;
            }
            if (sumSlant != sumFirstRow)
            {
                flag = false;
            }
            if (flag == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

