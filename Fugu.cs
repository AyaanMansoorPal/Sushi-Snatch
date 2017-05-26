using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Fugu
{
    public class Fugu
    {

        // Properties:
        string SpriteName;
        Texture2D sprite;
        Rectangle drawRectanglefugu = new Rectangle();
      
        Vector2 velocity = new Vector2(0, 0);

        // Constructor:
        public Fugu(ContentManager contentmanager, string spritename, int x, int y, Vector2 velocity)
        {
            this.SpriteName = spritename;
            drawRectanglefugu.X = x;
            drawRectanglefugu.Y = y;
            LoadContent(contentmanager);



            int speed = 5;
            double angle = Math.PI / 2;
            velocity.X = 0;
            velocity.Y = speed * (float)Math.Sin(angle);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, drawRectanglefugu, Color.White);

        }
        public void Update(Vector2 velocity)
        {
            drawRectanglefugu.X += (int)(velocity.X);
            drawRectanglefugu.Y += (int)(velocity.Y);




        }


    }



}
    

