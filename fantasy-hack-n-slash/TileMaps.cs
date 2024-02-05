using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_hack_n_slash
{
    internal class TileMaps
    {
        int
           sizeX,
           sizeY,
           tileSize,
           tileColumns;

        Rectangle
            srcRect;

        Texture2D
            tilset;

        public bool[,] collisionMap;

        public int[,] map =
        {
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {4, 4, 4, 4, 4, 5, 6, 7, 0, 1, 2, 3, 4, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {12, 12, 12, 12, 12, 13, 88, 88, 88, 88, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16},
            {12, 12, 12, 12, 12, 96, 97, 97, 96, 97, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16}
,
        };

        public TileMaps(int theSizeX, int theSizeY, Texture2D theTileset, int theTilleSize, int theTileColums)
        {
            sizeX = theSizeX;
            sizeY = theSizeY;

            tilset = theTileset;
            tileSize = theTilleSize;
            tileColumns = theTileColums;

            srcRect = new Rectangle(0, 0, tileSize, tileSize);
            CreateCollisonMap();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    srcRect.X = (map[y, x] % tileColumns) * tileSize;
                    srcRect.Y = (map[y, x] / tileColumns) * tileSize;
                    spriteBatch.Draw(tilset, new Vector2(x, y) * tileSize, srcRect, Color.White, 0, Vector2.Zero, 1f, 0, 0.5f);
                }
            }
            //spriteBatch.Draw(Data.background, new Vector2(0,100), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.0f);

        }

        public void CreateCollisonMap()
        {
            collisionMap = new bool[sizeY, sizeX];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (map[y, x] >= 144 && map[y, x] <= 146 ||
                        map[y, x] >= 0 && map[y, x] <= 6)

                    {
                        collisionMap[y, x] = true;

                    }
                    else
                        collisionMap[y, x] = false;


                }
            }
        }

    }
}
