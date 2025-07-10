using System.Text;

namespace Battleship {
    internal class Battleship {
        // Create boolean variables for the game
        static bool playGame, newGame;
        static int turnCount = 0, hitCount = 0;

        // Create variables for the board
        private const int BOARDSIZE = 10;
        static int letter, number;
        static readonly string[,] playerBoard = new string[BOARDSIZE, BOARDSIZE], computerBoard = new string[BOARDSIZE, BOARDSIZE];

        static void Main(string[] args) {
            //while (newGame == true) {
            //    SetBoard();
            //    while (playGame == true) {
            //        DisplayBoard();
            //    }
            //}
            SetBoard();
            DisplayBoard();
        }

        // Clear the console and redisplay the board
        static void DisplayBoard() {
            Console.Clear();
            DrawGrid();
        }

        // Create the grid for the board
        static void DrawGrid() {
            // Create the first line to show the numbers
            StringBuilder firstLine = new("   |");
            for (int i = 1; i <= BOARDSIZE; i++) {
                firstLine.Append(i < 10 ? $" {i} |" : $"{i} |");
            }
            Console.Write(firstLine.ToString());
            DrawLine();
            // For each row, write the corresponding uppercase letter at the start
            for (int rows = 0; rows < playerBoard.GetLength(0); rows++) {
                Console.Write($" {(char)('A' + (rows % 26))} |");
                // For each column in the row, display what is in the space
                for (int columns = 0;  columns < playerBoard.GetLength(1); columns++) {
                    Console.Write($" {playerBoard[rows,columns]} |");
                }
                DrawLine();
            }
        }

        static void DrawLine() {
            Console.WriteLine();
            for (int i = 0; i < playerBoard.GetLength(0) + 1; i++) {
                Console.Write("---+");
            }
            Console.WriteLine();
        }

        // Fill the not-yet-guessed spaces A-J and 1-10 with spaces
        static void SetBoard() {
            for (int row = 0; row < playerBoard.GetLength(0); row++) {
                for (int column = 0; column < playerBoard.GetLength(1); column++) {
                    playerBoard[row, column] = " ";
                }
            }
            PlaceShips();
        }

        // Algorithm for randomly placing ships at the beginning of the game
        static void PlaceShips() {
            int horizontal, vertical;
            Random shipOriention = new();
            Random shipPlacement = new();

            // Initialize array of Ship objects
            Ship[] ships = [
                new("Aircraft Carrier", 5),
                new("Battleship", 4),
                new("Destroyer", 3),
                new("Submarine", 3),
                new("Patrol Boat", 2)
            ];
        
            foreach (Ship ship in ships) {
                bool shipPlaced = false;
                int orientation = shipOriention.Next(2);

                // Pick a random starting position for the ship, making sure it won't go over the side of the board
                while (shipPlaced == false) {
                    if (orientation  == 0) {
                        horizontal = shipPlacement.Next((BOARDSIZE + 1) - ship.Length);
                        vertical = shipPlacement.Next(BOARDSIZE);
                    } else {
                        horizontal = shipPlacement.Next(BOARDSIZE);
                        vertical = shipPlacement.Next((BOARDSIZE + 1) - ship.Length);
                    }

                    // Loop through the spaces the ship is trying to occupy and make sure they are all empty
                    for (int shipPosition = 0; shipPosition < ship.Length; shipPosition++) {
                        if (orientation == 0) {
                            if (computerBoard[horizontal +  shipPosition, vertical] != null) {
                                break;
                            }
                        } else {
                            if (computerBoard[horizontal, vertical +  shipPosition] != null) {
                                break;
                            }
                        }

                        // If there are no more spaces to check, loop through the ship's length and place it on the computer's board
                        if (shipPosition == ship.Length - 1) {
                            for (int i  = 0; i < ship.Length; i++) {
                                if (orientation == 0) {
                                    computerBoard[horizontal + i, vertical] = Convert.ToString(ship.Name[0]);
                                } else {
                                    computerBoard[horizontal, vertical + i] = Convert.ToString(ship.Name[0]);
                                }
                            }
                            shipPlaced = true;
                        }
                    }
                } 
            }
        }
    }

    // Create a class for the ships
    internal class Ship(string shipName, int shipLength) {
        public string Name { get; set; } = shipName;
        public int Length { get; set; } = shipLength;
    }
}
