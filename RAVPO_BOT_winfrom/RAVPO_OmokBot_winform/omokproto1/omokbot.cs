using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Action = System.Action;
using Mat = OpenCvSharp.CPlusPlus.Mat;
using Point = System.Drawing.Point;

namespace omokproto1
{
    public enum BlockType
    {
        Empty,
        BlackStone,
        WhiteStone
    }

    public enum Diffcult
    {
        Normal,
        Hard,
        Jiwan
    }


    public partial class omokbot : Form
    {
        private VideoCapture beforecap = new VideoCapture(0);
        private Mat srcb = new Mat();
        static bool toggle;
        private VideoCapture aftercap;
        private Mat srca = new Mat();

        private const int BoardWidth = 11; //보드의 각 줄
        private const int BoardMargin = 50; //보드 마진
        private const int BoardCircleSize = 10; // 격자점 크기
        private const int BoardStoneSize = 42;
        private Random rnd = new Random();
        private readonly int[,] BoardDirection = new int[4, 2] { { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 } };
        private int[,] Ai_point = new int[5, 4];

        private int jiwancount;
        private int AIDelay = 2000;
        private Rectangle BoardSize;
        private BlockType[,] BoardGrid = new BlockType[BoardWidth, BoardWidth];
        BlockType[,] general_grid = new BlockType[BoardWidth, BoardWidth];
        BlockType[,] prev_grid = new BlockType[BoardWidth, BoardWidth];
        private Diffcult level;
        private Graphics g;

        private Image sprite_Blackstone;
        private Image sprite_Whitestone;

        private SoundPlayer sound_Placestone = new SoundPlayer(@"C:\Users\user\source\repos\RAVPO\RAVPO_BOT_winfrom\RAVPO_OmokBot_winform\omokproto1\Resources\dols.wav");
        private int fin_w;
        private bool Game_Run = false; 
        private BlockType Game_Turn = BlockType.BlackStone;

        private BlockType Game_Winner = BlockType.Empty;
        private Point c;
        private HierarchyIndex h;
        private int fin_x = -10, fin_y = -10, finend_x = -10, finend_y = -10;
        private BlockType Ai_stone = BlockType.WhiteStone;
        private Point Ai_lastPlace = new Point(-1, -1);
        private BlockType User_stone = BlockType.BlackStone;
        private Point User_lastPlace = new Point(-1, -1);

        private Font Game_font = new Font("Gulim", 10, System.Drawing.FontStyle.Bold);
        private Pen wp = new Pen(Color.White, 6);
        private Pen bp = new Pen(Color.Black, 6);
        private Pen PS = new Pen(Color.Red, 6);

        public omokbot()
        {
            InitializeComponent();
            win_lb.Text = "omoking...";
            //리소스 로드
            sprite_Blackstone = omokproto1.Properties.Resources.blackdol;
            sprite_Whitestone = omokproto1.Properties.Resources.whitedol;

            //보드 사이즈 생성과 보드 길이 유효성 체크
            if (BoardWidth % 2 == 0)
                throw new System.ArgumentException("BoardWidth must be Odd number");
            if (BoardWidth < 3)
                throw new System.ArgumentException("BoardWidth must be higher than 2");
            BoardSize = new Rectangle(BoardMargin, BoardMargin, omokpan.Width - BoardMargin * 2, omokpan.Height - BoardMargin * 2);

            //그래픽스 생성 밑 그리기 시작
            g = omokpan.CreateGraphics();
            omokpan.Refresh();

            //AI 평점 설정
            Ai_point[1, 0] = 1;  //xxOxx, 0xxxx
            Ai_point[2, 0] = 4;  // x00xx
            Ai_point[2, 1] = 3;  // x0x0x
            Ai_point[2, 2] = 2;  // x0xx0
            Ai_point[2, 3] = 1;  // 0xxx0
            Ai_point[3, 0] = 18; //x000x
            Ai_point[3, 1] = 17; //00x0x
            Ai_point[3, 2] = 16; //0x0x0
            Ai_point[4, 0] = 73; //0000x
            Ai_point[4, 1] = 72; //0x000
        }

