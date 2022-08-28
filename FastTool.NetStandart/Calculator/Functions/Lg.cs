﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastTool;

public class Lg : IFunction
{
    public List<object> Args { get; }

    public Lg(object arg)
    {
        Args = new List<object>() { arg };
    }

    public double Calculate(Mode mode, int digits)
    {
        Calculator calc = new Calculator(mode, digits);

        double num = calc.Transform(Args[0]);

        return Math.Log(num, 10);
    }
    public double Calculate(Calculator calc)
    {
        double num = calc.Transform(Args[0]);

        return Math.Log(num, 10);
    }

    public override string ToString()
    {
        return $"log({Args[0]})";
    }

}
