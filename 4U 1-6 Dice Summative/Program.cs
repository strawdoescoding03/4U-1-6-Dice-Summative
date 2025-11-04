using _4U_Topic_5._5_Classes;
using System;
using System.Drawing;

namespace _4U_1_6_Dice_Summative
{
    internal class Program
    {
        static double wallet;
        static int houseAngerPoints = 0, wins = 0, losses = 0;
        static bool walletSetUpComplete = false, gameOver = false;

        static void Main(string[] args)
        {
            string walletSetUpStatus = "INCOMPLETE";
            string userChoice;

            //Main Menu

            Console.Title = "The Gambler's Den";

            Console.WriteLine("Welcome to the Gambler's Den!");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("In your worldly travels, your unfortunate self has accidentally stumbled");
            Console.WriteLine("into The Gambler's Den, organized by a cruel and cunning ruler.");
            Thread.Sleep(1000);
            Console.WriteLine("You were captivated by the beauty of the foreign land...");
            Thread.Sleep(1000);
            Console.WriteLine("But now, you're stuck!");
            Thread.Sleep(1000);
            Console.WriteLine("There are only two methods of escape: ");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("\t 1) You must win at least one bet against the house");
            Console.WriteLine("\t 2) You are thrown out due to insufficient funds");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("If you manage to win against the house, you may play again if you so dare.");
            Thread.Sleep(2000);
            Console.WriteLine("But remember... the Dice Master is exceptionally auspicious.");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();


            while (!walletSetUpComplete)
            {

                Console.WriteLine("You have [1] new task.");
                Console.WriteLine($"Wallet Set Up Status: {walletSetUpStatus}");
                Console.WriteLine("Please set up your wallet to proceed?");
                Console.WriteLine("If you input an invalid responce, wallet will be set to 100.");
                Console.WriteLine();
                Console.Write("Press the w key followed by the enter key to set up your wallet: ");
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower().Trim();

                if (userChoice != "w")
                {
                    wallet = 100;
                    walletSetUpComplete = true;
                    Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                    Console.WriteLine($"             Your wallet has been set to {wallet}");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("Oh No! You've angered the Dice Master!");
                    Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                    Console.WriteLine("...Good Luck.");
                    houseAngerPoints += 3;
                }

                else
                {
                    Console.Clear();
                    WalletSetUp();
                }
            }

            while (!gameOver)
            {
                Console.WriteLine("DICE MASTER: I'm in the mood for a game...");
                Console.WriteLine("===========================================================");
                Console.WriteLine("1) Doubles");
                Console.WriteLine("2) Not Doubles");
                Console.WriteLine("3) Even Sum");
                Console.WriteLine("4) Odd Sum");
                Console.WriteLine("5) Rules");
                Console.WriteLine("6) Stats");
                if(wins >= 1)
                    Console.WriteLine("7) Escape");
                Console.ReadLine();
                Console.Clear();
                
            }
        }



        public static void WalletSetUp()
        {
            int userChoice;
            string strUserChoice;
            double addMoney;

            Console.Title = "Wallet Set Up";
            Console.WriteLine("Welcome to the Gambler's Den Wallet Set Up!");
            Console.WriteLine("In order to play, you must set up your wallet.");
            Console.WriteLine("========================================================================");
            Console.WriteLine("Here are the rules to setting up your wallet");
            Console.WriteLine();
            Console.WriteLine("\t*Players cannot bring in more than $500 dollars;");
            Console.WriteLine("\t   however, they can take out more than $500.");
            Console.WriteLine("\t*You cannot extract money until you have left the Gambler's Den");
            Console.WriteLine("\t*You cannot add a negitive amount of money to your wallet.");
            Console.WriteLine("========================================================================");
            Console.WriteLine();
            Console.WriteLine("Lets set up your wallet!");
            Console.WriteLine();
            Console.WriteLine("How much money you you like to enter your wallet?");
            Console.WriteLine("\t1)$100");
            Console.WriteLine("\t2)$250");
            Console.WriteLine("\t3)$500");
            Console.WriteLine("\t4)Custom");
            Console.WriteLine();
            Console.WriteLine("Please enter a number between 1 and 4");
            Console.WriteLine();
            Console.Write("Your requested number: ");
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice > 4 || userChoice < 1)
            {
                Console.WriteLine("DICE MASTER: You were unable to follow a SIMPLE instruction?!");
                Console.WriteLine($"            Its a NUMBER between 1 AND 4! Try again");
                Console.WriteLine("===============================================================");
                Console.WriteLine("Oh No! You've angered the Dice Master!");
                Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                Console.WriteLine("...Good Luck.");
                houseAngerPoints += 2;
                Console.WriteLine();
                Console.Write("Your requested amount: ");
            }
            strUserChoice = userChoice.ToString();
            Console.WriteLine();
            Console.WriteLine("Thank you for your choice!");
            if (strUserChoice == "4")
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }

