using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
             
            public static void GameField(string[] M) 
            {
                const string horiz = " +----+----+----+";
                const string vert = " |  ";
                Console.WriteLine(horiz);
                Console.WriteLine($"{vert}{M[0]}{vert}{M[1]}{vert}{M[2]}{vert}");
                Console.WriteLine(horiz);
                Console.WriteLine($"{vert}{M[3]}{vert}{M[4]}{vert}{M[5]}{vert}");
                Console.WriteLine(horiz);
                Console.WriteLine($"{vert}{M[6]}{vert}{M[7]}{vert}{M[8]}{vert}");
                Console.WriteLine(horiz);

             }

        public static bool DeterminWinner(string Zero, string[] M, bool Game, int turn) 
            {
                const string X = "X";
                const string O = "O";
                string p="";
                string[] plrs = { "X", "O" };
               
                int player, number;
                string s = " ";
                bool flag = true;
                player = (turn % 2) + 1;
                    if (player == 1)  p = X;
                    else if (player == 2) p = O;
            
                do
                {
               
                    try
                     {
                    
                        Console.Write("Игрок " +  p + " выберите клетку от 0 до 8:"); 
                        s = Console.ReadLine();
                        number = Convert.ToInt32(s);
                        if ((s.Length == 1) && (number >= 0) && (number <= 8))
                        {
                            if (M[number] == Zero)
                            {
                                if (player == 1)
                                    M[number] = X;
                                else M[number] = O;
                                flag = false;
                            }
                            else Console.WriteLine("Ошибка! Выбранная клетка занята");
                        }
                        else Console.WriteLine("Ошибка! Выберите клетку от 0 до 8");
                }
                
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка! Введите номер клетки: цифру от 0 до 8");
                    }
                
            }
                while (flag);

                Game = (Zero != M[0]) && (M[0] == M[1]) && (M[1] == M[2]) || //Проверка
                       (Zero != M[3]) && (M[3] == M[4]) && (M[4] == M[5]) ||
                       (Zero != M[6]) && (M[6] == M[7]) && (M[7] == M[8]) ||
                       (Zero != M[0]) && (M[0] == M[3]) && (M[3] == M[6]) ||
                       (Zero != M[1]) && (M[1] == M[4]) && (M[4] == M[7]) ||
                       (Zero != M[2]) && (M[2] == M[5]) && (M[5] == M[8]) ||
                       (Zero != M[0]) && (M[0] == M[4]) && (M[4] == M[8]) ||
                       (Zero != M[2]) && (M[2] == M[4]) && (M[4] == M[6]);

                GameField(M); 
                if (Game)
                    Console.WriteLine("Победил игрок " + p);
                else if (turn == 8)
                {
                    Game = true;
                    Console.WriteLine("Ничья");
                }
                return Game;
            }
            static void Main(string[] args)
            {
                const string zero = " ";
                string[] Field = new string[9];
                int turn = 0;
                bool game = false;
                
            
                    for (int i = 0; i < 9; i++)
                    {
                        Field[i] = zero;
                    }

                GameField(Field);
                while (game == false)
                {
                    game = DeterminWinner(zero, Field, game, turn);
                    turn += 1;
                }
                Console.ReadKey();
            }
        
    }


}
