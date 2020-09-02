using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Kino
{
    interface IKino
    {
        int moneyBet { get; set; }
        int numberOfDraws { get; set; }
        int totalEarnings { get; set; }
        int runADraw(Random randomNum, int menuNumber, int bet);
        void showDrawNumbers(List<int> allNumbers, List<int> oddNumbers, List<int> evenNumbers);
        int calculateEarnings(int menuNumber, List<int> oddNumbers, List<int> evenNumbers, int bet);

    }
    class Kino : IKino
    {
        public int[] bets = new int[] { 1, 2, 3, 5, 10, 15, 20, 30, 50, 100 };

        public int[] draws = new int[] { 1, 2, 3, 4, 5, 6, 10, 20, 50, 100, 200 };
        public int moneyBet { get; set; }
        public int numberOfDraws { get; set; }
        public int totalEarnings { get; set; }

        public void startOfGame(Random randomNum)
        {
            string answer;
            do
            {

                Console.WriteLine();
                Console.WriteLine("Where do you want to bet on? (Type a number)");
                Console.WriteLine("1. Odd numbers");
                Console.WriteLine("2. Even numbers");
                Console.WriteLine("3. Draw");
                Console.WriteLine();

                int menuNumber = playchecker();

                Console.WriteLine("How much money do you want to bet?");
                Console.WriteLine("1$, 2$, 3$, 5$, 10$, 15$, 20$, 30$, 50$, 100$");
                moneyBet = betcheker();
                Console.WriteLine();
                Console.WriteLine("How many games in a row do you want to play?");
                Console.WriteLine("1, 2, 3, 4, 5, 6, 10, 20, 50, 100, 200");
                numberOfDraws = drawchecker();
                int totalBet = moneyBet * numberOfDraws;
                Console.WriteLine();
                Console.WriteLine("Your total bet is {0}", totalBet);
                Console.WriteLine();
                int earnings = 0;
                for (int i = 1; i <= numberOfDraws; i++)
                {
                    earnings = runADraw(randomNum, menuNumber, moneyBet);
                    totalEarnings = totalEarnings + earnings;
                    Console.WriteLine("Press enter to continue");
                    Console.WriteLine();
                    Console.ReadKey();
                }

                if (numberOfDraws > 0)
                {
                    Console.WriteLine("Your total earnings are {0} $", totalEarnings);
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to play again?");
                Console.WriteLine();
                answer = yesOrNo();
                if (answer == "yes")
                    totalEarnings = 0;

            } while (answer == "yes");

            Console.ReadKey();
        }
        public int runADraw(Random randomNum, int menuNumber, int bet)
        {
            List<int> allNumbers = new List<int>();
            int number = randomNum.Next(1, 80);
            allNumbers.Add(number);
            while(allNumbers.Count() < 20)
            {
                number = randomNum.Next(1, 80);
                bool flag = false;
                for (int i = 0; i <= allNumbers.Count -1; i++)
                {
                    if (number == allNumbers[i])
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    allNumbers.Add(number);
                }
            }

            List<int> oddNumbers = new List<int>();
            List<int> evenNumbers = new List<int>();

            for (int i = 0; i <= allNumbers.Count - 1; i++)
            {
                if (allNumbers[i] % 2 == 1)
                {
                    oddNumbers.Add(allNumbers[i]);
                }
                else
                    evenNumbers.Add(allNumbers[i]);
            }
            showDrawNumbers(allNumbers, oddNumbers, evenNumbers);
            int earnings = calculateEarnings(menuNumber, oddNumbers, evenNumbers, bet);
            if (earnings > 0)
            {
                Console.WriteLine("You win {0} $ this round", earnings);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You didnt win this round");
                Console.WriteLine();
            }

            return earnings;
        }
        public void showDrawNumbers(List<int> allNumbers, List<int> oddNumbers, List<int> evenNumbers)
        {
            
            Console.WriteLine("Numbers have been drawn are:");
            for (int i = 0; i <= allNumbers.Count -1; i++)
            {
                Console.Write("{0} ", allNumbers[i]);               
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Odd numbers are:");
            for (int i = 0; i <= oddNumbers.Count - 1; i++)
            {
                Console.Write("{0} ", oddNumbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine("{0} in total", oddNumbers.Count);
            Console.WriteLine();
            Console.WriteLine("Even numbers are:");
            for (int i = 0; i <= evenNumbers.Count - 1; i++)
            {
                Console.Write("{0} ", evenNumbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine("{0} in total", evenNumbers.Count);
            Console.WriteLine();
        }
        public int calculateEarnings(int menuNumber, List<int> oddNumbers, List<int> evenNumbers, int bet)
        {
            int earnings = 0;
            if(menuNumber == 1)
            {
                if(oddNumbers.Count > evenNumbers.Count)
                {
                    earnings = bet * 2;
                }
            }
            else if(menuNumber == 2)
            {
                if(evenNumbers.Count > oddNumbers.Count)
                {
                    earnings = bet * 2;
                }
            }
            else
            {
                if(oddNumbers.Count == evenNumbers.Count)
                {
                    earnings = bet * 4;
                }
            }

            return earnings;
        }

        public int playchecker()
        {
            int number;
            string num = Console.ReadLine();
            bool flag = int.TryParse(num, out number);
            while(flag == false || ((number!= 1) && (number!=2) && (number!= 3)))
            {
                Console.WriteLine("Wrong ipnut, please try again");
                num = Console.ReadLine();
                flag = int.TryParse(num, out number);
            }
            return number;
        }

        public int betcheker()
        {
            int number;
            string num = Console.ReadLine();
            bool flag = int.TryParse(num, out number);
            bool exist = false;
            if (flag == true)
            {
                for (int i = 0; i <= bets.Length -1; i++)
                {
                    if (number == bets[i])
                    {
                        exist = true;
                    }
                }
            }

            while (flag == false || exist == false)
            {
                Console.WriteLine("Wrong ipnut, please try again");
                num = Console.ReadLine();
                flag = int.TryParse(num, out number);
                if (flag == true)
                {
                    for (int i = 0; i <= bets.Length - 1; i++)
                    {
                        if (number == bets[i])
                        {
                            exist = true;
                        }
                    }
                }
            }
            return number;
        }

        public int drawchecker()
        {
            int number;
            string num = Console.ReadLine();
            bool flag = int.TryParse(num, out number);
            bool exist = false;
            if (flag == true)
            {
                for (int i = 0; i <= draws.Length - 1; i++)
                {
                    if (number == draws[i])
                    {
                        exist = true;
                    }
                }
            }

            while (flag == false || exist == false)
            {
                Console.WriteLine("Wrong ipnut, please try again");
                num = Console.ReadLine();
                flag = int.TryParse(num, out number);
                if (flag == true)
                {
                    for (int i = 0; i <= draws.Length - 1; i++)
                    {
                        if (number == draws[i])
                        {
                            exist = true;
                        }
                    }
                }
            }
            return number;
        }

        public string yesOrNo()
        {
            string answer = Console.ReadLine();
            while (answer.ToLower() != "yes" && answer.ToLower() != "no")
            {
                Console.WriteLine("Wrong input, please try again");
                answer = Console.ReadLine();
                Console.WriteLine();
            }
            return answer.ToLower();
        }
    }
}
