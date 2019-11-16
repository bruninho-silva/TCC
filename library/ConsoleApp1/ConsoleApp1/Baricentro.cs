using System;

public class Baricentro
{
    public Baricentro(int mi, int lambda)
    {
        Mi = mi;
        Lambda = lambda;
    }

    public Baricentro()
    {

    }

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

    public double CalculaGrauDeCerteza()
    {
        return Math.Round(MiNormalizado() + LambdaNormalizado() - 1, 2);
    }

    public double CalculaGrauDeIncerteza()
    {
        return Math.Round(LambdaNormalizado() - MiNormalizado(), 2);
    }
}