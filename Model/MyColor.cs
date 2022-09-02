using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace exam.Model
{
    class MyColor
    {
        public int A { get; set; } = 0;
        public int R { get; set; } = 0;
        public int G { get; set; } = 0;
        public int B { get; set; } = 0;
        public string ColorString
        {
            get
            {
                Color color = new Color
                {
                    A = Convert.ToByte(this.A),
                    R = Convert.ToByte(this.R),
                    G = Convert.ToByte(this.G),
                    B = Convert.ToByte(this.B)
                };

                return color.ToString();
            }
        }

        public MyColor() { }
        public MyColor(int A, int R, int G, int B)
        {
            this.A = A;
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }
}
