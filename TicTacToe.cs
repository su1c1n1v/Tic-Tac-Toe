using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        public static char[,] game = new char[3, 3];
        public static Boolean endGame = true;
        public static int count = 1;
        static void Main(string[] args)
        {
            Boolean playGame = true;
            char player = 'X';
            //showNormal();
            while (playGame)
            {
                if(endGame == true || count == 10)
                {
                    //Console.WriteLine("Press any key to play!");
                    //Console.Read();
                    resetGame();
                    count = 1;
                    endGame = false;
                }
                showGame();
                Boolean readingKey = true,test = true;
                string local;
                do
                {
                    do
                    {
                        Console.Write("Player({0}), Escolha o local:", player);
                        local = Console.ReadLine();
                        if (local.Length == 1)
                        {
                            //Console.WriteLine("Correto!");
                            readingKey = false;
                        }
                    } while (readingKey);
                    test = changePosition(char.Parse(local), player);
                    if(test == true)
                    {
                        Console.WriteLine("Please choice another position!");
                    }

                } while (test);
                if (player == 'X')
                {
                    player = 'O';
                }
                else
                {
                    player = 'X';
                }
            }
        }
        public static void seachingWinner()
        {
            for(int i = 0;i < 3; i++)
            {
                if (game[i, 0] == game[i, 1] && game[i, 1] == game[i, 2])
                {
                    showGame();
                    Console.WriteLine("Winner({0})", game[i, 0]);
                    endGame = true;
                    Console.WriteLine("Press any key to play!");
                    Console.Read();
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (game[0, i] == game[1, i] && game[1, i] == game[2, i])
                {
                    showGame();
                    Console.WriteLine("Winner({0})", game[0, i]);
                    endGame = true;
                    Console.WriteLine("Press any key to play!");
                    Console.Read();
                    return;
                }
            }
            if(game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2] || game[2, 0] == game[1, 1] && game[1, 1] == game[0, 2])
            {
                showGame();
                Console.WriteLine("Winner({0})", game[0, 0]);
                endGame = true;
                Console.WriteLine("Press any key to play!");
                Console.Read();
                return;
            }
        }
        public static Boolean changePosition(char position, char player)
        {
            int[] positionAux = new int[2];
            switch (position)
            {
                case '1':
                    positionAux[0] = 0;
                    positionAux[1] = 0;
                    break;
                case '2':
                    positionAux[0] = 0;
                    positionAux[1] = 1;
                    break;
                case '3':
                    positionAux[0] = 0;
                    positionAux[1] = 2;
                    break;
                case '4':
                    positionAux[0] = 1;
                    positionAux[1] = 0;
                    break;
                case '5':
                    positionAux[0] = 1;
                    positionAux[1] = 1;
                    break;
                case '6':
                    positionAux[0] = 1;
                    positionAux[1] = 2;
                    break;
                case '7':
                    positionAux[0] = 2;
                    positionAux[1] = 0;
                    break;
                case '8':
                    positionAux[0] = 2;
                    positionAux[1] = 1;
                    break;
                case '9':
                    positionAux[0] = 2;
                    positionAux[1] = 2;
                    break;
            }

            if(game[positionAux[0],positionAux[1]] == 'O' || game[positionAux[0], positionAux[1]] == 'X')
            {
                return true;
            }
            else
            {
                char anterior = game[positionAux[0], positionAux[1]];
                game[positionAux[0], positionAux[1]] = player;
                Console.WriteLine("Player({0}), Alteração( de {1} para {2})", player,anterior, game[positionAux[0], positionAux[1]]);
                count++;
                seachingWinner();
                return false;
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
