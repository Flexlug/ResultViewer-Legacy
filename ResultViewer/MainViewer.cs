using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultViewer
{
    public partial class MainViewer : Form
    {
        private int[][] JuryChoise;


        private Color ContBarColor;
        private Color sndContBarColor;
        private int ContBarFontSize;
        private int ContBarWidth;
        private int ContBarHeight;

        private int XNum;
        private int YNum;

        private Color PointBarColor;
        private Color sndPointBarColor;
        private int PointBarWidth;
        private int PointBarHeight;
        private int PointBarInterval;
        private int PointBarFontSize;

        private Color JuryBarColor;
        private Color sndJuryBarColor;
        private int JuryBarWidth;
        private int JuryBarHeight;
        private int JuryBarFontSize;

        private string QuitFrase;
        private bool LastFrameAppeared = false;

        private int FrameRate = 10;
        private int FrameInterval = 10;

        


        private string[] ContestList;
        private List<JuryBar> JuryBarList;
        private List<ContestBar> ContestBarList;
        private List<PointBar> PointBarList;
        private bool inited = false;
        private int currentJury = 0;
        private int currentPoint = 0;
        private Point StartPoint;
        private Point DestinationPoint;

        private int xStep;
        private int yStep;

        private int aStep;
        private int rStep;
        private int gStep;
        private int bStep;

        private int PersonPromoted;
        private int PersonColored = -1;        

        private int frame = 0;

        private bool isWorking = false;

        Graphics MainDrawer;

        private void GetSettings(main MainForm)
        {
            ContBarColor = MainForm.ContBarColor;
            sndContBarColor = MainForm.sndContBarColor;
            ContBarFontSize = MainForm.ContBarFontSize;
            ContBarWidth = MainForm.ContBarWidth;
            ContBarHeight = MainForm.ContBarHeight;

            XNum = MainForm.XNum;
            YNum = MainForm.YNum;
            FrameRate = MainForm.FrameRate;
            FrameInterval = MainForm.FrameInterval;
            QuitFrase = MainForm.QuitFrase;

            PointBarColor = MainForm.PointBarColor;
            sndPointBarColor = MainForm.sndPointBarColor;
            PointBarWidth = MainForm.pointBarWidth;
            PointBarHeight = MainForm.pointBarHeight;
            PointBarInterval = MainForm.pointBarInterval;
            PointBarFontSize = MainForm.pointBarFontSize;

            JuryBarColor = MainForm.JuryBarColor;
            sndJuryBarColor = MainForm.sndJuryBarColor;
            JuryBarWidth = MainForm.JuryBarWidth;
            JuryBarHeight = MainForm.JuryBarHeight;
            JuryBarFontSize = MainForm.JuryBarFontSize;


            ContestList = new string[MainForm.contestList.Length];
            Array.Copy(MainForm.contestList, ContestList, MainForm.contestList.Length);
        }



        private void FillPointBarList(main MainForm)
        {
            PointBarList = new List<PointBar>();
            for (int i = 0; i < 10; i++)
            {
                PointBarList.Add(new PointBar(GetStartPointBarCord(i + 1),
                                              i + 1,
                                              PointBarFontSize,
                                              PointBarWidth,
                                              PointBarHeight,
                                              PointBarColor,
                                              sndPointBarColor));
            }
        }



        private void FillJuryChoise(main MainForm)
        {
            JuryChoise = new int[MainForm.juryChoise.Length][];
            for (int i = 0; i < MainForm.juryChoise.Length; i++)
            {
                JuryChoise[i] = new int[10];
            }

            Array.Copy(MainForm.juryChoise, JuryChoise, MainForm.juryChoise.Length);
        }



        private void FillJuryBarList(main MainForm)
        {
            JuryBarList = new List<JuryBar>();
            for (int i = 0; i < MainForm.juryList.Length; i++)
            {
                JuryBarList.Add(new JuryBar(GetStartContestBarCord(-1),
                                            MainForm.juryList[i],
                                            JuryBarFontSize,
                                            JuryBarWidth,
                                            JuryBarHeight,
                                            JuryBarColor));
                                            
            }
        }



        private void FillContestBarList(main MainForm)
        {
            ContestBarList = new List<ContestBar>();
            for (int i = 1; i < MainForm.contestList.Length; i++)
            {
                ContestBarList.Add(new ContestBar(GetStartContestBarCord(i),
                                                  MainForm.contestList[i],
                                                  ContBarFontSize,
                                                  ContBarWidth,
                                                  ContBarHeight,
                                                  ContBarColor));
            }
        }

        private void RefreshBackGroundImage()
        {
            this.BackgroundImage = Properties.Resources.mainViewerBcg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }



        private Point GetStartContestBarCord(int i)
        {
            return new Point((this.Width / XNum) - (ContBarWidth / 2),
                             (this.Height / YNum * (i + 3)) - (ContBarHeight / 2));
        }



        private Point GetStartPointBarCord(int i)
        {
            int bi = i;
            i = i <= 5? i -= 5 : i -= 6;
            return new Point((this.Width / 2) + (PointBarWidth * i) + (PointBarInterval * i) + ((PointBarInterval / 2) * (bi > 5 ? 1 : -1)) + ((PointBarWidth / 2) * (bi > 5 ? 1 : -1)) - (PointBarWidth / 2),
                              (this.Height / YNum * 2) - (PointBarHeight / 2));
        }



        private void DrawBars()
        {
            this.MainDrawer.Clear(Color.Transparent);

            foreach(ContestBar cb in ContestBarList)
            {
                cb.Draw(MainDrawer);
            }

            foreach(PointBar pb in PointBarList)
            {
                pb.Draw(MainDrawer);
            }

            JuryBarList[currentJury].Draw(MainDrawer);

            MainPictureBox.Invalidate();
        }



        private void RefreshGraphicsReference()
        {
            MainDrawer = Graphics.FromImage(MainPictureBox.Image);
        }



        private void SetMainDrawer() // ONLY AFTER DIALOG SHOWN!!!!!!
        {
            MainPictureBox.Image = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            RefreshGraphicsReference();
        }
        


        public MainViewer(main MainForm)
        {
            InitFormAndControls();
            GetSettings(MainForm);
            FillJuryChoise(MainForm);
            FillJuryBarList(MainForm);
            FillContestBarList(MainForm);
            FillPointBarList(MainForm);
            RefreshBackGroundImage();

        }

        
        private void RefreshPointBars()
        {
            for (int i = 0; i < 10; i++)
            {
                PointBarList[i].SetAlpha(255);
                PointBarList[i].SetCord(GetStartPointBarCord(i));
            }

            JuryBarList[currentJury].SetAlpha(0);

            DrawBars();
            isWorking = false;
        }



        private void FirstPlacing()
        {
            for (int i = 0; i < 10; i++)
            {
                PointBarList[i].SetCord(GetStartPointBarCord(i + 1));
            }

            for (int i = 0; i < ContestBarList.Count; i++)
            {
                ContestBarList[i].SetCord(GetStartContestBarCord(i + 1));
            }

            for (int i = 0; i < JuryBarList.Count; i++)
            {
                JuryBarList[i].SetCord(GetStartContestBarCord(-2));
            }

            DrawBars();
        }

        /// <summary>
        /// Перемещает выбранный балл к выбранному участнику без анимации
        /// </summary>
        /// <param name="NumOfPoint">Количество баллов (отсчёт начинается с нуля) </param>
        /// <param name="NumOfContest">Номер участника</param>
        private void MovePointToContest(int NumOfPoint, int NumOfContest)
        {
            Point newPosition = ContestBarList[NumOfContest].GetCord();
            newPosition.X -= PointBarInterval + PointBarWidth;
            newPosition.Y += (ContBarHeight - PointBarHeight > 0) ? (ContBarHeight - PointBarHeight) / 2 : (PointBarHeight - ContBarHeight) / 2;
            PointBarList[NumOfPoint].SetCord(newPosition);
        }



        #region Animation




        //*****************************************************//
        //********************STEP 0***************************//
        //*****************************************************//



        private void InitFirstPlacingAnim()
        {
            for (int i = 0; i < 10; i++)
            {
                PointBarList[i].SetAlpha(0);
                PointBarList[i].SetCord(GetStartPointBarCord(i + 1));
            }

            for (int i = 0; i < ContestBarList.Count; i++)
            {
                ContestBarList[i].SetAlpha(0);
                ContestBarList[i].SetCord(GetStartContestBarCord(i + 1));
            }

            for (int i = 0; i < JuryBarList.Count; i++)
            {
                JuryBarList[i].SetAlpha(0);
                JuryBarList[i].SetCord(GetStartContestBarCord(-2));
            }

            aStep = 255 / FrameRate;

            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(AppearAllBarsFrame);

            GraphicsTimer.Start();
        }



        private void AppearAllBarsFrame(object sender, EventArgs e)
        {
            if (frame < FrameRate)
            {
                foreach (PointBar pb in PointBarList)
                {
                    pb.MoveAlpha(aStep);
                }
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.MoveAlpha(aStep);
                }
                JuryBarList[currentJury].MoveAlpha(aStep);
                frame++;
                DrawBars();
            }
            else
            {
                frame = 0;
                foreach(PointBar pb in PointBarList)
                {
                    pb.SetAlpha(255);
                }
                foreach(ContestBar cb in ContestBarList)
                {
                    cb.SetAlpha(255);
                }
                JuryBarList[currentJury].SetAlpha(255);
                GraphicsTimer.Dispose();
                isWorking = false;
            }

        }



        //*****************************************************//
        //*******************STEP 1****************************//
        //*****************************************************//

        private Point GetDestinationPoint(int NumOfContest)
        {
            Point DestinationPoint = ContestBarList[NumOfContest].GetCord();
            DestinationPoint.X -= PointBarInterval + PointBarWidth;
            DestinationPoint.Y += (ContBarHeight - PointBarHeight > 0) ? (ContBarHeight - PointBarHeight) / 2 : (PointBarHeight - ContBarHeight) / 2;

            return DestinationPoint;
        }

        private void InitAnim(int NumOfPoint, int NumOfContest)
        {
            rStep = (sndContBarColor.R - ContBarColor.R) / FrameRate;
            gStep = (sndContBarColor.G - ContBarColor.G) / FrameRate;
            bStep = (sndContBarColor.B - ContBarColor.B) / FrameRate;



            StartPoint = PointBarList[NumOfPoint].GetCords();
            DestinationPoint = GetDestinationPoint(NumOfContest);

            xStep = (DestinationPoint.X - StartPoint.X) / FrameRate;

            yStep = (DestinationPoint.Y - StartPoint.Y) / FrameRate;




            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(DrawPointFrame);
            GraphicsTimer.Start();
            
        }                

        private void ReturnToStockFrame()
        {
            ContestBarList[PersonColored].MoveColor(0, 
                                                  -rStep, 
                                                  -gStep, 
                                                  -bStep);
        }

        private void DrawPointFrame(object sender, EventArgs e)
        {
            if (frame < FrameRate)
            {
                if (PersonColored != -1)
                {
                    ReturnToStockFrame();
                }
                ContestBarList[PersonPromoted].MoveColor(0, rStep, gStep, bStep);
                PointBarList[currentPoint].MovePoint(xStep, yStep);
                frame++;
                DrawBars();
            }
            else
            {
                frame = 0;
                PointBarList[currentPoint].SetCord(DestinationPoint);
                DrawBars();
                GraphicsTimer.Dispose();
                AddPointsToPromoted();
                InitFirstChangeColorAnim();
            }
        }



        //*****************************************************//
        //********************STEP 2***************************//
        //*****************************************************//



        private void InitFirstChangeColorAnim()
        {
            aStep = -(255 / FrameRate);

            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(HideColorFrame);

            GraphicsTimer.Start();
        }

        private void HideColorFrame(object sender, EventArgs e)
        {
            if (frame < FrameRate)
            {
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.MoveColor(aStep, 0, 0, 0);
                }
                PointBarList[currentPoint].MoveColor(aStep, 0, 0, 0);
                frame++;
                DrawBars();
            }
            else
            {
                frame = 0;                
                PointBarList[currentPoint].SetAlpha(0);                
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.MoveColor(255, 0, 0, 0);
                }
                DrawBars();
                GraphicsTimer.Dispose();
                SortAfterPromotion();
                InitSecondChangeColorAnim();
                
            }
        }



        //*****************************************************//
        //********************STEP 3***************************//
        //*****************************************************//

        



        private void InitSecondChangeColorAnim()
        {
            aStep = 255 / FrameRate;
            
            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(AppearColorFrame);

            GraphicsTimer.Start();
        }

        private void AppearColorFrame(object sender, EventArgs e)
        {
            if (frame < FrameRate)
            {
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.MoveColor(aStep, 0, 0, 0);
                }
                frame++;
                DrawBars();
            }
            else
            {
                frame = 0;
                PersonColored = PersonPromoted;
                PersonPromoted = -1;
                currentPoint++;
                GraphicsTimer.Dispose();
                isWorking = false;

            }

        }



        //*****************************************************//
        //********************STEP RETURNING*******************//
        //*****************************************************//       
        

        
        private void InitBarsRefreshAnim()
        {
            aStep = -(255 / FrameRate);

            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(BarsRefreshFrame);

            GraphicsTimer.Start();
        }

        private void BarsRefreshFrame(object sender, EventArgs e)
        {
            if (frame < FrameRate)
            {
                ReturnToStockFrame();
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.MoveAlpha(aStep);
                }
                foreach (PointBar pb in PointBarList)
                {
                    pb.MoveAlpha(aStep);
                }
                JuryBarList[currentJury].MoveAlpha(aStep);
                frame++;
                DrawBars();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    PointBarList[i].SetAlpha(0);
                    PointBarList[i].SetCord(GetStartPointBarCord(i + 1));
                }
                for (int i = 0; i < ContestBarList.Count; i++)
                {
                    ContestBarList[i].SetAlpha(0);
                }

                for (int i = 0; i < JuryBarList.Count; i++)
                {
                    JuryBarList[i].SetAlpha(0);
                }
                frame = 0;
                DrawBars();
                PersonColored = -1;
                currentJury++;
                GraphicsTimer.Dispose();

                if (currentJury == JuryBarList.Count)
                {
                    InitLastRefreshingAnim();
                }
                else
                {
                    ContinueRefreshingAnim();
                }

            }            

        }



        private void ContinueRefreshingAnim()
        {
            aStep = 255 / FrameRate;

            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(AppearAllBarsFrame);

            currentPoint = 0;
            GraphicsTimer.Start();
        }



        //*****************************************************//
        //*******************LAST REFRESHING ANIM**************//
        //*****************************************************//



        private void InitLastRefreshingAnim()
        {
            aStep = 255 / FrameRate;

            rStep = (sndJuryBarColor.R - JuryBarColor.R) / FrameRate;
            gStep = (sndJuryBarColor.G - JuryBarColor.G) / FrameRate;
            bStep = (sndJuryBarColor.B - JuryBarColor.B) / FrameRate;

            currentJury--;
            JuryBarList[currentJury].SetName(QuitFrase);

            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = FrameInterval;
            GraphicsTimer.Tick += new EventHandler(LastRefreshingAnimFrame);


            GraphicsTimer.Start();
        }



        private void LastRefreshingAnimFrame(object sender, EventArgs e)
        {
            if (frame < FrameRate)
            {
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.MoveAlpha(aStep);
                }
                JuryBarList[currentJury].MoveColor(aStep, rStep, gStep, bStep);
                frame++;
                DrawBars();
            }
            else
            {
                frame = 0;
                foreach (ContestBar cb in ContestBarList)
                {
                    cb.SetAlpha(255);
                }
                JuryBarList[currentJury].SetColor(sndJuryBarColor);
                JuryBarList[currentJury].SetAlpha(255);
                GraphicsTimer.Dispose();
                LastFrameAppeared = true;
                isWorking = false;
            }
        }
        
        
        






        #endregion




        private int SeekNextChoise()
        {
            int nextPoint = -1;

            do
            {
                if (JuryChoise[currentJury][currentPoint] > 0)
                {
                    ContestBar cbb = ContestBarList.Find((ContestBar cb) => { return cb.GetContestName() == ContestList[JuryChoise[currentJury][currentPoint]]; }) ;
                    nextPoint = ContestBarList.IndexOf(cbb);
                }
                else
                {
                    currentPoint++;
                }

            } while ((nextPoint == -1) && (currentPoint < 10));

            return nextPoint;
        }

        private void ChangeMembersBetween(int thoseWhoHaveMorePoints)
        {
            int xBuf = ContestBarList[thoseWhoHaveMorePoints - 1].GetCord().X;
            int yBuf = ContestBarList[thoseWhoHaveMorePoints - 1].GetCord().Y;

            ContestBarList[thoseWhoHaveMorePoints - 1].SetCord(ContestBarList[thoseWhoHaveMorePoints].GetCord());
            ContestBarList[thoseWhoHaveMorePoints].SetCord(new Point(xBuf, yBuf));

            ContestBar buf = ContestBarList[thoseWhoHaveMorePoints - 1];
            ContestBarList[thoseWhoHaveMorePoints - 1] = ContestBarList[thoseWhoHaveMorePoints];
            ContestBarList[thoseWhoHaveMorePoints] = buf;
            
        }

        private void SortAfterPromotion()
        {
            bool done = false;

            while (!done)
            {
                if (PersonPromoted != 0)
                {
                    if (ContestBarList[PersonPromoted].GetNumOfPoints() > ContestBarList[PersonPromoted - 1].GetNumOfPoints())
                    {
                        ChangeMembersBetween(PersonPromoted);
                        PersonPromoted--;
                        
                    }
                    else
                    {
                        done = true;
                    }
                }
                else
                {
                    done = true;
                }
            }
        }

        private void AddPointsToPromoted()
        {
            ContestBarList[PersonPromoted].AddPoints(PointBarList[currentPoint].GetNumOfPoints());
        }

        private void MainPictureBox_Click(object sender, EventArgs e)
        {
            if (!isWorking)
            {
                isWorking = true;
                Start();
            }
        }

        private void Start()
        {
            if (!inited)
            {
                ExitButton.BringToFront();
                SetMainDrawer();
                InitFirstPlacingAnim();
                inited = true;
            }
            else
            {
                if (!LastFrameAppeared)
                {
                    if (currentPoint < 10)
                    {
                        PersonPromoted = SeekNextChoise();
                        if (PersonPromoted != -1)
                        {
                            InitAnim(currentPoint, PersonPromoted);
                        }
                        else
                        {
                            InitBarsRefreshAnim();
                            currentPoint = 0;
                            if (currentJury == JuryBarList.Count)
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else
                    {
                        InitBarsRefreshAnim();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }

            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainViewer
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainViewer";
            this.ResumeLayout(false);

        }

        

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MainViewer_KeyPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.PageUp || (e.KeyCode == Keys.Next)))
            {
                if (!isWorking)
                {
                    isWorking = true;
                    Start();
                }

            }
        }
    }
}
