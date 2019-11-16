using System;

/// <summary>
/// Classe estática que realizar a verificação do estado Lógico no reticulado.
/// </summary>
public static class EstadoLogico
{
    /// <summary>
    /// Confere o estado lógico pelo grau de certeza e incerteza.
    /// </summary>
    /// <param name="gc">Grau de Certeza</param>
    /// <param name="gi">Grau de Incerteza</param>
    /// <returns> 
    /// Retorna o estado lógico.
    /// </returns>
    public static string DescobreEstadoLogico(double gc, double gi)
    {

        if (gc >= Constante.VCVE)
        {
            return Constante.VERDADE;
        }
        else if (gc <= Constante.VCFA)
        {
            return Constante.FALSO;
        }
        else if (gi >= Constante.VCIC)
        {
            return Constante.INCONSISTENTE;
        }
        else if (gi <= Constante.VCPA)
        {
            return Constante.PARACOMPLETO;
        }

        else if ((gc >= 0 && gc < Constante.VCVE) && (gi >= 0 && gi < Constante.VCIC))
        {
            if (gc >= gi)
            {
                return Constante.QUASE_V_I;
            }
            else
            {
                return Constante.INCONSISTENTE_T_VERDADE;
            }
        }
        else if ((gc >= 0 && gc < Constante.VCVE) && (gi > Constante.VCPA && gi <= 0))
        {
            if (gc >= Math.Abs(gi))
            {
                return Constante.QUASE_V_P;
            }
            else
            {
                return Constante.PARACOMPLETO_T_VERDADE;
            }
        }
        else if ((gc > Constante.VCFA && gc <= 0) && (gi > Constante.VCPA && gi <= 0))
        {
            if (Math.Abs(gc) > Math.Abs(gi))
            {
                return Constante.QUASE_F_P;
            }
            else
            {
                return Constante.PARACOMPLETO_T_FALSO;
            }
        }
        else if ((gc > Constante.VCFA && gc <= 0) && (gi >= 0 && gi < Constante.VCIC))
        {
            if (Math.Abs(gc) >= gi)
            {
                return Constante.QUASE_F_I;
            }
            else
            {
                return Constante.INCONSISTENTE_T_FALSO;
            }
        }
        return null;
    }

    /// <summary>
    /// Transforma a estado lógico em porcentagem.
    /// </summary>
    /// <param name="estadoLogico">Um dos doze estados lógico da paraconsistente.</param>
    /// <returns>
    /// Porcentagem em Danos.                                                                                  
    /// </returns>
    public static int TransformaEstadoLogicoEmPorcentagem(string estadoLogico)
    {
        switch (estadoLogico)
        {
            case Constante.VERDADE:
                return 100;
            case Constante.FALSO:
                return 0;
            case Constante.INCONSISTENTE:
                return 12;
            case Constante.PARACOMPLETO:
                return 10;
            case Constante.QUASE_V_I:
                return 35;
            case Constante.INCONSISTENTE_T_VERDADE:
                return 25;
            case Constante.QUASE_V_P:
                return 60;
            case Constante.PARACOMPLETO_T_VERDADE:
                return 49;
            case Constante.QUASE_F_P:
                return 89;
            case Constante.PARACOMPLETO_T_FALSO:
                return 45;
            case Constante.QUASE_F_I:
                return 8;
            case Constante.INCONSISTENTE_T_FALSO:
                return 85;

        }
        return 0;
    }
}
