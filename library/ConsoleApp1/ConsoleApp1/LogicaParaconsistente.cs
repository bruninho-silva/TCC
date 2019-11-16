using System;

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
    public Baricentro ObtemBaricentro(Carta[] objetos)
    {
        Baricentro[] list = new Baricentro[] { new Baricentro(), new Baricentro(), new Baricentro(), new Baricentro() };
        for(int i = 0; i < 4; i++)
        {
            Baricentro baricentro = ExtraiContradicaoPorAtributo(objetos, i);
            list[i] = baricentro;
        }
        Baricentro[] duasCartas = MaximilizaQuatroCartas(list);
        Baricentro carta = MiniminizaDuasCartas(duasCartas);
        return carta;        
    }

    private Baricentro ExtraiContradicaoPorAtributo(Carta[] objetos, int numeroDoAttr)
    {
        int[] arrayMi1 = EscolheQualAtributoUsarParaMi(objetos,numeroDoAttr);
        int[] arrayLamb1 = EscolheQualAtributoUsarParaLamb(objetos,numeroDoAttr);

        Baricentro[] quatroCartas = MaximilizaOitoCartas(arrayMi1, arrayLamb1);
       
        Baricentro[] duasCartas = MaximilizaQuatroCartas(quatroCartas);
    
        Baricentro carta = MiniminizaDuasCartas(duasCartas);

        return carta;    
    }

    private Baricentro MiniminizaDuasCartas(Baricentro[] duasCartas)
    {
        Baricentro carta = new Baricentro
        {
            Lambda = duasCartas[0].Lambda > duasCartas[1].Lambda ? duasCartas[0].Lambda : duasCartas[1].Lambda,
            Mi = duasCartas[0].Mi < duasCartas[1].Mi ? duasCartas[0].Mi : duasCartas[1].Mi
        };

        return carta;
    }

    private Baricentro[] MaximilizaQuatroCartas(Baricentro[] quatroCartas)
    {
       Baricentro[] duasCartas = new Baricentro[] { new Baricentro(), new Baricentro() };

       duasCartas[0].Mi = quatroCartas[0].Mi > quatroCartas[1].Mi ? quatroCartas[0].Mi : quatroCartas[1].Mi;
       duasCartas[0].Lambda = quatroCartas[0].Lambda < quatroCartas[1].Lambda ? quatroCartas[0].Lambda : quatroCartas[1].Lambda;

       duasCartas[1].Mi = quatroCartas[2].Mi > quatroCartas[3].Mi ? quatroCartas[2].Mi : quatroCartas[3].Mi;
       duasCartas[1].Lambda = quatroCartas[2].Lambda < quatroCartas[3].Lambda ? quatroCartas[2].Lambda : quatroCartas[3].Lambda;

       return duasCartas;
    }

    private int[] EscolheQualAtributoUsarParaLamb(Carta[] objetos, int numeroDoAtributo)
    {
        switch (numeroDoAtributo)
        {
            case 0:
                return new int[] {
                    objetos[0].LambAtributo1, objetos[1].LambAtributo1, objetos[2].LambAtributo1,
                                  objetos[3].LambAtributo1, objetos[4].LambAtributo1, objetos[5].LambAtributo1,
                                  objetos[6].LambAtributo1, objetos[7].LambAtributo1 };
            case 1:
                return new int[] {
                    objetos[0].LambAtributo2, objetos[1].LambAtributo2, objetos[2].LambAtributo2,
                                  objetos[3].LambAtributo2, objetos[4].LambAtributo2, objetos[5].LambAtributo2,
                                  objetos[6].LambAtributo2, objetos[7].LambAtributo2 };
            case 2:
                return new int[] {
                    objetos[0].LambAtributo3, objetos[1].LambAtributo3, objetos[2].LambAtributo3,
                                  objetos[3].LambAtributo3, objetos[4].LambAtributo3, objetos[5].LambAtributo3,
                                  objetos[6].LambAtributo3, objetos[7].LambAtributo3 };
            case 3:
                return new int[] {
                    objetos[0].LambAtributo4, objetos[1].LambAtributo4, objetos[2].LambAtributo4,
                                  objetos[3].LambAtributo4, objetos[4].LambAtributo4, objetos[5].LambAtributo4,
                                  objetos[6].LambAtributo4, objetos[7].LambAtributo4  };

        }
        return new int[0];
    }

    private int[] EscolheQualAtributoUsarParaMi(Carta[] objetos, int numeroDoAtributo)
    {
        switch (numeroDoAtributo)
        {
            case 0: return new int[] { objetos[0].MiAtributo1, objetos[1].MiAtributo1, objetos[2].MiAtributo1,
                                  objetos[3].MiAtributo1, objetos[4].MiAtributo1, objetos[5].MiAtributo1,
                                  objetos[6].MiAtributo1, objetos[7].MiAtributo1  };
            case 1:
                return new int[] { objetos[0].MiAtributo2, objetos[1].MiAtributo2, objetos[2].MiAtributo2,
                                  objetos[3].MiAtributo2, objetos[4].MiAtributo2, objetos[5].MiAtributo2,
                                  objetos[6].MiAtributo2, objetos[7].MiAtributo2  };
            case 2:
                return new int[] { objetos[0].MiAtributo3, objetos[1].MiAtributo3, objetos[2].MiAtributo3,
                                  objetos[3].MiAtributo3, objetos[4].MiAtributo3, objetos[5].MiAtributo3,
                                  objetos[6].MiAtributo3, objetos[7].MiAtributo3  };
            case 3:
                return new int[] { objetos[0].MiAtributo4, objetos[1].MiAtributo4, objetos[2].MiAtributo4,
                                  objetos[3].MiAtributo4, objetos[4].MiAtributo4, objetos[5].MiAtributo4,
                                  objetos[6].MiAtributo4, objetos[7].MiAtributo4  };
        }
        return new int[0];
    }

    private Baricentro[] MaximilizaOitoCartas(int[] arrayMi1, int[] arrayLamb1)
    {
        Baricentro[] quatroCartas = new Baricentro[] { new Baricentro(), new Baricentro(), new Baricentro(), new Baricentro(), };

        quatroCartas[0].Mi = arrayMi1[0] > arrayMi1[1] ? arrayMi1[0] : arrayMi1[1];
        quatroCartas[0].Lambda = arrayLamb1[0] < arrayLamb1[1] ? arrayLamb1[0] : arrayLamb1[1];

        quatroCartas[1].Mi = arrayMi1[2] > arrayMi1[3] ? arrayMi1[2] : arrayMi1[3];
        quatroCartas[1].Lambda = arrayLamb1[2] < arrayLamb1[3] ? arrayLamb1[2] : arrayLamb1[3];

        quatroCartas[2].Mi = arrayMi1[4] > arrayMi1[5] ? arrayMi1[4] : arrayMi1[5];
        quatroCartas[2].Lambda = arrayLamb1[4] < arrayLamb1[5] ? arrayLamb1[4] : arrayLamb1[5];

        quatroCartas[3].Mi = arrayMi1[6] > arrayMi1[7] ? arrayMi1[6] : arrayMi1[7];
        quatroCartas[3].Lambda = arrayLamb1[6] < arrayLamb1[7] ? arrayLamb1[6] : arrayLamb1[7];

        return quatroCartas;
    }
}