using System.Drawing;

namespace Tic_Tac_Toe_Project {
    internal class Program {
        static void Main(string[] args) {

            //PrintColor("               TIC-TAC-TOE GAME!!!                      ", ConsoleColor.Blue);
           

            char player1 = 'x';
            char player2 = 'o';
            int playerXcoor = 100;
            int playerYcoor = 100;
            bool player1Turn = true;
            bool IsGame = false;
            string entry = "";
            char[,] board = { { '\0', '\0', '\0' } , { '\0', '\0', '\0' } , { '\0', '\0', '\0' } };
            int gameCount = 0;
            bool playAgain = false;
            bool isTie = false;


            Print("Welcome To Tic-Tac-Toe!");
            Print("Rules: First Player To Place Three Of Their Symbol In A Row, Column, or Diagonally, Wins The Game! Let's Play!");
            Print("Player 1 is X and Player 2 is O");
            bool space = true;

            do {
                Print("SPACE to start!");
                space = InputSpace("");
                if (space) {
                    IsGame = true;
                    Console.Clear();
                    DrawBoard();
                } 
            } while (!space);



            do {

                //When Players Want To Play Again
                if (playAgain == true) {

                   if(isTie == false) {
                        PrintColor("Winner Goes First!", ConsoleColor.Green);
                        space = InputSpace("press SPACE to start!");
                        GameReset(board);
                   } else if (isTie){
                        PrintColor("Tie! Player ones turn!", ConsoleColor.Red);
                        space = InputSpace("press SPACE to start!");
                        isTie = false;
                        GameReset(board);
                   }//end if

                   if (space) {
                        IsGame = true;
                        Console.Clear();
                        DrawBoard();
                        playAgain = false;
                   }//end if
                }//end if 

                //Player 1 Turn
                if (player1Turn == true) {

                    Console.Clear();
                    DrawSymbols(board);


                    do {
                        Console.Clear();
                        DrawSymbols(board);
                        //get coordinates from string
                        do {
                            Console.Clear();
                            DrawSymbols(board);
                            Console.SetCursorPosition(0, 16);
                            Print("Player 1's Turn");
                            entry = Input("enter x and y coordinates: (X Y): "); 
                        } while (entry.Length != 3);
                        Console.WriteLine();
                        playerXcoor = xCoor(entry);
                        playerYcoor = yCoor(entry);  
                    } while ((playerXcoor < 0 || playerXcoor > 2) || (playerYcoor < 0 || playerYcoor > 2));
                    
                    //if space empy draw symbol
                    if (PlaceMaker(board, player2, playerXcoor, playerYcoor) == false && PlaceMaker(board, player1, playerXcoor, playerYcoor) == false) {
                        DrawSymbol(player1, playerXcoor, playerYcoor);
                        gameCount++;
                    } else {
                        do {

                            do {
                                //set board/cursor
                                Console.Clear();
                                DrawSymbols(board);
                                Console.SetCursorPosition(0, 16);
                                //error message
                                //prompt for coordinates while in range of grid
                                do {
                                    Console.Clear();
                                    DrawSymbols(board);
                                    Console.SetCursorPosition(0, 16);
                                    Print("The Space Is Already Used Try Again.");
                                    entry = Input("enter x and y coordinates: (X Y): ");
                                } while (entry.Length != 3);
                                Console.WriteLine();
                                playerXcoor = xCoor(entry);
                                playerYcoor = yCoor(entry);
                                //
                            } while ((playerXcoor < 0 || playerXcoor > 2) || (playerYcoor < 0 || playerYcoor > 2));
                        } while (PlaceMaker(board, player1, playerXcoor, playerYcoor) == true || PlaceMaker(board, player2, playerXcoor, playerYcoor) == true);
                        
                    }//end if

                    for (int xPos = 0; xPos < board.GetLength(0); xPos++) {

                        for (int yPos = 0; yPos < board.GetLength(1); yPos++) {
                            if (playerXcoor == 0 && playerYcoor == 0) {

                                if (player1Turn == true) {
                                    board[0, 0] = 'x';
                                } else if (player1Turn == false) {
                                    board[0, 0] = 'o';
                                }//end if

                            } else if (playerXcoor == 1 && playerYcoor == 0) {

                                if (player1Turn == true) {
                                    board[1, 0] = 'x';
                                } else if (player1Turn == false) {
                                    board[1, 0] = 'o';
                                }//end if

                            } else if (playerXcoor == 2 && playerYcoor == 0) {

                                if (player1Turn == true) {
                                    board[2, 0] = 'x';
                                } else if (player1Turn == false) {
                                    board[2, 0] = 'o';
                                }//end if

                            } else if (playerXcoor == 0 && playerYcoor == 1) {

                                if (player1Turn == true) {
                                    board[0, 1] = 'x';
                                } else if (player1Turn == false) {
                                    board[0, 1] = 'o';
                                }//end if

                            } else if (playerXcoor == 1 && playerYcoor == 1) {

                                if (player1Turn == true) {
                                    board[1, 1] = 'x';
                                } else if (player1Turn == false) {
                                    board[1, 1] = 'o';
                                }//end if

                            } else if (playerXcoor == 2 && playerYcoor == 1) {

                                if (player1Turn == true) {
                                    board[2, 1] = 'x';
                                } else if (player1Turn == false) {
                                    board[2, 1] = 'o';
                                }//end if

                            } else if (playerXcoor == 0 && playerYcoor == 2) {

                                if (player1Turn == true) {
                                    board[0, 2] = 'x';
                                } else if (player1Turn == false) {
                                    board[0, 2] = 'o';
                                }//end if

                            } else if (playerXcoor == 1 && playerYcoor == 2) {

                                if (player1Turn == true) {
                                    board[1, 2] = 'x';
                                } else if (player1Turn == false) {
                                    board[1, 2] = 'o';
                                }//end if

                            } else if (playerXcoor == 2 && playerYcoor == 2) {

                                if (player1Turn == true) {
                                    board[2, 2] = 'x';
                                } else if (player1Turn == false) {
                                    board[2, 2] = 'o';
                                }//end if

                            }//end if


                        }//end for



                    }//end for

                    if (winCheck(board) == 1) {
                        Console.Clear();
                        DrawSymbols(board);
                        Console.SetCursorPosition(0, 16);
                        PrintColor("Congratulations!! Player 1 Wins The Game. ", ConsoleColor.Green);
                        IsGame = false;
                    } else if (winCheck(board) == 2) {
                        Console.Clear();
                        DrawSymbols(board);
                        Console.SetCursorPosition(0, 16);
                        PrintColor("Congratulations!! Player 2 Wins The Game. ", ConsoleColor.Green);
                        IsGame = false;

                    }//end if

                    

                    if (winCheck(board) == 0) {
                        DrawSymbols(board);
                        player1Turn = false;
                    }//end if

                }//end if

                //When Game Is A Tie
                
                if (IsTie(board, gameCount)) {
                    Console.Clear();
                    DrawSymbols(board);
                    Console.SetCursorPosition(0, 16);
                    PrintColor("Oh No! You Have Reached A Tie!", ConsoleColor.Red);
                    IsGame = false;
                    player1Turn = true;
                    isTie = true;
                    gameCount = 0;
                }//end if


                //Player 2 Turn
                if (player1Turn == false) {


                    do {
                        Console.Clear();
                        DrawSymbols(board);
                        Console.SetCursorPosition(0, 16);
                        Print("Player 2's Turn");
                        //get coordinates from string
                        do {
                            Console.Clear();
                            DrawSymbols(board);
                            Console.SetCursorPosition(0, 16);
                            Print("Player 2's Turn");
                            entry = Input("enter x and y coordinates: (X Y): ");
                        } while (entry.Length != 3);
                        Console.WriteLine();
                        playerXcoor = xCoor(entry);
                        playerYcoor = yCoor(entry);
                    } while ((playerXcoor < 0 || playerXcoor > 2) || (playerYcoor < 0 || playerYcoor > 2));

                    if (PlaceMaker(board, player1, playerXcoor, playerYcoor) == false && PlaceMaker(board, player2, playerXcoor, playerYcoor) == false) {
                        DrawSymbol(player2, playerXcoor, playerYcoor);
                        gameCount++;
                    } else {
                        //If The Space Is Taken
                        do {

                            do {
                                //set board/cursor
                                Console.Clear();
                                DrawSymbols(board);
                                Console.SetCursorPosition(0, 16);
                                //error message
                                //prompt for coordinates while in range of grid
                                do {
                                    Console.Clear();
                                    DrawSymbols(board);
                                    Console.SetCursorPosition(0, 16);
                                    Print("The Space Is Already Used Try Again.");
                                    entry = Input("enter x and y coordinates: (X Y): ");
                                } while (entry.Length != 3);
                                Console.WriteLine();
                                playerXcoor = xCoor(entry);
                                playerYcoor = yCoor(entry);
                                //
                            } while ((playerXcoor < 0 || playerXcoor > 2) || (playerYcoor < 0 || playerYcoor > 2));
                        } while (PlaceMaker(board, player1, playerXcoor, playerYcoor) == true || PlaceMaker(board, player2, playerXcoor, playerYcoor) == true);
                    }//end if

                    for (int xPos = 0; xPos < board.GetLength(0); xPos++) {

                        for (int yPos = 0; yPos < board.GetLength(1); yPos++) {
                            if (playerXcoor == 0 && playerYcoor == 0) {

                                if (player1Turn == true) {
                                    board[0, 0] = 'x';
                                } else if (player1Turn == false) {
                                    board[0, 0] = 'o';
                                }//end if

                            } else if (playerXcoor == 1 && playerYcoor == 0) {

                                if (player1Turn == true) {
                                    board[1, 0] = 'x';
                                } else if (player1Turn == false) {
                                    board[1, 0] = 'o';
                                }//end if

                            } else if (playerXcoor == 2 && playerYcoor == 0) {

                                if (player1Turn == true) {
                                    board[2, 0] = 'x';
                                } else if (player1Turn == false) {
                                    board[2, 0] = 'o';
                                }//end if

                            } else if (playerXcoor == 0 && playerYcoor == 1) {

                                if (player1Turn == true) {
                                    board[0, 1] = 'x';
                                } else if (player1Turn == false) {
                                    board[0, 1] = 'o';
                                }//end if

                            } else if (playerXcoor == 1 && playerYcoor == 1) {

                                if (player1Turn == true) {
                                    board[1, 1] = 'x';
                                } else if (player1Turn == false) {
                                    board[1, 1] = 'o';
                                }//end if

                            } else if (playerXcoor == 2 && playerYcoor == 1) {

                                if (player1Turn == true) {
                                    board[2, 1] = 'x';
                                } else if (player1Turn == false) {
                                    board[2, 1] = 'o';
                                }//end if

                            } else if (playerXcoor == 0 && playerYcoor == 2) {

                                if (player1Turn == true) {
                                    board[0, 2] = 'x';
                                } else if (player1Turn == false) {
                                    board[0, 2] = 'o';
                                }//end if

                            } else if (playerXcoor == 1 && playerYcoor == 2) {

                                if (player1Turn == true) {
                                    board[1, 2] = 'x';
                                } else if (player1Turn == false) {
                                    board[1, 2] = 'o';
                                }//end if

                            } else if (playerXcoor == 2 && playerYcoor == 2) {

                                if (player1Turn == true) {
                                    board[2, 2] = 'x';
                                } else if (player1Turn == false) {
                                    board[2, 2] = 'o';
                                }//end if

                            }//end if


                        }//end for




                    }//end for

                    //Checking For Wins
                    if (winCheck(board) == 1) {
                        Console.Clear();
                        DrawSymbols(board);
                        Console.SetCursorPosition(0, 16);
                        PrintColor("Congratulations!! Player 1 Wins The Game. ", ConsoleColor.Green);
                        IsGame = false;
                    } else if (winCheck(board) == 2) {
                        Console.Clear();
                        DrawSymbols(board);
                        Console.SetCursorPosition(0, 16);
                        PrintColor("Congratulations!! Player 2 Wins The Game. ", ConsoleColor.Green);
                        IsGame = false;

                    }//end if

                   

                    if (winCheck(board) == 0) {
                       player1Turn = true;
                    }//end if

                    

                    if (player1Turn == true) {
                        Console.Clear();
                        DrawSymbols(board);
                    }//end if
                }//end if

                //When Game Is A Tie
                if (IsTie(board, gameCount)) {
                    Console.Clear();
                    DrawSymbols(board);
                    Console.SetCursorPosition(0, 16);
                    PrintColor("Oh No! You Have Reached A Tie!", ConsoleColor.Red);
                    IsGame = false;
                    player1Turn = false;
                    isTie = true;
                    gameCount = 0;
                }//end if

                //Play Again?
                if (IsGame == false) {


                    Console.SetCursorPosition(0, 18);
                    playAgain = Input("Thanks For Playing Tic-Tac-Toe! Would You Like To Play Again? (y/n): ").ToUpper() == "Y";

                    if(playAgain == true) {

                        IsGame = true;
                        
                        gameCount = 0;

                        if(winCheck(board) == 1) {
                            player1Turn = true;
                        }else if (winCheck(board) == 2) {
                            player1Turn = false;
                        }//end if 
                        GameReset(board);
                    } else {
                        Console.Clear();
                        Console.SetCursorPosition(0, 18);
                        PrintColor("Thanks For Playing! The End ", ConsoleColor.Green);

                    }//end if

                }//end if

            } while (IsGame == true);





        }//end main

