using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gui
{
    public class FrameLayout : Layout
    {
        public FrameLayout(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
        }

        public override Point GetSize(Point parentSize)
        {
            var xMax = Views.Max(x => x.GetSize(parentSize).X);
            var yMax = Views.Max(x => x.GetSize(parentSize).Y);

            var wigth = GetFiilingValue(parentSize.X, xMax, LayoutParameters.LayoutFillingX);
            var height = GetFiilingValue(parentSize.Y, yMax, LayoutParameters.LayoutFillingY);

            Size = new Point(wigth, height);
            return Size;
        }

        public override void ApplyChanges(Point parentLocation)
        {
            foreach (var view in Views)
            {
                var x = GetCoordinate(view.LayoutParameters.GravityX, view.LayoutParameters.OffsetX, view.Size.X,
                    Size.X,
                    Location.X);

                var y = GetCoordinate(view.LayoutParameters.GravityY, view.LayoutParameters.OffsetY, view.Size.Y,
                    Size.Y,
                    Location.Y);
                view.Location = new Point(x, y);

                if (view is Layout ley)
                    ley.ApplyChanges(Location);
            }
        }
    }
}