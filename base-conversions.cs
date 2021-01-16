using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            
            Write ( "Enter an integer of three or more: " );
            int number = int.Parse ( ReadLine ( ) );
            
            // error checking if the integer is less than 3
            if ( number < 3 ) throw new ArgumentOutOfRangeException( nameof ( number ),
                                "The size must be nonnegative." );

            for ( int numberBase = 2; numberBase < number; numberBase++ )
            {
            
                // calls the method to carry out calculations and stores it in calc array
                int[] calcs = Calculations ( number, numberBase );

                int counter = 0;

                // this for loop goes through the remainders array to check each digit
                for ( int j = 0; j < calcs.Length - 1; j++) 
                {
                    
                    //using an if statement check to see if the remainders are increasing (backwards array)
                    if ( calcs[ j ] < calcs [ j + 1 ] || calcs[ j ] == calcs [ j + 1 ] )
                    {
                    
                        counter++;
                                                
                        if ( counter == calcs.Length - 1 ) 
                        {
                            Write ("The base-10 number " + number + " expressed in base " + numberBase + " is " );

                            // displaying the result depending on if the base is less than or greater than 10
                            for ( int i = calcs.Length - 1; i >= 0; i-- ) 
                            {
                
                                if ( numberBase > 10 )
                                {
                                    Write ( calcs[i] );
            
                                    if ( i != 0 ) Write ( "," );
                                }
            
                                else Write ( calcs[i] );
                            }
                            Write ( "." );
                            WriteLine ( );
                        }
                    }                    
                }
            }
        }

        static int[ ] Calculations ( int number, int numberBase )
        {
            
            int count = 0;
            
            // determining the length of the array
            for (int i = number; i > 0; i = i / numberBase) count++;
                
            // initializing and setting the length of the array to store the remainders
            int[ ] remainders = new int [ count ];
            int result = number;
                
            // storing the remainder in the array
            for (int i = 0; i < remainders.Length; i++){
                remainders[i] = result % numberBase;
                result = result / numberBase;
                    
            }          
            return remainders;
        }
    }
}
