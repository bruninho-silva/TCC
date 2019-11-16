using System;
using System.Collections.Generic;

public class LogicaParaconsistente
{

    public int ObtemPorcentagemDeDano(Carta[] cartas)
    {
        Baricentro baricentro = ObtemBaricentro(cartas);
        double gC = baricentro.CalculaGrauDeCerteza();
        double gI = baricentro.CalculaGrauDeIncerteza();
        string estadoLogico = EstadoLogico.DescobreEstadoLogico(gC, gI);
        return EstadoLogico.TransformaEstadoLogicoEmPorcentagem(estadoLogico);
    }
    public Baricentro ObtemBaricentro(Carta[] cartas)
    {
        List<Baricentro> baricentros = new List<Baricentro>();
        for(int i = 0; i < 4; i++)
        {
            Baricentro baricentro = ExtraiContradicaoPorAtributo(cartas, i);
            baricentros.Add(baricentro);
        }
        List<Baricentro> duasCartas = Maximilizar(baricentros);
        Baricentro carta = MiniminizaDuasCartas(duasCartas);
        return carta;        
    }

    private Baricentro ExtraiContradicaoPorAtributo(Carta[] cartas, int numeroDoAttr)
    {
        List<Baricentro> listAtributos = ExtrairAtributosMiLambda(cartas, numeroDoAttr);

        List<Baricentro> quatroCartas = Maximilizar(listAtributos);

        List<Baricentro> duasCartas = Maximilizar(quatroCartas);


    
        Baricentro carta = MiniminizaDuasCartas(duasCartas);

        return carta;    
    }


    private Baricentro MiniminizaDuasCartas(List<Baricentro> baricentros)
    {
        int mi = baricentros[0].Mi < baricentros[1].Mi ? baricentros[0].Mi : baricentros[1].Mi;
        int lambda = baricentros[0].Lambda > baricentros[1].Lambda ? baricentros[0].Lambda : baricentros[1].Lambda;
        Baricentro carta = new Baricentro(mi, lambda);
        return carta;
    }

    private List<Baricentro> ExtrairAtributosMiLambda(Carta[] objetos, int numeroDoAtributo)
    {
        List<Baricentro> baricentros = new List<Baricentro>();
        for (int i = 0; i < objetos.Length; i++)
        {
            Baricentro baricentro = new Baricentro(objetos[i].GetAtributoMi(numeroDoAtributo + 1), objetos[i].GetAtributoLamb(numeroDoAtributo + 1));
            baricentros.Add(baricentro);
        }

        return baricentros;
    }

    private List<Baricentro> Maximilizar(List<Baricentro> baricentros)
    {
        List<Baricentro> cartas = new List<Baricentro>();
        int quantidadeCartas = baricentros.Count;
        
        for (int i = 0; i < quantidadeCartas; i+=2)
            {
                int mi = baricentros[i].Mi > baricentros[i + 1].Mi ? baricentros[i].Mi : baricentros[i + 1].Mi;
                int lambda = baricentros[i].Lambda < baricentros[i + 1].Lambda ? baricentros[i].Lambda : baricentros[i + 1].Lambda;
                cartas.Add(new Baricentro(mi, lambda));

            }
        return cartas;
    }
}