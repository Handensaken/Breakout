using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
namespace Breakout
{
    public class GameObject
    {
        public GameObject(){
            Program.gameObjects.Add(this);
        }
        public virtual void Update(float deltaTime)
        {

        }
        public virtual void Draw(RenderTarget target)
        {

        }
    }
}
