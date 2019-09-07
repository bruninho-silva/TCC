using System;
using System.Collections.Generic;

public class LogicaParaconsistente
{

    public int obtemPorcentagemDeDano(Cartas[] cartas){
        if (validaGameObject(cartas))
        {
            Baricentro baricentro = obtemBaricentro(cartas);
            Double gC = calculaGrauDeCerteza(baricentro);
            Double gI = calculaGrauDeIncerteza(baricentro);
            String estadoLogico = descobreEstadoLogico(gC, gI);
            return transformaEstadoLogicoEmPorcentagem(estadoLogico);
        }
        else
        {
            return 0;
        }
    }

    public string descobreEstadoLogico(Double gc, Double gi){


        if (gc > Constants.VCVE)
        {
            return "VERDADE"; 
        }
        else if (gc < Constants.VCFA)
        {
            return "FALSO";
        }
        else if (gi > Constants.VCIC)
        {
            return "INCONSISTENTE";
        }
        else if (gi > Constants.VCPA)
        {
            return "PARACOMPLETO";
        }
        else if (gc >= 0 && gc < Constants.VCVE && gi >= 0 && gi < Constants.VCIC && gc >= gi)
        {
            return "QUASE_VERDADE_TENDENDO_A_INCONSISTENTE";
        }
        else if (gc >= 0 && gc < Constants.VCVE && gi >= 0 && gi < Constants.VCIC && gc < gi)
        {
            return "INCONSISTENTE_TENDENDO_A_VERDADE";
        }/
        else if (gc >= 0 && gc < Constants.VCVE && gi > Constants.VCPA && gi <= 0 && gc >= Math.Abs(gi))
        {
            return "QUASE_VERDADE_TENDENDO_A_PARACOMPLETO";
        }
        else if (gc >= 0 && gc < Constants.VCVE && gi > Constants.VCPA && gi <= 0 && gc >= Math.Abs(gi))
        {
            return "PARACOMPLETO_TENDENTO_A_VERADADE";
        }
        else if (gc > Constants.VCFA && gc <= 0 && gi > Constants.VCPA && gi <= 0 && Math.Abs(gc) > Math.Abs(gi))
        {
            return "FALSO_TENDENDO_PARACOMPLETO";
        }
        else if (gc > Constants.VCFA && gc <= 0 && gi > Constants.VCPA && gc < gi && gi <= 0)
        {
            return "PARACOMPLETO_TENDENDO_A_FALSO";
        }
        else if (gc > Constants.VCFA && gc <= 0 && gi >= 0 && gi < Constants.VCIC && gc >= gi)
        {
            return "FALSO_TEDENDO_A_INCONSISTENTE";
        }
        else if (gc <= 0 &&  gc > Constants.VCFA && gi >= 0 && gi < Constants.VCIC && gc < gi)
        {
            return "INCONSISTENTE_TENDENDO_A_FALSO";
        }
    }


    public void transformaEstadoLogicoEmPorcentagem(String estadoLogico){}

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