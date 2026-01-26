using System;

namespace mars_trail
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome
            Console.WriteLine("Welcome to Mars Trail by NASA!");

            //Gather user info and variables

            int playerNumber = 3;


            //first name
            Console.WriteLine("Please give me your first name");
            string name1 = Console.ReadLine();
            Boolean name1Alive = true;


            //second name
            Console.WriteLine("Please give me a second name");
            string name2 = Console.ReadLine();
            Boolean name2Alive = true;


            //third name
            Console.WriteLine("Please give me one more name");
            string name3 = Console.ReadLine();
            Boolean name3Alive = true;

            Console.Clear();

            //introduction

            //Fish Drawing
            Console.WriteLine("><{{{*>");

            Console.WriteLine();
            Console.WriteLine("In 2092, the cats have become rabid and the fish are dying.");
            Console.WriteLine("These rabid cats have been so deadly that they have killed off 40% of the population so far.");
            Console.WriteLine("Of all the NASA applicants, you, " + name2 + ", and " + name3 + " were chosen and are Earth's last hope.");
            Console.WriteLine("Russia and all the other countries have already been overrun and will not be able to send anyone upwards.");
            Console.WriteLine("No one ever has been to Mars yet, so hopefully NASA's new rocket was designed properly.");
            Console.WriteLine("Good luck, the human race is on your shoulders!");

            Console.ReadKey();
            Console.Clear();

            //number of items you may carry
            int itemSpace = 10;

            Console.WriteLine("You have food, rusty nail, duct-tape, and ammo that you can take with you. You must decide the quantity of each item. You have room for 10 in total.");

            //quanities of all the different items

            //food
            Console.WriteLine("How much food?");
            int food = Convert.ToInt32(Console.ReadLine());
            itemSpace = itemSpace - food;
            Console.WriteLine("You have " + itemSpace + " left.");

            //rusty nail
            Console.WriteLine("How many rusty nails?");
            int rusty = Convert.ToInt32(Console.ReadLine());
            itemSpace = itemSpace - rusty;
            Console.WriteLine("You have " + itemSpace + " left.");

            //duct-tape
            Console.WriteLine("How much duct-tape?");
            int tape = Convert.ToInt32(Console.ReadLine());
            itemSpace = itemSpace - tape;
            Console.WriteLine("You have " + itemSpace + " left.");

            //ammo
            Console.WriteLine("How much ammo?");
            int ammo = Convert.ToInt32(Console.ReadLine());
            itemSpace = itemSpace - ammo;
            Console.WriteLine("You have " + itemSpace + " left.");

            Console.Clear();

            //If you picked too many items

            if (itemSpace < 0)
            {
                Console.WriteLine("You and your crew have been caught trying to sneak extra supplies onto the rocket.");
                Console.WriteLine(">>>>>>>>>>MARS CREW LOST IN ACTION<<<<<<<<<<");
                Console.ReadKey();
                Environment.Exit(0);
            }


            //The journey begins
            //The landing

            else
            {
                Console.WriteLine("The rocket takes off and it was a success!");

                //Space shuttle drawing
                Console.WriteLine("-------- ><*>");

                Console.WriteLine("You see Mars up ahead, you have three choices.");
                Console.WriteLine("1. Turn back to Earth");
                Console.WriteLine("2. Prepare for the landing");
                Console.WriteLine("3. Let " + name2 + " make the decision");

                int option = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                //Turn back to Earth
                if (option == 1)
                {
                    Console.Clear();
                    Console.WriteLine("You don't have enough fuel to make it back, you and your crew become stranded in space.");
                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                    Environment.Exit(0);
                }
                //Prepare for landing or make the decision
                if (option == 2 || option == 3)
                {
                    Console.Clear();
                    if (option == 3)
                    {
                        Console.WriteLine(name2 + " chose to prepare for the landing");
                    }

                    //The landing result
                    Console.WriteLine("The landing was very rough, your lucky you didn't die.");
                    Console.WriteLine(name3 + " says the rough landing was due to the weather, but they had no choice.");

                    //To go outside or not to
                    Console.WriteLine("You have landed and you and your team can either");
                    Console.WriteLine("1. Go outside without checking the gear");
                    Console.WriteLine("2. Wait until morning");
                    Console.WriteLine("3. Check the gear then go outside");

                    option = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();


                    //Go outside without checking gear
                    if (option == 1)
                    {
                        Console.WriteLine("You go outside without checking your gear. It appears there were cracks from the rough landing on all the helmets.");
                        Console.WriteLine("The Mars air bites at you and your crewmates faces");
                        Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                        Environment.Exit(0);
                    }
                    if (option == 3 || option == 2)
                    {
                        //Who Will stay behind?
                        if (option == 3)
                        {
                            Console.WriteLine("You and your crew find cracks on all the helmets, it will take a roll of duct-tape to fix them.");
                            if (tape < 1)
                            {
                                //should have brought duct-tape
                                Console.WriteLine("You and your crew cannot go outside, you should have brought duct-tape.");
                                Console.WriteLine("Finally, you find something to repair two of the three cracks, but someone will have to stay behind.");

                                //who is left to be able to be left behind
                                Console.WriteLine("Who will stay behind?");
                                if (name1Alive == true)
                                {
                                    Console.WriteLine("1. " + name1);
                                }

                                if (name2Alive == true)
                                {
                                    Console.WriteLine("2. " + name2);
                                }

                                if (name3Alive == true)
                                {
                                    Console.WriteLine("3. " + name3);
                                }

                                int option1 = Convert.ToInt32(Console.ReadLine());

                                //who will be left behind
                                if (option1 == 1)
                                {
                                    Console.WriteLine(name1 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name1Alive = false;
                                    playerNumber = playerNumber - 1;

                                    Console.ReadKey();
                                }
                                if (option1 == 2)
                                {
                                    Console.WriteLine(name2 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name2Alive = false;
                                    playerNumber = playerNumber - 1;

                                    Console.ReadKey();
                                }
                                if (option1 == 3)
                                {
                                    Console.WriteLine(name3 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name3Alive = false;
                                    playerNumber = playerNumber - 1;

                                    Console.ReadKey();
                                }
                            }

                            //if you packed enough duct-tape
                            if (tape > 0)
                            {
                                Console.WriteLine("The duct-tape is sketchy, but you can go exploring.");
                                Console.ReadKey();
                            }


                        }
                        //Wait until morning
                        if (option == 2)
                        {
                            Console.WriteLine("It's morning.");
                            Console.ReadKey();
                        }
                        //Time to explore
                        Console.Clear();

                        //where to go?
                        Console.WriteLine("Now to explore. You landed in the South Polar Cup.");
                        Console.WriteLine("No one has ever explored Mars so there could be many things.");
                        Console.WriteLine("You have three directions you may take");
                        Console.WriteLine("1. Tharis Montes");
                        Console.WriteLine("2. Terra Sirenum");
                        Console.WriteLine("3. Solis Lacus");

                        option = Convert.ToInt32(Console.ReadLine());

                        //Tharis Montes
                        if (option == 1)
                        {
                            Console.WriteLine("Unfortunately Tharis Montes is the longest journey and everyone must eat 2 food rations.");

                            food = food - (playerNumber * 2);

                            if (food < 0)
                            {
                                //not enough food
                                Console.WriteLine("Unfortunately you don't have enough food rations, someone must starve.");

                                //who is still alive?
                                if (name1Alive == true)
                                {
                                    Console.WriteLine("1. " + name1);
                                }

                                if (name2Alive == true)
                                {
                                    Console.WriteLine("2. " + name2);
                                }

                                if (name3Alive == true)
                                {
                                    Console.WriteLine("3. " + name3);
                                }

                                int option10 = Convert.ToInt32(Console.ReadLine());

                                //who dies?
                                if (option10 == 1)
                                {
                                    Console.WriteLine(name1 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name1Alive = false;
                                    playerNumber = playerNumber - 1;
                                }
                                if (option10 == 2)
                                {
                                    Console.WriteLine(name2 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name2Alive = false;
                                    playerNumber = playerNumber - 1;
                                }
                                if (option10 == 3)
                                {
                                    Console.WriteLine(name3 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name3Alive = false;
                                    playerNumber = playerNumber - 1;
                                }
                            }

                            //you packed enough food
                            else
                            {
                                Console.WriteLine("Good job planning ahead for enough food.");
                                Console.ReadKey();
                            }
                        }

                        Console.Clear();

                        //terra sirenum
                        if (option == 2)
                        {
                            Console.WriteLine("Terra Sirenum is a good distance so everyone must eat some food.");

                            food = food - playerNumber;

                            //not enough food
                            if (food < 0)
                            {
                                Console.WriteLine("Unfortunately you don't have enough food rations, someone must starve.");

                                //who is still alive?
                                if (name1Alive == true)
                                {
                                    Console.WriteLine("1. " + name1);
                                }

                                if (name2Alive == true)
                                {
                                    Console.WriteLine("2. " + name2);
                                }

                                if (name3Alive == true)
                                {
                                    Console.WriteLine("3. " + name3);
                                }

                                int option10 = Convert.ToInt32(Console.ReadLine());

                                //who dies?
                                if (option10 == 1)
                                {
                                    Console.WriteLine(name1 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name1Alive = false;
                                    playerNumber = playerNumber - 1;
                                }
                                if (option10 == 2)
                                {
                                    Console.WriteLine(name2 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name2Alive = false;
                                    playerNumber = playerNumber - 1;
                                }
                                if (option10 == 3)
                                {
                                    Console.WriteLine(name3 + " has been left behind and has died");
                                    Console.WriteLine(">>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                    name3Alive = false;
                                    playerNumber = playerNumber - 1;
                                }
                            }

                            //packed enough food
                            else
                            {
                                Console.WriteLine("Good job planning ahead for enough food.");
                            }
                        }

                        //solis lacus
                        if (option == 3)
                        {
                            Console.WriteLine("Fortunately for you, Solis Lacus is the shortest distance from your current location.");
                            Console.WriteLine("Its so short, you don't even need to eat!");
                        }

                        Console.ReadKey();
                        Console.Clear();

                        //arrival
                        Console.WriteLine("You have arrived at your destination, and you have found something that looks alive.");
                        Console.WriteLine("You and what's left of your crew approach this being.");

                        //Alien Drawing
                        Console.WriteLine(" (***)");
                        Console.WriteLine(" |( )|");
                        Console.WriteLine("  | |");

                        //Alien is Aggresive
                        Console.WriteLine("It apprears to be aggresive and is attacking you and your crew!");
                        Console.WriteLine("You can use;");

                        //choose your weapon!
                        if (rusty > 0)
                        {
                            Console.WriteLine("1. Rusty Nail");
                        }

                        if (ammo > 0)
                        {
                            Console.WriteLine("2. Ammo");
                        }

                        if (tape > 0)
                        {
                            Console.WriteLine("3. Duct-tape");
                        }

                        int option5 = Convert.ToInt32(Console.ReadLine());

                        //did you defeat the alien or die?

                        //killing the alien
                        if (option5 == 1)
                        {
                            Console.WriteLine("Congrats, you have defeated the enemy with the rusty nail!");
                            rusty = rusty - 1;
                            Console.ReadKey();
                            Console.Clear();

                            //Final score
                            int score = (playerNumber + food + rusty + ammo + tape) * 100;

                            Console.WriteLine("You had " + playerNumber + " crew members left.");
                            Console.WriteLine("You had " + food + " food left.");
                            Console.WriteLine("You had " + rusty + " rusty nails left.");
                            Console.WriteLine("You had " + ammo + " ammo left.");
                            Console.WriteLine("Your total score is " + score + ".");

                            Console.ReadKey();
                            Console.Clear();

                            Console.WriteLine("You have defeated the Alien and have successfully colonized Mars.");
                            Console.WriteLine(">>>>>>>>>>MISSION ACCOMPLISHED<<<<<<<<<");
                        }

                        //Choosing the wrong weapon
                        if (option5 == 2 || option5 == 3)
                        {
                            Console.WriteLine("Unfortunately your choice has unscathed the alien.");
                            Console.WriteLine("One of your crew mates has died.");

                            if (name2Alive = true)
                            {
                                Console.WriteLine(name2 + " has died");
                                Console.WriteLine(">>>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                name2Alive = false;
                                playerNumber = playerNumber - 1;
                            }

                            else if (name3Alive = true)
                            {
                                Console.WriteLine(name3 + " has died");
                                Console.WriteLine(">>>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                name3Alive = false;
                                playerNumber = playerNumber - 1;
                            }

                            else if (name1Alive = true)
                            {
                                Console.WriteLine(name2 + " has died");
                                Console.WriteLine(">>>>>>>>>>>KILLED IN ACTION<<<<<<<<<<");
                                name1Alive = false;
                                playerNumber = playerNumber - 1;
                            }

                            if (playerNumber < 1)
                            {
                                Console.WriteLine("All of the crew has died.");
                                Console.WriteLine(">>>>>>>>>>MARS CREW LOST IN ACTION<<<<<<<<<<");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }

                            //Lost
                            Console.Clear();
                            Console.WriteLine("The alien has chased you and your crew off and now you have lost the ship.");
                            Console.WriteLine("You and your crew have become lost and presumed dead.");
                            Console.WriteLine(">>>>>>>>>>MARS CREW LOST IN ACTION<<<<<<<<<<");
                        }
                    }
                }
            }

            Console.ReadKey();

        }
    }
}
