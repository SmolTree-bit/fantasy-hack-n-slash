﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_hack_n_slash
{
    internal class Data
    {
        // If this file is edited notify everyone to update
        public static KeyboardState keyboard;
        public static MouseState mouse;

        public static Random rnd = new Random();

        public static Texture2D
            hitBoxImage;
        public static void DataUpdate(GameTime gametime)
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
        }

        public static SpriteFont gameFont;
        public static Texture2D startGame;
        public static Texture2D endGame;
        public static Texture2D pixelTexture;



        public static int playerScore;
    }
    
}
