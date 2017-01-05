using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProgrammingAssignment3
{
    /// <summary>
    /// A rock
    /// </summary>
    public class Rock
    {
        #region Fields

        // drawing support
        Texture2D sprite;
        Rectangle drawRectangle;

        // moving support
        Vector2 velocity;

        // window containment support
        int windowWidth;
        int windowHeight;
        bool outsideWindow = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sprite">sprite for the rock</param>
        /// <param name="location">location of the center of the rock</param>
        /// <param name="velocity">velocity of the rock</param>
        /// <param name="windowWidth">window width</param>
        /// <param name="windowHeight">window height</param>
        public Rock(Texture2D sprite, Vector2 location, Vector2 velocity,
            int windowWidth, int windowHeight)
        {
            // save window dimensions
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            // save sprite and set draw rectangle
            this.sprite = sprite;
            drawRectangle = new Rectangle((int)location.X - sprite.Width / 2,
                (int)location.Y - sprite.Height / 2, sprite.Width, sprite.Height);

            // save velocity
            this.velocity = velocity;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets the rock's velocity
        /// </summary>
        public Vector2 Velocity
        {
            set
            {
                velocity.X = value.X;
                velocity.Y = value.Y;
            }
        }

        /// <summary>
        /// Gets whether or not the rock is outside the window
        /// </summary>
        public bool OutsideWindow
        {
            get { return outsideWindow; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the rock
        /// </summary>
        /// <param name="gameTime">game time</param>
        public void Update(GameTime gameTime)
        {
            // STUDENTS: Only update the rock if it's inside the window
            // STUDENTS: Update the rock's location

            /*
             
            distance = rate * time. In this case, distance is the amount you should move your draw rectangle in x or y, 
            rate is either the x or y component of the velocity 
            (whichever direction you're currently calculating the distance for), 
            and time is how many milliseconds have elapsed since Update was called last. 
            If you multiply the velocity component by the elapsed milliseconds and then cast the result to an int, 
            your rocks will move fine.

             */
            if ( !outsideWindow ) {
                drawRectangle.X += (int) (velocity.X * gameTime.ElapsedGameTime.Milliseconds);
                drawRectangle.Y += (int) (velocity.Y * gameTime.ElapsedGameTime.Milliseconds);
            }

            // STUDENTS: Set outsideWindow to true if the rock is outside the window
            // outsideWindow is equal to true if
            // the drawRectangle x is less than 0 is true
            // or the drawRectangle x + drawRectangle width is greater than window width is true
            // the drawRectangle y is less than 0 is true
            // or the drawRectangle y + drawRectangle height is greater than window height is true
            outsideWindow = (drawRectangle.X < 0 || drawRectangle.X + drawRectangle.Width > windowWidth) 
                            || (drawRectangle.Y < 0 || drawRectangle.Y + drawRectangle.Height > windowHeight);

        }

        /// <summary>
        /// Draws the rock
        /// </summary>
        /// <param name="spriteBatch">sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // STUDENTS: Only draw the rock if it's inside the window
            // STUDENTS: Draw the rock
            // Caution: Don't include spriteBatch.Begin or spriteBatch.End here
            if ( !outsideWindow )
                spriteBatch.Draw(sprite, drawRectangle, Color.White);
        }

        #endregion
    }
}
