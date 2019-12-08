using System;

namespace DecisionMakerLPA
{
    /// <summary>
    /// Classe modelo que contém os valores favoráveis(Mi) e desfavoráveis(Lambda). 
    /// </summary>
    public class Baricentro
    {
        /// <summary>
        /// Método Construtor.
        /// </summary>
        /// <param name="mi">
        /// Valor Favorável.
        /// </param>
        /// <param name="lambda">
        /// Valor Desfavorável.
        /// </param>
        public Baricentro(int mi, int lambda)
        {
            Mi = mi;
            Lambda = lambda;
        }

        /// <value> 
        /// Getter e Setter do valor Mi.
        /// </value>
        public int Mi { get; set; }

        /// <value> 
        /// Getter e Setter do valor Lambda.
        /// </value>
        public int Lambda { get; set; }

        /// <summary>
        /// Normalizar o valor para intervalo de 0 até 1.
        /// </summary>
        /// <returns>
        /// Retorna o valor do Mi ou Lambda divido por cem.
        /// </returns>
        public static double Normalizar(int atributo)
        {
            double value = Convert.ToDouble(atributo) / 100;
            return value;
        }

        /// <summary>
        /// Calcula o grau de Certeza.
        /// </summary>
        /// <returns>
        /// Retorna valor double no intervalo de 0 até 1.
        /// </returns>
        public double CalculaGrauDeCerteza => Math.Round(Normalizar(Mi) + Normalizar(Lambda) - 1, 2);

        /// <summary>
        /// Calcula o grau de incerteza.
        /// </summary>
        /// <returns>
        /// Retorna valor double no intervalo de 0 até 1.
        /// </returns>
        public double CalculaGrauDeIncerteza => Math.Round(Normalizar(Lambda) - Normalizar(Mi), 2);
    }
}