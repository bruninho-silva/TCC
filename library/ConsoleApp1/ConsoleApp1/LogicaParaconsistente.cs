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

    public void descobreEstadoLogico(Double gc, Double gi){


        if (gc > vcve)
        {
            // Verdade 
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