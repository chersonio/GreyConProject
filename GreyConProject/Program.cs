using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GreyConProject.DiskSpaceExceptions;

namespace GreyConProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskSpace diskSpace = new DiskSpace();

            //rixnei exception an de tou balw ", " alla mono " ".
            //rixnei exception an tou balw megalo int.
            //rixnei exception an de tou balw int (px float, grammata)
            //rixnw exception an balw keno. ****

            // Input the used data of the Hard Disk.
            string usedHardDisksInput;
            bool expectInput = true;
            int[] usedHardDisksSpace = { };
            do
            {
                Console.WriteLine("Please insert the number of data used in each Hard Disk. \nNote that you can write up to 50 Hard Disks with a number of Data from 1 to 1000. \nExample: 1, 90, 550, 1000 \nUsed:");
                try
                {
                    usedHardDisksInput = Console.ReadLine();
                    usedHardDisksSpace = usedHardDisksInput.Split(", ").Select(int.Parse).ToArray();
                    expectInput = false;
                }
                catch 
                {
                    Console.WriteLine("The values you entered are not in a valid format. Please try again.\n");
                }
            } 
            while (expectInput);

            // Convert it to int and into the main-array usedHardDisksSpace.

            // Input the total data of the Hard Disk.
            string totalHardDisksInput;
            int[] totalHardDisksSpace = { };
            expectInput = true;

            // Input must not be empty
            do 
            {
                Console.WriteLine("Please insert the number of total storage data capacity in each Hard Disk. \nNote that you can write up to 50 Hard Disks with a number of Data from 1 to 1000. \nExample: 50, 120, 700, 1000 \nTotal:");
                try
                {
                    totalHardDisksInput = Console.ReadLine();
                    totalHardDisksSpace = totalHardDisksInput.Split(", ").Select(int.Parse).ToArray();
                    expectInput = false;
                }
                catch
                {
                    Console.WriteLine("The values you entered are not in a valid format. Please try again.\n");
                }
            }
        
            while (expectInput);

            // Convert it to int and into the main-array totalHardDisksSpace.
            try
            {
                Console.WriteLine("Result: " + diskSpace.minDrives(usedHardDisksSpace, totalHardDisksSpace));
                
            }
            catch (InvalidValueException invalidValueException)
            {
                Console.WriteLine(invalidValueException.Message);
            }
            catch (InvalidLengthException invalidLengthException)
            {
                Console.WriteLine(invalidLengthException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}

