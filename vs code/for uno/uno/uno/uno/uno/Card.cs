using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//added in system.drawing to get images - Erin K.
namespace uno
{
    internal class Card
    {
        private string color;
        private int number;

        //this is the image variable, how do we use paint function with this to assign each peice of array an image? Ask for help - Erin K.
        private Image image;



        public Card()
        {

        }


        public Card(string color, int number, Image image)
        {
            this.color = color;
            this.number = number;
            this.image = image;
            
        }

        public string getColor()
        {
            return color;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        //Above is the getters and setters for the color aspect of card - Erin K.
        public int getNumber()
        {
            return number;
        }
        public void setNumber(int number)
        {
            this.number = number;
        }
        //Above is the getters and setters for the number aspect of card - Erin K.
        public Image getImage()
        {
            if (image == null)
            {
                Console.WriteLine("THIS IS BEING CALLED");
            }
            return image;
        }
        public  void setImage(Image image)
        {
            this.image = image;
            //do I need to change this in the future - Erin K.

        }
        //Above is the getters and setters for the Image aspect of the card, interference with paint function? - Erin K.
    }
}

