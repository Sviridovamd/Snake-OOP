﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press 'enter' to start the game :)");
            Console.ResetColor();
            Console.ReadLine();

            Walls walls = new Walls(80, 25);
            walls.Draw();


            // Отрисовка точек
            Point p = new Point(4, 6, '*');
            Snake snake = new Snake(p, 5, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail() )
                {
                    
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }   
            }
            WriteGameOver();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            Console.SetCursorPosition(17, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lose :( . Press 'enter' to quit the game.");
        }
    }
    
}
