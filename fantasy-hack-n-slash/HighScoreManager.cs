using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_hack_n_slash
{
    internal class HighScoreManager
    {
        private int currentHighScore;

        public HighScoreManager()
        {
            // Load the high score from a file
            currentHighScore = LoadHighScore();
        }

        public void UpdateHighScore(int playerScore)
        {
            // Check if the current score is greater than the high score
            if (playerScore > currentHighScore)
            {
                // If so, update the high score
                currentHighScore = playerScore;
                SaveHighScore(currentHighScore);
            }
        }

        // Draws the highscore and score in the upper left corner
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Data.gameFont, $"Score: {Data.playerScore}", new Vector2(10, 5), Color.White);
            spriteBatch.DrawString(Data.gameFont, $"High Score: {currentHighScore}", new Vector2(10, 25), Color.White);

        }

        private int LoadHighScore()
        {
            // Checks if highscore.txt exists
            if (File.Exists("highscore.txt"))
            {
                // Reads the txt file
                using (StreamReader reader = new StreamReader("highscore.txt"))
                {
                    string highScoreString = reader.ReadLine();
                    if (int.TryParse(highScoreString, out int highScore))
                    {
                        return highScore;
                    }
                }
            }

            return 0;
        }

        // writes the score in a txt file
        private void SaveHighScore(int score)
        {
            using (StreamWriter writer = new StreamWriter("highscore.txt"))
            {
                writer.Write(score);
            }
        }
    }
}
