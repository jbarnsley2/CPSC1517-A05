using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class die
    {
        //this is the definition of an object
        // it is a conceptual view of the data
        // that will be held by a physical 
        // instance (object of this class)

        // Data Members
        // is an internal private data storage item
        // private data members can not be reach directly by the user
        // public data members CAN be reached directly by the user

        private int _Size;
        private string _Colour;


        //Properties
        // a property is an external infterface between the user and a single
        // piece of data with in the instance
        // a property has two abilities 
        // a) the ability to assign a value to the internal data member and 
        // b) return an interal data member value to the user (2-way conversation)

        //Fully Implemented Property
        public int Size
        {
            get
            {
                //takes internal values and returns it to the user
                return _Size;

            }
            set
            {
                // takes the supplied user value and places it into the internal private data member
                // the incoming piece of data is placed into a special variable that is called: value
                // optionally you may place validation on the incoming value
                if (value >= 6 && value <= 20)
                {
                    _Size = value;

                }
                else
                {
                    throw new Exception("Die cannot be" + value.ToString() + "sides. Die must have between 6 and 20 sides.");

                }


            }
        }
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

        //Behaviours (methods)


    }
}
