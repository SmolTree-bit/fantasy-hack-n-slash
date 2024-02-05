using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_hack_n_slash
{
    internal class BossEnemy
    {
        public string bossType;
        public float
            level,
            gravaty,
            speed,
            attackspeed;
        public Vector2
            positon,
            velocity;
        public Rectangle
            hitBox;
        public Texture2D
            image,
            hitBoxImage;

        public BossEnemy(string _bossType)
        {
            bossType = _bossType;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
