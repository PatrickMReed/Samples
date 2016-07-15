using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Demo.Business;
using System.Collections.Generic;

namespace Demo.PatrickReed.Test
{
    [TestClass]
    public class FolderCounterTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Directory.CreateDirectory(@"C:\Testing_DeleteMe");
            Directory.CreateDirectory(@"C:\Testing_DeleteMe\Test1");
            Directory.CreateDirectory(@"C:\Testing_DeleteMe\Test2");
            Directory.CreateDirectory(@"C:\Testing_DeleteMe\Test1\Test3");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Directory.Delete(@"C:\Testing_DeleteMe", true);
        }

        [TestMethod]
        public void CountSubFolders_ReturnsExpectedCount()
        {
            // Arrange
            FolderCounter counter = new FolderCounter();

            // Act
            int result = counter.CountSubFolders(@"C:\Testing_DeleteMe");

            // Assert
            Assert.AreEqual(result, 3);        
        }

        [TestMethod]
        public void CountTopLevelFolders_ReturnsExpectedList()
        {
            // Arrange
            FolderCounter counter = new FolderCounter();
            string message;

            // Act
            List<string> results = counter.CountTopLevelFolders(@"C:\Testing_DeleteMe", out message);

            // Assert
            Assert.AreEqual(results.Count, 2);
        }
    }
}
