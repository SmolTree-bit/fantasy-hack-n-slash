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
            #region GameStateManager
            switch (MenuManager.CurrentGameState())
            {

                case (MenuManager.GameStates.MainMenu):
                    MenuManager.Update();
                    break;
                case (MenuManager.GameStates.Playing):

                    break;

                case (MenuManager.GameStates.PauseMenu):
                    MenuManager.Update();
                    break;

            }
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (MenuManager.CurrentGameState() == MenuManager.GameStates.Playing)
            scoreManager.Draw(spriteBatch);

            //Här är en switch för att rita ut olika saker beroende på gamestate.
            #region Gamestate-switch
            switch (MenuManager.CurrentGameState())
            {
                case (MenuManager.GameStates.MainMenu):
                    MenuManager.Draw(spriteBatch);
                    break;
                   
                case (MenuManager.GameStates.Playing):
                    
                    break;

                case (MenuManager.GameStates.PauseMenu):
                    MenuManager.Draw(spriteBatch);
                    break;
                    #endregion 
            }

        }
    }
}
