using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        public static char[,] game = new char[3, 3];
        static void Main(string[] args)
        {
            Boolean playGame = true;
            char player = 'X';
            resetGame();
            //showNormal();
            showGame();
            while(playGame)
            {

                Boolean readingKey = true;
                do
                {
                    Console.Write("Player({0}), Escolha o local:",player);
                    string local = Console.ReadLine();
                    if(local.Length == 1)
                    {
                        Console.WriteLine("Correto!");
                        readingKey = false;
                        if(player == 'X')
                        {
                            player = 'O';
                        }
                        else
                        {
                            player = 'X';
                        }
                    }
                } while (readingKey);
            }
        }
        public static Boolean changePosition(int position, char player)
        {
            char positionAux = 'N';
            switch (position)
            {
                case 1:
                    positionAux = game[0, 0];
                    break;
                case 2:
                    positionAux = game[0, 1];
                    break;
                case 3:
                    positionAux = game[0, 2];
                    break;
                case 4:
                    positionAux = game[1, 0];
                    break;
                case 5:
                    positionAux = game[1, 1];
                    break;
                case 6:
                    positionAux = game[1, 2];
                    break;
                case 7:
                    positionAux = game[2, 0];
                    break;
                case 8:
                    positionAux = game[2, 1];
                    break;
                case 9:
                    positionAux = game[2, 2];
                    break;
                default:
                    // code block
                    break;
            }

            if(positionAux == 'O' && positionAux == 'X')
            {
                return false;
            }
            else
            {
                positionAux = player;
                Console.WriteLine("Alteração({0})", positionAux);
                return true;
            }
        }
        public static void resetGame()
        {
            int count = 49;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    game[i, j] = Convert.ToChar(count);
                    count++;
                }
            }
        }
        public static void showNormal()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(game[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static void showGame()
        {
            int countX = 0, countY;
            for (int i = 0; i < 9; i++)
            {
                countY = 0;
                for (int j = 0; j < 17; j++)
                {
                    Boolean X = i == 1 || i == 4 || i == 7,
                            Y = j == 2 || j == 8 || j == 14;
                    if (X && Y)
                    {
                        Console.Write(game[countX, countY]);
                        countY++;
                    }
                    else if (j == 5 || j == 11)
                    {
                        Console.Write('|');
                    }
                    else if (i == 2 || i == 5)
                    {
                        Console.Write('_');
                    }
                    else 
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
                if (i == 1 || i == 4 || i == 7) 
                {
                    countX++;
                }
            }
            Console.WriteLine();
        }
    }
}
