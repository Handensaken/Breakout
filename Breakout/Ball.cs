using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;


namespace Breakout
{
    public class Ball
    {
        public Sprite sprite;
        public const float Diameter = 20.0f;
        public const float Radius = Diameter / 2f;
        public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(2.0f);
        public Ball()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/ball.png");
            sprite.Position = new Vector2f(250, 300);
            Vector2f ballTextureSize = (Vector2f)sprite.Texture.Size;
            sprite.Origin = 0.5f * ballTextureSize;
            sprite.Scale = new Vector2f(
                Diameter / ballTextureSize.X,
                Diameter / ballTextureSize.Y
            );
        }
        public void Update(float deltaTime)
        {
            var newPos = sprite.Position;
            newPos += (direction * deltaTime * 100.0f);
            CheckBounds(newPos);
            sprite.Position = newPos;

        }
        private void CheckBounds(Vector2f newPos)
        {
            //X-Axis
            if (newPos.X > Program.ScreenW - Radius)
            {
                newPos.X = Program.ScreenW - Radius;
                Reflect(new Vector2f(-1, 0));
            }
            if (newPos.X < 0 + Radius)
            {
                newPos.X = 0 + Radius;
                Reflect(new Vector2f(1, 0));
            }

            //Y-Axis
            if(newPos.Y> Program.ScreenH - Radius){
                Console.WriteLine("Below play area");
                newPos.Y = Program.ScreenH - Radius;
                Reflect(new Vector2f(0,-1));

                //Above code is temporary untill I handle missed balls
            }
            if(newPos.Y < 0 + Radius){
                newPos.Y = 0 + Radius;
                Reflect(new Vector2f(0,1));
            }


        }
        private void Reflect(Vector2f normal)
        {
            direction -= normal * (2 * (direction.X * normal.X + direction.Y * normal.Y));
        }
        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);
        }
    }
}
