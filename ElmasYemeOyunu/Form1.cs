using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasYemeOyunu
{
    public partial class Form1 : Form
    {
        int mapWidth = 20;
        int mapHeight = 15;
        int squareSize = 40;
        int characterX = 0;
        int characterY = 0;
        int diamondCount = 20; //kaç elmas istiyorsak burda o kadar sayı yazarız
        int firstTime = 60;        

        Character character;
        Diamonds[] diamonds;
        int time;
        int level = 1;
        bool isControl = true;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDiamonds();
            CreateCharacter();
            time = firstTime;
            lblTime.Text = "SÜRE: " + time;
            lblLevel.Text = "LEVEL " + level;            
        }

        void CreateCharacter()
        {
            character = new Character();
            character.Name = "Hero";
            character.X = characterX;
            character.Y = characterY;
            character.Width = squareSize;
            character.Height = squareSize;
            character.Image = Properties.Resources.karakter;
            character.SizeMode = PictureBoxSizeMode.StretchImage;
            character.Location = new Point(squareSize * character.X, squareSize * character.Y);
            pnlSahne.Controls.Add(character);
        }

        void resetCharacter()
        {
            character.X = characterX;
            character.Y = characterY;
            character.Location = new Point(squareSize * character.X, squareSize * character.Y);
            pnlSahne.Controls.Add(character);
        }

        void FillDiamonds()
        {
            pnlSahne.Controls.Clear();
            diamonds = new Diamonds[diamondCount];
            Random r = new Random();

            for (int i = 0; i < diamondCount; i++)
            {
                Diamonds d = new Diamonds();
                d.Name = "Diamond" + i;
                int _x, _y, _color;
                _x = r.Next(0, mapWidth);
                _y = r.Next(0, mapHeight);
                d.X = _x;
                d.Y = _y;
                _color = r.Next(0, 3);
                if (_color == 0)
                {
                    d.Adi = "kirmizi";
                    d.Image = Properties.Resources.kirmizi;
                    d.Point = 10;
                }
                if (_color == 1)
                {
                    d.Adi = "yesil";
                    d.Image = Properties.Resources.yesil;
                    d.Point = 20;
                }
                if (_color == 2)
                {
                    d.Adi = "mavi";
                    d.Image = Properties.Resources.mavi;
                    d.Point = 30;
                }
                diamonds[i] = d;
            }
            for (int i = 0; i < diamonds.Length; i++)
            {
                diamonds[i].Size = new Size(squareSize, squareSize);
                diamonds[i].SizeMode = PictureBoxSizeMode.StretchImage;
                diamonds[i].Location = new Point(squareSize * diamonds[i].X, squareSize * diamonds[i].Y);
                pnlSahne.Controls.Add(diamonds[i]);
            }
        }

        void CollisionControl()
        {
            for (int i = 0; i < diamonds.Length; i++)
            {
                if (diamonds[i] != null)
                {
                    if (diamonds[i].X == character.X && diamonds[i].Y == character.Y)
                    {
                        pnlSahne.Controls.RemoveByKey(diamonds[i].Name);
                        character.Point += diamonds[i].Point;
                        lblScore.Text = "SCORE: " + character.Point;
                        diamonds[i] = null;
                    }
                }
            }
            bool over = true;
            for (int j = 0; j < diamonds.Length; j++)
            {
                if (diamonds[j] != null)
                    over = false;
            }
            if (over)
            {
                MessageBox.Show("Tüm elmasları topladınız.");
                time = firstTime - (level * 10);
                diamondCount += 5;
                level += 1;
                FillDiamonds();
                resetCharacter();
                lblTime.Text = "SÜRE: " + time;
                lblLevel.Text = "LEVEL " + level;
            }
        }

        private void tmrGameTime_Tick(object sender, EventArgs e)
        {

            time -= 1;
            lblTime.Text = "SÜRE: " + time;

            if (time < 0)
            {
                tmrGameTime.Enabled = false;
                isControl = false;
                MessageBox.Show("Süre bitti.\r\nSkorunuz " + character.Point, "Oyun Bitti");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isControl)
            {
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    if (character.X > 0)
                    {
                        character.X -= 1;
                        character.Location = new Point(character.X * squareSize, character.Y * squareSize);
                        CollisionControl();
                    }
                }
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    if (character.Y < mapHeight - 1)
                    {
                        character.Y += 1;
                        character.Location = new Point(character.X * squareSize, character.Y * squareSize);
                        CollisionControl();
                    }
                }
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    if (character.X < mapWidth - 1)
                    {
                        character.X += 1;
                        character.Location = new Point(character.X * squareSize, character.Y * squareSize);
                        CollisionControl();
                    }
                }
                else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    if (character.Y > 0)
                    {
                        character.Y -= 1;
                        character.Location = new Point(character.X * squareSize, character.Y * squareSize);
                        CollisionControl();
                    }
                }
            }
        }
    }
}

