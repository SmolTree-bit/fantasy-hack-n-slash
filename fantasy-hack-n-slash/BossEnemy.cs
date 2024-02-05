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
            gravity,
            speed,
            attackspeed,
            frame,
            deadCounter,
            frameTimer;
        public Vector2
            position,
            velocity;
        Rectangle sourceRect = new Rectangle(0, 0, 64, 64);
        public Rectangle
           boundingBox;
        public Texture2D
            image,
            hitBoxImage;
        public PlatformController controller;
        public bool alive, facing, isGrounded, idel, moveing;

        public BossEnemy(string _bossType, Vector2 _position, Texture2D _image)
        {
            this.bossType = _bossType;
            this.position = _position;
            image = _image;

            isGrounded = false;
            gravity = 0.2f;
            speed = 1;

            idel = moveing = false;
            frameTimer = 0;
            alive = facing = false;
            frame = deadCounter = 0;

            boundingBox.Location = position.ToPoint();
            boundingBox.Width = 64 / 3;
            boundingBox.Height = 64 / 3;
            controller = new PlatformController();
            controller.Initialize(boundingBox, 5, 3, 16);
            controller.SetCollisionMap(Data.level1.collisionMap);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
