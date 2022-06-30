using NUnit.Framework;

namespace PwCProject
{
    /// <summary>
    /// This class contains the methods which are applicable on the Home page of the website.
    /// </summary>
    [TestFixture]
    public class HomeTestClass : TestBase
    {
        Home hm = new Home();

        [Test, Order(1)]
        [TestCase(Description = "Counting the number of articles in the first column of the Home page")]
        public void Verify_The_Count_Of_Articles_In_First_Column()
        {
            Assert.AreEqual(hm.CountArticlesInColumns("column1"), Constants._countColumn1ArticlesHome, "The number of articles is 1");
        }

        [Test, Order(2)]
        [TestCase(Description = "Counting the number of articles in the second column of the Home page")]
        public void Verify_The_Count_Of_Articles_In_Second_Column()
        {
            Assert.AreEqual(hm.CountArticlesInColumns("column2"), Constants._countColumn2ArticlesHome, "The number of articles is 2");
        }

        [Test, Order(3)]
        [TestCase(Description = "Counting the number of articles in the third column of the Home page")]
        public void Verify_The_Count_Of_Articles_In_Third_Column()
        {
            Assert.AreEqual(hm.CountArticlesInColumns("column3"), Constants._countColumn3ArticlesHome, "The number of articles is 4");
        }
    }
}
