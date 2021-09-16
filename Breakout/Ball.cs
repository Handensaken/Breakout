using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;


namespace Breakout
{
    public class Ball
    {
        public int health;
        public int score;
        Text gui;
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
            gui = new Text();
            gui.CharacterSize = 24;
            gui.Font = new Font(@"assets/future.ttf");

            health = 3;
        }
        public void Update(float deltaTime)
        {
            var newPos = sprite.Position;
            newPos += (direction * deltaTime * 100.0f);
            newPos = CheckBounds(newPos);
            sprite.Position = newPos;


        }
        private void ResetBall()
        {
            sprite.Position = new Vector2f(250, 300);
        }
        private Vector2f CheckBounds(Vector2f newPos)
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
            if (newPos.Y > Program.ScreenH - Radius)
            {
                newPos = new Vector2f(250, 300);
                health--;
                int vectorValue = new Random().Next() % 2;
                if (vectorValue == 0)
                {
                    vectorValue = -1;
                }
                direction = new Vector2f(vectorValue, 1) / MathF.Sqrt(2.0f);
            }
            if (newPos.Y < 0 + Radius)
            {
                newPos.Y = 0 + Radius;
                Reflect(new Vector2f(0, 1));
            }
            return newPos;

        }
        public void Reflect(Vector2f normal)
        {
            direction -= normal * (2 * (direction.X * normal.X + direction.Y * normal.Y));
        }
        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);

            gui.DisplayedString = $"Health: {health}";
            gui.Position = new Vector2f(12, 8);
            target.Draw(gui);

            gui.DisplayedString = $"Score {score}";
            gui.Position = new Vector2f(Program.ScreenW - gui.GetGlobalBounds().Width - 12, 8);
            target.Draw(gui);
        }
    }
}
