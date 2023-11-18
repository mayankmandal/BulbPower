using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BulbPower.Tests
{
    public class BulbManagerTests
    {
        [Fact]
        public void TestBulbManagerWithInput6and5()
        {
            // Arrange
            var input = new StringReader("6\n5\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var expectedOutput =
                "Bulb #1 --> OFF" + Environment.NewLine +
                "Bulb #2 --> ON" + Environment.NewLine +
                "Bulb #3 --> OFF" + Environment.NewLine +
                "Bulb #4 --> OFF" + Environment.NewLine +
                "Bulb #5 --> ON" + Environment.NewLine;

            // Act
            //Program.Main();
            var consoleOutput = output.ToString();
            consoleOutput = consoleOutput.Replace("Enter the number of people in the room: \r\nEnter the number of bulbs in the hallway: \r\n", "");

            // Assert
            Assert.Equal(expectedOutput.ToString(), consoleOutput);
        }

        [Fact]
        public void TestBulbManagerWithInput3and3()
        {
            // Arrange
            var input = new StringReader("3\n3\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var expectedOutput =
                "Bulb #1 --> ON" + Environment.NewLine +
                "Bulb #2 --> ON" + Environment.NewLine +
                "Bulb #3 --> OFF" + Environment.NewLine;

            // Act
            //Program.Main();
            var consoleOutput = output.ToString();
            consoleOutput = consoleOutput.Replace("Enter the number of people in the room: \r\nEnter the number of bulbs in the hallway: \r\n", "");

            // Assert
            Assert.Equal(expectedOutput, consoleOutput);
        }

        [Fact]
        public void TestBulbManagerWithInput4and7()
        {
            // Arrange
            var input = new StringReader("4\n7\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var expectedOutput =
                "Bulb #1 --> OFF" + Environment.NewLine +
                "Bulb #2 --> ON" + Environment.NewLine +
                "Bulb #3 --> OFF" + Environment.NewLine +
                "Bulb #4 --> OFF" + Environment.NewLine +
                "Bulb #5 --> ON" + Environment.NewLine +
                "Bulb #6 --> ON" + Environment.NewLine +
                "Bulb #7 --> ON" + Environment.NewLine;

            // Act
            //Program.Main();
            var consoleOutput = output.ToString();
            consoleOutput = consoleOutput.Replace("Enter the number of people in the room: \r\nEnter the number of bulbs in the hallway: \r\n", "");

            // Assert
            Assert.Equal(expectedOutput, consoleOutput);
        }
    }
}