        static void DrawBoard() {

            byte[] color = { 255, 255, 225 };
            char[,]board = new char[16, 16];

            for (int xPos = 0; xPos < board.GetLength(0); xPos++) {
                for (int yPos = 0; yPos < board.GetLength(1); yPos++) {

                    if (xPos == 5) {

                        ConsoleSetBlock(xPos, yPos, color);

                    }//end if
                    if (xPos == 11) {

                        ConsoleSetBlock(xPos, yPos, color);

                    }//end if
                    
                    if (yPos == 5) {

                        ConsoleSetBlock(xPos, yPos, color);

                    }//end if
                    if (yPos == 11) {

                        ConsoleSetBlock(xPos, yPos, color);

                    }//end if
                    
                    Console.WriteLine();

                }//end for
            }//end for


        }//end function

        static void DrawSymbols(char[,] board) { 
        
            DrawBoard();

            for (int xPos = 0; xPos < board.GetLength(0); xPos++) {
                for (int yPos = 0; yPos < board.GetLength(1); yPos++) {

                    if (board[xPos, yPos] == 'x') {

                        DrawSymbol('x', xPos, yPos);
                    } else if (board[xPos, yPos] == 'o') {

                        DrawSymbol('o', xPos, yPos);
                    }//end if

                }//end for

            }//end for 


            

        }//end function

