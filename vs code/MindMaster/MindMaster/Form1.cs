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
    public partial class Form1 : Form
    {
        String[] answer;
        public Form1()
        {
            InitializeComponent();
            answer = new String[5];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void twoPlayerBut_Click(object sender, EventArgs e)
        {
            Select newWindow = new MindMaster.Select(answer);
            newWindow.Visible = true;
            this.Visible = false;
        }

        private void onePlayerBut_Click(object sender, EventArgs e)
        {
            Random myRan = new Random();
            int ranNum = 0;

            for(int i = 0; i < 5; i++)
            {
                ranNum = myRan.Next (0, 5);
                if(ranNum == 0)
                {
                    answer[i] = "red";
                }
                else if(ranNum == 1)
                {
                    answer[i] = "orange";
                }
                else if(ranNum == 2)
                {
                    answer[i] = "blue";
                }
                else if(ranNum == 3)
                {
                    answer[i] = "green";
                }
                else
                {
                    answer[i] = "yellow";
                }
            }
            Game newWindow = new Game(answer);
            newWindow.Visible = true;
            this.Visible = false;


        }
    }
}
