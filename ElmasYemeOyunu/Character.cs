using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasYemeOyunu
{
    class Character : PictureBox
    {
        int x;
        int y;
        string status;//Live,Dead
        int point;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Point { get { return point; } set { point = value; } }
        public string Status { get { return status; } set { status = value; } }

    }
}