            switch (strUserChoice)
            {
                case "1":
                    {
                        wallet = 100.00;
                        Console.WriteLine($"Success! Your wallet now contains ${wallet}!");
                        Console.WriteLine("You are ready to gamble!");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        walletSetUpComplete = true;
                    }
                    break;

                case "2":
                    {
                        wallet = 250.00;
                        Console.WriteLine($"Success! Your wallet now contains ${wallet}!");
                        Console.WriteLine("You are ready to gamble!");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        walletSetUpComplete = true;
                    }
                    break;

                case "3":
                    {
                        wallet = 500.00;
                        Console.WriteLine($"Success! Your wallet now contains ${wallet}!");
                        Console.WriteLine("You are ready to gamble!");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        walletSetUpComplete = true;
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("How much would you like to enter?");

                        while (!Double.TryParse((Console.ReadLine()), out addMoney) || addMoney < 0 || addMoney > 500)
                        {
                            if (addMoney < 0)
                            {
                                Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                                Console.WriteLine($"            You cannot enter a negitive number in your wallet!");
                                Console.WriteLine("             Try again!");
                                Console.WriteLine("===============================================================");
                                Console.WriteLine("Oh No! You've angered the Dice Master!");
                                Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                                Console.WriteLine("...Good Luck.");
                                houseAngerPoints += 2;
                                Console.WriteLine();
                                Console.Write("Your requested amount: ");
                            }
                            else if (addMoney > 500)
                            {
                                Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                                Console.WriteLine($"            You cannot enter a number which exceeds the");
                                Console.WriteLine("             wallet threshold! Try again!");
                                Console.WriteLine("===============================================================");
                                Console.WriteLine("Oh No! You've angered the Dice Master!");
                                Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                                Console.WriteLine("...Good Luck.");
                                houseAngerPoints += 1;
                                Console.WriteLine();
                                Console.Write("Your requested amount: ");
                            }

                            else
                            {
                                Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                                Console.WriteLine($"            That is NOT a number? Do you perchance have a");
                                Console.WriteLine("             brain? Try again!");
                                Console.WriteLine("===============================================================");
                                Console.WriteLine("Oh No! You've angered the Dice Master!");
                                Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                                Console.WriteLine("...Good Luck.");
                                houseAngerPoints += 3;
                                Console.WriteLine();
                                Console.Write("Your requested amount: ");
                            }
                        }

                        wallet += addMoney;

                        Console.WriteLine("DICE MASTER: I doubted your abilites at first, but I'm");
                        Console.WriteLine($"            pleasently supprised! Good work.");
                        Console.WriteLine("===============================================================");

                        if (houseAngerPoints > 0)
                        {
                            Console.WriteLine("Congratulations! You were able to calm down the Dice Master");
                            if (houseAngerPoints > 5)
                            {
                                Console.WriteLine("with your input! 3 anger points have been reduced!");
                                houseAngerPoints = houseAngerPoints - 3;
                                Console.WriteLine($"The Dice Master currently has {houseAngerPoints} AP");
                            }
                            if (houseAngerPoints <= 5)
                            {
                                Console.WriteLine("with your input! Anger Points have been reduced by 1!");
                                houseAngerPoints = houseAngerPoints - 1;
                                Console.WriteLine($"The Dice Master currently has {houseAngerPoints} AP");
                            }
                            Console.WriteLine("...Try not to make the Dice Master too angry.");
                            Console.WriteLine("Or winning will be impossible!");
                        }

                        else
                        {
                            Console.WriteLine("Congratulations! You made it through this section without");
                            Console.WriteLine("angering the House Master! Keep it up and escape will be");
                            Console.WriteLine("easy!");
                        }
                        Console.WriteLine($"Success! Your wallet now contains ${wallet}!");
                        Console.WriteLine("You are ready to gamble!");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        walletSetUpComplete = true;
                    }
                    break;
            }

