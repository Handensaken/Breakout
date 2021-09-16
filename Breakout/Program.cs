using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Breakout
{
    class Program
    {
        public const int ScreenH = 700;
        public const int ScreenW = 500;
        public static List<GameObject> gameObjects = new List<GameObject>();
        static void Main(string[] args)
        {

            using (var window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Breakout"))
            {
                Clock clock = new Clock();
                Ball ball = new Ball();
                Paddle paddle = new Paddle();
                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();


                    //UPDATE
                    ball.Update(deltaTime);
                    paddle.Update(deltaTime, ball);

                    window.Clear(new Color(139, 197, 238));

                    //DRAW
                    ball.Draw(window);
                    paddle.Draw(window);
                    window.Display();
                }
            }
        }
    }
}
