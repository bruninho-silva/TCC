using System;
using System.Collections.Generic;

public class LogicaParaconsistente
{
    readonly double vcve = 0.5; //Var de controle de Veracidade
    readonly double vcfa = 0.5; //Var de controle de Falsidade
    readonly double vcic = 0.5; //var de conttole de Inconsistencia
    readonly double vcpa = 0.5; //var de controle de Paracompleto

    public int obtemPorcentagemDeDano(Cartas[] cartas){
        if (validaGameObject(cartas))
        {
            Baricentro baricentro = obtemBaricentro(cartas);
            Double gC = CalculaGrauDeCerteza(baricentro);
            Double gI = CalculaGrauDeIncerteza(baricentro);
            String estadoLogico = descobreEstadoLogico(gC, gI);
            return transformaEstadoLogicoEmPorcentagem(estadoLogico);
        }
        else
        {
            return 0;
        }
    }

    public string descobreEstadoLogico(Double gc, Double gi){


        if (gc > vcve)
        {
           return Constants.VERDADE;
        }
        else if (gc < vcfa)
        {
            // Falso 
        }
        else if (gi > vcic)
        {
            // Inconsistencia
        }
        else if (gi > vcpa)
        {
            // Paracompleto
        }
        else if (gc >= 0 && gc < vcve && gi >= 0 && gi < vcic && gc >= gi)
        {
            // Quase Verdade tedendo a inconsistente
        }
        else if (gc >= 0 && gc < vcve && gi >= 0 && gi < vcic && gc < gi)
        {
            // Incosistente tedendo a verdade
        }
        else if (gc >= 0 && gc < vcve && gi > vcpa && gi <= 0 && gc >= Math.Abs(gi))
        {
            // Quase Verdadeiro tendendo a Paracompleto
        }
        else if (gc >= 0 && gc < vcve && gi > vcpa && gi <= 0 && gc >= Math.Abs(gi))
        {
            // Paracompleto tendendo a Verdadeiro
        }
        else if (gc > vcfa && gc <= 0 && gi > vcpa && gi <= 0 && Math.Abs(gc) > Math.Abs(gi))
        {
            // Falso tendendo paracompleto
        }
        else if (gc > vcfa && gc <= 0 && gi > vcpa && gc < gi && gi <= 0)
        {
            // Paracompleto tendendo a falso
        }
        else if (gc > vcfa && gc <= 0 && gi >= 0 && gi < vcic && gc >= gi)
        {
            // Falso tedendo a inconsistente
        }
        else if (gc <= 0 &&  gc > vcfa && gi >= 0 && gi < vcic && gc < gi)
        {
            // Inconsistente tendendo a falso
        }
    }


    public void transformaEstadoLogicoEmPorcentagem(String estadoLogico){}

    public Baricentro obtemBaricentro(Cartas[] objetos){
        Baricentro[] list = new Baricentro[3];
        for(int i = 0; i < 4; i++)
        {
            Baricentro baricentro = ExtraiContradicaoPorAtributo(objetos, i);
            list[i] = baricentro;
        }
        return null;        
    }

    private Baricentro ExtraiContradicaoPorAtributo(Cartas[] objetos, int numeroDoAttr)
    {
        int[] arrayMi1 = EscolheQualAtributoUsarParaMi(objetos,numeroDoAttr);
        int[] arrayLamb1 = EscolheQualAtributoUsarParaLamb(objetos,numeroDoAttr);

        Baricentro[] quatroCartas = maximilizaOitoCartas(arrayMi1, arrayLamb1);
       
        Baricentro[] duasCartas = maximilizaQuatroCartas(quatroCartas);
    
        Baricentro carta = miniminizaDuasCartas(duasCartas);

        return carta;    
    }

    private Baricentro miniminizaDuasCartas(Baricentro[] duasCartas)
    {
        Baricentro carta = new Baricentro();
        carta.lambida = duasCartas[0].lambida > duasCartas[1].lambida ? duasCartas[0].lambida : duasCartas[1].lambida;
        carta.mi = duasCartas[0].mi < duasCartas[1].mi ? duasCartas[0].mi : duasCartas[1].mi;

        return carta;
    }

