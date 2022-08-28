﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastTool;

public class Cbrt : IFunction
{
    public List<object> Args { get; }

    public Cbrt(object arg)
    {
        Args = new List<object>() { arg };
    }

    public double Calculate(Mode mode, int digits)
    {
        Calculator calc = new Calculator(mode, digits);

        double num = calc.Transform(Args[0]);

        return Math.Pow(num, 1 / 3);
    }
    public double Calculate(Calculator calc)
    {
        double num = calc.Transform(Args[0]);

        return Math.Pow(num, 1 / 3);
    }

    public override string ToString()
    {
        return $"cbrt({Args[0]})";
    }

}