using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace ConnorGilliom_Final
{
    public partial class SelectStartingPoints : Form
    {

        //store a reference to the setup form so we can give it the starting points
        private Setup setupForm;

        //game board stores which are alive and dead
        private bool[,] boolArrArrGameBoard;

        //a list to store all starting live points
        private List<Point> lstPntStartingLivePoints = new List<Point>();

        //store the board size so the pain method can use it
        private int intBoardSize;

        //store brushes for setting colors
        Brush brushAlive;
        Brush brushDead;

        //file read objects, store them globably so we can close them when we are done with the form
        private Stream streamFile;
        private StreamReader streamReaderFile;

        //file write object, store it globably so we can close it when we are done with it
        private StreamWriter streamWriterFile;

        public SelectStartingPoints(Setup setupForm, int intBoardSize)
        {
            InitializeComponent();

            //create the game board, since the default value is bool for each
            //square we only need to change the living ones
            boolArrArrGameBoard = new bool[intBoardSize, intBoardSize];

            //store the items we need later
            this.setupForm = setupForm;
            this.intBoardSize = intBoardSize;

            brushAlive = new SolidBrush(Color.Yellow);
            brushDead = new SolidBrush(Color.Gray);

            //make the panel double buffered to stop flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
              BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
              null, pnlGameBoard, new object[] { true });

        }

        //used if the user wants to come back and edit their choices
        public SelectStartingPoints(Setup setupForm, int intBoardSize, bool[,] boolArrArrGameBoard) : this(setupForm, intBoardSize)
        {
            this.boolArrArrGameBoard = boolArrArrGameBoard;
        }

        //the user is done setting the live points, send back the data to the startup form
        private void btnDone_Click(object sender, EventArgs e)
        {
            
            //go through all the squares checking for live ones
            for(int x = 0; x < boolArrArrGameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < boolArrArrGameBoard.GetLength(0); y++)
                {
                    //live point
                    if(boolArrArrGameBoard[x, y])
                    {
                        lstPntStartingLivePoints.Add(new Point(x, y));
                    }
                }
            }

            //send back the live data
            setupForm.setStartingLivePoints(lstPntStartingLivePoints.ToArray(), boolArrArrGameBoard);
            this.Close();
        }

        //detect when a square on the board is clicked and toggle it's alive/dead state
        private void pnlGameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            //get the size of the squares based of the board size and how many squares
            int squareSize = 512 / intBoardSize;

            //toggle the living/dead value based on the click
            boolArrArrGameBoard[e.Location.X / squareSize, e.Location.Y / squareSize] = !boolArrArrGameBoard[e.Location.X / squareSize, e.Location.Y / squareSize];

            //update the board to show the updated square
            pnlGameBoard.Refresh();
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

        //clears the game board
        private void btnClear_Click(object sender, EventArgs e)
        {
            boolArrArrGameBoard = new bool[intBoardSize, intBoardSize];
            pnlGameBoard.Refresh();
        }

        //save the current game board
        private void btnSave_Click(object sender, EventArgs e)
        {

            //setup the file save dialog
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt";
            saveFile.FilterIndex = 1;

            //file to save to was selected
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //open the save file for writing
                streamWriterFile = new StreamWriter(saveFile.FileName);

                //go through the game board and save all values
                for (int x = 0; x < boolArrArrGameBoard.GetLength(0); x++)
                {
                    for (int y = 0; y < boolArrArrGameBoard.GetLength(0); y++)
                    {
                        streamWriterFile.Write(boolArrArrGameBoard[x, y] + " ");
                    }
                    streamWriterFile.Write("\n");
                }
            }

            //clean up the stream if it is still open
            if (streamWriterFile != null)
            {
                streamWriterFile.Close();
                streamWriterFile = null;
            }
        }

        //load a game board form a file
        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<string> listStrFileLines = new List<string>();

            //setup the open dialog box to ask the user for a text file
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.txt";
            openFile.FilterIndex = 1;

            //file was chosen
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //setup the file input stream
                streamFile = openFile.OpenFile();
                streamReaderFile = new StreamReader(streamFile);

                //read the file and store the string data
                while(streamReaderFile.Peek() >= 0)
                {
                    listStrFileLines.Add(streamReaderFile.ReadLine());
                }

                
            }
            else //if the user didn't pick a file cancle the load
            {
                return;
            }

            //clean up all streams if they are still open
            //-----------------------------------------//
            if (streamFile != null)
            {
                streamFile.Close();
                streamFile = null;
            }
            if (streamReaderFile != null)
            {
                streamReaderFile.Close();
                streamReaderFile = null;
            }
            //-----------------------------------------//

            //if we tried to load a diff board size
            if (listStrFileLines.Count != intBoardSize)
            {
                string strBoardSizeMessage = string.Format("Cannot load a {0}x{0} file on a {1}x{1} board!", listStrFileLines.Count, intBoardSize);
                MessageBox.Show(strBoardSizeMessage, "Error", MessageBoxButtons.OK);
                return;
            }

            //prccess each line we got from the file
            for (int x = 0; x < listStrFileLines.Count; x++)
            {
                //split each line so we can use the values
                string[] strArrCurrentLine = listStrFileLines[x].Split(' ');
                //store the value in the file into the board
                for (int y = 0; y < listStrFileLines.Count; y++)
                {
                    boolArrArrGameBoard[x, y] = bool.Parse(strArrCurrentLine[y]);
                }
                
            }

            //done update redraw the board
            pnlGameBoard.Refresh();
        }

        //if the form closes during file read/write clean it up
        private void SelectStartingPoints_FormClosed(object sender, FormClosedEventArgs e)
        {
            //check if the load file stream is still open, if it is close it
            if (streamFile != null)
            {
                streamFile.Close();
            }

            //check if the stream reader is still open, if it is close it
            if (streamReaderFile != null)
            {
                streamReaderFile.Close();
            }

            //check if the stream writer is still open, if it is close it
            if (streamWriterFile != null)
            {
                streamWriterFile.Close();
            }
        }

    }
}
