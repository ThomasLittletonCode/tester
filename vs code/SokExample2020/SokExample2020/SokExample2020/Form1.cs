using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SokExample2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Invalidate();
        }

        /*What I need to finish
         * The Game
         * Movement - done
         * Undo function/option-done
         * Determine a winner
         * Get to the next level - done
         * Restart, Quit, About, Help menu Items.
         * Set a size-done
         */

        enum GamePieces { blank = 0, wall = 1, worker = 2, destination = 3, baggage = 4, baggageOnDestination, workerOnDestination }

        //Make needed variables
        GamePieces[,] gameData;
        GamePieces[,] savedState;
        

        Size gridSize = new Size();//we will get this from the text file
        Size cellSize = new Size(25, 25);

        bool simpleGraphics = true;
        Bitmap graphicBits = new Bitmap(typeof(Form1), "sokabanBB.png");//this would be for the sokobanMW.gif file
        Bitmap simpleGraphicBits = new Bitmap(typeof(Form1), "sokabanBB.png");
        Point workerLocation = new Point(0, 0);
        
        int level = 1;

        

        Stack<GamePieces[,]> savedStateHistory = new Stack<GamePieces[,]>();
        Stack<Point> savedWorkerLocation = new Stack<Point>();
        Stack<GamePieces[,]> savedStatesForRedo = new Stack<GamePieces[,]>();
        Stack<Point> savedWorkerLocForRedo = new Stack<Point >();

        int numMoves = 0;

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readMap();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void readMap()
        {
            string lineOfText = null;
            try
            {
                StreamReader mapFile = new StreamReader("../../sokoban_maps.txt");
                while (!mapFile.EndOfStream)
                {
                    lineOfText = mapFile.ReadLine();
                    if (lineOfText[0] == '-') continue;//this will skip this line of text
                    if(lineOfText[0] == '@' && lineOfText[1] == Convert.ToChar(level.ToString()))
                    {
                        lineOfText = mapFile.ReadLine();//this line will have our dimensions
                        string[] data = lineOfText.Split(',');
                        gridSize.Width = Convert.ToInt16(data[0]);
                        gridSize.Height = Convert.ToInt16(data[1]);
                        gameData = new GamePieces[gridSize.Width, gridSize.Height];

                        for(int row = 0; row<gridSize.Height; row++)
                        {
                            lineOfText = mapFile.ReadLine();
                            for(int col = 0; col <lineOfText.Length; col++)
                            {
                                SetCell(col, row, lineOfText[col]);
                            }
                        }
                    }
                }
                mapFile.Close();
                this.ClientSize = new Size(cellSize.Width * gridSize.Width, cellSize.Height * gridSize.Height + menuStrip1.Height);
                this.CenterToScreen();
                this.Invalidate();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error reading file");
            }
        }

        private void SetCell(int x, int y, char character)
        {
            if (character.Equals('#'))
            {
                gameData[x, y] = GamePieces.wall;
            }
            else if (character.Equals('w'))
            {
                gameData[x, y] = GamePieces.worker;
            }
            else if (character.Equals('W'))
            {
                gameData[x, y] = GamePieces.workerOnDestination;
            }
            else if (character.Equals('b'))
            {
                gameData[x, y] = GamePieces.baggage;
            }
            else if (character.Equals('B'))
            {
                gameData[x, y] = GamePieces.baggageOnDestination;
            }
            else if (character.Equals('D'))
            {
                gameData[x, y] = GamePieces.destination;
            }


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, menuStrip1.Height);
            int imageIndex = 0;
            //vertical lines
            for(int i = 0; i <gridSize.Width; i++)
            {
                e.Graphics.DrawLine(Pens.Black, i * cellSize.Width, 0, i * cellSize.Width, ClientRectangle.Bottom);
            }

            //horizontal lines
            for(int i = 0; i <gridSize.Height; i++)
            {
                e.Graphics.DrawLine(Pens.Black, 0, i * cellSize.Height, ClientRectangle.Right, i * cellSize.Height);
            }

            for(int i = 0; i <gridSize.Width; i++)
            {
                for(int j = 0; j <gridSize.Height; j++)
                {
                    Rectangle srcRect;
                    Rectangle destRect = new Rectangle(i * cellSize.Width, j * cellSize.Height, cellSize.Width, cellSize.Height);

                    if(gameData[i,j] == GamePieces.wall)
                    {
                        imageIndex = 0;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    else if (gameData[i, j] == GamePieces.destination || gameData[i, j] == GamePieces.workerOnDestination)
                    {
                        //This is the image we want
                        imageIndex = 2;
                        //This is the part of the picture file you want to draw
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);

                        e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    else if (gameData[i, j] == GamePieces.baggage)
                    {
                        imageIndex = 3;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    else if (gameData[i, j] == GamePieces.baggageOnDestination)
                    {
                        imageIndex = 3;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
                        imageIndex = 2;
                        e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    else if (gameData[i, j] == GamePieces.worker)
                    {
                        imageIndex = 1;
                        workerLocation.X = i;
                        workerLocation.Y = j;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(graphicBits, destRect, srcRect, GraphicsUnit.Pixel);

                    }



                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //The switch is the match expression, this is what we are going to compare to the different
            //case statements
            savedForUndo();
            
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveWorker(0, -1);
                    break;
                case Keys.Down:
                    MoveWorker(0, 1);
                    break;
                
            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MoveWorker(-1, 0);
                    break;
                case Keys.Right:
                    MoveWorker(1, 0);
                    break;

            }
            if (CheckWin())
            {
                if (level == 5)
                {
                    MessageBox.Show("You Won the Game!!");

                }
                level++;
                readMap();
                Invalidate();
            }
            


        }
        
        private bool MoveWorker(int h, int v)
        {
            bool validMove = false;
            int x = workerLocation.X;
            int y = workerLocation.Y;

            if(gameData[x+h,y+v]== GamePieces.blank)
            {
                gameData[x + h, y + v] = GamePieces.worker;
                WorkerCameFrom();
                workerLocation.X += h;
                workerLocation.Y += v;

                validMove = true;
                numMoves++;
            }


            else if (gameData[x + h, y + v] == GamePieces.baggage && gameData[x + 2*h, y + 2*v] == GamePieces.blank)
            {
                gameData[x + 2*h, y + 2*v] = GamePieces.baggage;
                gameData[x + h, y + v] = GamePieces.worker;
                WorkerCameFrom();
                workerLocation.X += h;
                workerLocation.Y += v;

                validMove = true;
                numMoves++;
            }

            else if (gameData[x + h, y + v] == GamePieces.baggage && gameData[x + 2 * h, y + 2 * v] == GamePieces.destination)
            {
                gameData[x + 2 * h, y + 2 * v] = GamePieces.baggageOnDestination;
                gameData[x + h, y + v] = GamePieces.worker;
                WorkerCameFrom();
                workerLocation.X += h;
                workerLocation.Y += v;

                validMove = true;
                numMoves++;
            }



            //I will have to create if statements for all the other possible moves



            Invalidate();
            return validMove;
        }

        private void WorkerCameFrom()
        {
            if(gameData[workerLocation.X, workerLocation.Y] == GamePieces.worker)
            {
                gameData[workerLocation.X, workerLocation.Y] = GamePieces.blank;
            }
            else
            {
                gameData[workerLocation.X, workerLocation.Y] = GamePieces.destination;
            }
            


        }

        private bool CheckWin()
        {
            bool checkWin = true;
            for (int x = 0; x < gridSize.Width; x++)
            {
                for (int y = 0; y < gridSize.Height; y++)
                {
                    if (gameData[x, y] == GamePieces.baggage)
                    {
                        checkWin = false;
                    }
                }
            }
            return checkWin;

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (savedStateHistory.Count > 0)
            {

                savedState = savedStateHistory.Pop();
                for (int x = 0; x < gridSize.Width; x++)
                {
                    for (int y = 0; y < gridSize.Height; y++)
                    {

                        gameData[x, y] = savedState[x, y];

                    }
                }
                workerLocation = savedWorkerLocation.Pop();

                this.Invalidate();

            }

        }

        private void savedForUndo()
        {
            GamePieces[,] saveData = new GamePieces[gridSize.Width, gridSize.Height];
            Point saveWorkerLocation = new Point(workerLocation.X, workerLocation.Y);

            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    saveData[i, j] = gameData[i, j];

                }

            }

            savedStateHistory.Push(saveData);
            savedWorkerLocation.Push(saveWorkerLocation);


        }

        private bool Win()
        {
            bool Win = true;


            for (int i = 0; i < gridSize.Height; i++)
            {
                for (int j = 0; j < gridSize.Width; j++)
                {
                    if (gameData[j, i] == GamePieces.baggage)
                    {
                        Win = false;

                    }

                }

            }

            Invalidate();
            return Win;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you move the baggage to the targets once you have all the baggage on the targets you move to the next level");

        }
    }
}
