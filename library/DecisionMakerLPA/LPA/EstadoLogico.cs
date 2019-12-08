using System;

namespace DecisionMakerLPA
{
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
            if (gc == gi)
            {
                return Constante.indefinido;
            }
            else if (gc >= Constante.VCVE)
            {
                return Constante.verdade;
            }
            else if (gc <= Constante.VCFA)
            {
                return Constante.falso;
            }
            else if (gi >= Constante.VCIC)
            {
                return Constante.inconsistente;
            }
            else if (gi <= Constante.VCPA)
            {
                return Constante.paracompleto;
            }

            else if ((gc >= 0 && gc < Constante.VCVE) && (gi >= 0 && gi < Constante.VCIC))
            {
                if (gc >= gi)
                {
                    return Constante.quaseVerdadeInconsistente;
                }
                else
                {
                    return Constante.inconsistenteVerdade;
                }
            }
            else if ((gc >= 0 && gc < Constante.VCVE) && (gi > Constante.VCPA && gi <= 0))
            {
                if (gc >= Math.Abs(gi))
                {
                    return Constante.quaseVerdadeParacompleto;
                }
                else
                {
                    return Constante.paracompletoVerdade;
                }
            }
            else if ((gc > Constante.VCFA && gc <= 0) && (gi > Constante.VCPA && gi <= 0))
            {
                if (Math.Abs(gc) > Math.Abs(gi))
                {
                    return Constante.quaseFalsoParacompleto;
                }
                else
                {
                    return Constante.paracompletoFalso;
                }
            }
            else if ((gc > Constante.VCFA && gc <= 0) && (gi >= 0 && gi < Constante.VCIC))
            {
                if (Math.Abs(gc) >= gi)
                {
                    return Constante.quaseFalsoInconsistente;
                }
                else
                {
                    return Constante.inconsistenteFalso;
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
        public static int? TransformaEstadoLogicoEmPorcentagem(string estadoLogico)
        {
            switch (estadoLogico)
            {
                case Constante.verdade:
                    return 100;
                case Constante.falso:
                    return 0;
                case Constante.inconsistente:
                    return 50;
                case Constante.paracompleto:
                    return 40;
                case Constante.quaseVerdadeInconsistente:
                    return 90;
                case Constante.inconsistenteVerdade:
                    return 70;
                case Constante.quaseVerdadeParacompleto:
                    return 80;
                case Constante.paracompletoVerdade:
                    return 60;
                case Constante.quaseFalsoParacompleto:
                    return 5;
                case Constante.paracompletoFalso:
                    return 20;
                case Constante.quaseFalsoInconsistente:
                    return 10;
                case Constante.inconsistenteFalso:
                    return 30;
                case Constante.indefinido:
                    return null;
            }
            return 0;
        }
    }
}
