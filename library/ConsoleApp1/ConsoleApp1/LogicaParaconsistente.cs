using System;
using System.Collections.Generic;

public class LogicaParaconsistente
{

    public int ObtemPorcentagemDeDano(Cartas[] cartas){
        if (validaGameObject(cartas))
        {
            Baricentro baricentro = obtemBaricentro(cartas);
            double gC = CalculaGrauDeCerteza(baricentro);
            double gI = CalculaGrauDeIncerteza(baricentro);
            string estadoLogico = DescobreEstadoLogico(gC, gI);
            return TransformaEstadoLogicoEmPorcentagem(estadoLogico);
        }
        else
        {
            return 0;
        }
    }

    public string DescobreEstadoLogico(double gc, double gi){

        if (gc > Constants.VCVE)
        {
            return Constants.VERDADE;
        }
        else if (gc < Constants.VCFA)
        {
            return Constants.FALSO;
        }
        else if (gi > Constants.VCIC)
        {
            return Constants.INCONSISTENTE;
        }
        else if (gi > Constants.VCPA)
        {
            return Constants.PARACOMPLETO;
        }
        else if (gc >= 0 && gc < Constants.VCVE && gi >= 0 && gi < Constants.VCIC && gc >= gi)
        {
            return Constants.QUASE_V_I;
        }
        else if (gc >= 0 && gc < Constants.VCVE && gi >= 0 && gi < Constants.VCIC && gc < gi)
        {
            return Constants.INCONSISTENTE_T_VERDADE;
        }/
        else if (gc >= 0 && gc < Constants.VCVE && gi > Constants.VCPA && gi <= 0 && gc >= Math.Abs(gi))
        {
            return Constants.QUASE_V_P;
        }
        else if (gc >= 0 && gc < Constants.VCVE && gi > Constants.VCPA && gi <= 0 && gc >= Math.Abs(gi))
        {
            return Constants.PARACOMPLETO_T_VERDADE;
        }
        else if (gc > Constants.VCFA && gc <= 0 && gi > Constants.VCPA && gi <= 0 && Math.Abs(gc) > Math.Abs(gi))
        {
            return Constants.QUASE_F_P;
        }
        else if (gc > Constants.VCFA && gc <= 0 && gi > Constants.VCPA && gc < gi && gi <= 0)
        {
            return Constants.PARACOMPLETO_T_FALSO;
        }
        else if (gc > Constants.VCFA && gc <= 0 && gi >= 0 && gi < Constants.VCIC && gc >= gi)
        {
            return Constants.QUASE_F_I;
        }
        else if (gc <= 0 &&  gc > Constants.VCFA && gi >= 0 && gi < Constants.VCIC && gc < gi)
        {
            return Constants.INCONSISTENTE_T_FALSO;
        }
        return null;
    }


    public int TransformaEstadoLogicoEmPorcentagem(string estadoLogico)
    {
        switch(estadoLogico)
        {
            case Constants.VERDADE:
                return 100;
            case Constants.FALSO:
                return 0;
            case Constants.INCONSISTENTE:
                return 10;
            case Constants.PARACOMPLETO:
                return 10;
            case Constants.QUASE_V_I:
                return 35;
            case Constants.INCONSISTENTE_T_VERDADE:
                return 25;
            case Constants.QUASE_V_P:
                return 60;
            case Constants.PARACOMPLETO_T_VERDADE:
                return 49;
            case Constants.QUASE_F_P:
                return 89;
            case Constants.PARACOMPLETO_T_FALSO:
                return 45;
            case Constants.QUASE_F_I:
                return 8;
            case Constants.INCONSISTENTE_T_FALSO:
                return 85;

        }
        return 0;
    }

    public Baricentro obtemBaricentro(Cartas[] objetos){
        Baricentro[] list = new Baricentro[3];
        for(int i = 0; i < 4; i++)
        {
            Baricentro baricentro = ExtraiContradicaoPorAtributo(objetos, i);
            list[i] = baricentro;
        }
        Baricentro[] duasCartas = maximilizaQuatroCartas(list);
        Baricentro carta = miniminizaDuasCartas(duasCartas);
        return carta;        
    }

    private Baricentro ExtraiContradicaoPorAtributo(Cartas[] objetos, int numeroDoAttr)
    {
        int[] arrayMi1 = EscolheQualAtributoUsarParaMi(objetos,numeroDoAttr);
        int[] arrayLamb1 = EscolheQualAtributoUsarParaLamb(objetos,numeroDoAttr);

        Baricentro[] quatroCartas = MaximilizaOitoCartas(arrayMi1, arrayLamb1);
       
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

  
    private Baricentro[] MaximilizaOitoCartas(int[] arrayMi1, int[] arrayLamb1)
    {
        Baricentro[] quatroCartas = new Baricentro[1];

        quatroCartas[0].mi = quatroCartas[0].mi > quatroCartas[1].mi ? quatroCartas[0].mi : quatroCartas[1].mi;
        quatroCartas[0].lambida = quatroCartas[0].lambida < quatroCartas[1].lambida ? quatroCartas[0].lambida : quatroCartas[1].lambida;

        quatroCartas[1].mi = quatroCartas[2].mi > quatroCartas[3].mi ? quatroCartas[2].mi : quatroCartas[3].mi;
        quatroCartas[1].lambida = quatroCartas[2].lambida < quatroCartas[3].lambida ? quatroCartas[2].lambida : quatroCartas[3].lambida;

        quatroCartas[2].mi = quatroCartas[4].mi > quatroCartas[5].mi ? quatroCartas[4].mi : quatroCartas[5].mi;
        quatroCartas[2].lambida = quatroCartas[4].lambida < quatroCartas[5].lambida ? quatroCartas[4].lambida : quatroCartas[5].lambida;

        quatroCartas[3].mi = quatroCartas[6].mi > quatroCartas[7].mi ? quatroCartas[6].mi : quatroCartas[7].mi;
        quatroCartas[3].lambida = quatroCartas[6].lambida < quatroCartas[7].lambida ? quatroCartas[6].lambida : quatroCartas[7].lambida;

        return quatroCartas;
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