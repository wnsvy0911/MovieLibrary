using System;
using NLog.Web;
using System.IO;

namespace MovieLibrary
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        static void Main(string[] args)
        {
            
            MovieManager manager = new MovieManager("movies.csv");
            logger.Info("Movie Manager loaded.");

             try
            {
                
                Boolean done = false;

                while(!done) {
                    Console.WriteLine("\nWelcome to Movie Library!");
                    Console.WriteLine("1 - List Movies");
                    Console.WriteLine("2 - Add New Movie");
                    Console.WriteLine("3 - Save Movie List");
                    Console.WriteLine("E - Exit Program");

                    string choice = Console.ReadLine();
                    logger.Info("Users choice = " + choice);

                    if(choice == "1") {
                        manager.printMovies();
                    } else if (choice == "2") {
                        manager.userAddMovie();
                    } else if (choice == "3") {
                        manager.writeToFile();
                        logger.Info("Wrote to file");
                    } else if (choice == "E" || choice == "e") {
                        done = true;
                    } else{
                        Console.WriteLine("Not a valid choice.");
                    };
                }
                logger.Info("Program Exitting");

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}