        private void omokbot_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 115200;
            serialPort1.Open();
            serialPort1.DataReceived += SerialPort1_DataReceived;
            DetectShape();
        }

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.Invoke(new Action(() => listView1.Items.Add(serialPort1.ReadLine())));

        }

        private void difficult_changed(object _, EventArgs __)
        {
            beforecap.Read(srcb);
            Cv2.ImWrite("p90.jpg", srcb);
            if (normal_rb.Checked)
            {
                level = Diffcult.Normal;
                Ai_point[1, 0] = 1; //xxOxx, 0xxxx
                Ai_point[2, 0] = 2; // x00xx
                Ai_point[2, 1] = 3; // x0x0x
                Ai_point[2, 2] = 4; // x0xx0
                Ai_point[2, 3] = 5; // 0xxx0
                Ai_point[3, 0] = 6; //x000x
                Ai_point[3, 1] = 7; //00x0x
                Ai_point[3, 2] = 8; //0x0x0
                Ai_point[4, 0] = 9; //0000x
                Ai_point[4, 1] = 10;//0x000
                explainer_lb.Text = "보통의 난이도로 초등 수준의 난이도 입니다.";
            }
            else if (hard_rb.Checked)
            {
                level = Diffcult.Hard;
                Ai_point[1, 0] = 1; //xxOxx, 0xxxx
                Ai_point[2, 0] = 4; // x00xx
                Ai_point[2, 1] = 3; // x0x0x
                Ai_point[2, 2] = 2; // x0xx0
                Ai_point[2, 3] = 1; // 0xxx0
                Ai_point[3, 0] = 18; //x000x
                Ai_point[3, 1] = 17; //00x0x
                Ai_point[3, 2] = 16; //0x0x0
                Ai_point[4, 0] = 73; //0000x
                Ai_point[4, 1] = 72; //0x000
                explainer_lb.Text = "어려움의 난이도로 고등 수준의 난이도 입니다.";
            }
            else if (jiwan_rb.Checked)
            {
                level = Diffcult.Jiwan;
                explainer_lb.Text = "대소고에 재학중인 한지완 학생이\r\n\r\n AI를 원격으로 조종합니다.";
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("start");
            if (Game_Run)
            {
                explainer_lb.Text = "                                                         ";
                Game_Run = false;
                start_btn.Text = "start";
                BoardGrid = new BlockType[BoardWidth, BoardWidth];
                general_grid = new BlockType[BoardWidth, BoardWidth];
                prev_grid = new BlockType[BoardWidth, BoardWidth];
                omokpan.Refresh();
            }
            else
            {
                fin_x = -10; fin_y = -10; finend_x = -10; finend_y = -10;
                Game_Run = true;
                start_btn.Text = "stop";

                BoardGrid = new BlockType[BoardWidth, BoardWidth];
                Game_Winner = BlockType.Empty;

                if (cmb_first.Text == "유저 선수")
                {
                    Ai_stone = BlockType.WhiteStone;
                    User_stone = BlockType.BlackStone;

                    //action_Place_stone(User_stone, BoardWidth / 2, BoardWidth / 2);
                    Game_Turn = Ai_stone;

                    timer1.Interval = AIDelay;
                    timer1.Enabled = true;
                }
                else
                {
                    Ai_stone = BlockType.BlackStone;
                    User_stone = BlockType.WhiteStone;

                    //action_Place_stone(Ai_stone, BoardWidth / 2, BoardWidth / 2);
                    Game_Turn = User_stone;
                }
            }
        }

        private void omokpan_MouseDown_1(object sender, MouseEventArgs e)
        {
            bool run = true;
            if (Game_Run && Game_Turn == User_stone)
            {
                for (int x = 0; x < BoardWidth && run; ++x)
                {
                    for (int y = 0; y < BoardWidth && run; ++y)
                    {
                        if (BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardStoneSize / 2 < e.X && e.X < BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardStoneSize / 2 + BoardStoneSize &&
                            BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardStoneSize / 2 < e.Y && e.Y < BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardStoneSize / 2 + BoardStoneSize)
                        {
                            if (BoardGrid[x, y] == BlockType.Empty)
                            {
                                action_Place_stone(User_stone, x, y);
                                User_lastPlace = new Point(x, y);
                                Game_Turn = Ai_stone;
                                if (x == User_lastPlace.X && y == User_lastPlace.Y)
                                {
                                    g.DrawString("User", Game_font, Ai_stone == BlockType.BlackStone ? Brushes.Black : Brushes.White, BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardStoneSize / 2, BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardStoneSize / 2);
                                }
                                if (!action_Check_Winner())
                                {
                                    timer1.Interval = AIDelay;
                                    timer1.Enabled = true;
                                }
                            }
                            run = false;
                        }
                    }
                }
            }
        }

        private void action_Place_stone(BlockType type, int x, int y)
        {
            sound_Placestone.Play();
            BoardGrid[x, y] = type;
            omokpan.Refresh();
        }

        private void SerialSend_bt_Click(object sender, EventArgs e)
        {
            serialPort1.Write(X_tb.Text);
            Thread.Sleep(10);
            serialPort1.Write(Y_tb.Text);
        }

        private bool action_Check_Winner()
        {
            BlockType winner = BlockType.Empty;
            for (int x = 0; x < BoardWidth && winner == BlockType.Empty; ++x)
            {
                for (int y = 0; y < BoardWidth && winner == BlockType.Empty; ++y)
                {
                    for (int w = 0; w < 4; ++w)
                    {
                        int end_x = x + BoardDirection[w, 0] * 5;
                        int end_y = y + BoardDirection[w, 1] * 5;
                        if (0 <= end_x && end_x < BoardWidth && 0 <= end_y && end_y < BoardWidth)
                        {
                            //승패 결정
                            {
                                Point pos = new Point(x, y);
                                BlockType owner = BlockType.Empty;

                                for (int i = 0; i < 5; ++i)
                                {
                                    if (owner == BlockType.Empty && BoardGrid[pos.X, pos.Y] != BlockType.Empty)
                                    {
                                        owner = BoardGrid[x, y];
                                    }
                                    else if (owner != BlockType.Empty && BoardGrid[pos.X, pos.Y] != owner)
                                    {
                                        owner = BlockType.Empty;
                                        break;
                                    }

                                    if (owner == BlockType.Empty)
                                    {
                                        break;
                                    }
                                    pos.X += BoardDirection[w, 0];
                                    pos.Y += BoardDirection[w, 1];
                                }

                                if (owner != BlockType.Empty)
                                {
                                    winner = owner;
                                    Game_Winner = winner;
                                    fin_x = x;
                                    fin_y = y;
                                    finend_x = end_x;
                                    finend_y = end_y;
                                    fin_w = w;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (winner != BlockType.Empty)
            {
                if (level == Diffcult.Jiwan)
                {
                    win_lb.Text = "Winner is Jiwan";
                }
                else win_lb.Text = "Winner is " + winner.ToString();

                jiwancount = 0;
                Game_Run = false;
                start_btn.Text = "start";
                this.omokpan.Paint += new System.Windows.Forms.PaintEventHandler(this.Omokpan_Paint);
                omokpan.Refresh();
                return true;
            }
            return false;
        }

        private void cvtimer_Tick(object sender, EventArgs e)
        {
            
            beforecap.Read(srcb);
            Cv2.ImWrite("p90.jpg", srcb);
            DetectShape();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int x = 0; x < 11; x++)
            {
                for(int y = 0; y < 11; y++)
                {
                    prev_grid[x, y] = general_grid[x, y];
                }
            }
            
            cvtimer.Enabled = true;
        }

        private void Omokpan_Paint(object sender, PaintEventArgs e)
        {
            //가로선과 세로선 긋기
            for (int i = 0; i < BoardWidth; i++)
            {
                //가로선
                g.DrawLine(Pens.Black,
                    BoardSize.X + BoardSize.Width * i / (BoardWidth - 1),
                    BoardSize.Y,
                    BoardSize.X + BoardSize.Width * i / (BoardWidth - 1),
                    BoardSize.Y + BoardSize.Height
                );

                //세로선
                g.DrawLine(Pens.Black,
                    BoardSize.X,
                    BoardSize.Y + BoardSize.Height * i / (BoardWidth - 1),
                    BoardSize.X + BoardSize.Width,
                    BoardSize.Y + BoardSize.Height * i / (BoardWidth - 1)
                );
            }

            const int BoardCenter = (BoardWidth) / 2;

            //화점 그리기
            for (int x = 1; x < BoardWidth - 1; ++x)
            {
                for (int y = 1; y < BoardWidth - 1; ++y)
                {
                    if ((x - BoardCenter) % 4 == 0 && (y - BoardCenter) % 4 == 0 && Math.Abs((y - BoardCenter)) == Math.Abs(x - BoardCenter))
                    {
                        g.FillEllipse(Brushes.Black,
                            BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardCircleSize / 2,
                            BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardCircleSize / 2,
                            BoardCircleSize,
                            BoardCircleSize
                        );
                    }
                }
            }

            //돌 그리기
            for (int x = 0; x < BoardWidth; ++x)
            {
                for (int y = 0; y < BoardWidth; ++y)
                {
                    switch (BoardGrid[x, y])
                    {
                        case BlockType.BlackStone:
                            g.DrawImage(sprite_Blackstone,
                                BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardStoneSize / 2,
                                BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardStoneSize / 2,
                                BoardStoneSize,
                                BoardStoneSize
                            );
                            break;

                        case BlockType.WhiteStone:
                            g.DrawImage(sprite_Whitestone,
                                BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardStoneSize / 2,
                                BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardStoneSize / 2,
                                BoardStoneSize,
                                BoardStoneSize
                            );
                            break;
                    }
                    if (x == Ai_lastPlace.X && y == Ai_lastPlace.Y)
                    {
                        g.DrawString("AI", Game_font, Ai_stone == BlockType.WhiteStone ? Brushes.Black : Brushes.White, BoardSize.X + BoardSize.Width * x / (BoardWidth - 1) - BoardStoneSize / 2, BoardSize.Y + BoardSize.Height * y / (BoardWidth - 1) - BoardStoneSize / 2);
                    }
                }
            }

            if (Game_Winner == BlockType.WhiteStone) PS = bp;
            else if (Game_Winner == BlockType.BlackStone) PS = wp;
            switch (fin_w)
            {
                case 0:
                    g.DrawLine(PS, BoardSize.X + BoardSize.Width * fin_x / (BoardWidth - 1),
                                BoardSize.Y + BoardSize.Width * fin_y / (BoardWidth - 1),
                                BoardSize.X + BoardSize.Width * (finend_x - 1) / (BoardWidth - 1),
                                BoardSize.Y + BoardSize.Width * (finend_y) / (BoardWidth - 1));
                    break;

                case 1:
                    g.DrawLine(PS, BoardSize.X + BoardSize.Width * fin_x / (BoardWidth - 1),
                             BoardSize.Y + BoardSize.Width * fin_y / (BoardWidth - 1),
                             BoardSize.X + BoardSize.Width * (finend_x - 1) / (BoardWidth - 1),
                             BoardSize.Y + BoardSize.Width * (finend_y + 1) / (BoardWidth - 1));
                    break;

                case 2:
                    g.DrawLine(PS, BoardSize.X + BoardSize.Width * fin_x / (BoardWidth - 1),
                                BoardSize.Y + BoardSize.Width * fin_y / (BoardWidth - 1),
                                BoardSize.X + BoardSize.Width * (finend_x) / (BoardWidth - 1),
                                BoardSize.Y + BoardSize.Width * (finend_y + 1) / (BoardWidth - 1));
                    break;

                case 3:
                    g.DrawLine(PS, BoardSize.X + BoardSize.Width * fin_x / (BoardWidth - 1),
                                BoardSize.Y + BoardSize.Width * fin_y / (BoardWidth - 1),
                                BoardSize.X + BoardSize.Width * (finend_x + 1) / (BoardWidth - 1),
                                BoardSize.Y + BoardSize.Width * (finend_y + 1) / (BoardWidth - 1));
                    break;

                default: break;
            }
        }

        public void DetectShape()
        {
            
            StringBuilder stringBuilder = new StringBuilder("성능 : ");
            Image<Bgr, Byte> sourceImage = new Image<Bgr, byte>("C:/Users/user/source/repos/RAVPO/RAVPO_BOT_winfrom/RAVPO_OmokBot_winform/omokproto1/bin/Debug/p90.jpg").Resize(400, 600, INTER.CV_INTER_LINEAR, true).Rotate(180, new Bgr());
            Image<Bgr, Byte> oriimage = new Image<Bgr, byte>("C:/Users/user/source/repos/RAVPO/RAVPO_BOT_winfrom/RAVPO_OmokBot_winform/omokproto1/bin/Debug/p90.jpg").Resize(400, 600, INTER.CV_INTER_LINEAR, true).Rotate(180, new Bgr()); ;
            Image<Gray, Byte> grayscaleImage = sourceImage.Convert<Gray, Byte>().PyrDown().PyrUp();


            this.originalImageBox.Image = oriimage;

            #region 원을 검출한다.

            double cannyThreshold = 180.0;
            double circleAccumulatorThreshold = 120;

            CircleF[][] circleArray = grayscaleImage.HoughCircles
            (
                new Gray(cannyThreshold),
                new Gray(circleAccumulatorThreshold),
                2.0,  // 원 중심 검출에 사용되는 누산기 해상도
                20.0, // 최소 거리
                5,    // 최소 반경
                0     // 최대 반경
            );

            #endregion 원을 검출한다.
           
            ;

            #region 선을 검출한다.

            double cannyThresholdLinking = 120.0;

            Image<Gray, Byte> cannyEdges = grayscaleImage.Canny(cannyThreshold, cannyThresholdLinking);

            LineSegment2D[][] lineArray = cannyEdges.HoughLinesBinary
            (
                1,              // 거리 해상도 (픽셀 관련 단위)
                Math.PI / 45.0, // 라디안으로 측정되는 각도 해상도
                20,             // 한계점
                30,             // 최소 선 너비
                10              // 선간 간격
            );

            #endregion 선을 검출한다.

            #region 삼각형과 사각형을 검출한다.

            List<Triangle2DF> triangleList = new List<Triangle2DF>();

            List<MCvBox2D> rectangleList = new List<MCvBox2D>();

            using (MemStorage storage = new MemStorage())
            {
                for (Contour<Point> pointContour = cannyEdges.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, RETR_TYPE.CV_RETR_LIST, storage); pointContour != null; pointContour = pointContour.HNext)
                {
                    Contour<Point> currentContour = pointContour.ApproxPoly(pointContour.Perimeter * 0.1, storage);

                    if (currentContour.Area > 1000)
                    {
                        if (currentContour.Total == 3) // 삼각형인 경우
                        {
                            Point[] pointArray = currentContour.ToArray();

                            triangleList.Add(new Triangle2DF(pointArray[0], pointArray[1], pointArray[2]));
                        }
                        else if (currentContour.Total == 4) // 사각형인 경우
                        {
                            #region 윤곽의 모든 각도가 [80, 100]도 이내인지 결정한다.

                            bool isRectangle = true;

                            Point[] pointArray = currentContour.ToArray();

                            LineSegment2D[] edgeArray = PointCollection.PolyLine(pointArray, true);

                            for (int i = 0; i < edgeArray.Length; i++)
                            {
                                double angle = Math.Abs(edgeArray[(i + 1) % edgeArray.Length].GetExteriorAngleDegree(edgeArray[i]));

                                if (angle < 80 || angle > 100)
                                {
                                    isRectangle = false;

                                    break;
                                }
                            }

                            #endregion 윤곽의 모든 각도가 [80, 100]도 이내인지 결정한다.

                            if (isRectangle)
                            {
                                rectangleList.Add(currentContour.GetMinAreaRect());
                            }
                        }
                    }
                }
            }

            #endregion 삼각형과 사각형을 검출한다.

            Text = stringBuilder.ToString();

            #region 삼각형/사각형을 그린다.

            Image<Bgr, Byte> triangleRectangleImage = sourceImage.CopyBlank();

            foreach (Triangle2DF triangle in triangleList)
            {
                triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
            }
            int count = 0;

            foreach (MCvBox2D rectangle in rectangleList)
            {
                //void foo()
                {
                    PointF[] vtx = rectangle.GetVertices();
                    Point[] pts = new Point[vtx.Length];
                    for (int i = 0; i < vtx.Length; ++i) pts[i] = new Point((int)vtx[i].X, (int)vtx[i].Y);

                    List<FloatInt> fv = new List<FloatInt>();

                    for (int i = 0; i < 4; ++i) fv.Add(new FloatInt { f = vtx[i].X, i = i });
                    fv.Sort();

                    PointF[,] vetx = new PointF[2, 2];
                    if (vtx[fv[0].i].Y < vtx[fv[1].i].Y)
                    {
                        vetx[1, 0] = vtx[fv[0].i];
                        vetx[1, 1] = vtx[fv[1].i];
                    }
                    else
                    {
                        vetx[1, 0] = vtx[fv[1].i];
                        vetx[1, 1] = vtx[fv[0].i];
                    }
                    if (vtx[fv[2].i].Y < vtx[fv[3].i].Y)
                    {
                        vetx[0, 0] = vtx[fv[2].i];
                        vetx[0, 1] = vtx[fv[3].i];
                    }
                    else
                    {
                        vetx[0, 0] = vtx[fv[3].i];
                        vetx[0, 1] = vtx[fv[2].i];
                    }



                    float width = (float)Math.Sqrt(Math.Pow(vetx[1, 0].X - vetx[0, 0].X, 2) + Math.Pow(vetx[1, 0].Y - vetx[0, 0].Y, 2));
                    float[,] trans = new float[2, 2];
                    float rad = (float)Math.Atan2(vetx[1, 0].Y - vetx[0, 0].Y, vetx[1, 0].X - vetx[0, 0].X);
                    Image<Bgr, Byte>[,] grids = new Image<Bgr, Byte>[11, 11];
                    trans[0, 0] = +(float)Math.Cos(rad);
                    trans[1, 0] = -(float)Math.Sin(rad);
                    trans[0, 1] = +(float)Math.Sin(rad);
                    trans[1, 1] = +(float)Math.Cos(rad);

                    for (int x = 0; x < 11; ++x)
                    {
                        for (int y = 0; y < 11; ++y)
                        {
                            PointF[] abstractPoint = new PointF[4]
                            {
                                new PointF((x - 0.5f) / 10, (y - 0.5f) / 10),
                                new PointF((x + 0.5f) / 10, (y - 0.5f) / 10),
                                new PointF((x + 0.5f) / 10, (y + 0.5f) / 10),
                                new PointF((x - 0.5f) / 10, (y + 0.5f) / 10)
                            };

                            Point[] drawpts = new Point[4];
                            for (int i = 0; i < 4; ++i)
                            {

                                drawpts[i] = new Point(
                                    (int)(vetx[0, 0].X + 
                                    width * abstractPoint[i].X * trans[0, 0] +
                                    width * abstractPoint[i].Y * trans[1, 0]
                                    ),
                                    (int)(vetx[0, 0].Y +
                                    width * abstractPoint[i].X * trans[0, 1] +
                                    width * abstractPoint[i].Y * trans[1, 1]
                                    )
                                );
                            }

                            sourceImage.DrawPolyline(drawpts, true, new Bgr(Color.Red), 1);
                            int redsum=0, greensum=0, bluesum=0;
                            int redp=0, bluep=0;
                            int pixelvalue=0;
                            for (int i = 0; i < (drawpts[1].X - drawpts[0].X); ++i)
                            {
                                for (int j = 0; j < (drawpts[2].Y - drawpts[0].Y); ++j)
                                {

                                     int sat =  ( oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j, 0]+
                                                  oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j, 1]+
                                                  oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j, 2])/3;



                                        bluesum += oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j, 0];
                                        greensum += oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j, 1];
                                        redsum += oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j, 2];
                                        pixelvalue++;
                                    
                                    //oriimage.Data[drawpts[0].Y + i, drawpts[0].X + j,1] = 255; 
                                    
                                }
                            }
                            redsum = redsum / pixelvalue;
                            bluesum = bluesum / pixelvalue;
                            greensum = greensum / pixelvalue;

                            redp = redsum - ((bluesum + greensum) / 2);
                            bluep = bluesum - ((redsum + greensum) / 2);

                            for (int i = 0; i < (drawpts[1].X - drawpts[0].X); ++i)
                            {
                                for (int j = 0; j < (drawpts[2].Y - drawpts[0].Y); ++j)
                                {

                                    if (redp > 15)
                                    {
                                        sourceImage.Data[drawpts[0].Y + i, drawpts[0].X + j, 2] = 255;
                                        sourceImage.Data[drawpts[0].Y + i, drawpts[0].X + j, 1] = 100;
                                        sourceImage.Data[drawpts[0].Y + i, drawpts[0].X + j, 0] = 100;
                                        
                                    }
                                    else if (general_grid[x,y]==BlockType.BlackStone||bluep > 14)
                                    {
                                        sourceImage.Data[drawpts[0].Y + i, drawpts[0].X + j, 0] = 255;
                                        sourceImage.Data[drawpts[0].Y + i, drawpts[0].X + j, 1] = 100;
                                        sourceImage.Data[drawpts[0].Y + i, drawpts[0].X + j, 2] = 100;
                                        general_grid[x, y] = BlockType.BlackStone;
                                    }
                                    
                                }
                            }
                            if (prev_grid[x, y] != general_grid[x, y])
                            {
                                action_Place_stone(BlockType.BlackStone,x,y);
                                cvtimer.Enabled = false;
                                timer1.Enabled = true;
                                timer1.Interval = AIDelay;
                            }





                        }
                    }


                }


                count++;
            }

            this.cap_btn.Image = sourceImage;

            #endregion 삼각형/사각형을 그린다.

            #region 원을 그린다.

            Image<Bgr, Byte> circleImage = sourceImage.CopyBlank();

            foreach (CircleF circle in circleArray[0])
            {
                circleImage.Draw(circle, new Bgr(Color.Brown), 2);
            }

            #endregion 원을 그린다.

            #region 선을 그린다.

            Image<Bgr, Byte> lineImage = sourceImage.CopyBlank();

            foreach (LineSegment2D line in lineArray[0])
            {
                lineImage.Draw(line, new Bgr(Color.Green), 2);
            }

            #endregion 선을 그린다.
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            AIDelay = rnd.Next(500, 5000);
            for (int _ = 0; _ < ((Diffcult.Jiwan == level && jiwancount % 5 == 0) ? 2 : 1); ++_)
            {
                jiwancount++;
                double[,] ai_benefit = new double[BoardWidth, BoardWidth];
                double[,] user_benefit = new double[BoardWidth, BoardWidth];
                for (int x = 0; x < BoardWidth; ++x)
                {
                    for (int y = 0; y < BoardWidth; ++y)
                    {
                        for (int w = 0; w < 4; ++w)
                        {
                            int end_x = x + BoardDirection[w, 0] * 5;
                            int end_y = y + BoardDirection[w, 1] * 5;
                            if (0 <= end_x && end_x < BoardWidth && 0 <= end_y && end_y < BoardWidth)
                            {
                                //User Benefit 계산
                                {
                                    int count = 0;
                                    int start = -1;
                                    int end = -1;
                                    Point pos = new Point(x, y);
                                    for (int i = 0; i < 5; ++i)
                                    {
                                        if (BoardGrid[pos.X, pos.Y] == Ai_stone)
                                        {
                                            count = 0;
                                            //5개를 이어서 놓을수 없는 자리
                                            break;
                                        }
                                        else if (BoardGrid[pos.X, pos.Y] == User_stone)
                                        {
                                            if (start == -1) start = i;
                                            end = i;
                                            ++count;
                                        }
                                        pos.X += BoardDirection[w, 0];
                                        pos.Y += BoardDirection[w, 1];
                                    }

                                    if (count > 0)
                                    {
                                        //돌 사이의 빈 공간
                                        int space = end - start + 1 - count;

                                        double score = Ai_point[count, space];
                                        pos = new Point(x, y);
                                        for (int i = 0; i < 5; ++i)
                                        {
                                            user_benefit[pos.X, pos.Y] += score;
                                            pos.X += BoardDirection[w, 0];
                                            pos.Y += BoardDirection[w, 1];
                                        }
                                    }
                                }

                                //AI Benefit 계산
                                {
                                    int count = 0;
                                    int start = -1;
                                    int end = -1;
                                    Point pos = new Point(x, y);
                                    for (int i = 0; i < 5; ++i)
                                    {
                                        if (BoardGrid[pos.X, pos.Y] == User_stone)
                                        {
                                            count = 0;
                                            //5개를 이어서 놓을수 없는 자리
                                            break;
                                        }
                                        else if (BoardGrid[pos.X, pos.Y] == Ai_stone)
                                        {
                                            if (start == -1) start = i;
                                            end = i;
                                            ++count;
                                        }
                                        pos.X += BoardDirection[w, 0];
                                        pos.Y += BoardDirection[w, 1];
                                    }

                                    if (count > 0)
                                    {
                                        //돌 사이의 빈 공간
                                        int space = end - start + 1 - count;

                                        double score = Ai_point[count, space];
                                        if (count == 4) score *= 10;
                                        pos = new Point(x, y);
                                        for (int i = 0; i < 5; ++i)
                                        {
                                            ai_benefit[pos.X, pos.Y] += score;
                                            pos.X += BoardDirection[w, 0];
                                            pos.Y += BoardDirection[w, 1];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                double best_score = -1;
                Point best_pos = new Point(-1, -1);

                for (int x = 0; x < BoardWidth; ++x)
                {
                    for (int y = 0; y < BoardWidth; ++y)
                    {
                        if (BoardGrid[x, y] == BlockType.Empty)
                        {
                            double score = ai_benefit[x, y] + (level != Diffcult.Jiwan ? user_benefit[x, y] : 0.0);
                            if (score > best_score)
                            {
                                best_score = score;
                                best_pos = new Point(x, y);
                            }
                        }
                    }
                }

                Ai_lastPlace = best_pos;
                serialPort1.Write(best_pos.X.ToString());
                Thread.Sleep(10);
                serialPort1.Write(best_pos.Y.ToString());
                action_Place_stone(Ai_stone, best_pos.X, best_pos.Y);
            }
            Game_Turn = User_stone;

            action_Check_Winner();

            timer1.Enabled = false;
        }
    }
    internal class FloatInt : IComparable
    {
        public float f;
        public int i;

        public int CompareTo(Object Item)
        {
            FloatInt that = (FloatInt)Item;

            if (this.f > that.f)
                return -1;
            if (this.f < that.f)
                return 1;

            if (this.f > that.f)
                return -1;
            if (this.f < that.f)
                return 1;

            return 0;
        }
    }
}