using System;
using System.Xml.Serialization;

namespace Gui.Models
{
    public class LayoutParameters
    {
        [XmlElement(ElementName = "type", IsNullable = true)]
        public int? Wight;
        [XmlElement(ElementName = "type", IsNullable = true)]
        public int? Height;
        //public LayoutFilling LayoutFillingX;
        //public LayoutFilling LayoutFillingY;
        //public int OffsetX;
        //public int OffsetY;
        //public Gravity GravityX;
        //public Gravity GravityY;

    }
    public enum LayoutFilling
    {
        WrapContent,
        MatchViewport,
        None
    }

    public enum Gravity
    {
        Start,
        Center,
        End
    }
}
