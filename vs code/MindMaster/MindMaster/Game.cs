using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindMaster
{
    public partial class Game : Form
    {


        int numGuess = 35;
        Button[] answerButtons;
        String[] answer;
        Button[] guessArray;
        int turn = 0;
        int counter = 0;
        Button[] bwChecker;

        public Game(String[] ans)
        {
            InitializeComponent();
            guessArray = new Button[numGuess];
            bwChecker = new Button[numGuess];
            answerButtons = new Button[] { ans1, ans2, ans3, ans4, ans5 };
            answer = ans;
            displayAnswer();
            placeAnswerArray();
            bwFiller();
        }

        private void oneOne_Click(object sender, EventArgs e)
        {
            //Create the button
            Button currentButton = (Button)sender;

            //Set the current color
            if(blueCB.Checked)
            {
                currentButton.BackColor = Color.Blue;
            }
            else if(orangeCB .Checked)
            {
                currentButton.BackColor = Color.Orange;
            }
            else if(redCB .Checked)
            {
                currentButton.BackColor = Color.Red;
            }
            else if(greenCB.Checked)
            {
                currentButton.BackColor = Color.Green;
            }
            else if(yellowCB .Checked)
            {
                currentButton.BackColor = Color.Yellow;
            }



        }

        private void displayAnswer()
        {
            //This function will display the answer

            for(int i = 0; i < answer.Length; i++)
            {
                if (answer[i].Equals("red"))
                {
                    answerButtons[i].BackColor = Color.Red;
                }
                else if (answer[i].Equals("orange"))
                {
                    answerButtons[i].BackColor = Color.Orange;
                }
                else if (answer[i].Equals("blue"))
                {
                    answerButtons[i].BackColor = Color.Blue;
                }
                else if (answer[i].Equals("green"))
                {
                    answerButtons[i].BackColor = Color.Green;
                }
                else if (answer[i].Equals("yellow"))
                {
                    answerButtons[i].BackColor = Color.Yellow;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numberCorrect = 0;
            int temp = 0;
            //place the buttons into an array for comparisons
            if (turn < 7)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (guessArray[counter].BackColor.Equals(answerButtons[i].BackColor))
                    {
                        //bwChecker[counter].BackColor = Color.Black;
                        numberCorrect++;
                    }
                    /*else
                    {
                        bwChecker[counter].BackColor = Color.White;
                    }
                    */
                    counter++;
                }
                for(int i = 0; i < 5; i++)
                {
                    if(temp < numberCorrect)
                    {
                        bwChecker[(counter - 5 + i)].BackColor = Color.Black;
                        temp++;
                    }
                    else
                    {
                        bwChecker[(counter - 5 + i)].BackColor = Color.White;
                    }
                    
                }
                if (numberCorrect == 5)
                {
                    cover.Visible = false;
                    label2.Text = "Winner";
                    turn = 10;
                }
                numberCorrect = 0;

                if (turn < 6)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        guessArray[counter + i].Enabled = true;
                    }
                }
                turn++;
            }
            if (turn == 7)
            {
                label2.Text = "Sorry ";
                cover.Visible = false;
            }
          
        }

        private void placeAnswerArray()
        {
            guessArray[0] = oneOne;
            guessArray[1] = oneTwo;
            guessArray[2] = oneThree;
            guessArray[3] = oneFour;
            guessArray[4] = oneFive;
            guessArray[5] = twoOne;
            guessArray[6] = twoTwo;
            guessArray[7] = twoThree;
            guessArray[8] = twoFour;
            guessArray[9] = twoFive;
            guessArray[10] = threeOne;
            guessArray[11] = threeTwo;
            guessArray[12] = threeThree;
            guessArray[13] = threeFour;
            guessArray[14] = threeFive;
            guessArray[15] = fourOne;
            guessArray[16] = fourTwo;
            guessArray[17] = fourThree;
            guessArray[18] = fourFour;
            guessArray[19] = fourFive;
            guessArray[20] = fiveOne;
            guessArray[21] = fiveTwo;
            guessArray[22] = fiveThree;
            guessArray[23] = fiveFour;
            guessArray[24] = fiveFive;
            guessArray[25] = sixOne;
            guessArray[26] = sixTwo;
            guessArray[27] = sixThree;
            guessArray[28] = sixFour;
            guessArray[29] = sixFive;
            guessArray[30] = sevenOne;
            guessArray[31] = sevenTwo;
            guessArray[32] = sevenThree;
            guessArray[33] = sevenFour;
            guessArray[34] = sevenFive;
        }

        private void bwFiller()
        {
            bwChecker[0] = bw1;
            bwChecker[1] = bw2;
            bwChecker[2] = bw3;
            bwChecker[3] = bw4;
            bwChecker[4] = bw5;
            bwChecker[5] = bw6;
            bwChecker[6] = bw7;
            bwChecker[7] = bw8;
            bwChecker[8] = bw9;
            bwChecker[9] = bw10;
            bwChecker[10] = bw11;
            bwChecker[11] = bw12;
            bwChecker[12] = bw13;
            bwChecker[13] = bw14;
            bwChecker[14] = bw15;
            bwChecker[15] = bw16;
            bwChecker[16] = bw17;
            bwChecker[17] = bw18;
            bwChecker[18] = bw19;
            bwChecker[19] = bw20;
            bwChecker[20] = bw21;
            bwChecker[21] = bw22;
            bwChecker[22] = bw23;
            bwChecker[23] = bw24;
            bwChecker[24] = bw25;
            bwChecker[25] = bw26;
            bwChecker[26] = bw27;
            bwChecker[27] = bw28;
            bwChecker[28] = bw29;
            bwChecker[29] = bw30;
            bwChecker[30] = bw31;
            bwChecker[31] = bw32;
            bwChecker[32] = bw33;
            bwChecker[33] = bw34;
            bwChecker[34] = bw35;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 newGame = new Form1();
            newGame.Visible = true;
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToPlay newAbout = new HowToPlay();
            newAbout.Visible = true;
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
