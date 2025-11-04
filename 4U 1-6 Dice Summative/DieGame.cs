using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4U_Topic_5._5_Classes
{
    public class DieGame
    {
        ///Variables called fields
        ///Use _ before field names
        ///Reason: to differentiate between fields and properties
        ///--->Hidden from outside the class

        private int _roll;
        private Random _generator = new Random();
        private ConsoleColor _colour;
        ///Constructors 
        ///--->Method someone uses to initalize an object
        public DieGame() //initalize starting values
        {
            _generator = new Random();
            _roll = _generator.Next(1, 7); //1-6 inclusive                 
        }

        //Accessor Property

        public int Roll //Property
        {
            get { return _roll; }
            //set { _roll = value; } //allows edits for roll from outside the class
        }
        public void RollDie() //Method
        {
            _roll = _generator.Next(1, 7); //1-6 inclusive

        }

        public ConsoleColor Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

        //Override ToString Method
        public override string ToString()
        {
            return _roll.ToString();
        }
        //Draw the roll
        public void DrawRoll()
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = _colour;

            if (Roll == 1)
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("|       |");
                Console.WriteLine("|   *   |");
                Console.WriteLine("|       |");
                Console.WriteLine(" ------- ");
            }
            else if (Roll == 2)
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("| *     |");
                Console.WriteLine("|       |");
                Console.WriteLine("|     * |");
                Console.WriteLine(" ------- ");
            }
            else if (Roll == 3)
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("| *     |");
                Console.WriteLine("|   *   |");
                Console.WriteLine("|     * |");
                Console.WriteLine(" ------- ");
            }
            else if (Roll == 4)
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("| *   * |");
                Console.WriteLine("|       |");
                Console.WriteLine("| *   * |");
                Console.WriteLine(" ------- ");
            }
            else if (Roll == 5)
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("| *   * |");
                Console.WriteLine("|   *   |");
                Console.WriteLine("| *   * |");
                Console.WriteLine(" ------- ");
            }
            else if (Roll == 6)//6
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("| *   * |");
                Console.WriteLine("| *   * |");
                Console.WriteLine("| *   * |");
                Console.WriteLine(" ------- ");
            }

            else //error
            {
                Console.WriteLine(" ------- ");
                Console.WriteLine("| XXXXX |");
                Console.WriteLine("| XXXXX |");
                Console.WriteLine("| XXXXX |");
                Console.WriteLine(" ------- ");
            }
            Console.ForegroundColor = previous;

        }
        //Overload Constructor

        public DieGame(int roll)
        {
            _generator = new Random();
            _roll = roll; //1-6 inclusive
            if (_roll < 1)
            {
                _roll = 1;
            }
            else if (_roll > 6)
            {
                _roll = 6;
            }
            else
            {
                _roll = roll;
            }
        }

        



    }
}
