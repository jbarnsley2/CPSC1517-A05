using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class die
    {

        // create a new instance of the math class Random
        // this instance (occurance, object) will be shared by each instance
        // of the class die. This instance will be created when the first instance of die is created. 

        private static Random_rnd = new Random();


        //this is the definition of an object
        // it is a conceptual view of the data
        // that will be held by a physical 
        // instance (object of this class)

        // Data Members
        // is an internal private data storage item
        // private data members can not be reach directly by the user
        // public data members CAN be reached directly by the user

        private int _Sides;
        private string _Colour;


        //Properties
        // a property is an external infterface between the user and a single
        // piece of data with in the instance
        // a property has two abilities 
        // a) the ability to assign a value to the internal data member and 
        // b) return an interal data member value to the user (2-way conversation)

        //Fully Implemented Property
        public int Sides
        {
            get
            {
                //takes internal values and returns it to the user
                return _Sides;

            }
            set
            {
                // takes the supplied user value and places it into the internal private data member
                // the incoming piece of data is placed into a special variable that is called: value
                // optionally you may place validation on the incoming value
                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                    Roll(); // consider placing this method within the property if the set is public 
                    // and not private . If private then the method SetSides solves this problem

                }
                else
                {
                    throw new Exception("Die cannot be" + value.ToString() + "sides. Die must have between 6 and 20 sides.");

                }


            }
        }

        //another version of sides using a private set and auto implemented property 
        // in thi version you would need to code a method like SetSides()
       // public int Sides { get; private set; }


        // Auto Implemented Property
        //public
        // It has a datatype
        // It has a name
        // IT DOES NOT have an internal data member that you can DIRECTLY access
        // The system will create, internally, a data storage area of the appropriate datatype and manage the area
        // The only way to access the data of an Auto Implemented Property is via the property
        // usually use when there is no need for any internal validation or other property logic

        public int FaceValue { get; set; }

        public string Colour
        {

            get
            {
                return _Colour;
            }
            set
            {

                //(value == null) this will fail for an empty string
                // (value == "") this will fail for a null value 
                // never enough validation. 
                if (string.IsNullOrEmpty(value))   // isnullorempty expects a string value
                {
                    throw new Exception("Colour has no value.");
                }
                else
                {
                    _Colour = value;

                }
            }


        }


        //Constructors

        // optional: if not supplied the system default constructor is used which will assign a value
        // to each data member/auto implement property according to it's datatype

        // you can have any number of constructors within your class. Ass soon as you code a constructor
        // your program is responsible for ALL constructors

        // syntax: public classname([list of parameters]) { ... }

        // Typical constructors: Default constructor
        // This is similar to the system default constructor

        public die()
        {

            // you could leave this constructor empty and they system would access normal default value to your 
            // data members and auto implemented properties
            //you can directly access a private data member in any place within your class

            _Sides = 6;

            // you can access any property any place within your class

            Colour = "White";

            // Greedy Constructor
            // typical has a parameter for each data member and auto implemented property  within you class
            // parameter order is not important
            // this constructor allows the outside user to create and assign their own values to the data members/ auto 
            // properties at the time of instance creation

        }
        public void Die(int sides, string colour, int facevalue)
        {
         //  since this data is coming from an outside source, it is best to use your property to save
        // the values ; especially if the property has validation
            Sides = sides;
            Colour = colour;
            FaceValue = facevalue;

        }

}

    //Behaviours (methods)
    // these are actions that the class can perform. The actions may or may not alter data members / auto values 
    // the actions could simply take a value(s) from the user and perform some logic against the values

    // can be public or or private 
    // create a method that allows the user to change the number of sides on a die

    public void SetSides(int sides)
    {
        if (sides > -6 && sides <= 20)
        {
            sides = sides;
        }
        else
        {
            //optionally 
            // a) throw a new exception
            throw new Exception("Invalid value for sides");
            // b) set _Sides to a default value
            //sides = 6;
        }

    }

    public void Roll()
    {
        // no parameter are required for this method since it will be using the internal data values
        // to complete its functionality

        //randomly generate a value for the die depending on the maximum sides

        FaceValue = rnd.Next(1, Sides + 1);
    }


}

