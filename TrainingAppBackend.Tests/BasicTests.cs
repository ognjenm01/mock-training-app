namespace TrainingAppBackend.Tests
{
    public class BasicTests
    {
        [Fact]
        public void SanityTest()
        {
            int expected = 2;
            int actual = 1 + 1;

            Assert.Equal(expected, actual);
        }
    }
}
