using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gui
{
    public class LinearLayout : Layout
    {
        public int ContentOffest { get; set; }

        public Direction Direction { get; set; }

        public override Point GetSize(Point parentSize)
        {
            int xMax = 0;
            int yMax = 0;

            if (Views.Count == 0)
            {
                return new Point(GetFiilingValue(parentSize.X, 0, LayoutParameters.LayoutFillingX), GetFiilingValue(parentSize.Y, 0, LayoutParameters.LayoutFillingY));
            }

            xMax = Direction == Direction.Horizontal ? Views.Sum(x => x.GetSize(parentSize).X) : Views.Max(x => x.GetSize(parentSize).X);
            yMax = Direction == Direction.Vertical ? Views.Sum(x => x.GetSize(parentSize).Y) : Views.Max(x => x.GetSize(parentSize).Y);
            

            var wigth = GetFiilingValue(parentSize.X, xMax, LayoutParameters.LayoutFillingX);
            var height = GetFiilingValue(parentSize.Y, yMax, LayoutParameters.LayoutFillingY);

            if (LayoutParameters.Wight != null)
            {
                wigth = LayoutParameters.Wight.Value;
            }
            if (LayoutParameters.Height != null)
            {
                height = LayoutParameters.Height.Value;
            }

            Size = new Point(wigth, height);
            return Size;
        }

        public override void ApplyChanges(Point parentLocation)
        {
            int elementsValue = 0;
            foreach (var view in Views)
            {
                var xOffset = Direction == Direction.Horizontal ? ContentOffest : 0;
                var yOffset = Direction == Direction.Vertical ? ContentOffest : 0;

                var x = GetCoordinate(view.LayoutParameters.GravityX, view.LayoutParameters.OffsetX , view.Size.X,Size.X, Location.X) + xOffset;
                var y = GetCoordinate(view.LayoutParameters.GravityY, view.LayoutParameters.OffsetY, view.Size.Y, Size.Y, Location.Y) + yOffset;

                view.Location = Direction == Direction.Horizontal ? new Point(x + elementsValue, y) : new Point(x, y + elementsValue);
                elementsValue += view.Size.X;

                if (view is Layout ley)
                    ley.ApplyChanges(Location);
            }
        }

        public LinearLayout(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
        }
    }

    public enum Direction
    {
        Horizontal,
        Vertical
    }
}
