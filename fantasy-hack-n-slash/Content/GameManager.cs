using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static fantasy_hack_n_slash.MenuManager;

namespace fantasy_hack_n_slash
{
    internal class GameManager
    {
        HighScoreManager scoreManager = new HighScoreManager();

        Plattformer.Player player = new Plattformer.Player(Data.hitBoxImage, new Vector2(0, 0));

        private static GameStates gameState = GameStates.MainMenu;


        public static void Update(GameTime gameTime)
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


        public static void Draw(SpriteBatch _spriteBatch)
        {
           

            //Här är en switch för att rita ut olika saker beroende på gamestate.
            #region Gamestate-switch
            switch (MenuManager.CurrentGameState())
            {
                case (MenuManager.GameStates.MainMenu):
                    MenuManager.Draw(_spriteBatch);
                    break;

                case (MenuManager.GameStates.Playing):

                    break;

                case (MenuManager.GameStates.PauseMenu):
                    MenuManager.Draw(_spriteBatch);
                    break;
                    #endregion 
            }

        }
    }
}
