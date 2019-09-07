using System;
using System.Collections.Generic;

public class LogicaParaconsistente
{

    public int obtemPorcentagemDeDano(Cartas[] cartas){
        if (validaGameObject(cartas))
        {
            Baricentro baricentro = obtemBaricentro(cartas);
            double gC = calculaGrauDeCerteza(baricentro);
            double gI = calculaGrauDeIncerteza(baricentro);
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
    }

    public Baricentro obtemBaricentro(Cartas[] objetos){
        int posicao = 0;
        int[] arrayMi1 = new int[] { objetos[0].miAtributo1, objetos[1].miAtributo1, objetos[2].miAtributo1,
                                  objetos[3].miAtributo1, objetos[4].miAtributo1, objetos[5].miAtributo1,
                                  objetos[6].miAtributo1, objetos[7].miAtributo1 ,objetos[8].miAtributo1 };
        int[] listaLamb1 = new int[] { objetos[0].lambAtributo1, objetos[1].lambAtributo1, objetos[2].lambAtributo1,
                                  objetos[3].lambAtributo1, objetos[4].lambAtributo1, objetos[5].lambAtributo1,
                                  objetos[6].lambAtributo1, objetos[7].lambAtributo1 ,objetos[8].lambAtributo1 };
            
        return new Baricentro();
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

    public Double ConverteNumeros(int numeroInteiro)
    {
        return Convert.ToDouble(numeroInteiro)
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