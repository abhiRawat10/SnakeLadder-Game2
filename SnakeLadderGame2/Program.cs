using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Snake Ladder Game Press any key to play");
            Console.ReadKey();

            int[,] board = new int[10, 10];

            //putting snakes
            board[9, 8] = -1;
            board[7, 2] = -1;
            board[5, 4] = -1;
            board[3, 1] = -1;
            board[2, 3] = -1;

            //putting ladders
            board[8, 1] = 1;
            board[6, 5] = 1;
            board[5, 3] = 1;
            board[3, 4] = 1;
            board[1, 1] = 1;

            int player1Position = 0;
            int player2Position = 0;

            int currentPlayer = 1;

            while (player1Position < 100 && player2Position < 100)
            {
                Console.WriteLine("\n");
                Console.WriteLine(currentPlayer == 1 ? "Player 1 turn" : "Player 2 turn");


                Console.WriteLine("Click to Roll the dice...");
                Console.ReadKey();
                int diceValue = rollDice();
                Console.WriteLine("Dice value is: " + diceValue);

                Console.WriteLine("Press any key to move \n");
                Console.ReadKey();

                if (currentPlayer == 1)
                {
                    //moving player 1
                    if (player1Position + diceValue > 100)
                    {
                        currentPlayer = 2;
                        Console.WriteLine();
                        Console.WriteLine("You need lesser value");
                        continue;
                    }
                    player1Position += diceValue;
                    if (player1Position == 100) break;

                    int i = getRow(player1Position);
                    int j = getColumn(player1Position);

                    //checking if there is snake or ladder
                    //if (board[i, j] != 0)
                    //{
                    //    if (board[i, j] < 0) Console.WriteLine("Snake");
                    //    else Console.WriteLine("Ladder");

                    //    player1Position += board[i, j];
                    //}

                    if (board[i,j]==-1)//means snake
                    {
                        Console.WriteLine("Snake");
                        player1Position -= 2 * diceValue;
                        if(player1Position < 0) player1Position = 0; //handling negative position
                    }
                    else if (board[i,j] == 1)//means ladder
                    {
                        Console.WriteLine("Ladder, You got another turn");
                        if(player1Position+diceValue<=100)player1Position +=  diceValue;
                        if (player1Position == 100) break;
                        Console.WriteLine("Player 1 position: " + player1Position);
                        continue;
                    }
                    

                    Console.WriteLine("Player 1 position: " + player1Position);
                    currentPlayer = 2;
                }
                else
                {
                    //moving player 2
                    if (player2Position + diceValue > 100)
                    {
                        currentPlayer = 1;
                        Console.WriteLine();
                        Console.WriteLine("You need lesser value");

                        continue;
                    }
                    player2Position += diceValue;
                    if (player2Position == 100) break;
                    int i = getRow(player2Position);
                    int j = getColumn(player2Position);

                    //checking if there is snake or ladder
                    if(board[i, j] == -1)//means snake
                    {
                        Console.WriteLine("Snake");
                        player2Position -= 2 * diceValue;
                        if (player2Position < 0) player2Position = 0; //handling negative position
                    }
                    else if (board[i, j] == 1)//means ladder
                    {
                        Console.WriteLine("Ladder, you got another turn");
                        if (player2Position + diceValue <= 100) player2Position += diceValue;
                        if (player2Position == 100) break;
                        Console.WriteLine("Player 2 position: " + player2Position);
                        continue;
                    }

                    Console.WriteLine("Player 2 position: " + player2Position);
                    currentPlayer = 1;
                }

            }//while loop ends here






            if (player1Position == 100)
            {
                Console.WriteLine();
                Console.WriteLine("Player 1 won the game");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Player 2 won the game");
            }
        }



        public static int rollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public static int getRow(int position)
        {
            return position / 10;
        }

        public static int getColumn(int position)
        {
            return position % 10;
        }
    }
}
