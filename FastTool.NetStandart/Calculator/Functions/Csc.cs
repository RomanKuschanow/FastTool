﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastTool;

public class Csc : IFunction
{
    private readonly object arg;

    public Csc(object arg)
    {
        this.arg = arg;
    }

    public double Calculate(Mode mode, int digits)
    {
        Calculator calc = new Calculator(mode, digits);

        double num = calc.Transform(arg);
        num = calc.ConvertToRad(num);

        return 1 / Math.Sin(num);
    }
}
