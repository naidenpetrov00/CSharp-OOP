namespace _2.PointinRectangle
{
    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(Point top, Point bottom)
        {
            this.TopLeft = top;
            this.BottomRight = bottom;
        }

        public Point TopLeft
        {
            get { return this.topLeft; }
            private set { this.topLeft = value; }
        }

        public Point BottomRight
        {
            get { return this.bottomRight; }
            private set { this.bottomRight = value; }
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal =
                this.TopLeft.CoordinateX <= point.CoordinateX
                && this.BottomRight.CoordinateX >= point.CoordinateX;
            bool isInVertical =
                this.TopLeft.CoordinateY <= point.CoordinateY
                && this.BottomRight.CoordinateY >= point.CoordinateY;

            return isInHorizontal && isInVertical;
        }
    }
}
