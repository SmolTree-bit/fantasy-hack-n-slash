using fantasy_hack_n_slash;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Plattformer
{
    internal class Player
    {
        Texture2D image;
        public Vector2 position, velocity;
        bool facing;
        Rectangle sourceRect = new Rectangle(0, 0, 64, 64);
        public Rectangle boundingBox;

        bool isGrounded;
        float gravity, speed;
        public PlatformController controller;


        public Player(Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;

            isGrounded = false;
            gravity = 0.2f;
            speed = 1;
            facing = true;


            boundingBox.Location = position.ToPoint();
            boundingBox.Width = 18;                                 
            boundingBox.Height = 32;                                
            /*controller = new PlatformController();
            controller.Initialize(boundingBox, 5, 3, 16); 
            controller.SetCollisionMap(Data.level1.collisionMap);*/

        }

        public void Update(GameTime gameTime)
        {
            //Movement
            if (Data.keyboard.IsKeyDown(Keys.D))
            {
                facing = true;
                velocity.X = speed;
            }
            else if (Data.keyboard.IsKeyDown(Keys.A))
            {
                facing = false;
                velocity.X = -speed;
            }
            else
            {
                velocity.X = 0;
            }

            //Kollar om man är på marken och i så fall kan man hoppa
            if (isGrounded)
            {
                if (Data.keyboard.IsKeyDown(Keys.Space))
                {
                    velocity.Y = -5;
                    isGrounded = false;

                }
            }

            //Kollar om nuvarande hastighet kommer krocka med något innan velocity sätts. 
            velocity.Y += gravity;
            /*velocity = controller.CalculateVelocity(velocity, boundingBox);*/
            position += velocity;
            boundingBox.Location = position.ToPoint();

            //Kollar om man är på marken
            if (!isGrounded)
            {
               /* if (controller.collisions.below)
                {
                    isGrounded = true;
                    velocity.Y = 0;
                }
                else
                {
                    if (!controller.collisions.below)
                    {
                        isGrounded = false;
                    }
                }*/
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (facing == true)
                spriteBatch.Draw(image, position, sourceRect, Color.White, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(image, position, sourceRect, Color.White, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.FlipHorizontally, 0f);

        }
    }

}