        static void DrawSymbol(char symbol, int xPosition, int yPosition) {

            if (xPosition == 0 && yPosition == 0) {

                if (symbol == 'x') {
                    XSymbol(1, 1);
                }
                if (symbol == 'o') {
                    OSymbol(1, 1);
                }//end if
                
            } else if (xPosition == 1 && yPosition == 0) {

                if (symbol == 'x') {
                    XSymbol(7, 1);
                }
                if (symbol == 'o') {
                    OSymbol(7, 1);
                }//end if

            } else if (xPosition == 2 && yPosition == 0) {

                if (symbol == 'x') {
                    XSymbol(13, 1);
                }
                if (symbol == 'o') {
                    OSymbol(13, 1);
                }//end if

            }else if (xPosition == 0 && yPosition == 1) {

                if (symbol == 'x') {
                    XSymbol(1, 7);
                }
                if (symbol == 'o') {
                    OSymbol(1, 7);
                }//end if

            }else if (xPosition == 1 && yPosition == 1) {

                if (symbol == 'x') {
                    XSymbol(7, 7);
                }
                if (symbol == 'o') {
                    OSymbol(7, 7);
                }//end if

            }else if (xPosition == 2 && yPosition == 1) {

                if (symbol == 'x') {
                    XSymbol(13, 7);
                }
                if (symbol == 'o') {
                    OSymbol(13, 7);
                }//end if

            }else if (xPosition == 0 && yPosition == 2) {

                if (symbol == 'x') {
                    XSymbol(1, 13);
                }
                if (symbol == 'o') {
                    OSymbol(1, 13);
                }//end if

            }else if (xPosition == 1 && yPosition == 2) {

                if (symbol == 'x') {
                    XSymbol(7, 13);
                }
                if (symbol == 'o') {
                    OSymbol(7, 13);
                }//end if

            }else if (xPosition == 2 && yPosition == 2) {

                if (symbol == 'x') {
                    XSymbol(13, 13);
                }
                if (symbol == 'o') {
                    OSymbol(13, 13);
                }//end if

            }//end if 

            

        }//end function

