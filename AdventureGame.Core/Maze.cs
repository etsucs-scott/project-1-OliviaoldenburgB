using System;
using System.Collections.Generic;
// note-to-self: everything goes inside the 'using System' blah blah
namespace AdventureGame.Core
{
    public class Maze
    {
        private Dictionary<(int, int), Monster> monsters = new();
        private Dictionary<(int, int), Item> items = new();  
// Not entirly sure how the 'dictionary' works but I didnt know how to make it not have an error so I used suggestions from CLaude AI
        public int Width { get; }
        public int Height { get; }

        private char[,] grid;
        private Random random = new Random();

        public int PlayerX { get; private set; }
        public int PlayerY { get; private set; }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new char[width, height];

            GenerateMaze();
        }



        private void GenerateMaze()
        {
            // Fill everything with empty space
            for (int x = 0; x < Width; x++)
            {
                 for (int y = 0; y < Height; y++)
                {
                    grid[x, y] = '.';
                }
            }

          
          // Random internal walls
            for (int i = 0; i < (Width * Height) / 5; i++)
            {
                 int x = random.Next(1, Width - 1);
                 int y = random.Next(1, Height - 1);

                 // Don't block start or exit
                 if ((x == 1 && y == 1) || (x == Width - 2 && y == Height - 2))
                 continue;

                 grid[x, y] = '#';
            }

            // Create outer walls
            for (int x = 0; x < Width; x++)
            {
                grid[x, 0] = '#';
                grid[x, Height - 1] = '#';
            }

            for (int y = 0; y < Height; y++)
            {
                grid[0, y] = '#';
                grid[Width - 1, y] = '#';
            }

            // Set player start position
            PlayerX = 1;
            PlayerY = 1;

            // Place exit
            grid[Width - 2, Height - 2] = 'E';

            //Ok now I THINK these stupid monsters go here
            // Spawn monsters
            for (int i = 0; i < 5; i++)
            {
                int x = random.Next(1, Width - 1);
                int y = random.Next(1, Height - 1);

                if (grid[x, y] == '.')
                {
                    grid[x, y] = 'M';
                    monsters[(x, y)] = new Monster(random);
                }
            }

            // Spawn weapons
            for (int i = 0; i < 3; i++)
            {
                int x = random.Next(1, Width - 1);
                int y = random.Next(1, Height - 1);

                if (grid[x, y] == '.')
                {
                    grid[x, y] = 'W';
                    items[(x, y)] = new Weapon("Sword", random.Next(5, 11));
                }
            }

        // Spawn potions
        for (int i = 0; i < 3; i++)
        {
            int x = random.Next(1, Width - 1);
            int y = random.Next(1, Height - 1);

            if (grid[x, y] == '.')
            {
                grid[x, y] = 'P';
                items[(x, y)] = new Potion();
            }
        }   
    }

    public char GetTile(int x, int y)
        {
            return grid[x, y];
        }

        public void SetTile(int x, int y, char value)
        {
            grid[x, y] = value;
        }

        public bool IsWall(int x, int y)
        {
            return grid[x, y] == '#';
        }
//This next part moves the player by direction and blocks the walls off
        public bool MovePlayer(int dx, int dy)
        {
            int newX = PlayerX + dx;
            int newY = PlayerY + dy;

            // Prevent moving off grid
            if (newX < 0 || newX >= Width || newY < 0 || newY >= Height)
                return false;

            if (grid[newX, newY] == '#')
                 return false;

            PlayerX = newX;
            PlayerY = newY;

            return true;
        }
            public bool IsExit(int x, int y)
            {
                return grid[x, y] == 'E';
            }
//ok the joke is over. I need help..Omg im going to fail--ToT
        public Monster? GetMonsterAt(int x, int y)
        {
            if (monsters.ContainsKey((x, y)))
                return monsters[(x, y)];

            return null;
        }
        public void RemoveMonster(int x, int y)
        {
            monsters.Remove((x, y));
            grid[x, y] = '.';
        }

        public Item? GetItemAt(int x, int y)
        {
            if (items.ContainsKey((x, y)))
                return items[(x, y)];

            return null;
        }
        public void RemoveItem(int x, int y)
        {
            items.Remove((x, y));
            grid[x, y] = '.';
        }
        }

 
}
//THANKK YOU TAB KEY 