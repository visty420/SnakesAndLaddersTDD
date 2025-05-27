using System;

namespace SnakesAndLadders.Core;

public class Dice
{
    private readonly Random _random;

    public Dice()
    {
        _random = new Random();
    }
    public virtual int Roll()
    {
        return _random.Next(1, 7);
    }
}