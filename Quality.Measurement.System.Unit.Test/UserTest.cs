using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quality.Measurement.System.Shared.Data.Repository;
using Quality.Measurement.System.Data.Repository;
using System.Threading.Tasks;
using Quality.Measurement.System.BusinessLogic;
using Moq;
using Quality.Measurement.System.Shared.Helpers.Constants;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.Unit.Test
{
    [TestClass]
    public class UserTest
    {
        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        /// <summary>
        /// Users the logic constructor test1.
        /// </summary>
        [TestMethod]
        public void UserLogicConstructorTest1()
        {
            IRepository<User> userRepository = new UserRepository();
            UserLogic target = new UserLogic(userRepository);
            Assert.IsInstanceOfType(target, typeof(UserLogic));
        }

        /// <summary>
        /// Users the logic constructor test2.
        /// </summary>
        [TestMethod]
        public void UserLogicConstructorTest2()
        {
            var mockUserRepository = new Mock<IRepository<User>>();
            UserLogic target = new UserLogic(mockUserRepository.Object);
            Assert.IsInstanceOfType(target, typeof(UserLogic));
        }

        /// <summary>
        /// Gets the physician test.
        /// </summary>
        [TestMethod]
        public void Get()
        {
            // defining the expected result 
            User expectedValue = new User();
            long userId = 1;
            Task<User> result = Task<User>.Factory.StartNew(() => expectedValue);
            // creating mock object of IUserRepository
            var mockGet = new Mock<IRepository<User>>();
            // setting the return value from Mock object on function call Get
            mockGet.Setup(
                f =>
                    f.Get(new CommandParameter(CommandConstants.GetUserDetails, CommandExecutionType.ExecuteReaderAsync)))
                .Returns(result);
            // Creating object of UserLogic using mock object
            UserLogic target = new UserLogic(mockGet.Object);
            // calling function Get
            User actual = target.Get(userId).Result;
            // performing nunit test
            Assert.AreEqual(result.Result.UserId, actual.UserId);
        }
    }
}