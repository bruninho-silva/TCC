using System.Collections.Generic;

namespace DecisionMakerLPA
{
    /// <summary>
    /// Classe Responsável por implementar a Lógica Paraconsistente.
    /// </summary>
    public class LogicaParaconsistente
    {
        private List<Baricentro> listaBaricentros;

        /// <summary>
        /// Recebe uma lista "Carta" com seus valores favoráveis e desfavaravéis, aplicar a Lógica Paraconsistente.
        /// </summary>
        /// <param name="cartas">
        /// Índice do atributo da carta. 
        /// </param>
        /// <returns>
        /// Retorna porcentagem de Dano.
        /// </returns>
        public int? ObtemPorcentagemDeDano(List<Carta> cartas)
        {
            Baricentro baricentro = ObtemBaricentro(cartas);
            double gC = baricentro.CalculaGrauDeCerteza;
            double gI = baricentro.CalculaGrauDeIncerteza;
            string estadoLogico = EstadoLogico.DescobreEstadoLogico(gC, gI);
            return EstadoLogico.TransformaEstadoLogicoEmPorcentagem(estadoLogico);
        }

        /// <summary>
        /// Adiquire o Baricentro através da lista de cartas.
        /// </summary>
        /// <param name="cartas">
        /// Índice do atributo da carta. 
        /// </param>
        /// <returns>
        /// Retorna a classe Baricentro.
        /// </returns>
        public Baricentro ObtemBaricentro(List<Carta> cartas)
        {
            List<Baricentro> baricentros = new List<Baricentro>();
            for (int i = 0; i < 4; i++)
            {
                Baricentro baricentro = ExtraiContradicaoPorAtributo(cartas, i);
                baricentros.Add(baricentro);
            }
            List<Baricentro> duasCartas = Maximilizar(baricentros);
            Baricentro carta = Miniminizar(duasCartas);
            return carta;
        }

        /// <summary>
        /// Realiza a maximilização e minimização dos valores da cartas
        /// </summary>
        /// <param name="cartas">
        /// lista da classe Carta
        /// </param>
        /// <param name="numeroDoAttr">
        /// Índice do atributo da carta. 
        /// </param>
        /// <returns>
        /// Retorna class Baricentro com os valores de Mi e Lambda.
        /// </returns>
        private Baricentro ExtraiContradicaoPorAtributo(List<Carta> cartas, int numeroDoAttr)
        {
            listaBaricentros = ExtrairAtributosMiLambda(cartas, numeroDoAttr);
            while (listaBaricentros.Count > 2)
            {
                List<Baricentro> resultadoMax = Maximilizar(listaBaricentros);
                listaBaricentros = resultadoMax;
            }

            Baricentro carta = Miniminizar(listaBaricentros);

            return carta;
        }

        /// <summary>
        /// Extrair valores de Mi e Lambda da carta.
        /// </summary>
        /// <param name="cartas">
        /// Lista da classe Carta,
        /// </param>
        /// <param name="numeroDoAtributo">
        /// Índicce do atributo da carta.
        /// </param>
        /// <returns>
        /// Retorna uma lista de Baricentro.
        /// </returns>
        private List<Baricentro> ExtrairAtributosMiLambda(List<Carta> cartas, int numeroDoAtributo)
        {
            List<Baricentro> baricentros = new List<Baricentro>();
            for (int i = 0; i < cartas.Count; i++)
            {
                Baricentro baricentro = new Baricentro(cartas[i].GetAtributoMi(numeroDoAtributo + 1), cartas[i].GetAtributoLamb(numeroDoAtributo + 1));
                baricentros.Add(baricentro);
            }

            return baricentros;
        }

        /// <summary>
        /// Realizar a maximização dos baricentros.
        /// </summary>
        /// <param name="baricentros">
        /// lista de Baricentro.
        /// </param>
        /// <returns>
        /// Retorna lista de Baricentro após maximização.
        /// </returns>
        private List<Baricentro> Maximilizar(List<Baricentro> baricentros)
        {
            List<Baricentro> cartas = new List<Baricentro>();
            int quantidadeCartas = baricentros.Count;

            for (int i = 0; i < quantidadeCartas; i += 2)
            {
                int mi = baricentros[i].Mi > baricentros[i + 1].Mi ? baricentros[i].Mi : baricentros[i + 1].Mi;
                int lambda = baricentros[i].Lambda < baricentros[i + 1].Lambda ? baricentros[i].Lambda : baricentros[i + 1].Lambda;
                cartas.Add(new Baricentro(mi, lambda));
            }

            return cartas;
        }

        /// <summary>
        /// Realizar a minimização de duas class Baricentro.
        /// </summary>
        /// <param name="baricentros">
        /// Lista de Baricentro.
        /// </param>
        /// <returns>
        /// Retorna uma classe Baricentro após minimização.
        /// </returns>
        private Baricentro Miniminizar(List<Baricentro> baricentros)
        {
            int mi = baricentros[0].Mi < baricentros[1].Mi ? baricentros[0].Mi : baricentros[1].Mi;
            int lambda = baricentros[0].Lambda > baricentros[1].Lambda ? baricentros[0].Lambda : baricentros[1].Lambda;
            Baricentro carta = new Baricentro(mi, lambda);

            return carta;
        }
    }
}