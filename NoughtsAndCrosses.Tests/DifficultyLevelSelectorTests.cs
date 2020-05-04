using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class DifficultyLevelSelectorTests
    {
        [Fact]
        public void DifficultyLevelSelector_InputIs1_ReturnsEasyComputerPlayer()
        {
            TestConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever("1");
            var actual = DifficultyLevelSelector.SetComputerPlayerLevel(inputRetriever);
            Assert.IsType<EasyComputerPlayer>(actual);
        }

        [Fact]
        public void DifficultyLevelSelector_InputIs2_ReturnsMediumComputerPlayer()
        {
            TestConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever("2");
            var actual = DifficultyLevelSelector.SetComputerPlayerLevel(inputRetriever);
            Assert.IsType<MediumComputerPlayer>(actual);
        }

        [Fact]
        public void DifficultyLevelSelector_InputIs3_ReturnsImpossibleComputerPlayer()
        {
            TestConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever("3");
            var actual = DifficultyLevelSelector.SetComputerPlayerLevel(inputRetriever);
            Assert.IsType<HardComputerPlayer>(actual);
        }
    }
}
