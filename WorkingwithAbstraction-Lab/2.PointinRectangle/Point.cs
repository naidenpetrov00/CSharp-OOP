namespace _2.PointinRectangle
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
        }

        public int CoordinateX
        {
            get { return this.x; }
            private set { this.x = value; }
        }

        public int CoordinateY
        {
            get { return this.y; }
            private set { this.y = value; }
        }
    }
}