            Console.WriteLine();
        }

        public static void Doubles()
        {            
            Console.Title = "The Gambler's Den || Doubles";

            double doublesBet;
            Random generator = new Random();
            List <ConsoleColor> diceColours;

            diceColours = new List<ConsoleColor>();

            diceColours.Add(ConsoleColor.Blue);
            diceColours.Add(ConsoleColor.Red);
            diceColours.Add(ConsoleColor.Green);
            diceColours.Add(ConsoleColor.Magenta);



            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            Console.WriteLine(Console.Title);
            Console.WriteLine("============================");
            Console.WriteLine("Welcome to the Gambler's Den. You have bet on Doubles");
            Console.WriteLine();
            Console.WriteLine("====================================================================");
            Console.WriteLine("DICE MASTER: Before you can role, place a bet worthy of my time.");
            if (!Double.TryParse(Console.ReadLine(), out doublesBet) || doublesBet < wallet * 0.07 || doublesBet > wallet)
            {
                Console.WriteLine("DICE MASTER: Those bets are unworthy of my time.");
                Console.WriteLine("             Since you are incapible of making a bet on your own");
                Console.WriteLine("             I'll take it as all or nothing. Sounds fair?");
                Console.WriteLine("             No? Well, too bad. My patience is running thin ");
                Console.WriteLine("====================================================================");
                doublesBet = wallet;
                Console.WriteLine($"[SUCCESS] Your bet of {doublesBet.ToString("C")} has been placed");
                Console.WriteLine($"Dice will roll shortly");
            }
            else
            {
                Console.WriteLine("DICE MASTER: That bet is quite worthy of this one's time");
                Console.WriteLine("             Much gratitude for a competent opponent");
                Console.WriteLine("             May the luckiest one here win...");
                Console.WriteLine("====================================================================");
                Console.WriteLine($"[SUCCESS] Your bet of {doublesBet.ToString("C")} has been placed");
                Console.WriteLine($"Dice will roll shortly");
            }
            Console.WriteLine();
            Console.Write("Press any key to roll the dice");
            Console.ReadLine();
            Console.Clear();

            Console.Title ="The Gambler's Den || The Dice House";
            Console.WriteLine("===================================");

            Console.WriteLine("DICE MASTER: Before we begin, let us choose the colour of our dice");
            Console.WriteLine("             I'll let you go first... for good luck");
            Console.WriteLine("====================================================================");
            die1.Colour = SetColour();

            Console.WriteLine();
            Console.WriteLine($"DICE MASTER: Good choice. I quite like the colour {die1.Colour.ToString()}");
            Console.WriteLine("              Now it's my turn.");


            for (int i = 0; i < diceColours.Count; i++)

            {
                foreach (ConsoleColor colour in diceColours)
                {
                    if (colour == die1.Colour)
                    {
                        diceColours.Remove[i];
                    }
                }
            }


            die1.RollDie();
            die2.RollDie();


            if (houseAngerPoints > 0)
            {
                if (die1.Roll == die2.Roll)
                {
                   for (int i = 0; i < houseAngerPoints; i++)
                    {
                        die1.RollDie();
                        die2.RollDie();
                    }
                }

            }

            if (die1.Roll == die2.Roll)
            {
                wallet += 2 * (doublesBet);
                wins += 1;
                houseAngerPoints += 4;
            }

            else
            {
                wallet -= doublesBet;
                losses += 1;
                if (houseAngerPoints > 0)
                    houseAngerPoints -= 1;
            }


        }

        public static void NotDoubles()
        {
            Console.Title = "The Gambler's Den || Not Doubles";

            double doublesBet = 10;

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            die1.RollDie();
            die2.RollDie();


            if (houseAngerPoints > 0)
            {
                if (die1.Roll != die2.Roll)
                {
                    for (int i = 0; i < houseAngerPoints; i++)
                    {
                        die1.RollDie();
                        die2.RollDie();
                    }
                }

            }

            if (die1.Roll != die2.Roll)
            {
                wallet += 0.5f * (doublesBet);
                wins += 1;
                houseAngerPoints += 4;
            }

            else
            {
                wallet -= doublesBet;
                losses += 1;
                if (houseAngerPoints > 0)
                    houseAngerPoints -= 1;
            }


        }

        public static void EvenSum()
        {
            Console.Title = "The Gambler's Den || Even Sum";
            double doublesBet = 10;
            int dieTotal;

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            die1.RollDie();
            die2.RollDie();

            dieTotal = die1.Roll + die2.Roll;



            if (houseAngerPoints > 0)
            {
                if (dieTotal %2 == 0)
                {
                    for (int i = 0; i < houseAngerPoints; i++)
                    {
                        die1.RollDie();
                        die2.RollDie();
                    }
                }

            }

            dieTotal = die1.Roll + die2.Roll;
            if (dieTotal % 2 == 0)
            {
                wallet += doublesBet;
                wins += 1;
                houseAngerPoints += 4;
            }

            else
            {
                wallet -= doublesBet;
                losses += 1;
                if (houseAngerPoints > 0)
                    houseAngerPoints -= 1;
            }

        }

        public static void OddSum()
        {
            double oddSumBet;
            Console.Title = "The Gambler's Den || Odd Sum";

            double doublesBet = 10;
            int dieTotal;

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            die1.RollDie();
            die2.RollDie();

            dieTotal = die1.Roll + die2.Roll;



            if (houseAngerPoints > 0)
            {
                if (dieTotal % 2 != 0)
                {
                    for (int i = 0; i < houseAngerPoints; i++)
                    {
                        die1.RollDie();
                        die2.RollDie();
                    }
                }

            }

            dieTotal = die1.Roll + die2.Roll;
            if (dieTotal % 2 != 0)
            {
                wallet += doublesBet;
                wins += 1;
                houseAngerPoints += 4;
            }

            else
            {
                wallet -= doublesBet;
                losses += 1;
                if (houseAngerPoints > 0)
                    houseAngerPoints -= 1;
            }
        }

        public static ConsoleColor SetColour()
        {
            string colour;
            Console.WriteLine("Colour Set");
            Console.WriteLine("==========");
            Console.WriteLine("* Red");
            Console.WriteLine("* Blue");
            Console.WriteLine("* Green");
            Console.WriteLine("* Purple");
            Console.WriteLine("==========");
            Console.WriteLine("Please select a colour for your die from the options above:");
            colour = Console.ReadLine();
            colour = colour.ToLower();

            while (colour != "red" && colour != "blue" && colour != "green" && colour != "purple")
            {
                Console.WriteLine("Invalid colour. Please select Red, Blue, Green, or Purple.");
                colour = Console.ReadLine();
                colour = colour.ToLower();

            }
            Console.WriteLine("You have selected " + colour + " as your die colour.");

            if (colour == "blue")
            {
                return ConsoleColor.Blue;
            }
            else if (colour == "green")
            {
                return ConsoleColor.Green;
            }
            else if (colour == "purple")
            {
                return ConsoleColor.Magenta;
            }
            else
            {
                return ConsoleColor.Red;
            }
        }




        public static void Rules()
        {
            string userChoice;


            Console.Title = "The Gambler's Den || Rules";
            Console.WriteLine(Console.Title);
            Console.WriteLine("==================================================================");
            Console.WriteLine("Welcome to the Gambler's Den. The rules are quite simple:");
            Console.WriteLine();
            Console.WriteLine("HOUSE RULES");
            Console.WriteLine("==================");
            Console.WriteLine("1) Do NOT anger the Dice Master! For every anger point you score,");
            Console.WriteLine("   if you get the bet right on your first try, the dice will be");
            Console.WriteLine("   rerolled. (ie. You have 15 AP, the dice will be rerolled 15x)");
            Console.WriteLine();
            Console.WriteLine("2) You cannot back out of a bet. Money over life, Gains over Shame");
            Console.WriteLine();
            Console.WriteLine("3) You connot leave the Gambler's den until you've one once");
            Console.WriteLine("   against the Dice Master. Prove you're the luckiest on here");
            Console.WriteLine("   and you can leave");
            Console.WriteLine();
            Console.WriteLine("4) All wins result in +4 anger points");
            Console.WriteLine("   All losses result in -1 anger points");
            Console.WriteLine();
            Console.WriteLine("BET AND GAME RULES");
            Console.WriteLine("==================");
            Console.WriteLine("1) Betting on doubles and winning will result in double your bet");
            Console.WriteLine();
            Console.WriteLine("2) Betting on not doubles and winning will result in half your bet");
            Console.WriteLine();
            Console.WriteLine("3) Betting on even sums will win your full bet");
            Console.WriteLine();
            Console.WriteLine("4) Betting on odd sums will win your full bet");
            Console.WriteLine();
            Console.WriteLine("5) Incorrect results will result in a lost bet");
            Console.WriteLine("==================================================================");
            Console.Write("Press r followed by the enter key to return to the Gambler's Den: ");
            userChoice = Console.ReadLine();
            userChoice = userChoice.ToLower().Trim();

            if (userChoice != "r")
            {
                wallet = 100;
                walletSetUpComplete = true;
                Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                Console.WriteLine("             I'll let you off easy...this time.");
                Console.WriteLine("=============================================================");
                Console.WriteLine("Few! That was close! Do not anger the Dice Master!");
                Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                Console.WriteLine("...Good Luck.");
            }
            else
            {
                Console.Clear();
            }
        }
    }  


}
