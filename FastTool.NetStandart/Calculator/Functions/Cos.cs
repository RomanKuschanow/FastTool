﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastTool;

public class Cos : IFunction
{
    private readonly object arg;

    public Cos(object arg)
    {
        this.arg = arg;
    }

    public double Calculate(Mode mode, int digits)
    {
        Calculator calc = new Calculator(mode, digits);

        double num = calc.Transform(arg);
        num = calc.ConvertToRad(num);

        return Math.Cos(num);
    }
}