        static bool PlaceMaker(char[,] board, char symbol, int xSlot,  int ySlot) {

            for (int xPos =  0; xPos < board.GetLength(0); xPos++) {
                for (int yPos = 0; yPos < board.GetLength(1); yPos++) {

                    if (board[xSlot, ySlot] == symbol) {


                        return true;
                    }//end if

                }//end for

            }//end for

            
            return false;
        
        }//end function

        static int winCheck(char[,] board) {

            int playerOne = 1;
            int playerTwo = 2;

            for (int xPos = 0; xPos < board.GetLength(0); xPos++) {
                for(int yPos = 0; yPos < board.GetLength(1); yPos++) {

                    //Win For Diagonal
                    if ((board[0, 0] == 'x' && board[1, 1] == 'x' && board[2, 2] == 'x') || (board[2, 0] == 'x' && board[1, 1] == 'x' && board[0, 2] == 'x')) {
                        return playerOne;
                    }else if ((board[0, 0] == 'o' && board[1, 1] == 'o' && board[2, 2] == 'o') || (board[2, 0] == 'o' && board[1, 1] == 'o' && board[0, 2] == 'o')) {
                        return playerTwo;
                    }//end if 
                }//end for

            }//end for

            //Win For Cross
            for (int row = 0; row < board.GetLength(0); row++) {

                if (board[row, 0] == 'x' && board[row, 1] == 'x' && board[row,2] == 'x') {
                    return playerOne;
                }//end if
                if (board[row, 0] == 'o' && board[row, 1] == 'o' && board[row, 2] == 'o') {
                    return playerTwo;
                }//end if

            }//end for

            //Win For Down
            for (int column = 0; column < board.GetLength(1); column++) {
                
                if (board[0, column] == 'x' && board[1,column] == 'x' && board[2, column] == 'x') {
                    return playerOne;
                }//end if
                if (board[0, column] == 'o' && board[1, column] == 'o' && board[2, column] == 'o') { 
                        return playerTwo;
                }//end if
            }//end for

            return 0;

        }//end function

