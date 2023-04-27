using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasYemeOyunu
{
    class Diamonds : PictureBox
    {
        int x;
        int y;
        string adi;
        int point;
        string renk;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public string Adi { get { return adi; } set { adi = value; } }
        public int Point { get { return point; } set { point = value; } }
        public string Renk { get { return renk; } set { renk = value; } }
    }
}
