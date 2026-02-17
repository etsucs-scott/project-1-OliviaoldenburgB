using System;
using AdventureGame.Core;

//I asked Claude AI for help on this next part**
// note-to-self: use the console class from system not namespace or something idk
namespace AdventureGame.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(10, 10);
            Player player = new Player();
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("HP: " + player.Health);
                System.Console.WriteLine();
                DrawMaze(maze);


                System.ConsoleKeyInfo key = System.Console.ReadKey(true);

                char input = char.ToLower(key.KeyChar);

                switch (input)
                {
                    //note-to-self: The a,w,s,d keys must be lowercase
                    case 'w':
                        maze.MovePlayer(0, -1);
                        break;
                    case 's':
                        maze.MovePlayer(0, 1);
                        break;
                    case 'a':
                        maze.MovePlayer(-1, 0);
                        break;
                    case 'd':
                        maze.MovePlayer(1, 0);
                        break;
                }
                    if (maze.IsExit(maze.PlayerX, maze.PlayerY))
                {
                System.Console.Clear();
                DrawMaze(maze);
                System.Console.WriteLine();
                System.Console.WriteLine("🎉 You reached the exit! You win!");
                break;
                }
                 
                 
                Monster? monster = maze.GetMonsterAt(maze.PlayerX, maze.PlayerY);

                if (monster != null)
                {
                    System.Console.Clear();
                    DrawMaze(maze);

                    System.Console.WriteLine();
                    System.Console.WriteLine("A monster appears!");

                    while (monster.IsAlive && player.IsAlive)
                    {
                        int playerDamage = player.Attack();
                        monster.TakeDamage(playerDamage);
                        System.Console.WriteLine($"You hit the monster for {playerDamage} damage!");

                        if (!monster.IsAlive)
                            break;

                        int monsterDamage = monster.Attack();
                        player.TakeDamage(monsterDamage);
                        System.Console.WriteLine($"Monster hits you for {monsterDamage} damage!");
                    }

                    if (!player.IsAlive)
                    {
                        System.Console.WriteLine("You died! Game Over.");
                        break;
                    }
                    
                    System.Console.WriteLine("Monster defeated!");
                    maze.RemoveMonster(maze.PlayerX, maze.PlayerY);

                    System.Console.WriteLine("Press any key to continue...");
                    System.Console.ReadKey(true);
                }
                
                Item? item = maze.GetItemAt(maze.PlayerX, maze.PlayerY);

                if (item != null)
                {
                    System.Console.Clear();
                    DrawMaze(maze);

                    System.Console.WriteLine();
                    System.Console.WriteLine(item.PickupMessage);

                    item.Apply(player);
                    maze.RemoveItem(maze.PlayerX, maze.PlayerY);

                    System.Console.WriteLine("Press any key to continue...");
                    System.Console.ReadKey(true);
                }

                    
            }
        }


        static void DrawMaze(Maze maze)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    if (x == maze.PlayerX && y == maze.PlayerY)
                    {
                        System.Console.Write("@ ");
                    }
                    else
                    {
                        System.Console.Write(maze.GetTile(x, y) + " ");
                    }
                }
                System.Console.WriteLine();
            }
        }
    }
}
