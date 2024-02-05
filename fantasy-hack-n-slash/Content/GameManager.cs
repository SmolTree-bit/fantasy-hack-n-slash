using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_hack_n_slash
{
    internal class GameManager
    {
        HighScoreManager scoreManager = new HighScoreManager();

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            scoreManager.Draw(spriteBatch);
        }
    }
}