        static void XSymbol(int xPos, int yPos) {

            byte[] color = { 255, 000, 000 };

            ConsoleSetBlock(0 + xPos, 0 + yPos, color);
            ConsoleSetBlock(2 + xPos, 0 + yPos, color);
            ConsoleSetBlock(1 + xPos, 1 + yPos, color);
            ConsoleSetBlock(0 + xPos, 2 + yPos, color);
            ConsoleSetBlock(2 + xPos, 2 + yPos, color);
        
        }//end function

        static void OSymbol(int xPos, int yPos) {

            byte[] color = { 255, 255, 000 };

            ConsoleSetBlock(0 + xPos, 0 + yPos, color);
            ConsoleSetBlock(1 + xPos, 0 + yPos, color);
            ConsoleSetBlock(2 + xPos, 0 + yPos, color);
            ConsoleSetBlock(0 + xPos, 1 + yPos, color);
            ConsoleSetBlock(2 + xPos, 1 + yPos, color);
            ConsoleSetBlock(0 + xPos, 2 + yPos, color);
            ConsoleSetBlock(1 + xPos, 2 + yPos, color);
            ConsoleSetBlock(2 + xPos, 2 + yPos, color);

        }//end function

        static int xCoor(string x) {

            char entry = '\0';
            int ParsedCord = 0;
            bool canParse = false;


            for (int i = 0; i < x.Length; i++) {

                entry =  x[0];
                canParse = int.TryParse(entry.ToString(), out ParsedCord);
                
            }

            
            return ParsedCord;
        }//end function

