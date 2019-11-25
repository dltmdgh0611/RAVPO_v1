using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace omokproto1
{
    public partial class Form1 : Form
    {
        const int X = 0;
        const int Y = 1;
        const int XY = 2;
        int margin = 22;
        int gridSize = 42; // gridSize
        int stoneSize = 42; // stoneSize
        int checkshapeSize = 10; // 격자점 크기
        Rectangle r;
        int[,] omokpans = new int[19,19];
        bool flag = false;  // false = 검은 돌, true = 흰돌
        bool wintrigger = false;
        bool startflag = false;
        short[] xyomok = new short[2];
        short[] xomok = new short[2];
        short[] yomok = new short[2];
        Graphics g;
        Pen pen;
        Brush wBrush, bBrush;
        SoundPlayer simpleSound = new SoundPlayer(@"C:/Users/user/source/repos/omokproto1/omokproto1/Resources/dolsound.wav");
        public Form1()
        {

            InitializeComponent();
            g = omokpan.CreateGraphics();
            this.Text = "omok";
            omokpan.BackColor = Color.Orange;

            pen = new Pen(Color.Black);
            bBrush = new SolidBrush(Color.Black);
            wBrush = new SolidBrush(Color.White);

            this.ClientSize = new Size(2 * margin + 18 * gridSize + 330,
              2 * margin + 18 * gridSize + 20);
            DrawBoard();
        }


        void DrawBoard()
        {
            // panel1에 Graphics 객체 생성
            g = omokpan.CreateGraphics();

            // 세로선 19개
            for (int i = 0; i < 19; i++)
            {
                g.DrawLine(pen, new Point(margin + i * gridSize, margin),
                  new Point(margin + i * gridSize, margin + 18 * gridSize));
            }

            // 가로선 19개
            for (int i = 0; i < 19; i++)
            {
                g.DrawLine(pen, new Point(margin, margin + i * gridSize),
                  new Point(margin + 18 * gridSize, margin + i * gridSize));
            }

            // 화점그리기
            for (int x = 3; x <= 15; x += 6)
                for (int y = 3; y <= 15; y += 6)
                {
                    g.FillEllipse(bBrush,
                      margin + gridSize * x - checkshapeSize / 2,
                      margin + gridSize * y - checkshapeSize / 2,
                      checkshapeSize, checkshapeSize);
                }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            win_lb.Text = "omoking...";
            startflag = true;
            for (int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 19; j++)
                {
                    omokpans[i, j] = 0;
                }
            }
            omokpan.Refresh();
            DrawBoard();
        }

        public void winningtext(int flag)
        {
            if (flag == X)
            {
                if (xomok[0] == 5)
                {
                    win_lb.Text = "black win!";
                    startflag = false;
                }
                if (xomok[1] == 5)
                {
                    win_lb.Text = "white win!";
                    startflag = false;
                }
                xomok[0] = 0;
                xomok[1] = 0;
            }
            else if (flag == Y)
            {
                if (yomok[0] == 5)
                {
                    win_lb.Text = "black win!";
                    startflag = false;
                }
                if (yomok[1] == 5)
                {
                    win_lb.Text = "white win!";
                    startflag = false;
                }
                yomok[0] = 0;
                yomok[1] = 0;
            }
            else if (flag == XY)
            {
                if (xyomok[0] == 5)
                {
                    win_lb.Text = "black win!";
                    startflag = false;
                }
                if (xyomok[1] == 5)
                {
                    win_lb.Text = "white win!";
                    startflag = false;
                }
                xyomok[0] = 0;
                xyomok[1] = 0;
            }
            
        }

        private void omokpan_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (startflag) { 
                simpleSound.Play();
                // e.X는 픽셀단위, x는 바둑판 좌표
                int x = (e.X - margin + gridSize / 2) / gridSize;
                int y = (e.Y - margin + gridSize / 2) / gridSize;

                if (omokpans[x, y] != 0)
                    return;

                // 바둑판[x,y] 에 돌을 그린다
                r = new Rectangle(
                  margin + gridSize * x - stoneSize / 2,
                  margin + gridSize * y - stoneSize / 2,
                  stoneSize, stoneSize);

                // 검은돌 차례
                if (flag == false)
                {

                    Bitmap bmp = new Bitmap("C:/Users/user/source/repos/omokproto1/omokproto1/Resources/blackdol.png");
                    g.DrawImage(bmp, r);

                    flag = true;
                    omokpans[x, y] = 1;
                }
                else
                {
                    g.FillEllipse(wBrush, r);
                    Bitmap bmp = new Bitmap("C:/Users/user/source/repos/omokproto1/omokproto1/Resources/whitedol.png");
                    g.DrawImage(bmp, r);

                    flag = false;
                    omokpans[x, y] = 2;
                }
                int i=0, j=0;
                for (i = x - 4; i <= x + 4; i++)
                {
                    for (j = y - 4; j <= y + 4; j++)
                    {
                        
                        if (omokpans[i, j] == 1) yomok[0]++;
                        else if (omokpans[i, j] == 2) yomok[1]++;
                    }
                    winningtext(Y);
                }

                for (j = x - 4; j <= x + 4; j++)
                {
                    for (i = y - 4; i <= y + 4; i++)
                    {

                        if (omokpans[i, j] == 1) xomok[0]++;
                        else if (omokpans[i, j] == 2) xomok[1]++;
                    }
                    winningtext(X);
                }

                i = x - 4;
                for (j = y - 4; j <= y + 4; j++)
                {
                    if (omokpans[i, j] == 1) xyomok[0]++;
                    else if (omokpans[i, j] == 2) xyomok[1]++;

                    i++;

                }
                winningtext(XY);

                i = x + 4;
                for (j = y - 4; j <= y + 4; j++)
                {
                    if (omokpans[i, j] == 1) xyomok[0]++;
                    else if (omokpans[i, j] == 2) xyomok[1]++;
                    i--;
                }
                winningtext(XY);

            }
        }
    }
}
