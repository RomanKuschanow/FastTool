﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastTool;

public class Sech : IFunction
{
    public List<object> Args { get; }

    public Sech(object arg)
    {
        Args = new List<object>() { arg };
    }

    public double Calculate(Mode mode, int digits)
    {
        Calculator calc = new Calculator(mode, digits);

        double num = calc.Transform(Args[0]);
        num = calc.ConvertToRad(num);

        return 1 / Math.Cosh(num);
    }
    public double Calculate(Calculator calc)
    {
        double num = calc.Transform(Args[0]);
        num = calc.ConvertToRad(num);

        return 1 / Math.Cosh(num);
    }

    public override string ToString()
    {
        return $"sech({Args[0]})";
    }

}
