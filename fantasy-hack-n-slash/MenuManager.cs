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
        private static GameStates gameState = GameStates.MainMenu;

        public static void SetGameState(GameStates newGameState)
        {
            gameState = newGameState;
        }

        public static GameStates CurrentGameState()
        {
            return gameState; 
        }
    }
   

}
