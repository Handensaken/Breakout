using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;

namespace Breakout
{
    public class Paddle
    {


        public const float Height = 25.0f;
        public const float Width = 100.0f;
        public Sprite sprite;
        Vector2f size;
        public Paddle()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture(@"assets/paddle.png");
            sprite.Position = new Vector2f(Program.ScreenW / 2, Program.ScreenH - 50);
            Vector2f paddleTextureSize = (Vector2f)sprite.Texture.Size;
            sprite.Origin = 0.5f * paddleTextureSize;
            sprite.Scale = new Vector2f(
                Width / paddleTextureSize.X,
                Height / paddleTextureSize.Y
            );
            size = new Vector2f(
                sprite.GetGlobalBounds().Width,
                sprite.GetGlobalBounds().Height
            );
        }
        public void Update(float deltaTime, Ball ball)
        {
            var newPos = sprite.Position;
            Move(newPos, deltaTime);


            if (Collision.CircleRectangle(ball.sprite.Position, Ball.Radius, this.sprite.Position, size, out Vector2f hit))
            {
                ball.sprite.Position += hit;
                ball.Reflect(hit.Normalized());
            }


        }
        private void Move(Vector2f newPos, float deltaTime)
        {
            if (newPos.X <= Program.ScreenW - Width / 2)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right) || Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    newPos.X += deltaTime * 300.0f;
                }
            }
            if (newPos.X >= 0 + Width / 2)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left) || Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    newPos.X -= deltaTime * 300.0f;
                }
            }
            sprite.Position = newPos;
        }
        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);
        }
    }
}
