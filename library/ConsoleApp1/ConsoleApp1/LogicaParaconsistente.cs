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
        }
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
        Baricentro[] list = new Baricentro[] { new Baricentro(), new Baricentro(), new Baricentro(), new Baricentro() };
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
        carta.Lambida = duasCartas[0].Lambida > duasCartas[1].Lambida ? duasCartas[0].Lambida : duasCartas[1].Lambida;
        carta.Mi = duasCartas[0].Mi < duasCartas[1].Mi ? duasCartas[0].Mi : duasCartas[1].Mi;

        return carta;
    }

    private Baricentro[] maximilizaQuatroCartas(Baricentro[] quatroCartas)
    {
       Baricentro[] duasCartas = new Baricentro[] { new Baricentro(), new Baricentro() };

       duasCartas[0].Mi = quatroCartas[0].Mi > quatroCartas[1].Mi ? quatroCartas[0].Mi : quatroCartas[1].Mi;
       duasCartas[0].Lambida = quatroCartas[0].Lambida < quatroCartas[1].Lambida ? quatroCartas[0].Lambida : quatroCartas[1].Lambida;

       duasCartas[1].Mi = quatroCartas[2].Mi > quatroCartas[3].Mi ? quatroCartas[2].Mi : quatroCartas[3].Mi;
       duasCartas[1].Lambida = quatroCartas[2].Lambida < quatroCartas[3].Lambida ? quatroCartas[2].Lambida : quatroCartas[3].Lambida;

       return duasCartas;
    }

    private int[] EscolheQualAtributoUsarParaLamb(Cartas[] objetos, int numeroDoAtributo)
    {
        switch (numeroDoAtributo)
        {
            case 0:
                return new int[] {
                    objetos[0].lambAtributo1, objetos[1].lambAtributo1, objetos[2].lambAtributo1,
                                  objetos[3].lambAtributo1, objetos[4].lambAtributo1, objetos[5].lambAtributo1,
                                  objetos[6].lambAtributo1, objetos[7].lambAtributo1 };
            case 1:
                return new int[] {
                    objetos[0].lambAtributo2, objetos[1].lambAtributo2, objetos[2].lambAtributo2,
                                  objetos[3].lambAtributo2, objetos[4].lambAtributo2, objetos[5].lambAtributo2,
                                  objetos[6].lambAtributo2, objetos[7].lambAtributo2 };
            case 2:
                return new int[] {
                    objetos[0].lambAtributo3, objetos[1].lambAtributo3, objetos[2].lambAtributo3,
                                  objetos[3].lambAtributo3, objetos[4].lambAtributo3, objetos[5].lambAtributo3,
                                  objetos[6].lambAtributo3, objetos[7].lambAtributo3 };
            case 3:
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
            case 0: return new int[] { objetos[0].miAtributo1, objetos[1].miAtributo1, objetos[2].miAtributo1,
                                  objetos[3].miAtributo1, objetos[4].miAtributo1, objetos[5].miAtributo1,
                                  objetos[6].miAtributo1, objetos[7].miAtributo1  };
            case 1:
                return new int[] { objetos[0].miAtributo2, objetos[1].miAtributo2, objetos[2].miAtributo2,
                                  objetos[3].miAtributo2, objetos[4].miAtributo2, objetos[5].miAtributo2,
                                  objetos[6].miAtributo2, objetos[7].miAtributo2  };
            case 2:
                return new int[] { objetos[0].miAtributo3, objetos[1].miAtributo3, objetos[2].miAtributo3,
                                  objetos[3].miAtributo3, objetos[4].miAtributo3, objetos[5].miAtributo3,
                                  objetos[6].miAtributo3, objetos[7].miAtributo3  };
            case 3:
                return new int[] { objetos[0].miAtributo4, objetos[1].miAtributo4, objetos[2].miAtributo4,
                                  objetos[3].miAtributo4, objetos[4].miAtributo4, objetos[5].miAtributo4,
                                  objetos[6].miAtributo4, objetos[7].miAtributo4  };
        }
        return new int[0];
    }

  
    private Baricentro[] MaximilizaOitoCartas(int[] arrayMi1, int[] arrayLamb1)
    {
        Baricentro[] quatroCartas = new Baricentro[] { new Baricentro(), new Baricentro(), new Baricentro(), new Baricentro(), };

        quatroCartas[0].Mi = arrayMi1[0] > arrayMi1[1] ? arrayMi1[0] : arrayMi1[1];
        quatroCartas[0].Lambida = arrayLamb1[0] < arrayLamb1[1] ? arrayLamb1[0] : arrayLamb1[1];

        quatroCartas[1].Mi = arrayMi1[2] > arrayMi1[3] ? arrayMi1[2] : arrayMi1[3];
        quatroCartas[1].Lambida = arrayLamb1[2] < arrayLamb1[3] ? arrayLamb1[2] : arrayLamb1[3];

        quatroCartas[2].Mi = arrayMi1[4] > arrayMi1[5] ? arrayMi1[4] : arrayMi1[5];
        quatroCartas[2].Lambida = arrayLamb1[4] < arrayLamb1[5] ? arrayLamb1[4] : arrayLamb1[5];

        quatroCartas[3].Mi = arrayMi1[6] > arrayMi1[7] ? arrayMi1[6] : arrayMi1[7];
        quatroCartas[3].Lambida = arrayLamb1[6] < arrayLamb1[7] ? arrayLamb1[6] : arrayLamb1[7];

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
        Double mi = baricentro.Mi;
        Double lambida = baricentro.Lambida;
        return mi + lambida - 1;
    }

    public Double CalculaGrauDeIncerteza(Baricentro baricentro)
    {
        Double mi = baricentro.Mi;
        Double lambida = baricentro.Lambida;
        return lambida - mi;
    }
    
   
}