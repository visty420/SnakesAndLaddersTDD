using SnakesAndLadders.Core;

namespace SnakesAndLadders.tests;

public class FakeDice : Dice
{
    private readonly int _fixedRoll;

    public FakeDice(int fixedRoll)
    {
        _fixedRoll = fixedRoll;
    }

    public override int Roll()
    {
        return _fixedRoll;
    }
}