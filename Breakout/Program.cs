using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Breakout
{
    class Program
    {
        public const int ScreenH = 700;
        public const int ScreenW = 500;
        static void Main(string[] args)
        {

            using (var window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Breakout"))
            {
                Clock clock = new Clock();
                Ball ball = new Ball();
                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();

                    ball.Update(deltaTime);
                    //UPDATES

                    window.Clear(new Color(139, 197, 238));

                    ball.Draw(window);
                    //DRAW

                    window.Display();
                }
            }
        }
    }
}