        static int yCoor(string x) {

            char entry = '\0';
            int ParsedCord = 0;
            bool canParse = false;


            for (int i = 0; i < x.Length; i++) {

                entry = x[2];
                canParse = int.TryParse(entry.ToString(), out ParsedCord);

            }


            return ParsedCord;
        }//end function

        static void GameReset (char[,] board) {

            for (int row = 0;  row < board.GetLength(0); row++) {
                for (int column = 0;  column < board.GetLength(1); column++) {

                    board[row, column] = '\0';

                }//end for
            }//end for

        }//end function

        static bool IsTie(char[,] board, int x) {
            //When Game Is A Tie
            bool tie = false;
            if (x == 9 && winCheck(board) == 0) {
                tie = true;
            }//end if
            return tie;
        }

        #region HELPER FUNCTIONS

        static void ConsoleSetForeColor(byte red, byte grn, byte blu) {
            Console.Write($"\x1b[38;2;{red};{grn};{blu}m");
        }//end function

        static void ConsoleSetBackColor(byte red, byte grn, byte blu) {
            Console.Write($"\x1b[48;2;{red};{grn};{blu}m");
        }//end function

        static void ConsoleSetBlock(int xPos, int yPos, byte[] color) {
            //STORE OLD COLORS
            ConsoleColor origForeground = Console.ForegroundColor;
            ConsoleColor origBackground = Console.BackgroundColor;

            //SET BLOCK COLOR
            byte red = color[0];
            byte grn = color[1];
            byte blu = color[2];

            ConsoleSetForeColor(red, grn, blu);
            ConsoleSetBackColor(red, grn, blu);

            //MOVE CURSOR TO POSITION
            Console.SetCursorPosition(xPos, yPos);

            //DRAW BLOCK
            Console.Write(" ");

            //CHANGE COLORS BACK
            Console.ForegroundColor = origForeground;
            Console.BackgroundColor = origBackground;
        }//end function

        static void Print(string message) {
            Console.WriteLine(message);
        }//end function

        static void PrintColor(string message, ConsoleColor color) {

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }//end function

        static string Input(string message) {
            Console.Write(message);
            string value = Console.ReadLine();
            return value;

        }//end function

        static char TryInputChar(string message) {
            //Variables

            char parsedValue = ' ';
            bool gotParsed = false;

            //Validation Loop Until Valid Int HAs Been Submitted
            do {

                gotParsed = char.TryParse(Input(message), out parsedValue);

            } while (gotParsed == false);

            //Return Parsed Value
            return parsedValue;

        }//end function

        static decimal TryInputDecimal(string message) {
            //Variables

            decimal parsedValue = 0;
            bool gotParsed = false;

            //Validation Loop Until Valid Int HAs Been Submitted
            do {

                gotParsed = decimal.TryParse(Input(message), out parsedValue);

            } while (gotParsed == false);

            //Return Parsed Value
            return parsedValue;

        }//end function

        static double TryInputDouble(string message) {
            double parsedValue = 0;
            bool gotParsed = false;

            do {

                gotParsed = double.TryParse(Input(message), out parsedValue);

            } while (gotParsed == false);

            return parsedValue;

        }//end function


        static int TryInputInt(string message) {
            int parsedValue = 0;
            bool gotParsed = false;

            do {

                gotParsed = int.TryParse(Input(message), out parsedValue);


            } while (gotParsed == false);

            return parsedValue;
        }//end function


        static decimal InputDecimal(string message) {
            string value = Input(message);
            return decimal.Parse(value);
        }//end function

        static double InputDouble(string message) {
            string value = Input(message);
            return double.Parse(value);
        }//end function

        static int InputInt(string message) {
            string value = Input(message);
            return int.Parse(value);
        }//end function

        static bool InputSpace(string message) {

            Console.Write(message);

            char keyPressed = Console.ReadKey().KeyChar;
            Console.WriteLine();

            bool gotKeyPressed = keyPressed == ' ';

            return gotKeyPressed;
        }
        #endregion

    }//end class

}//end namespace