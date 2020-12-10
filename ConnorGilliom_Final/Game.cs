using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ConnorGilliom_Final
{
    public partial class Game : Form
    {

        //store the board size so the pain method can use it
        private int intBoardSize;

        //game board stores which are alive and dead
        private bool[,] boolArrArrGameBoard;

        //store brushes for setting colors
        Brush brushAlive;
        Brush brushDead;

        //create a timer to automatically progress the game
        private Timer timerTickRate;

        private int speed;

        public Game(int intBoardSize, string strLivingColor, string strDeadColor, Point[] pntArrStartingLiveSquares)
        {
            InitializeComponent();

            //create the game board, since the default value is bool for each
            //square we only need to change the living ones
            boolArrArrGameBoard = new bool[intBoardSize, intBoardSize];

            this.intBoardSize = intBoardSize;
            
            //create two brushes with our given colors
            brushAlive = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#" + strLivingColor));
            brushDead = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#" + strDeadColor));

            //add each living point to the game board
            for (int i = 0; i < pntArrStartingLiveSquares.Length; i++)
            {
                //get the point we are currently adding to the board
                Point pntCurrent = pntArrStartingLiveSquares[i];

                //set the point as alive
                boolArrArrGameBoard[pntCurrent.X, pntCurrent.Y] = true;
            }

            //setup the timer
            timerTickRate = new Timer();
            timerTickRate.Interval = 500;
            timerTickRate.Tick += timerTickRate_Tick;

            //make the panel double buffered to stop flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
              BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
              null, pnlGameBoard, new object[] { true });

        }

        //progress to the next gen each tick
        private void timerTickRate_Tick(object sender, EventArgs e)
        {
            boolArrArrGameBoard = getNextGen();
            pnlGameBoard.Refresh();
        }

        //check the number of alive neighbors for a given point
        //make sure each neighbor is in bounds of the array first
        private int numberOfAliveNeighbors(Point pnt)
        {
            int intNumAlive = 0;

            //top left
            if (pnt.X - 1 >= 0 && pnt.Y - 1 >= 0 && boolArrArrGameBoard[pnt.X - 1, pnt.Y - 1])
            {
                intNumAlive++;
            }

            //top middle
            if (pnt.Y - 1 >= 0 && boolArrArrGameBoard[pnt.X, pnt.Y - 1])
            {
                intNumAlive++;
            }

            //top right
            if (pnt.X + 1 < boolArrArrGameBoard.GetLength(0) && pnt.Y - 1 >= 0 && boolArrArrGameBoard[pnt.X + 1, pnt.Y - 1])
            {
                intNumAlive++;
            }

            //middle left
            if (pnt.X - 1 >= 0 && boolArrArrGameBoard[pnt.X - 1, pnt.Y])
            {
                intNumAlive++;
            }

            //middle right
            if (pnt.X + 1 < boolArrArrGameBoard.GetLength(0) && boolArrArrGameBoard[pnt.X + 1, pnt.Y])
            {
                intNumAlive++;
            }

            //bottom left
            if (pnt.X - 1 >= 0 && pnt.Y + 1 < boolArrArrGameBoard.GetLength(0) && boolArrArrGameBoard[pnt.X - 1, pnt.Y + 1])
            {
                intNumAlive++;
            }
            
            //bottom middle
            if (pnt.Y + 1 < boolArrArrGameBoard.GetLength(0) && boolArrArrGameBoard[pnt.X, pnt.Y + 1])
            {
                intNumAlive++;
            }

            //bottom right
            if (pnt.X + 1 < boolArrArrGameBoard.GetLength(0) && pnt.Y + 1 < boolArrArrGameBoard.GetLength(0) && boolArrArrGameBoard[pnt.X + 1, pnt.Y + 1])
            {
                intNumAlive++;
            }

            return intNumAlive;
        }

        private bool[,] getNextGen()
        {
            //create the next gen for the board
            bool[,] boolArrArrNextGen = new bool[intBoardSize, intBoardSize];

            for(int x = 0; x < boolArrArrGameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < boolArrArrGameBoard.GetLength(0); y++)
                {
                    //get wether the current cell is alive or not
                    bool boolAlive = boolArrArrGameBoard[x, y];

                    //cell is alive run those game rules
                    if (boolAlive)
                    {
                        //get how many live neighbors this cell has
                        int intNumAlive = numberOfAliveNeighbors(new Point(x, y));

                        //if a live cell has 2-3 live nieghbors it stays alive
                        if(intNumAlive >= 2 && intNumAlive <= 3)
                        {
                            boolArrArrNextGen[x, y] = true;
                        }
                        else //all other live cells die
                        {
                            boolArrArrNextGen[x, y] = false;
                        }

                    }
                    else //cell is dead run that game rule
                    {
                        //a dead cell with 3 live neighbors becomes alive
                        if (numberOfAliveNeighbors(new Point(x, y)) == 3)
                        {
                            boolArrArrNextGen[x, y] = true;
                        }
                    }


                }
            }

            return boolArrArrNextGen;
        }

        //with each click progress to the next gen
        private void btnStep_Click(object sender, EventArgs e)
        {
            boolArrArrGameBoard = getNextGen();
            pnlGameBoard.Refresh();
        }

        //start the game tick timer, and toggle buttons based on the start state
        private void btnStart_Click(object sender, EventArgs e)
        {
            //enable the pause button
            btnPause.Enabled = true;

            //disable the step button, since progression is automatic
            btnStep.Enabled = false;

            //disable start button, since already started
            btnStart.Enabled = false;

            //start the game
            timerTickRate.Start();
        }

        //pause the game tick timer, and toggle buttons based on the pause state
        private void btnPause_Click(object sender, EventArgs e)
        {
            //disable the pause button since we are paused
            btnPause.Enabled = false;

            //enable the step and start button since they are both valid
            btnStart.Enabled = true;
            btnStep.Enabled = true;

            //stop the game
            timerTickRate.Stop();
        }

        //close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //draw squares to the canvas based on the data array
        private void pnlGameBoard_Paint(object sender, PaintEventArgs e)
        {
            //get the size of the squares based of the board size and how many squares
            int squareSize = 512 / intBoardSize;

            for (int x = 0; x < boolArrArrGameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < boolArrArrGameBoard.GetLength(0); y++)
                {
                    //if the cell is alive use the alive pen, otherwise the dead one
                    if (boolArrArrGameBoard[x, y])
                    {
                        e.Graphics.FillRectangle(brushAlive, x * squareSize, y * squareSize, squareSize, squareSize);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(brushDead, x * squareSize, y * squareSize, squareSize, squareSize);
                    }
                }
            }
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {
            //try and update the speed var
            int oldSpeed = speed;
            if (!int.TryParse(txtSpeed.Text, out speed) || speed == 0) //if the new speed isn't an int
            {
                speed = oldSpeed;
                txtSpeed.Text = "" + speed;
                return;
            }

            //update the tick speed
            timerTickRate.Interval = speed;
        }
    }
}
