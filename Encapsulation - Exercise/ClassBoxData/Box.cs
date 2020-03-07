namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get { return this.length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            var result = 2 * this.Length * this.Width
                         + 2 * this.Length * this.Height
                         + 2 * this.Width * this.Height;

            return result;
        }

        public double LateralSurfaceArea()
        {
            var result = 2 * this.Length * this.Height
                         + 2 * this.Width * this.Height;

            return result;
        }

        public double Volume()
        {
            var result = this.Length * this.Width * this.Height;

            return result;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            output.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            output.AppendLine($"Volume - {this.Volume():F2}");

            return output.ToString().Trim();
        }
    }
}
