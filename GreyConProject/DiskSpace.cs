using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreyConProject.DiskSpaceExceptions;

namespace GreyConProject
{
    public class DiskSpace
    {
        /// <summary>
        /// Calculates the Sum of used. Then it subtracts it from the highest total HardDisk Space to the lowest HardDisk Space.  
        /// </summary>
        /// <param name="used"></param>
        /// <param name="total"></param>
        /// <returns>The number of HardDisks that have data.</returns>
        /// <exception cref="InvalidValueException"></exception>
        /// <exception cref="InvalidLengthException"></exception>

        public int minDrives(int[] used, int[] total)
        {
            #region Error checking.
            #region Check if used and total have equal number of Hard Drives

            if (used.Length != total.Length) throw new InvalidLengthException("Used and Total need to contain the same number of elements");

            #endregion

            #region Check if used and total have more than 50 Hard Disks

            if (used.Length > 50 || total.Length > 50) throw new InvalidLengthException("Hard Disks cannot be more than 50.");

            #endregion

            #region Check if used or total are in the correct range.  

            if (used.Where(u => u < 0 || u > 1000).Any() ||
                total.Where(t => t < 0 || t > 1000).Any())
            {
                DiskSpaceArray invalidValueArray;
                int invalidValueIndex = 0;
                if (total.Where(t => t < 0 || t > 1000).Any())
                {
                    invalidValueArray = DiskSpaceArray.Total;
                    invalidValueIndex = total.Select((t, i) => new { val = t, index = i }).First(tuple => tuple.val > 1000 || tuple.val < 0).index; 
                }
                else
                {
                    invalidValueArray = DiskSpaceArray.Used;
                    invalidValueIndex = used.Select((u, i)=> new { val = u, index = i }).First(tuple => tuple.val > 1000 || tuple.val < 0).index;
                }
                    throw new InvalidValueException("Each element of used and total can be between 1 and 1000.", invalidValueArray, invalidValueIndex);
            }

            #endregion

            #region Check if total is greater than used.

            for (int i = 0; i < total.Length; i++)
            {
                if (total[i] < used[i])
                    throw new InvalidValueException("Used cannot exceed Total.", DiskSpaceArray.Used, i);
            }

            #endregion

            #endregion

            // Initialize counter for the drives that will have data.
            int countDrivesWithData = 0;

            total = total.OrderByDescending(t => t).ToArray();
            
            int usedSum = used.Sum();
            
            for (int i = 0; i < total.Length; i++)
            {
                if (usedSum <= 0) break;
            
                usedSum -= total[i];
                countDrivesWithData++;
            }
            
            return countDrivesWithData;
        }
    }
}