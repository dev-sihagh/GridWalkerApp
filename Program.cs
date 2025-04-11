
using System;

namespace ToyRobot
{
    enum Direction { NORTH, EAST, SOUTH, WEST }

    class Table
    {
        public const int Width = 5;
        public const int Height = 5;

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }

    class Robot
    {
        private int x;
        private int y;
        private Direction direction;
        private bool isPlaced = false;
        private Table table;

        public Robot(Table table)
        {
            this.table = table;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (table.IsValidPosition(x, y))
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
                isPlaced = true;
            }
        }

        public void Move()
        {
            if (!isPlaced) return;

            int newX = x, newY = y;
            switch (direction)
            {
                case Direction.NORTH: newY++; break;
                case Direction.EAST: newX++; break;
                case Direction.SOUTH: newY--; break;
                case Direction.WEST: newX--; break;
            }

            if (table.IsValidPosition(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        public void Left()
        {
            if (!isPlaced) return;
            direction = (Direction)(((int)direction + 3) % 4);
        }

        public void Right()
        {
            if (!isPlaced) return;
            direction = (Direction)(((int)direction + 1) % 4);
        }

        public void Report()
        {
            if (!isPlaced) return;
            Console.WriteLine($"Output: {x},{y},{direction}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            Robot robot = new Robot(table);

            Console.WriteLine("Enter robot commands (type 'EXIT' to quit):");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;
                input = input.Trim().ToUpper();

                if (input == "EXIT") break;

                if (input.StartsWith("PLACE"))
                {
                    var parts = input.Substring(6).Split(',');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[0], out int x) &&
                        int.TryParse(parts[1], out int y) &&
                        Enum.TryParse(parts[2], out Direction dir))
                    {
                        robot.Place(x, y, dir);
                    }
                }
                else if (input == "MOVE")
                {
                    robot.Move();
                }
                else if (input == "LEFT")
                {
                    robot.Left();
                }
                else if (input == "RIGHT")
                {
                    robot.Right();
                }
                else if (input == "REPORT")
                {
                    robot.Report();
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }
}