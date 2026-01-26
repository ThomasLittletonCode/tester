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
    public partial class Select : Form
    {
        String[] answer;

        public Select(String[] ans)
        {
            InitializeComponent();
            answer = ans;
        }

        private void Select_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //First Box
            if (checkBox1 .Checked)
            {
                answer[0] = "red";
            }
            else if(checkBox4.Checked)
            {
                answer[0] = "orange";
            }
            else if(checkBox2.Checked)
            {
                answer[0] = "blue";
            }
            else if(checkBox3.Checked)
            {
                answer[0] = "green";
            }
            else if(checkBox5.Checked)
            {
                answer[0] = "yellow";
            }

            //Second Box
            if (checkBox10.Checked)
            {
                answer[1] = "red";
            }
            else if (checkBox7.Checked)
            {
                answer[1] = "orange";
            }
            else if (checkBox9.Checked)
            {
                answer[1] = "blue";
            }
            else if (checkBox8.Checked)
            {
                answer[1] = "green";
            }
            else if (checkBox6.Checked)
            {
                answer[1] = "yellow";
            }

            //Thrid box
            if (checkBox15.Checked)
            {
                answer[2] = "red";
            }
            else if (checkBox12.Checked)
            {
                answer[2] = "orange";
            }
            else if (checkBox14.Checked)
            {
                answer[2] = "blue";
            }
            else if (checkBox13.Checked)
            {
                answer[2] = "green";
            }
            else if (checkBox11.Checked)
            {
                answer[2] = "yellow";
            }

            //Forth Box
            if (checkBox20.Checked)
            {
                answer[3] = "red";
            }
            else if (checkBox17.Checked)
            {
                answer[3] = "orange";
            }
            else if (checkBox19.Checked)
            {
                answer[3] = "blue";
            }
            else if (checkBox18.Checked)
            {
                answer[3] = "green";
            }
            else if (checkBox16.Checked)
            {
                answer[3] = "yellow";
            }

            //Fifth Box
            if (checkBox25.Checked)
            {
                answer[4] = "red";
            }
            else if (checkBox22.Checked)
            {
                answer[4] = "orange";
            }
            else if (checkBox24.Checked)
            {
                answer[4] = "blue";
            }
            else if (checkBox23.Checked)
            {
                answer[4] = "green";
            }
            else if (checkBox21.Checked)
            {
                answer[4] = "yellow";
            }

            //Make a new game board
            Game newGame = new Game(answer);
            newGame.Visible = true;
            this.Visible = false;

        }
    }
}