    private Baricentro[] maximilizaQuatroCartas(Baricentro[] quatroCartas)
    {
       Baricentro[] duasCartas = new Baricentro[1];

       duasCartas[0].mi = quatroCartas[0].mi > quatroCartas[1].mi ? quatroCartas[0].mi : quatroCartas[1].mi;
       duasCartas[0].lambida = quatroCartas[0].lambida < quatroCartas[1].lambida ? quatroCartas[0].lambida : quatroCartas[1].lambida;

       duasCartas[1].mi = quatroCartas[2].mi > quatroCartas[3].mi ? quatroCartas[2].mi : quatroCartas[3].mi;
       duasCartas[1].lambida = quatroCartas[2].lambida < quatroCartas[3].lambida ? quatroCartas[2].lambida : quatroCartas[3].lambida;

       return duasCartas;
    }

    private int[] EscolheQualAtributoUsarParaLamb(Cartas[] objetos, int numeroDoAtributo)
    {
        switch (numeroDoAtributo)
        {
            case 1:
                return new int[] {
                    objetos[0].lambAtributo1, objetos[1].lambAtributo1, objetos[2].lambAtributo1,
                                  objetos[3].lambAtributo1, objetos[4].lambAtributo1, objetos[5].lambAtributo1,
                                  objetos[6].lambAtributo1, objetos[7].lambAtributo1 };
            case 2:
                return new int[] {
                    objetos[0].lambAtributo2, objetos[1].lambAtributo2, objetos[2].lambAtributo2,
                                  objetos[3].lambAtributo2, objetos[4].lambAtributo2, objetos[5].lambAtributo2,
                                  objetos[6].lambAtributo2, objetos[7].lambAtributo2 };
            case 3:
                return new int[] {
                    objetos[0].lambAtributo3, objetos[1].lambAtributo3, objetos[2].lambAtributo3,
                                  objetos[3].lambAtributo3, objetos[4].lambAtributo3, objetos[5].lambAtributo3,
                                  objetos[6].lambAtributo3, objetos[7].lambAtributo3 };
            case 4:
                return new int[] {
                    objetos[0].lambAtributo4, objetos[1].lambAtributo4, objetos[2].lambAtributo4,
                                  objetos[3].lambAtributo4, objetos[4].lambAtributo4, objetos[5].lambAtributo4,
                                  objetos[6].lambAtributo4, objetos[7].lambAtributo4  };

        }
        return new int[0];
    }

    private int[] EscolheQualAtributoUsarParaMi(Cartas[] objetos, int numeroDoAtributo)
    {
        switch (numeroDoAtributo)
        {
            case 1: return new int[] { objetos[0].miAtributo1, objetos[1].miAtributo1, objetos[2].miAtributo1,
                                  objetos[3].miAtributo1, objetos[4].miAtributo1, objetos[5].miAtributo1,
                                  objetos[6].miAtributo1, objetos[7].miAtributo1  };
            case 2:
                return new int[] { objetos[0].miAtributo2, objetos[1].miAtributo2, objetos[2].miAtributo2,
                                  objetos[3].miAtributo2, objetos[4].miAtributo2, objetos[5].miAtributo2,
                                  objetos[6].miAtributo2, objetos[7].miAtributo2  };
            case 3:
                return new int[] { objetos[0].miAtributo3, objetos[1].miAtributo3, objetos[2].miAtributo3,
                                  objetos[3].miAtributo3, objetos[4].miAtributo3, objetos[5].miAtributo3,
                                  objetos[6].miAtributo3, objetos[7].miAtributo3  };
            case 4:
                return new int[] { objetos[0].miAtributo4, objetos[1].miAtributo4, objetos[2].miAtributo4,
                                  objetos[3].miAtributo4, objetos[4].miAtributo4, objetos[5].miAtributo4,
                                  objetos[6].miAtributo4, objetos[7].miAtributo4  };
        }
        return new int[0];
    }

  
    private Baricentro[] maximilizaOitoCartas(int[] arrayMi1, int[] arrayLamb1)
    {
        throw new NotImplementedException();
    }

    public Boolean validaGameObject(Cartas[] objetos) {
        if (objetos.Length == 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Double CalculaGrauDeCerteza(Baricentro baricentro)
    {
        Double mi = baricentro.mi;
        Double lambida = baricentro.lambida;
        return mi + lambida - 1;
    }

    public Double CalculaGrauDeIncerteza(Baricentro baricentro)
    {
        Double mi = baricentro.mi;
        Double lambida = baricentro.lambida;
        return lambida - mi;
    }
    
   
}