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

namespace MyGOL
{
    public partial class Form1 : Form
    {
        // The universe array
        bool[,] universe = new bool[30, 30];
        bool[,] scratchPad = new bool[30, 30];
        int currentSeed;

        //Flags 
        bool showCount;
        bool showGrid;
        bool showHud;
        bool IsFinite;

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            //Settings

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            universe = new bool[Properties.Settings.Default.Width, Properties.Settings.Default.Height];
            timer.Interval = Properties.Settings.Default.Timer; //100 milliseconds
            IsFinite = Properties.Settings.Default.IsFinite;

            //Updates game mode

            RefreshGameModeUI();

            // Setup the timer

            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
            showCount = neighborCountToolStripMenuItem.Checked;
            showGrid = gridToolStripMenuItem.Checked;
            showHud = hUDToolStripMenuItem.Checked;

            RefreshToolStripStatus();
        }
        //Finite Mode
        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                        continue;
                    // if xCheck is less than 0 then continue
                    if (xCheck < 0)
                        continue;
                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                        continue;
                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                        continue;
                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                        continue;

                    if (universe[xCheck, yCheck] == true)
                        count++;
                }
            }
            return count;
        }
        //Toroidal Mode
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                        continue;
                    // if xCheck is less than 0 then set to xLen - 1
                    if (xCheck < 0)
                        xCheck = xLen - 1;
                    // if yCheck is less than 0 then set to yLen - 1
                    if (yCheck < 0)
                        yCheck = yLen - 1;
                    // if xCheck is greater than or equal too xLen then set to 0
                    if (xCheck >= xLen)
                        xCheck = 0;
                    // if yCheck is greater than or equal too yLen then set to 0
                    if (yCheck >= yLen)
                        yCheck = 0;

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }

        //Randomize alive cells by user seeds
        private void RandomBySeed(int seed)
        {
            NewGame();
            Random r = new Random(seed);

            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {

                    int randomInt = r.Next(0, 2);
                    if (randomInt == 1)
                        universe[i, j] = true;
                    else
                        universe[i, j] = false;
                }
            }


            graphicsPanel1.Invalidate();
        }

        //Randomize alive cells by time

        private void RandomByTime()
        {
            NewGame();
            Random r = new Random();

            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {

                    int randomInt = r.Next(0, 2);
                    if (randomInt == 1)
                        universe[i, j] = true;
                    else
                        universe[i, j] = false;
                }

            }

            graphicsPanel1.Invalidate();
        }



        // Calculate the next generation of cells
        private void NextGenerationFinite()
        {

            scratchPad = new bool[universe.GetLength(0), universe.GetLength(1)];
            // Increment generation count
            generations++;
            //Seeing which cells die or live and save into scratch pad
            for (int y = 0; y < universe.GetLength(1); y++)
            {

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        if (CountNeighborsFinite(x, y) < 2)
                            scratchPad[x, y] = false;
                        else if (CountNeighborsFinite(x, y) > 3)
                            scratchPad[x, y] = false;
                        else if (CountNeighborsFinite(x, y) == 2 || CountNeighborsFinite(x, y) == 3)
                            scratchPad[x, y] = true;
                    }
                    else if (universe[x, y] == false)
                    {
                        if (CountNeighborsFinite(x, y) == 3)
                            scratchPad[x, y] = true;
                    }

                }

            }

            universe = scratchPad;
            graphicsPanel1.Invalidate();
            // Update status strip generations
            RefreshToolStripStatus();

        }

        // Toroidal logic implemented
        private void NextGenerationToroidal()
        {

            scratchPad = new bool[universe.GetLength(0), universe.GetLength(1)];
            // Increment generation count
            generations++;
            //Seeing which cells die or live and save into scratch pad
            for (int y = 0; y < universe.GetLength(1); y++)
            {

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        if (CountNeighborsToroidal(x, y) < 2)
                            scratchPad[x, y] = false;
                        else if (CountNeighborsToroidal(x, y) > 3)
                            scratchPad[x, y] = false;
                        else if (CountNeighborsToroidal(x, y) == 2 || CountNeighborsToroidal(x, y) == 3)
                            scratchPad[x, y] = true;
                    }
                    else if (universe[x, y] == false)
                    {
                        if (CountNeighborsToroidal(x, y) == 3)
                            scratchPad[x, y] = true;
                    }

                }

            }

            universe = scratchPad;
            graphicsPanel1.Invalidate();
            // Update status strip generations
            RefreshToolStripStatus();

        }

        //Retrieving amount of cells alive
        private int TotalNumberOfLivingCells()
        {
            int livingCells = 0;
            for (int y = 0; y < universe.GetLength(1); y++)
            {

                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        livingCells++;
                    }

                }
            }

            return livingCells;
        }

        // The event called by the timer every Interval milliseconds
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IsFinite)
                NextGenerationFinite();//advances 1 genration
            else
                NextGenerationToroidal();
        }

        //Paints the grid
        public void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            //FLOAT MAKES THE PROGRAM LOOK BETTER (Use Rectanglef further down)
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            Font stringFont = new Font("Arial", 8f);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;


            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;


                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);

                        if (showCount)
                            e.Graphics.DrawString(CountNeighborsFinite(x, y).ToString(), stringFont, Brushes.Black, cellRect, sf);

                    }


                    // Outline the cell with a pen
                    if (showGrid)
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);



                }
            }

            if (showHud)
            {
                string GameMode = (IsFinite) ? "Finite" : "Toroidal";
                string hud = $"Generations: {generations} \nCell Count:{TotalNumberOfLivingCells()} \nBoundary Type: { GameMode } \nUniverse Size:{universe.GetLength(0)}x{universe.GetLength(1)}";
                e.Graphics.DrawString(hud, stringFont, Brushes.DarkRed, 10, 10);


            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        //Turns on or off cells by click
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                //USE FLOATS HERE TOO
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                //Exception handling

                if (x >= universe.GetLength(0) || y >= universe.GetLength(1) || x < 0 || y < 0)
                    return;


                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }

            RefreshToolStripStatus();
        }
        //Exit click event
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Start timer running
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true; 
        }
        //Stops timer
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false; 
        }
        //Moves generation fwd once (next)
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            nextToolStripMenuItem_Click(sender, e);
        }
        //empty the universe
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void RefreshToolStripStatus()
        {
            toolStripStatusLabelGenerations.Text = "Generations: " + generations.ToString() + " Alive: " + TotalNumberOfLivingCells();


        }
        //Starts timer running in tool strip
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = true; // start timer running
        }
        //Stops timer in tool strip
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false; // stops timer
        }
        //Moves generation ahead once tool strip
        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsFinite)
                NextGenerationFinite();//advances 1 genration
            else
                NextGenerationToroidal();
        }
        //Clears screen
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        //Clear logic
        private void NewGame()
        {
            Array.Clear(universe, 0, universe.Length);
            Array.Clear(scratchPad, 0, scratchPad.Length);
            timer.Enabled = false;
            generations = 0;
            RefreshToolStripStatus();
            graphicsPanel1.Invalidate();
        }

        //Grid color click event (mistakenly named back color)
        private void backColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;

                graphicsPanel1.Invalidate();
            }
        }
        //Cell color click event
        private void cellColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;

                graphicsPanel1.Invalidate();
            }
        }
        //Back color click event
        private void backColorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;

                graphicsPanel1.Invalidate();
            }
        }
        //Options modal dialog box event
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModalDialog dlg = new ModalDialog();

            dlg.Time = timer.Interval;

            dlg.Width = universe.GetLength(0);

            dlg.Height = universe.GetLength(1);

            if (DialogResult.OK == dlg.ShowDialog())
            {
                timer.Interval = dlg.Time;

                if (dlg.Width != universe.GetLength(0) || dlg.Height != universe.GetLength(1))
                {
                    scratchPad = universe = new bool[dlg.Width, dlg.Height];

                    RefreshToolStripStatus();

                    graphicsPanel1.Invalidate();
                }

            }

        }
        //From seed click event
        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedDialog dlg = new SeedDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                currentSeed = dlg.seed;
                RandomBySeed(currentSeed);
                RefreshToolStripStatus();
            }
        }
        //Current seed click event
        private void currentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomBySeed(currentSeed);
        }
        //From time click event
        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomByTime();
        }
        //Neighbor Count toogle
        private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            neighborCountToolStripMenuItem.Checked = !neighborCountToolStripMenuItem.Checked;

            neighborCountToolStripMenuItem1.Checked = !neighborCountToolStripMenuItem1.Checked;

            showCount = neighborCountToolStripMenuItem.Checked;

            graphicsPanel1.Invalidate();
        }
        //Grid toogle
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;

            gridToolStripMenuItem1.Checked = !gridToolStripMenuItem1.Checked;

            showGrid = gridToolStripMenuItem.Checked;

            graphicsPanel1.Invalidate();
        }
        //HUD toogle
        private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hUDToolStripMenuItem.Checked = !hUDToolStripMenuItem.Checked;

            hUDToolStripMenuItem1.Checked = !hUDToolStripMenuItem1.Checked;

            showHud = hUDToolStripMenuItem.Checked;

            graphicsPanel1.Invalidate();
        }
        //Saving as closing settings
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;

            Properties.Settings.Default.GridColor = gridColor;

            Properties.Settings.Default.CellColor = cellColor;

            Properties.Settings.Default.Width = universe.GetLength(0);

            Properties.Settings.Default.Height = universe.GetLength(1);

            Properties.Settings.Default.Timer = timer.Interval;

            Properties.Settings.Default.IsFinite = IsFinite;

            Properties.Settings.Default.Save();
        }

        //Reset click event
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;

            gridColor = Properties.Settings.Default.GridColor;

            cellColor = Properties.Settings.Default.CellColor;

            universe = new bool[Properties.Settings.Default.Width, Properties.Settings.Default.Height];

            timer.Interval = Properties.Settings.Default.Timer;

            IsFinite = Properties.Settings.Default.IsFinite;

            RefreshGameModeUI();
        }
        //Reload click event
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;

            gridColor = Properties.Settings.Default.GridColor;

            cellColor = Properties.Settings.Default.CellColor;

            universe = new bool[Properties.Settings.Default.Width, Properties.Settings.Default.Height];

            timer.Interval = Properties.Settings.Default.Timer;

            IsFinite = Properties.Settings.Default.IsFinite;

            RefreshGameModeUI();

        }
        //Context menu strip for view -> HUD
        private void hUDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hUDToolStripMenuItem_Click(sender, e);
        }
        //Context menu strip for view -> Neighbor Count

        private void neighborCountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            neighborCountToolStripMenuItem_Click(sender, e);
        }

        //Context menu strip for view -> Grid
        private void gridToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridToolStripMenuItem_Click(sender, e);
        }
        //Refresh toogle option for finite and toroidal
        private void RefreshGameModeUI()
        {
            finiteToolStripMenuItem.Checked = IsFinite;
            toroidalToolStripMenuItem.Checked = !IsFinite;
            graphicsPanel1.Invalidate();

        }
        //Finite click toogle
        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFinite = true;
            RefreshGameModeUI();
        }
        //Toroidal click toogle
        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFinite = false;
            RefreshGameModeUI();
        }
        //Save game logic and click event
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine($"!File Created on {DateTime.Now}");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y] == true)
                            currentRow += "O";
                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                            currentRow += ".";
                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }
        //Load game click event and logic
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.

                    string firstChar = row.Substring(0, 1);

                    if (firstChar != "!")
                    {
                        maxHeight++;

                        if (maxWidth < row.Length)
                            maxWidth = row.Length;
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.

                universe = scratchPad = new bool[maxWidth, maxHeight];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                int i = 0;

                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.

                    string firstChar = row.Substring(0, 1);

                    if (firstChar != "!")
                    {
                        // If the row is not a comment then 
                        // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            universe[xPos, i] = (row[xPos] == 'O') ? true : false;
                            // If row[xPos] is a 'O' (capital O) then
                            // set the corresponding cell in the universe to alive.
                            // If row[xPos] is a '.' (period) then
                            // set the corresponding cell in the universe to dead.
                        }

                        i++;
                    }
                }

                // Close the file.
                reader.Close();
                graphicsPanel1.Invalidate();
            }
        }
    }
}
