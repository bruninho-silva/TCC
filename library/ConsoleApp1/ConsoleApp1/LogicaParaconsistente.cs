public class LogicaParaconsistente implements{
    
public Integer obtemPorcentagemDeDano(Cartas[] cartas){
    validaGameObject(cartas);
    Baricentro baricentro = obtemBaricentro(cartas)
    Double gC = calculaGrauDeCerteza(baricentro);
    Double gI = calculaGrauDeIncerteza(baricentro);
    String estadoLogico = descobreEstadoLogico(gC,gI);
    return transformaEstadoLogicoEmPorcentagem(estadoLogico);
}

public void descobreEstadoLogico(Double gc, Double gi){

    if (gc > 0  && gi > 0)
    {
        if (gc == 0 )
        {
            return Constants.INCOSISTENTE;
        }
        if (gi == 0)
        {
            return Constants.VERDADE;
        }
        
        if (gc > gi)
        {
           return Constants.INCONSISTENTE_TENTE_VERDADE ;
        }
        if (gi > gc){
           return Constants.VERDADE_TENDE_INCONSISTENTE;
        }
        
    }
    if (gc < 0 && gi < 0)
    {
        
    }
    if (gc > 0 && gi < 0)
    {
        
    }
    if (gc < 0 && gi > 0)
    {
        
    }

if (gc == 0)
{
    if (gi > 0)
    {
      Inconsistemte  
    }
     if (gi < 0)
    {
       Paraconpleto 
    }
}




}

public void transformaEstadoLogicoEmPorcentagem(){}

public Baricentro obtemBaricentro(Cartas[] objetos){}

public void validaGameObject(cartas[] objetos) trows GameObjectInvalido {}

public Double converteNumeros(Integer numeroInteiro){}

public Double calculaGrauDeCerteza(Baricentro baricentro){
    Double mi = baricentro.getMi();
    Double lambida = baricentro.getLambida();
    return mi + lambida - 1
}

public Double calculaGrauDeIncerteza(Baricentro baricentro){
    Double mi = baricentro.getMi();
    Double lambida = baricentro.getLambida();
    return lambida - mi;
}
    
public void descobreEstadoLogico(Double grauDeCerteza, Double grauDeIncerteza){}

}