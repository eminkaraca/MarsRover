using MarsRover.Model;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program will keep working even if it gets errors
            while (true)
            {
                try
                {
                    Console.WriteLine("Welcome to Mars");
                    Console.WriteLine("Enter Plataeu upper right coordinates; X Y");
                    //Read commands

                    //firstCommand - it is for plataeu upper righ coordinate
                    string plataeuCommands = Console.ReadLine();

                    NASA.CreatePlataeu(plataeuCommands);
                    


                    string position = string.Empty;
                    string command = string.Empty;
                    Console.WriteLine("Enter rover position; X Y HeadingTo");
                    //read all rover positions and commands
                    while ((position = Console.ReadLine()) != null)
                    {
                        
                        NASA.CreateRover(position);

                        Console.WriteLine("Enter rover commands");
                        //read commands for rover
                        command = Console.ReadLine();
                        //make rover apply the commands
                        NASA.StartRover(command);
                        //write the current position of rover
                        Console.WriteLine(NASA.GetRoverPosition());

                        //Read next  rovers position
                        Console.WriteLine("Enter rover position; X Y HeadingTo");
                    }


                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured");
                }
            }
        }

        

        
    }
}
