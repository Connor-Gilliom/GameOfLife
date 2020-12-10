using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConnorGilliom_Final
{
    public partial class Setup : Form
    {

        //store hex codes for each living color option
        const string STR_RED = "990000";
        const string STR_BLUE = "000099";
        const string STR_YELLOW = "999900";

        //stores wether the starting grid has been setup yet
        bool boolStartingGridSetup = false;

        //stores which points are alive
        Point[] pntArrStartingLive;

        //stores setup grid for the setup starting points incase we need to edit
        private bool[,] boolArrArrGameBoard;

        //file read objects, store them globably so we can close them when we are done with the form
        private Stream streamFile;
        private StreamReader streamReaderFile;

        //file write object, store it globably so we can close it when we are done with it
        private StreamWriter streamWriterFile;

        //stores the last selected board size index so the user doesn't have to reset if the board size didn't change
        private int intLastSlectedIndexForBoardSize = 0;

        public Setup()
        {
            InitializeComponent();

            //setup the context menu for the setup form
            //----------------------------------------------------------//
            ContextMenu contextMenuSetup = new ContextMenu();

            //create the clear fields menu item
            MenuItem menuClearFields = new MenuItem("Clear Fields");
            menuClearFields.Click += menuClearFields_Click;
            
            //add the menu item and add the context menu to this form
            contextMenuSetup.MenuItems.Add(menuClearFields);
            this.ContextMenu = contextMenuSetup;
            //----------------------------------------------------------//

            //set the default board size
            cbxBoardSize.SelectedIndex = 0;

            //setup tooltips for the controls
            ToolTip ttSetupMenu = new ToolTip();
            ttSetupMenu.SetToolTip(cbxBoardSize, "Sets the board size");
            ttSetupMenu.SetToolTip(groupBoxColorSets, "Sets the color for living cells");
            ttSetupMenu.SetToolTip(txtDeadColorInput, "Sets the color for dead cells");
            ttSetupMenu.SetToolTip(chkbxLoadFromFile, "Enables the load button");
            ttSetupMenu.SetToolTip(btnSave, "Saves the current settings to a file");
            ttSetupMenu.SetToolTip(btnLoad, "Loads settings from a file");
            ttSetupMenu.SetToolTip(btnExit, "Closes the app");
        }

        //return all the game fields to their inital states
        private void clearFields()
        {
            //set the board size back to the default
            cbxBoardSize.SelectedIndex = 0;

            //uncheck all radio buttons
            rbtnColorSetOne.Checked = false;
            rbtnColorSetTwo.Checked = false;
            rbtnColorSetThree.Checked = false;

            //clear the color input
            txtDeadColorInput.Text = "";

            //uncheck the load from file button
            chkbxLoadFromFile.Checked = false;
        }

        //makes sure all the given fields are correct value types
        private bool checkInput()
        {

            //board size will have a default value, and the only other options for it
            //are expected values so we don't need to check it

            //make sure a color was picked for living
            bool boolColorPicked = false;
            if(rbtnColorSetOne.Checked)
            {
                boolColorPicked = true;
            }
            else if(rbtnColorSetTwo.Checked)
            {
                boolColorPicked = true;
            }
            else if (rbtnColorSetThree.Checked)
            {
                boolColorPicked = true;
            }

            //if a color wasn't picked
            if(!boolColorPicked)
            {
                MessageBox.Show("You must select a color for living squares!", "Error", MessageBoxButtons.OK);
                return false;
            }

            string strDeadColor = txtDeadColorInput.Text;

            //make sure the user gave a value for the dead squares
            if(strDeadColor == null || strDeadColor.Equals(""))
            {
                MessageBox.Show("You must provid a color for the dead squares!", "Error", MessageBoxButtons.OK);
                return false;
            }
            
            //make sure the user gave a valid value for the dead squares
            int intDeadColor;
            if(strDeadColor.Length != 6 || !int.TryParse(strDeadColor, out intDeadColor))
            {
                MessageBox.Show("Dead Color must be a valid 6-digit int!", "Error", MessageBoxButtons.OK);
                return false;
            }

            //all fields are good to go
            return true;
        }

        //reset all the fields because of a context menu click
        private void menuClearFields_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        //stop the app
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //start the form for setting up the game grid
        private void setupStartGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int intBoardSize = 0;
            //get the game board size, with the default being 64
            switch (cbxBoardSize.SelectedIndex)
            {
                case 1:
                    intBoardSize = 32;
                    break;
                case 2:
                    intBoardSize = 16;
                    break;
                default:
                    intBoardSize = 64;
                    break;
            }

            if (boolStartingGridSetup) //if the grid size is the same and it has already been setup edit it
            {
                Form formStartingPoints = new SelectStartingPoints(this, intBoardSize, boolArrArrGameBoard);
                formStartingPoints.ShowDialog();
            }
            else //new grid
            {
                Form formStartingPoints = new SelectStartingPoints(this, intBoardSize);
                formStartingPoints.ShowDialog();
            }

        }

        //start the game form
        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //we can't start the game if the starting grid hasn't been set
            if(!boolStartingGridSetup)
            {
                MessageBox.Show("You must setup the starting grid before you start the game!", "Error", MessageBoxButtons.OK);
                return;
            }

            //validate user input, if there is some invalid data cancel game launch
            if (!checkInput())
            {
                return;
            }

            int intBoardSize = 0;
            //get the game board size, with the default being 64
            switch(cbxBoardSize.SelectedIndex)
            {
                case 1: 
                    intBoardSize = 32;
                    break;
                case 2:
                    intBoardSize = 16;
                    break;
                default:
                    intBoardSize = 64;
                    break;
            }

            //get the living color with the default being red
            string strLivingColor = STR_RED;
            if(rbtnColorSetTwo.Checked)
            {
                strLivingColor = STR_BLUE;
            }
            else if (rbtnColorSetThree.Checked)
            {
                strLivingColor = STR_YELLOW;
            }

            //launch the game form giving it all the setting data
            Form formGame = new Game(intBoardSize, strLivingColor, txtDeadColorInput.Text, pntArrStartingLive);
            formGame.ShowDialog();
        }

        //start the about form
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAbout = new About();
            formAbout.ShowDialog();
        }

        private void chkbxLoadFromFile_CheckedChanged(object sender, EventArgs e)
        {
            //the user wants to load settings from a file
            if(chkbxLoadFromFile.Checked)
            {
                btnLoad.Visible = true;
            }
            else //the user doesn't
            {
                btnLoad.Visible = false;
            }
        }

        //save the current settings, making sure they are valid first
        private void btnSave_Click(object sender, EventArgs e)
        {
            //validate user input, if there is some invalid data cancel save
            if (!checkInput())
            {
                return;
            }

            int intLivingColor = 0;
            if(rbtnColorSetOne.Checked)
            {
                intLivingColor = 0;
            }
            else if(rbtnColorSetTwo.Checked)
            {
                intLivingColor = 1;
            }
            else if (rbtnColorSetThree.Checked)
            {
                intLivingColor = 2;
            }

            //format all the data from the fields for saving
            string strSaveData = cbxBoardSize.SelectedIndex + ":" + intLivingColor + ":" + txtDeadColorInput.Text;

            //setup the file save dialog
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt";
            saveFile.FilterIndex = 1;

            //file to save to was selected
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //open the save file for writing
                streamWriterFile = new StreamWriter(saveFile.FileName);
                streamWriterFile.Write(strSaveData);
            }

            //clean up the stream if it is still open
            if (streamWriterFile != null)
            {
                streamWriterFile.Close();
                streamWriterFile = null;
            }
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string strFileContent = "";

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
                strFileContent = streamReaderFile.ReadToEnd();
            }
            else //if the user didn't pick a file cancle the load
            {
                return;
            }


            //clean up all streams if they are still open
            //-----------------------------------------//
            if(streamFile != null)
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

            //grab each field item from the file data
            string[] strArrSplitFileData = strFileContent.Split(':');

            //set the board size
            int intIndex = -1;
            if(!int.TryParse(strArrSplitFileData[0], out intIndex))
            {
                //if it's not a valid int for board size set it to the default
                intIndex = 0;
            }
            cbxBoardSize.SelectedIndex = intIndex;

            //set the living color
            int intColor = -1;
            if (!int.TryParse(strArrSplitFileData[1], out intColor))
            {
                //if it's not a valid int for board size set it Red as a default
                intColor = 0;
            }

            if(intColor == 1) //blue
            {
                rbtnColorSetTwo.Checked = true;
            }
            else if (intColor == 2) //yellow
            {
                rbtnColorSetThree.Checked = true;
            }
            else //default red
            {
                //confirm it is red
                if(intColor == 0)
                {
                    rbtnColorSetOne.Checked = true;
                }
                
            }

            //set the dead color
            txtDeadColorInput.Text = strArrSplitFileData[2];
        }

        //if the form closes during file read/write clean it up
        private void Setup_FormClosed(object sender, FormClosedEventArgs e)
        {

            //check if the load file stream is still open, if it is close it
            if(streamFile != null)
            {
                streamFile.Close();
            }

            //check if the stream reader is still open, if it is close it
            if (streamReaderFile != null)
            {
                streamReaderFile.Close();
            }

            //check if the stream writer is still open, if it is close it
            if(streamWriterFile != null)
            {
                streamWriterFile.Close();
            }

        }

        //force the user to reselect the starting live squares if the grid size changed
        //and they already selected the starting live squares
        private void cbxBoardSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid got setup
            if (boolStartingGridSetup && cbxBoardSize.SelectedIndex != intLastSlectedIndexForBoardSize)
            {
                MessageBox.Show("The grid size has changed, you must reselect the starting live squares", "Notice", MessageBoxButtons.OK);
                boolStartingGridSetup = false;
            }
        
            //store the last index so we can check if it changed later
            intLastSlectedIndexForBoardSize = cbxBoardSize.SelectedIndex;
        }

        //called by the live point settup form to store the living points and 
        //mark the starting grid as ready
        public void setStartingLivePoints(Point[] pntArrStartingLive, bool[,] boolArrArrGameBoard)
        {
            boolStartingGridSetup = true;
            this.pntArrStartingLive = pntArrStartingLive;
            this.boolArrArrGameBoard = boolArrArrGameBoard;
        }
    }
}
