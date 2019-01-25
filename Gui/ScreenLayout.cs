using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Gui
{
    public class ScreenLayout : Layout
    {
        private readonly Game _game;

        public ScreenLayout(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            _game = game;
            LayoutParameters = new LayoutParameters(Gravity.Start, Gravity.Start, 0, 0, LayoutFilling.MatchViewport,
                LayoutFilling.MatchViewport);

            GetSize(new Point(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height));
            Location = Point.Zero;
            
        }

        public override void ApplyChanges(Point parant)
        {
            foreach (var view in Views.Cast<Layout>()) view.GetSize(Size);

            foreach (var view in Views.Cast<Layout>())
            {
                view.Location = Location;
                view.ApplyChanges(Point.Zero);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Touches = TouchPanel.GetState(_game.Window).GetState();
            base.Update(gameTime);
        }
    }
}