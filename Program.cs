//*****************************************************//
//  Title: Vacuum Cleaner                              //
//  Description: Simulate vacuum cleaning two rooms    //
//  Author: SID 2018481                                //
//  Date: 27/09/2022                                   //
//  Console based                                      //
//*****************************************************//
using System;
using System.Collections.Generic;
using System.Linq;

namespace VacuumCleaner
{
    class Program
    {
        /// <summary>
        /// User enters dirty room(s) and position of vacuum. Program searches for dirty room and cleans. 
        /// Rechecks rooms for dirt and ends when this goal is reached. Output results for each action to console.
        /// Test log included at the end of code.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //goalstate a=0,b=0
            Console.SetWindowSize(70, 30);
            Dictionary<string, int> roomState = new Dictionary<string, int>(2);
            // start clean status with value 0, add 1 for dirty status
            roomState.Add("a", 0);
            roomState.Add("b", 0);

            Console.WriteLine("Hello and welcome to the vacuum cleaner");
            string startFromRoom = "x";

            // Getting room to put vacuum in
            while (startFromRoom != "a" && startFromRoom != "b")
            {
                Console.WriteLine("Please enter the room where the vacuum should be placed, a or b");
                startFromRoom = Console.ReadLine();
                Console.WriteLine("Entered: " + startFromRoom);
            }

            Console.WriteLine("Thanks.");
            // Getting the rooms to be cleaned
            int x = 0;
            while (x == 0)
            {
                Console.WriteLine("Now enter a room that is dirty a, b or press x to end");
                var roomDirty = Console.ReadLine();
                if (roomDirty == "a")
                {
                    roomState["a"] = 1;
                }
                if (roomDirty == "b")
                {
                    roomState["b"] = 1;
                }
                if (roomDirty == "x")
                {
                    x += 1;
                }
            }
            string actionRight = "Moving right.\n";
            string actionLeft = "Moving left.\n";
            string actionSuck = "Room is dirty so sucking up stuff.\n";
            string clean = "The room is clean.\n";
            string roomA = "In room a\n";
            string roomB = "In room b\n";

            //keep track of loops till both rooms are clean include check run
            int countCleanRooms = 0;
            //need starting point to = startRoom
            var startRoom = char.Parse(startFromRoom);
            //clean and dirty split
            while (countCleanRooms < 3) 
            {
               foreach (KeyValuePair<string, int> rstate in roomState.ToList())
                {
                    Console.WriteLine("startRoom is now {0}.", startRoom); //check print
                    //if foreach iteration is start room and is dirty
                    if (rstate.Key.Contains(startRoom.ToString()) && rstate.Value == 1)
                    {
                        Console.WriteLine("Entering dirty loop");
                        if (startRoom.Equals('a'))
                        {
                            Console.WriteLine(roomA + actionSuck + clean + actionRight); //action
                            roomState[startRoom.ToString()] = 0; //change value to 0 (clean)
                            startRoom = 'b'; //moving to next room
                        }
                        else
                        {
                            Console.WriteLine(roomB + actionSuck + clean + actionLeft); //action
                            roomState[startRoom.ToString()] = 0; //change value to 0 (clean)
                            startRoom = 'a'; //moving to next room
                        }
                    }
                    //if foreach iteration is start room and is clean
                    if (rstate.Key.Contains(startRoom.ToString()) && rstate.Value == 0)
                    {
                        Console.WriteLine("Entering clean loop");
                        if (startRoom.Equals('b'))
                        {
                            Console.WriteLine(roomB + clean + actionLeft); //action
                            startRoom = 'a'; //moving to next room
                        }
                        else
                        {
                            Console.WriteLine(roomA + clean + actionRight); //action
                            startRoom = 'b'; //moving to next room
                        }
                        countCleanRooms++;
                    }
               }
            }   
            Console.WriteLine("Rooms are now cleaned.\n");
            Console.WriteLine("Pausing for thought...");
            Console.ReadLine();
        }
        /*
         * tested clean and dirty split 24/09/2022
         * test: a and a = ok,pass
         * test: a and b = ok,pass
         * test: a and a,b= ok,pass
         * test: b and a = failed, wouldn't go to a
         * test: b and b = failed, cleans b but not move to a
         * test: b and a,b= failed, cleans b but not move to a
         * moved 'var startRoom = char.Parse(startFromRoom);' out of while loop
         * test: b and a = ok,pass
         * test: b and b = ok,pass
         * test: b and a,b= ok,pass
         */

    }
}
