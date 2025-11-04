using _4U_Topic_5._5_Classes;
using System;
using System.Drawing;
using System.Reflection.Emit;

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
            string strUserChoice;
            int userChoice;
            //Main Menu

            Console.Title = "The Gambler's Den";

            Console.WriteLine("Welcome to the Gambler's Den!");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("In your worldly travels, your unfortunate self has accidentally stumbled");
            Console.WriteLine("into The Gambler's Den, organized by a cruel and cunning ruler.");
            Thread.Sleep(500);
            Console.WriteLine("You were captivated by the beauty of the foreign land...");
            Thread.Sleep(500);
            Console.WriteLine("But now, you're stuck!");
            Thread.Sleep(500);
            Console.WriteLine("There are only two methods of escape: ");
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("\t 1) You must win at least one bet against the house");
            Console.WriteLine("\t 2) You are thrown out due to insufficient funds");
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("If you manage to win against the house, you may play again if you so dare.");
            Thread.Sleep(1000);
            Console.WriteLine("But remember... the Dice Master is exceptionally auspicious.");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();


            while (!walletSetUpComplete)
            {

                Console.WriteLine("You have [1] new task.");
                Console.WriteLine($"Wallet Set Up Status: {walletSetUpStatus}");
                Console.WriteLine("Please set up your wallet to proceed?");
                Console.WriteLine("If you input an invalid responce, wallet will be set to $100.");
                Console.WriteLine();
                Console.Write("Press the w key followed by the enter key to set up your wallet: ");
                strUserChoice = Console.ReadLine();
                strUserChoice = strUserChoice.ToLower().Trim();

                if (strUserChoice != "w")
                {
                    wallet += 100;
                    walletSetUpComplete = true;
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                    Console.WriteLine($"             Your wallet has been set to {wallet.ToString("C")}");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("Oh No! You've angered the Dice Master!");
                    Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                    Console.WriteLine("...Good Luck.");
                    houseAngerPoints += 3;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
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
                if (wins >= 1)
                    Console.WriteLine("7) Escape");
                Console.WriteLine("===========================================================");
                Console.WriteLine();
                Console.Write("Enter the number of your requested game:");

                while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 7 || (userChoice == 7 && wins < 1))
                {
                    Console.WriteLine("DICE MASTER: You were unable to follow a SIMPLE instruction?!");

                    if (userChoice == 7 && wins < 1)
                    {
                        Console.WriteLine($"            Its a NUMBER between 1 AND 6! Try again");
                    }
                    else
                        Console.WriteLine($"            Its a NUMBER between 1 AND 7! Try again");
                    Console.WriteLine("===========================================================");
                    Console.WriteLine("Oh No! You've angered the Dice Master!");
                    Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                    Console.WriteLine("...Good Luck.");
                    houseAngerPoints += 2;
                    Console.WriteLine();
                    Console.Write("Your requested number: ");
                }

                strUserChoice = userChoice.ToString();

                switch (strUserChoice)
                {
                    case "1":
                        {
                            Console.Clear();
                            Doubles();
                        }
                        break;

                    case "2":
                        {
                            Console.Clear();
                            NotDoubles();
                        }
                        break;
                    case "3":
                        {
                            Console.Clear();
                            EvenSum();
                        }
                        break;
                    case "4":
                        {
                            Console.Clear();
                            OddSum();
                        }
                        break;

                    case "5":
                        {
                            Console.Clear();
                            Rules();
                        }
                        break;
                    case "6":
                        {
                            Console.Clear();
                            Stats();
                        }
                        break;
                    case "7":
                        {
                            Console.Clear();
                            if (wins >= 1)
                            {                                
                                Console.WriteLine("DICE MASTER: So, you think you can just leave after");
                                Console.WriteLine("             besting me? Hahaha! Very well, leave");
                                Console.WriteLine("             while you still can...");
                                Console.WriteLine("===========================================================");
                                Console.WriteLine("Congratulations! You have bested the Dice Master!");
                                Console.WriteLine("You may now leave the Gambler's Den!");
                                Console.WriteLine("Thank you for playing!");
                                Console.WriteLine("Press any key to exit...");
                                Console.ReadLine();
                                gameOver = true;
                            }

                            Console.Clear();
                        }
                        break;
                }
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
            Console.WriteLine("\t*Players cannot bring in more than $500, or less than $100;");
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
                        wallet += 100.00;
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
                        wallet += 250.00;
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
                        wallet += 500.00;
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

                        while (!Double.TryParse((Console.ReadLine()), out addMoney) || addMoney < 100 || addMoney > 500)
                        {
                            if (addMoney < 100)
                            {
                                Console.Clear();
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
                                Console.Clear();
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
                                Console.Clear();
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

                        Console.Clear();
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
            bool ongoingGame = true;
            Random generator = new Random();
            List<ConsoleColor> diceColours;
            int colourIndex;
            string userChoice;
            diceColours = new List<ConsoleColor>();

            diceColours.Add(ConsoleColor.Blue);
            diceColours.Add(ConsoleColor.Red);
            diceColours.Add(ConsoleColor.Green);
            diceColours.Add(ConsoleColor.Magenta);

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            while (ongoingGame)
            {
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
                    doublesBet = Math.Round(doublesBet, 2);
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

                Console.Title = "The Gambler's Den || The Dice House";
                Console.WriteLine("===================================");

                Console.WriteLine("DICE MASTER: Before we begin, let us choose the colour of our dice");
                Console.WriteLine("             I'll let you go first... for good luck");
                if (wins >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             Great. Now I can get my revenge...");
                }
                if (losses >= 1)
                {
                    Console.WriteLine("             Its...Its you?! You dare show your face?");
                    Console.WriteLine("             No matter. I'll crush you like the last fool");
                    Console.WriteLine("             who dared enter my den!");
                }

                Console.WriteLine("====================================================================");
                die1.Colour = SetColour();

                Console.WriteLine();
                Console.WriteLine($"DICE MASTER: Good choice. I quite like the colour {die1.Colour.ToString()}");
                Console.WriteLine("              Now it's my turn.");


                if (diceColours.Contains(die1.Colour))
                {
                    diceColours.Remove(die1.Colour);
                }

                colourIndex = generator.Next(0, diceColours.Count);
                die2.Colour = diceColours[colourIndex];

                Console.WriteLine($"DICE MASTER: Hmm.... I think I'll choose {die2.Colour.ToString()}");
                Console.WriteLine($"DICE MASTER: I think it's time to roll the dice...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("The Dice Master is ready. Press any key to start the game!");
                Console.ReadLine();

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
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine($"The House Forfeits. You scored doubles!");

                    Console.WriteLine("DICE MASTER: How...unexpected...");
                    Console.WriteLine("             It appears luck is on your side today...");
                    Console.WriteLine("             Very well, you have won this round.");
                    Console.WriteLine("             I shall honor your victory... this time.");
                    Console.WriteLine("             You are free to leave... for now.");
                    Console.WriteLine();
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have won this round, but be careful");
                    Console.WriteLine("The Dice Master is growing angrier...");

                    wallet += 2 * (doublesBet);
                    wins += 1;
                    houseAngerPoints += 4;
                }

                else
                {
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine("The House Prevails. You did not score doubles.");
                    Console.WriteLine("DICE MASTER: Hahaha! Foolish mortal!");
                    Console.WriteLine("             Did you really think you could best me?");
                    Console.WriteLine("             Care for another round? I'm just getting started!");
                    Console.WriteLine("             In the meantime, I'll take what I'm owed.");
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have lost this round, but do not give up!");
                    Console.WriteLine("The Dice Master can be beaten...");
                    Console.WriteLine("Losing only makes you stronger! He's less angry, less vengeful");

                    wallet -= doublesBet;
                    losses += 1;
                    if (houseAngerPoints > 0)
                        houseAngerPoints -= 1;
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("DICE MASTER: My offer still stands");
                Console.WriteLine("             Care for another round?");
                Console.WriteLine();
                Console.Write("Press y followed by the enter key to play again, or any other key to exit to the Gambler's Den: ");
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower().Trim();
                if (userChoice != "y")
                {
                    ongoingGame = false;
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Very well. Return when you are");
                    Console.WriteLine("             ready to test your luck again.");
                    Console.WriteLine("===============================================================");
                    if (wins >= 1)
                    {

                        Console.WriteLine($"You have {wins} win(s)");
                        Console.WriteLine("Congratulations on your victory!");
                        Console.WriteLine("You may now leave the Gambler's Den if you so choose.");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("You have yet to best the Dice Master.");
                        Console.WriteLine("Return when you are ready to test your luck again.");
                        Console.WriteLine("DICE MASTER: I'm waiting... I'll see you soon...");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                else if (userChoice == "y")
                {
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Excellent! Let us begin another round!");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("Prepare yourself...");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (wallet <= 0)
                {
                    ongoingGame = false;
                    gameOver = true;
                    Console.WriteLine("DICE MASTER: It appears you have run out of funds...");
                    Console.WriteLine("             Perhaps next time you'll be luckier.");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("You have run out of money...");
                    Console.WriteLine("The Dice Master has thrown you out of the Gambler's Den");
                    Console.WriteLine("Better luck next time...");
                    Console.WriteLine("GAME OVER");
                    Environment.Exit(0);
                }
            }


        }

        public static void NotDoubles()
        {
            Console.Title = "The Gambler's Den || Not Doubles";

            double nonDoublesBet;
            bool ongoingGame = true;
            Random generator = new Random();
            List<ConsoleColor> diceColours;
            int colourIndex;
            string userChoice;
            diceColours = new List<ConsoleColor>();

            diceColours.Add(ConsoleColor.Blue);
            diceColours.Add(ConsoleColor.Red);
            diceColours.Add(ConsoleColor.Green);
            diceColours.Add(ConsoleColor.Magenta);

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            while (ongoingGame)
            {


                Console.WriteLine(Console.Title);
                Console.WriteLine("============================");
                Console.WriteLine("Welcome to the Gambler's Den. You have bet on Not Doubles!");
                Console.WriteLine();
                Console.WriteLine("====================================================================");
                Console.WriteLine("DICE MASTER: Before you can role, place a bet worthy of my time.");
                Console.WriteLine("             If you input an invalid responce, all or nothing will be");
                Console.WriteLine("             assumed.");
                if (!Double.TryParse(Console.ReadLine(), out nonDoublesBet) || nonDoublesBet < wallet * 0.07 || nonDoublesBet > wallet)
                {
                    Console.WriteLine("DICE MASTER: Those bets are unworthy of my time.");
                    Console.WriteLine("             Since you are incapible of making a bet on your own");
                    Console.WriteLine("             I'll take it as all or nothing. Sounds fair?");
                    Console.WriteLine("             No? Well, too bad. My patience is running thin ");
                    Console.WriteLine("====================================================================");
                    nonDoublesBet = wallet;
                    Console.WriteLine($"[SUCCESS] Your bet of {nonDoublesBet.ToString("C")} has been placed");
                    Console.WriteLine($"Dice will roll shortly");
                }
                else
                {
                    nonDoublesBet = Math.Round(nonDoublesBet, 2);
                    Console.WriteLine("DICE MASTER: That bet is quite worthy of this one's time");
                    Console.WriteLine("             Much gratitude for a competent opponent");
                    Console.WriteLine("             May the luckiest one here win...");
                    Console.WriteLine("====================================================================");
                    Console.WriteLine($"[SUCCESS] Your bet of {nonDoublesBet.ToString("C")} has been placed");
                    Console.WriteLine($"Dice will roll shortly");
                }
                Console.WriteLine();
                Console.Write("Press any key to roll the dice");
                Console.ReadLine();
                Console.Clear();

                Console.Title = "The Gambler's Den || The Dice House";
                Console.WriteLine("===================================");

                Console.WriteLine("DICE MASTER: Before we begin, let us choose the colour of our dice");
                Console.WriteLine("             I'll let you go first... for good luck...");
                if (wins >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             Great. Now I can get my revenge...");
                }
                if (losses >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             No matter. I'll crush you like the last fool");
                    Console.WriteLine("             who dared enter my den!");
                }
                Console.WriteLine("====================================================================");
                die1.Colour = SetColour();

                Console.WriteLine();
                Console.WriteLine($"DICE MASTER: Good choice. I quite like the colour {die1.Colour.ToString()}");
                Console.WriteLine("              Now it's my turn.");


                if (diceColours.Contains(die1.Colour))
                {
                    diceColours.Remove(die1.Colour);
                }

                colourIndex = generator.Next(0, diceColours.Count);
                die2.Colour = diceColours[colourIndex];

                Console.WriteLine($"DICE MASTER: Hmm.... I think I'll choose {die2.Colour.ToString()}");
                Console.WriteLine($"DICE MASTER: I think it's time to roll the dice...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("The Dice Master is ready. Press any key to start the game!");
                Console.ReadLine();

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
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine($"The House Forfeits. You did not score doubles!");

                    Console.WriteLine("DICE MASTER: Hmm...unexpected...");
                    Console.WriteLine("             It appears luck is on your side today...");
                    Console.WriteLine("             It looks like I've been bested.");
                    Console.WriteLine("             Very well, you have won this round.");
                    Console.WriteLine("             I shall honor your victory... this time.");
                    Console.WriteLine("             You are free to leave... for now.");
                    Console.WriteLine();
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have won this round, but be careful");
                    Console.WriteLine("The Dice Master is growing angrier...");

                    wallet += 0.5 * (nonDoublesBet);
                    wins += 1;
                    houseAngerPoints += 4;
                }

                else
                {
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine("The House Prevails. You scored doubles! How unlucky.");
                    Console.WriteLine("DICE MASTER: Hahaha! Foolish mortal!");
                    Console.WriteLine("             Did you really think you could best me?");
                    Console.WriteLine("             You thought you could beat THE DICE MASTER?!");
                    Console.WriteLine("             Care for another round? I'm just getting started!");
                    Console.WriteLine("             In the meantime, I'll take what I'm owed.");
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have lost this round, but do not give up!");
                    Console.WriteLine("The Dice Master can be beaten...");
                    Console.WriteLine("Losing only makes you stronger! He's less angry, less vengeful");

                    wallet -= nonDoublesBet;
                    losses += 1;
                    if (houseAngerPoints > 0)
                        houseAngerPoints -= 1;
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("DICE MASTER: My offer still stands");
                Console.WriteLine("             Care for another round?");
                Console.WriteLine();
                Console.Write("Press y followed by the enter key to play again, or any other key to exit to the Gambler's Den: ");
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower().Trim();
                if (userChoice != "y")
                {
                    ongoingGame = false;
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Very well. Return when you are");
                    Console.WriteLine("             ready to test your luck again.");
                    Console.WriteLine("===============================================================");
                    if (wins >= 1)
                    {
                        Console.WriteLine($"You have {wins} win(s)");
                        Console.WriteLine("Congratulations on your victory!");
                        Console.WriteLine("You may now leave the Gambler's Den if you so choose.");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("You have yet to best the Dice Master.");
                        Console.WriteLine("Return when you are ready to test your luck again.");
                        Console.WriteLine("DICE MASTER: I'm waiting... I'll see you soon...");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                else if (userChoice == "y")
                {
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Excellent! Let us begin another round!");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("Prepare yourself...");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (wallet <= 0)
                {
                    ongoingGame = false;
                    gameOver = true;
                    Console.WriteLine("DICE MASTER: It appears you have run out of funds...");
                    Console.WriteLine("             Perhaps next time you'll be luckier.");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("You have run out of money...");
                    Console.WriteLine("The Dice Master has thrown you out of the Gambler's Den");
                    Console.WriteLine("Better luck next time...");
                    Console.WriteLine("GAME OVER");
                    Environment.Exit(0);
                }
            }


        }

        public static void EvenSum()
        {
            Console.Title = "The Gambler's Den || Even Sum";
            double evenSumBet;
            int dieTotal;

            bool ongoingGame = true;
            Random generator = new Random();
            List<ConsoleColor> diceColours;
            int colourIndex;
            string userChoice;
            diceColours = new List<ConsoleColor>();

            diceColours.Add(ConsoleColor.Blue);
            diceColours.Add(ConsoleColor.Red);
            diceColours.Add(ConsoleColor.Green);
            diceColours.Add(ConsoleColor.Magenta);

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            while (ongoingGame)
            {


                Console.WriteLine(Console.Title);
                Console.WriteLine("============================");
                Console.WriteLine("Welcome to the Gambler's Den. You have bet on Even Sum!");
                Console.WriteLine();
                Console.WriteLine("====================================================================");
                Console.WriteLine("DICE MASTER: Before you can role, place a bet worthy of my time.");
                Console.WriteLine("             If you input an invalid responce, all or nothing will be");
                Console.WriteLine("             assumed.");
                if (!Double.TryParse(Console.ReadLine(), out evenSumBet) || evenSumBet < wallet * 0.07 || evenSumBet > wallet)
                {
                    Console.WriteLine("DICE MASTER: Those bets are unworthy of my time.");
                    Console.WriteLine("             Since you are incapible of making a bet on your own");
                    Console.WriteLine("             I'll take it as all or nothing. Sounds fair?");
                    Console.WriteLine("             No? Well, too bad. My patience is running thin ");
                    Console.WriteLine("====================================================================");
                    evenSumBet = wallet;
                    Console.WriteLine($"[SUCCESS] Your bet of {evenSumBet.ToString("C")} has been placed");
                    Console.WriteLine($"Dice will roll shortly");
                }
                else
                {
                    evenSumBet = Math.Round(evenSumBet, 2);
                    Console.WriteLine("DICE MASTER: That bet is quite worthy of this one's time");
                    Console.WriteLine("             Much gratitude for a competent opponent");
                    Console.WriteLine("             May the luckiest one here win...");
                    Console.WriteLine("====================================================================");
                    Console.WriteLine($"[SUCCESS] Your bet of {evenSumBet.ToString("C")} has been placed");
                    Console.WriteLine($"Dice will roll shortly");
                }
                Console.WriteLine();
                Console.Write("Press any key to roll the dice");
                Console.ReadLine();
                Console.Clear();

                Console.Title = "The Gambler's Den || The Dice House";
                Console.WriteLine("===================================");

                Console.WriteLine("DICE MASTER: Before we begin, let us choose the colour of our dice");
                Console.WriteLine("             I'll let you go first... for good luck...");
                if (wins >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             Great. Now I can get my revenge...");
                }
                if (losses >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             No matter. I'll crush you like the last fool");
                    Console.WriteLine("             who dared enter my den!");
                }
                Console.WriteLine("====================================================================");
                die1.Colour = SetColour();

                Console.WriteLine();
                Console.WriteLine($"DICE MASTER: Good choice. I quite like the colour {die1.Colour.ToString()}");
                Console.WriteLine("              Now it's my turn.");


                if (diceColours.Contains(die1.Colour))
                {
                    diceColours.Remove(die1.Colour);
                }

                colourIndex = generator.Next(0, diceColours.Count);
                die2.Colour = diceColours[colourIndex];

                Console.WriteLine($"DICE MASTER: Hmm.... I think I'll choose {die2.Colour.ToString()}");
                Console.WriteLine($"DICE MASTER: I think it's time to roll the dice...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("The Dice Master is ready. Press any key to start the game!");
                Console.ReadLine();

                die1.RollDie();
                die2.RollDie();

                dieTotal = die1.Roll + die2.Roll;

                if (houseAngerPoints > 0)
                {
                    if (dieTotal % 2 == 0)
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
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine($"The House Forfeits. You scored an Even Sum!");

                    Console.WriteLine("DICE MASTER: Hmm...unexpected...");
                    Console.WriteLine("             It appears luck is on your side today...");
                    Console.WriteLine("             It looks like I've been bested.");
                    Console.WriteLine("             Very well, you have won this round.");
                    Console.WriteLine("             I shall honor your victory... this time.");
                    Console.WriteLine("             You are free to leave... for now.");
                    Console.WriteLine();
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have won this round, but be careful");
                    Console.WriteLine("The Dice Master is growing angrier...");

                    wallet += (evenSumBet);
                    wins += 1;
                    houseAngerPoints += 4;
                }

                else
                {
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine("The House Prevails. You scored Odd Sums! How unlucky.");
                    Console.WriteLine("DICE MASTER: Hahaha! Foolish mortal!");
                    Console.WriteLine("             Did you really think you could best me?");
                    Console.WriteLine("             You thought you could beat THE DICE MASTER?!");
                    Console.WriteLine("             Care for another round? I'm just getting started!");
                    Console.WriteLine("             In the meantime, I'll take what I'm owed.");
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have lost this round, but do not give up!");
                    Console.WriteLine("The Dice Master can be beaten...");
                    Console.WriteLine("Losing only makes you stronger! He's less angry, less vengeful");

                    wallet -= evenSumBet;
                    losses += 1;
                    if (houseAngerPoints > 0)
                        houseAngerPoints -= 1;
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("DICE MASTER: My offer still stands");
                Console.WriteLine("             Care for another round?");
                Console.WriteLine();
                Console.Write("Press y followed by the enter key to play again, or any other key to exit to the Gambler's Den: ");
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower().Trim();
                if (userChoice != "y")
                {
                    ongoingGame = false;
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Very well. Return when you are");
                    Console.WriteLine("             ready to test your luck again.");
                    Console.WriteLine("===============================================================");
                    if (wins >= 1)
                    {
                        Console.WriteLine($"You have {wins} win(s)");
                        Console.WriteLine("Congratulations on your victory!");
                        Console.WriteLine("You may now leave the Gambler's Den if you so choose.");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("You have yet to best the Dice Master.");
                        Console.WriteLine("Return when you are ready to test your luck again.");
                        Console.WriteLine("DICE MASTER: I'm waiting... I'll see you soon...");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                else if (userChoice == "y")
                {
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Excellent! Let us begin another round!");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("Prepare yourself...");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (wallet <= 0)
                {
                    ongoingGame = false;
                    gameOver = true;
                    Console.WriteLine("DICE MASTER: It appears you have run out of funds...");
                    Console.WriteLine("             Perhaps next time you'll be luckier.");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("You have run out of money...");
                    Console.WriteLine("The Dice Master has thrown you out of the Gambler's Den");
                    Console.WriteLine("Better luck next time...");
                    Console.WriteLine("GAME OVER");
                    Environment.Exit(0);
                }
            }
        }

        public static void OddSum()
        {
            Console.Title = "The Gambler's Den || Odd Sum";
            double oddSumBet;
            int dieTotal;

            bool ongoingGame = true;
            Random generator = new Random();
            List<ConsoleColor> diceColours;
            int colourIndex;
            string userChoice;
            diceColours = new List<ConsoleColor>();

            diceColours.Add(ConsoleColor.Blue);
            diceColours.Add(ConsoleColor.Red);
            diceColours.Add(ConsoleColor.Green);
            diceColours.Add(ConsoleColor.Magenta);

            DieGame die1 = new DieGame();
            DieGame die2 = new DieGame();

            while (ongoingGame)
            {


                Console.WriteLine(Console.Title);
                Console.WriteLine("============================");
                Console.WriteLine("Welcome to the Gambler's Den. You have bet on Even Sum!");
                Console.WriteLine();
                Console.WriteLine("====================================================================");
                Console.WriteLine("DICE MASTER: Before you can role, place a bet worthy of my time.");
                Console.WriteLine("             If you input an invalid responce, all or nothing will be");
                Console.WriteLine("             assumed.");
                if (!Double.TryParse(Console.ReadLine(), out oddSumBet) || oddSumBet < wallet * 0.07 || oddSumBet > wallet)
                {
                    Console.WriteLine("DICE MASTER: Those bets are unworthy of my time.");
                    Console.WriteLine("             Since you are incapible of making a bet on your own");
                    Console.WriteLine("             I'll take it as all or nothing. Sounds fair?");
                    Console.WriteLine("             No? Well, too bad. My patience is running thin ");
                    Console.WriteLine("====================================================================");
                    oddSumBet = wallet;
                    Console.WriteLine($"[SUCCESS] Your bet of {oddSumBet.ToString("C")} has been placed");
                    Console.WriteLine($"Dice will roll shortly");
                }
                else
                {
                    oddSumBet = Math.Round(oddSumBet, 2);
                    Console.WriteLine("DICE MASTER: That bet is quite worthy of this one's time");
                    Console.WriteLine("             Much gratitude for a competent opponent");
                    Console.WriteLine("             May the luckiest one here win...");
                    Console.WriteLine("====================================================================");
                    Console.WriteLine($"[SUCCESS] Your bet of {oddSumBet.ToString("C")} has been placed");
                    Console.WriteLine($"Dice will roll shortly");
                }
                Console.WriteLine();
                Console.Write("Press any key to roll the dice");
                Console.ReadLine();
                Console.Clear();

                Console.Title = "The Gambler's Den || The Dice House";
                Console.WriteLine("===================================");

                Console.WriteLine("DICE MASTER: Before we begin, let us choose the colour of our dice");
                Console.WriteLine("             I'll let you go first... for good luck...");
                if (wins >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             Great. Now I can get my revenge...");
                }
                if (losses >= 1)
                {
                    Console.WriteLine("             Its...Its you? Haven't I seen you before?");
                    Console.WriteLine("             No matter. I'll crush you like the last fool");
                    Console.WriteLine("             who dared enter my den!");
                }
                Console.WriteLine("====================================================================");
                die1.Colour = SetColour();

                Console.WriteLine();
                Console.WriteLine($"DICE MASTER: Good choice. I quite like the colour {die1.Colour.ToString()}");
                Console.WriteLine("              Now it's my turn.");


                if (diceColours.Contains(die1.Colour))
                {
                    diceColours.Remove(die1.Colour);
                }

                colourIndex = generator.Next(0, diceColours.Count);
                die2.Colour = diceColours[colourIndex];

                Console.WriteLine($"DICE MASTER: Hmm.... I think I'll choose {die2.Colour.ToString()}");
                Console.WriteLine($"DICE MASTER: I think it's time to roll the dice...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("The Dice Master is ready. Press any key to start the game!");
                Console.ReadLine();

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
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine($"The House Forfeits. You scored an Odd Sum!");

                    Console.WriteLine("DICE MASTER: Hmm...unexpected...");
                    Console.WriteLine("             It appears luck is on your side today...");
                    Console.WriteLine("             It looks like I've been bested.");
                    Console.WriteLine("             Very well, you have won this round.");
                    Console.WriteLine("             I shall honor your victory... this time.");
                    Console.WriteLine("             You are free to leave... for now.");
                    Console.WriteLine();
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have won this round, but be careful");
                    Console.WriteLine("The Dice Master is growing angrier...");

                    wallet += (oddSumBet);
                    wins += 1;
                    houseAngerPoints += 4;
                }

                else
                {
                    Console.WriteLine("==============================================================");
                    Console.WriteLine($"You rolled a {die1.Roll}");
                    die1.DrawRoll();
                    Console.WriteLine($"The Dice Master rolled a {die2.Roll}");
                    die2.DrawRoll();
                    Console.WriteLine("The House Prevails. You scored Even Sums! How unlucky.");
                    Console.WriteLine("DICE MASTER: Hahaha! Foolish mortal!");
                    Console.WriteLine("             Did you really think you could best me?");
                    Console.WriteLine("             You thought you could beat THE DICE MASTER?!");
                    Console.WriteLine("             Care for another round? I'm just getting started!");
                    Console.WriteLine("             In the meantime, I'll take what I'm owed.");
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("You have lost this round, but do not give up!");
                    Console.WriteLine("The Dice Master can be beaten...");
                    Console.WriteLine("Losing only makes you stronger! He's less angry, less vengeful");

                    wallet -= oddSumBet;
                    losses += 1;
                    if (houseAngerPoints > 0)
                        houseAngerPoints -= 1;
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("DICE MASTER: My offer still stands");
                Console.WriteLine("             Care for another round?");
                Console.WriteLine();
                Console.Write("Press y followed by the enter key to play again, or any other key to exit to the Gambler's Den: ");
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower().Trim();
                if (userChoice != "y")
                {
                    ongoingGame = false;
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Very well. Return when you are");
                    Console.WriteLine("             ready to test your luck again.");
                    Console.WriteLine("===============================================================");
                    if (wins >= 1)
                    {

                        Console.WriteLine($"You have {wins} win(s)");
                        Console.WriteLine("Congratulations on your victory!");
                        Console.WriteLine("You may now leave the Gambler's Den if you so choose.");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("You have yet to best the Dice Master.");
                        Console.WriteLine("Return when you are ready to test your luck again.");
                        Console.WriteLine("DICE MASTER: I'm waiting... I'll see you soon...");
                        Console.WriteLine("Press any key to exit the Dice House");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                else if (userChoice == "y")
                {
                    Console.Clear();
                    Console.WriteLine("DICE MASTER: Excellent! Let us begin another round!");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("Prepare yourself...");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (wallet <= 0)
                {
                    ongoingGame = false;
                    gameOver = true;
                    Console.WriteLine("DICE MASTER: It appears you have run out of funds...");
                    Console.WriteLine("             Perhaps next time you'll be luckier.");
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("You have run out of money...");
                    Console.WriteLine("The Dice Master has thrown you out of the Gambler's Den");
                    Console.WriteLine("Better luck next time...");
                    Console.WriteLine("GAME OVER");
                    Environment.Exit(0);
                }
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
            Console.WriteLine();
            Console.WriteLine("6) Minimum bet is 7% of your current wallet");
            Console.WriteLine("==================================================================");
            Console.Write("Press r followed by the enter key to return to the Gambler's Den: ");
            userChoice = Console.ReadLine();
            userChoice = userChoice.ToLower().Trim();

            if (userChoice != "r")
            {
                Console.Clear();
                Console.WriteLine("DICE MASTER: You were unable to follow a simple instruction?!");
                Console.WriteLine("             I'll let you off easy...this time.");
                Console.WriteLine("=============================================================");
                Console.WriteLine("Few! That was close! Do not anger the Dice Master!");
                Console.WriteLine("The angrier the Dice Master, the harder it is to win!");
                Console.WriteLine("...Good Luck.");
                Console.WriteLine("=============================================================");
                Console.WriteLine("Press any key to return to the Gambler's Den");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
        }

        public static void Stats()
        {
            Console.Title = "The Gambler's Den || Player Stats";
            Console.WriteLine(Console.Title);
            Console.WriteLine("===================================");
            Console.WriteLine($"Current Wallet: {wallet.ToString("C")}");
            Console.WriteLine($"Total Wins: {wins}");
            Console.WriteLine($"Total Losses: {losses}");
            Console.WriteLine($"Current House Anger Points: {houseAngerPoints}");
            Console.WriteLine("===================================");
            Console.WriteLine("Press any key to return to the Gambler's Den");
            Console.ReadLine();
            Console.Clear();
        }
    }

}
