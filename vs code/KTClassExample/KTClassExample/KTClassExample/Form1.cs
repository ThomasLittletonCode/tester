using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTClassExample
{
    public partial class Form1 : Form
    {

        /*
         *assignment
         *make the menus work - quit,restart, hint*- may have many if staments, about. - done
         *make sure the move is valid - done
         *determine if the playes won
         *determine if the playes lost- no more valid moves left and doars not full
         * **Extra HUGE EXTRA MARKS - a menu option (that works) that aute solves the board-shown step by step.
         * ** Extra marks** - A race option vs AI you create
         
         */

        enum GamePieces { blank, knight, yellowKnight};
        GamePieces[,] gameData;
        private bool about;
        
        //Define board size
        Size cellSize = new Size(75, 75);
        Size gridSize = new Size(8, 8);

        //Load Images
        Bitmap chessBlack = new Bitmap(Image.FromFile("../../Knight-black.png"));
        Bitmap chessWhite = new Bitmap(Image.FromFile("../../Knight-yellow.png"));

        //Coordinates of the knight that was last placed
        Point lastPlaced;
        Boolean showHints = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            //Set the form size
            ClientSize = new Size(cellSize.Width * gridSize.Width, cellSize.Height * gridSize.Height + menuStrip1.Height);
            gameData = new GamePieces[gridSize.Width, gridSize.Height];

            lastPlaced = new Point(-1, -1);

            for (int row = 0; row < gridSize.Height; row++)
            {
                for(int col = 0; col <gridSize.Width; col++)
                {
                    gameData[row, col] = GamePieces.blank;
                }
            }

            Invalidate();//causes the paint function to run

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Adjuste the origin
            e.Graphics.TranslateTransform(0, menuStrip1.Height);

            Brush a = new SolidBrush(Color.Orange);
            Brush b = new SolidBrush(Color.Snow);

            for(int i = 0; i <gridSize.Height; i++)
            {
                for (int j = 0; j <gridSize.Width; j++)
                {
                    Rectangle rect = new Rectangle(j * cellSize.Width, i * cellSize.Height, cellSize.Width, cellSize.Height);
               
                    if((i+j)%2 == 0)
                    {
                        e.Graphics.FillRectangle(a, rect);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }
                    if (gameData[j, i] == GamePieces.knight)
                    {
                        e.Graphics.DrawImage(chessBlack, rect);


                    }
                    if (gameData[j, i] == GamePieces.yellowKnight)
                    {
                        e.Graphics.DrawImage(chessWhite, rect);

                    }
                    



                }
            }


            //draw the lines that divide the rectangles


            for (int i = 0; i <gridSize.Height; i++)
            {
                e.Graphics.DrawLine(Pens.Black, 0, i * cellSize.Height, ClientRectangle.Right, i * cellSize.Height);

            }
            for (int i = 0; i < gridSize.Width; i++)
            {
                e.Graphics.DrawLine(Pens.Black, i * cellSize.Width, 0, i * cellSize.Width, ClientRectangle.Bottom);


            }


            
            if(Win() == true)
            {
                FontFamily fontFamily = new FontFamily("arial");
                Font arial = new Font(fontFamily, 40, FontStyle.Regular, GraphicsUnit.Pixel);
                Brush textBrush = new SolidBrush(Color.Blue);
                e.Graphics.DrawString("you win", arial, textBrush, gridSize.Width, ClientSize.Height / 2);

            }


            if (Lose() == true)
            {
                FontFamily fontFamily = new FontFamily("arial");
                Font arial = new Font(fontFamily, 40, FontStyle.Regular, GraphicsUnit.Pixel);
                Brush textBrush = new SolidBrush(Color.Blue);
                e.Graphics.DrawString("you lose", arial, textBrush, gridSize.Width, ClientSize.Height / 2);

            }


            if (about)
            {
                FontFamily fontFamily = new FontFamily("arial");
                Font arial = new Font(fontFamily, 20, FontStyle.Regular, GraphicsUnit.Pixel);
                Brush textBrush = new SolidBrush(Color.Blue);
                e.Graphics.DrawString("hello your goal is to fill the borad with knights but you can ", arial, textBrush, gridSize.Width, ClientSize.Height / 6);
                e.Graphics.DrawString(" only move them the same way as chest", arial, textBrush, gridSize.Width, ClientSize.Height / 5);

            }

            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            about = false;
            int selectedX = e.X / cellSize.Width;
            int selectedY = (e.Y - menuStrip1.Height) / cellSize.Height;
            if(validMove(selectedX, selectedY))
            {
                gameData[selectedX, selectedY] = GamePieces.knight;
                lastPlaced.X = selectedX;
                lastPlaced.Y = selectedY;

            }


            RemoveHints();
            Invalidate();


        }

        private bool validMove(int xPos, int yPos)
        {
            bool valid = false;// make sure you start with a false value


            //check if a valid move
            //3 cases
            //1 -> was the click on the form and not on the border ot title bar
            //2 -> is it the first move if so it must be valid
            //3 -> is it a L shaped move / valid move or not

            //case 1 - off form
            if(xPos < 0 || xPos >= gridSize.Width || yPos < 0 || yPos >= gridSize.Height)
            {
                valid = false;
            }

            //case 2 - first move

            else if(lastPlaced.X == -1 && lastPlaced.Y == -1)
            {
                valid = true;
            }
            //case 3 - L shaped move
            else
            {
                int changeX = Math.Abs (lastPlaced.X - xPos);
                int changeY = Math.Abs (lastPlaced.Y - yPos);

                if(changeX * changeY == 2 && gameData[xPos,yPos] == GamePieces.blank || gameData[xPos, yPos] == GamePieces.yellowKnight)
                {
                    valid = true;
                }
                
            }

           
            return valid;
        }

        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DisplayHints();








            /*

            Console.WriteLine(lastPlaced.X + " " + lastPlaced.Y);
            
            
            if (showHints)
            {
                showHints = false;

            }
            else
            {
                showHints = true;
            }

            if (showHints)
            {
                gameData[lastPlaced.X + 1, lastPlaced.Y + 2] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + 2, lastPlaced.Y + 1] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + -1, lastPlaced.Y + -2] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + -2, lastPlaced.Y + -1] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + -1, lastPlaced.Y + 2] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + -2, lastPlaced.Y + 1] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + 1, lastPlaced.Y + -2] = GamePieces.yellowKnight;
                gameData[lastPlaced.X + 2, lastPlaced.Y + -1] = GamePieces.yellowKnight;
            }
            else
            {
                for (int row = 0; row < gridSize.Height; row++)
                {
                    for (int col = 0; col < gridSize.Width; col++)
                    {
                        if(gameData[row, col] == GamePieces.yellowKnight)
                        {
                            gameData[row, col] = GamePieces.yellowKnight;

                        }


                    }
                }
            }

            Invalidate();
            */









        }

        private void DisplayHints()
        {
            
            if (validMove(lastPlaced.X + 1, lastPlaced.Y - 2) && gameData[lastPlaced.X + 1, lastPlaced.Y - 2] ==GamePieces.blank)
            {
                gameData[lastPlaced.X + 1, lastPlaced.Y - 2] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X + 1, lastPlaced.Y + 2) && gameData[lastPlaced.X + 1, lastPlaced.Y + 2] == GamePieces.blank)
            {
                gameData[lastPlaced.X + 1, lastPlaced.Y + 2] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X + 2, lastPlaced.Y + 1) && gameData[lastPlaced.X + 2, lastPlaced.Y + 1] == GamePieces.blank)
            {
                gameData[lastPlaced.X + 2, lastPlaced.Y + 1] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X - 1, lastPlaced.Y - 2) && gameData[lastPlaced.X - 1, lastPlaced.Y - 2] == GamePieces.blank)
            {
                gameData[lastPlaced.X - 1, lastPlaced.Y - 2] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X - 2, lastPlaced.Y - 1) && gameData[lastPlaced.X - 2, lastPlaced.Y - 1] == GamePieces.blank)
            {
                gameData[lastPlaced.X - 2, lastPlaced.Y - 1] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X - 1, lastPlaced.Y + 2) && gameData[lastPlaced.X - 1, lastPlaced.Y + 2] == GamePieces.blank)
            {
                gameData[lastPlaced.X - 1, lastPlaced.Y + 2] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X - 2, lastPlaced.Y + 1) && gameData[lastPlaced.X - 2, lastPlaced.Y + 1] == GamePieces.blank)
            {
                gameData[lastPlaced.X - 2, lastPlaced.Y + 1] = GamePieces.yellowKnight;
            }
            if (validMove(lastPlaced.X + 2, lastPlaced.Y - 1) && gameData[lastPlaced.X + 2, lastPlaced.Y - 1] == GamePieces.blank)
            {
                gameData[lastPlaced.X + 2, lastPlaced.Y - 1] = GamePieces.yellowKnight;
            }
            
            Invalidate();

        }

        private void RemoveHints()
        {
            for(int i = 0; i <gridSize.Height; i++)
            {
                for (int j = 0; j <gridSize.Width; j++)
                {
                    if(gameData[i,j] == GamePieces.yellowKnight)
                    {
                        gameData[i, j] = GamePieces.blank;
                        
                    }

                }

            }
            

        }

        private bool Win()
        {
            bool Win = false;

            int checkWin = 0;

            for (int i = 0; i < gridSize.Height; i++)
            {
                for (int j = 0; j < gridSize.Width; j++)
                {
                    if (gameData[i, j] == GamePieces.knight)
                    {
                        checkWin++;

                    }

                }

            }
            
            if(checkWin == 64)
            {
                Win = true;
            }
            return Win;

        }

        private bool Lose()
        {
            bool lose = false;
            int validMoves = 0;
            int checkLose = 0;
             
            if (validMove(lastPlaced.X + 1, lastPlaced.Y - 2) && gameData[lastPlaced.X + 1, lastPlaced.Y - 2] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X + 1, lastPlaced.Y + 2) && gameData[lastPlaced.X + 1, lastPlaced.Y + 2] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X + 2, lastPlaced.Y + 1) && gameData[lastPlaced.X + 2, lastPlaced.Y + 1] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X - 1, lastPlaced.Y - 2) && gameData[lastPlaced.X - 1, lastPlaced.Y - 2] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X - 2, lastPlaced.Y - 1) && gameData[lastPlaced.X - 2, lastPlaced.Y - 1] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X - 1, lastPlaced.Y + 2) && gameData[lastPlaced.X - 1, lastPlaced.Y + 2] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X - 2, lastPlaced.Y + 1) && gameData[lastPlaced.X - 2, lastPlaced.Y + 1] != GamePieces.knight)
            {
                validMoves++;
            }
            if (validMove(lastPlaced.X + 2, lastPlaced.Y - 1) && gameData[lastPlaced.X + 2, lastPlaced.Y - 1] != GamePieces.knight)
            {
                validMoves++;
            }

            bool Lose = false;

            checkLose = 0;

            if(validMoves > 0)
            {
                lose = false;
            }
            else
            {
                lose = true;
            }





            return lose;


        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = true;
            Invalidate();
        }
       




    }
}
