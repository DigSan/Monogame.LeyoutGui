using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gui
{
    public abstract class Layout : View
    {
        protected Layout(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            Views = new ObservableCollection<View>();
        }

        public ObservableCollection<View> Views { get; }

        public abstract void ApplyChanges(Point parentLocation);

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (var view in Views) view.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (var view in Views) view.Update(gameTime);
        }

        protected int GetCoordinate(Gravity gravity, int offset, int width, int viewportWidth, int parentX)
        {
            switch (gravity)
            {
                case Gravity.Start:
                    return offset + parentX;
                case Gravity.Center:
                    return viewportWidth / 2 - width / 2 + offset + parentX;
                case Gravity.End:
                    return viewportWidth - width + offset + parentX;
            }

            return 0;
        }
    }
}