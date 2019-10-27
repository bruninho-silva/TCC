using System;

public class Baricentro{



    public int Mi { get; set; }

    public int Lambda { get; set; }

    public double MiNormalizado()
    {
        double value = Convert.ToDouble(Mi) / 100;
        return value;
    }
    public double LambdaNormalizado()
    {
        double value = Convert.ToDouble(Lambda) / 100;
        return value;
    }
}