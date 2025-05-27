using Xunit;
using SnakesAndLadders.Core;

namespace SnakesAndLadders.tests;

public class DiceTests
{
    [Fact]
    public void Roll_Returns_Value_Between_1_And_6()
    {
        var dice = new Dice();
        for (int i = 0; i < 100; i++)
        {
            int result = dice.Roll();
            Assert.InRange(result, 1, 6);
        }
    }
}