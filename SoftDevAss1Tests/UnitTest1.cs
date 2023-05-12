using NUnit.Framework;
using SoftDevAss1;
using Moq;

namespace SoftDevAss1Tests
{
    [TestFixture]
    public class BuildingControllerTests
    {
        string id = "C001";
        string startState = "Out of hours";
        //testcases created for multiple uses
        string newOpenToClosedTest = "Open";
        string newValidState = "Closed";
        string newInvalidState = "Test";
        string[] possibleStates = { "Out of hours", "Closed", "Open" };
        [Test]
        //Test cases created to work only in this test
        [TestCase("ACOP")]
        [TestCase("1111")]
        public void IsId_Set_Return_Are_Equal_True(string id) //Testing L1R2
        {
            //Arrange
            string lowercaseId = id.ToLower();
            //creating the controller named BC to test on
            BuildingController BC = new BuildingController(id, startState);
            //Act
            string result = BC.GetBuildingID();
            //Assert
            Assert.AreEqual(result, lowercaseId);
        }
        [Test]
        public void IsId_Lowercase_Return_Are_Equal_True() //Testing L1R4
        {
            //Arrange
            BuildingController BC = new BuildingController(id, startState);
            string lowercaseId = id.ToLower();
            //Act
            string result = BC.GetBuildingID();
            //Assert
            Assert.AreEqual(lowercaseId, result);
        }
        [Test]
        public void Controller_Start_State_Is_Set_AreEqual() //Testing L1R6
        {
            //Arrange
            BuildingController BC = new BuildingController(id, startState);
            //Act
            string result = BC.GetCurrentState();
            //Assert
            Assert.NotNull(result);
        }
        [Test]
        [TestCase("Open")]
        public void Controller_Set_State_To_Valid_State_Returns_True(string newValidState) //Testing L1R7
        {
            //Arrange
            BuildingController BC = new BuildingController(id, startState);
            //act
            bool result = BC.SetCurrentState(newValidState, possibleStates, startState);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Controller_Set_State_To_Invalid_State_Returns_False() //Testing L1R7
        {
            //Arrange
            BuildingController BC = new BuildingController(id, startState);
            //Act
            bool result = BC.SetCurrentState(newInvalidState, possibleStates, startState);
            //Assert
            Assert.IsFalse(result);

        }
        [Test]
        public void Controller_Set_State_Going_From_Closed_To_Open_Returns_False() //Testing L2R1
        {
            //Arrange
            BuildingController BC = new BuildingController(id, startState);
            //Act
            //first setting the current state to see if the state is then changed
            BC.SetCurrentState(newValidState, possibleStates, startState);
            bool result = BC.SetCurrentState(newOpenToClosedTest, possibleStates, startState);
            //Assert
            Assert.IsFalse(result);

        }
        [Test]
        public void Controller_Set_State_To_Current_State_Returns_True_And_Chances_Nothing() //Testing L2R2
        {
            //Arrange
            BuildingController BC = new BuildingController(id, startState);
            //Act
            bool result = BC.SetCurrentState(startState, possibleStates, startState);
            //Assert
            Assert.IsTrue(result);
        }
    }
}