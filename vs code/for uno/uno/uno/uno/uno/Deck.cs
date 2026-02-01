 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace uno
{
    internal class Deck
    {

        Card[] unoCard = new Card[37];
        Card[] p1Hand;
        Card[] p2Hand;
        Card[] p3Hand;
        Card[] p4Hand;

        int[] discard;

        private int size;

        //testing bitmap - Erin K
        //blue cards
        Bitmap blue1 = new Bitmap(Image.FromFile("../../blueone.png"));
        Bitmap blue2 = new Bitmap(Image.FromFile("../../bluetwo.png"));
        Bitmap blue3 = new Bitmap(Image.FromFile("../../bluethree.png"));
        Bitmap blue4 = new Bitmap(Image.FromFile("../../bluefour.png"));
        Bitmap blue5 = new Bitmap(Image.FromFile("../../bluefive.png"));
        Bitmap blue6 = new Bitmap(Image.FromFile("../../bluesix.png"));
        Bitmap blue7 = new Bitmap(Image.FromFile("../../blueseven.png"));
        Bitmap blue8 = new Bitmap(Image.FromFile("../../blueeght.png"));
        Bitmap blue9 = new Bitmap(Image.FromFile("../../bluenine.png"));


        //red cards - Thomas L.
        Bitmap red1 = new Bitmap(Image.FromFile("../../redone.png"));
        Bitmap red2 = new Bitmap(Image.FromFile("../../redtwo.png"));
        Bitmap red3 = new Bitmap(Image.FromFile("../../redthree.png"));
        Bitmap red4 = new Bitmap(Image.FromFile("../../redfour.png"));
        Bitmap red5 = new Bitmap(Image.FromFile("../../redfive.png"));
        Bitmap red6 = new Bitmap(Image.FromFile("../../redsix.png"));
        Bitmap red7 = new Bitmap(Image.FromFile("../../redseven.png"));
        Bitmap red8 = new Bitmap(Image.FromFile("../../redeight.png"));
        Bitmap red9 = new Bitmap(Image.FromFile("../../rednine.png"));

        //green cards -Thomas L.
        Bitmap green1 = new Bitmap(Image.FromFile("../../greenone.png"));
        Bitmap green2 = new Bitmap(Image.FromFile("../../greentwo.png"));
        Bitmap green3 = new Bitmap(Image.FromFile("../../greenthree.png"));
        Bitmap green4 = new Bitmap(Image.FromFile("../../greenfour.png"));
        Bitmap green5 = new Bitmap(Image.FromFile("../../greenfive.png"));
        Bitmap green6 = new Bitmap(Image.FromFile("../../greensix.png"));
        Bitmap green7 = new Bitmap(Image.FromFile("../../greenseven.png"));
        Bitmap green8 = new Bitmap(Image.FromFile("../../greeneight.png"));
        Bitmap green9 = new Bitmap(Image.FromFile("../../greennine.png"));

        //purple cards -Thomas L.
        Bitmap purple1 = new Bitmap(Image.FromFile("../../purpleone.png"));
        Bitmap purple2 = new Bitmap(Image.FromFile("../../purpletwo.png"));
        Bitmap purple3 = new Bitmap(Image.FromFile("../../purplethree.png"));
        Bitmap purple4 = new Bitmap(Image.FromFile("../../purplefour.png"));
        Bitmap purple5 = new Bitmap(Image.FromFile("../../purplefive.png"));
        Bitmap purple6 = new Bitmap(Image.FromFile("../../purplesix.png"));
        Bitmap purple7 = new Bitmap(Image.FromFile("../../purpleseven.png"));
        Bitmap purple8 = new Bitmap(Image.FromFile("../../purpleeight.png"));
        Bitmap purple9 = new Bitmap(Image.FromFile("../../purplenine.png"));

        Bitmap back = new Bitmap(Image.FromFile("../../unoback.png"));


        /*
        How do I insert an image into an array?
        Once you've created your image object, you can then push it to arrayOfImages as usual:
         // Declare an array object for our array of images let arrayOfImages = []; // Create image
          object and assign width and height let myImage = new Image('1024','768'); // Assign src attribute to image object myImage.
        */


        public void AssembleDeck()
        {
            Bitmap table = new Bitmap(Image.FromFile("../../table.png"));

            //the first number is equal to what colour the card is

            //colour one is red
            //colour two is blue
            //colour three is green
            //colour four is purple


            //the second number is what the number of the card is

            //card number 1 is for the back of the card

            //back of card - Thomas L.

            //red deck array[0]-[8] - Erin K.
            unoCard[0] = new Card("red", 1, red1);
            unoCard[1] = new Card("red", 2, red2);
            unoCard[2] = new Card("red", 3, red3);
            unoCard[3] = new Card("red", 4, red4);
            unoCard[4] = new Card("red", 5, red5);
            unoCard[5] = new Card("red", 6, red6);
            unoCard[6] = new Card("red", 7, red7);
            unoCard[7] = new Card("red", 8, red8);
            unoCard[8] = new Card("red", 9, red9);

            //blue deck array[9]-[17] - Erin K.
            unoCard[9] = new Card("blue", 1, blue1);
            unoCard[10] = new Card("blue", 2, blue2);
            unoCard[11] = new Card("blue", 3, blue3);
            unoCard[12] = new Card("blue", 4, blue4);
            unoCard[13] = new Card("blue", 5, blue5);
            unoCard[14] = new Card("blue", 6, blue6);
            unoCard[15] = new Card("blue", 7, blue7);
            unoCard[16] = new Card("blue", 8, blue8);
            unoCard[17] = new Card("blue", 9, blue9);

            //green deck array [18] - [26] - Thomas L.
            unoCard[18] = new Card("green", 1, green1);
            unoCard[19] = new Card("green", 2, green2);
            unoCard[20] = new Card("green", 3, green3);
            unoCard[21] = new Card("green", 4, green4);
            unoCard[22] = new Card("green", 5, green5);
            unoCard[23] = new Card("green", 6, green6);
            unoCard[24] = new Card("green", 7, green7);
            unoCard[25] = new Card("green", 8, green8);
            unoCard[26] = new Card("green", 9, green9);

            //purple deck array [27] - [35] - Thomas L.
            unoCard[27] = new Card("purple", 1, purple1);
            unoCard[28] = new Card("purple", 2, purple2);
            unoCard[29] = new Card("purple", 3, purple3);
            unoCard[30] = new Card("purple", 4, purple4);
            unoCard[31] = new Card("purple", 5, purple5);
            unoCard[32] = new Card("purple", 6, purple6);
            unoCard[33] = new Card("purple", 7, purple7);
            unoCard[34] = new Card("purple", 8, purple8);
            unoCard[35] = new Card("purple", 9, purple9);
            //back of uno card - Thomas L
            unoCard[36] = new Card("back", 1, back);
        }
        
        public void ShuffleunoCard()
        {
            Console.WriteLine("We Made it here!! Cards are shuffled");
            //Made by Mr Winkler

            //Shuffle The UnoCards
            Random random = new Random();

            for (int i = unoCard.Length - 1; i > 0; i--)
            {
                int randomIndex = random.Next(0, i + 1);

                Card temp = unoCard[i];
                unoCard[i] = unoCard[randomIndex];
                unoCard[randomIndex] = temp;
            }

            int handSize = 5;

            p1Hand = new Card[handSize];
            p2Hand = new Card[handSize];
            p3Hand = new Card[handSize];
            p4Hand = new Card[handSize];

            for (int i = 0; i < handSize; i++)
            {

                p1Hand[i] = unoCard[i];

                // To Do later
                p2Hand[i] = unoCard[i];
                p3Hand[i] = unoCard[i];
                p4Hand[i] = unoCard[i];

            }

        }

        //Drawing random card below this will only be used once- Erin K.
        public void topCard()
        {
            //first card flipped
            Card discard = new Card();
            int S = unoCard.Length;
            var rng = new Random();

            int N = rng.Next(S--);
            while (unoCard[N] == null)
            {
                N = rng.Next(S);
            }
            unoCard[N] = null;
            discard = unoCard[N];

            discardFunction();

        }

        public void discardFunction()
        {
            int l = unoCard.Length;
            //clueless
            
        }






        //- Erin K.
        //if we make a random card like this it would be placed as if flipped as first card
        //this is now the card that users need to see and match to, do they have same color or number or a wild card (wild card for later)
        //how does discard pile work and how do I call this right after start button is clicked?
        //each time a player places a card it's top of array
        //Stack?

        //if used stack, use specific 'pop' = "Removes and returns items from the top of the stack."


    }
}
