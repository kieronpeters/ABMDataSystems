
namespace TechnicalTestABDDataSystems
{
    /// <summary>
    /// This class is our main entry point to the application and will execute our classes and render the results on the screen 
    /// </summary>
    class ProgramTestQuestion1
    {
        /// <summary>
        /// This method is the primary starting point of the application, it will be used to run the classes we have created and show their output
        /// A note to users, we don't reccomend using the test methods within these classes, they are merely and example of how to run unit tests for the functionality
        /// If you want to run these, they should be in their own separate class or in another project that will test this one separately
        /// </summary>
        static void Main()
        {
            // creating a new object from our class and executing the main function entry point of edifact
            Test1Edifact test1 = new Test1Edifact();
            test1.test1_Edifact();
            // creating a new object from our class and executing the
            // main function entry point of the xml document parser and extracting the target elements
            Test2XML test2 = new Test2XML();
            test2.test2_Xml();

        }

    }
}
