using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_hack_n_slash
{
    internal class MenuManager
    {
        public enum GameStates
        {
            MainMenu,
            Playing,
            PauseMenu
        }
        private static Rectangle 
           startBox = new Rectangle(705, 404, 1215 - 705, 529 - 404),
           exitBox = new Rectangle(765, 572, 1154 - 765, 692 - 572);
        private static GameStates gameState = GameStates.MainMenu;
        public static bool drawStartEffect = false, drawExitEffect = false;

        public static void SetGameState(GameStates newGameState)
        {
            gameState = newGameState;
        }

        public static GameStates CurrentGameState()
        {
            return gameState; 
        }
        public static void Update()
        {
            if (startBox.Contains(Data.mouse.Position))
            {
                drawStartEffect = true;
                if (Data.mouse.LeftButton == ButtonState.Pressed)
                {
                    SetGameState(GameStates.Playing);
                }
            }
            else drawStartEffect = false;

            if (exitBox.Contains(Data.mouse.Position))
            {
                drawExitEffect = true;

            }
            else drawExitEffect = false;
        }



        public static void Draw(SpriteBatch _spriteBatch)
        {
            if(!drawStartEffect)
            _spriteBatch.Draw(Data.startGame, Vector2.Zero, Color.White);
            else
                _spriteBatch.Draw(Data.startGame, Vector2.Zero, Color.Red);

            if (!drawExitEffect)
            _spriteBatch.Draw(Data.endGame, Vector2.Zero, Color.White);
            else
                _spriteBatch.Draw(Data.endGame, Vector2.Zero, Color.Red);


            /*
            _spriteBatch.Draw(Data.pixelTexture, startBox, Color.Red);
            _spriteBatch.Draw(Data.pixelTexture, exitBox, Color.Red);
            */
        }

       
    }
   

}
