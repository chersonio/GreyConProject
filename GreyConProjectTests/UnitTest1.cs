using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreyConProject;
using System.Linq;
using GreyConProject.DiskSpaceExceptions;

namespace GreyConProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FillArrays_NormalTestCase()
        {
            //Arrange
            DiskSpace diskSpace = new DiskSpace();

            string usedHardDiskInput = "1, 200, 200, 199, 200, 200";
            int[] usedHardDisksSpace = usedHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            string totalHardDiskInput = "1000, 200, 200, 200, 200, 200";
            int[] totalHardDisksSpace = totalHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            //Act
            int res = diskSpace.minDrives(usedHardDisksSpace, totalHardDisksSpace);

            //Assert
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void FillArrays_NotEqual_ThrowException()
        {
            //Arrange
            DiskSpace diskSpace = new DiskSpace();

            string usedHardDiskInput = "100";
            int[] usedHardDisksSpace = usedHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            string totalHardDiskInput = "1000, 200, 200, 200, 200, 200";
            int[] totalHardDisksSpace = totalHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            //Act
            try
            {
                int res = diskSpace.minDrives(usedHardDisksSpace, totalHardDisksSpace);
            }
            //Assert
            catch (InvalidLengthException invalidLengthException)
            {
                Assert.AreEqual("Used and Total need to contain the same number of elements", invalidLengthException.Message);
            }
        }

        [TestMethod]
        public void FillArrays_Negative_CheckExceptionMessage()
        {
            // Act
            try
            {
                FillArrays_Negative_ThrowException();
            }
            // Assert
            catch (InvalidValueException invalidValueException)
            {
                Assert.AreEqual("Each element of used and total can be between 1 and 1000.", invalidValueException.Message);
            }
        }

        [TestMethod]
        public void FillArrays_Negative_CheckInvalidArray()
        {
            // Act
            try
            {
                FillArrays_Negative_ThrowException();
            }
            // Assert
            catch (InvalidValueException invalidValueException)
            {
                Assert.AreEqual(DiskSpaceArray.Total, invalidValueException.InvalidValueArray);
            }
        }

        [TestMethod]
        public void FillArrays_Negative_CheckInvalidIndex()
        {
            //Act
            try
            {
                FillArrays_Negative_ThrowException();
            }
            //Assert
            catch (InvalidValueException invalidValueException)
            {
                Assert.AreEqual(1, invalidValueException.InvalidValueIndex);
            }
        }

        public void FillArrays_Negative_ThrowException()
        {
            //Arrange
            DiskSpace diskSpace = new DiskSpace();

            string usedHardDiskInput = "500, -10";
            int[] usedHardDisksSpace = usedHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            string totalHardDiskInput = "700, -1000";
            int[] totalHardDisksSpace = totalHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            //Act
            int res = diskSpace.minDrives(usedHardDisksSpace, totalHardDisksSpace);
        }

        [TestMethod]
        public void FillArrays_MoreThan50_ThrowException()
        {
            //Arrange
            DiskSpace diskSpace = new DiskSpace();

            string usedHardDiskInput = "49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 50";
            int[] usedHardDisksSpace = usedHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            string totalHardDiskInput = "49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 49, 50";
            int[] totalHardDisksSpace = totalHardDiskInput.Split(", ").Select(int.Parse).ToArray();

            //Act
            try
            {
                int res = diskSpace.minDrives(usedHardDisksSpace, totalHardDisksSpace);
            }
            catch (InvalidLengthException invalidLengthException)
            {
                //Assert
                Assert.AreEqual("Hard Disks cannot be more than 50.", invalidLengthException.Message);
            }

        }
    }
}
