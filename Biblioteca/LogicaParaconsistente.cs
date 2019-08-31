public class LogicaParaconsistente implements{
    
public Integer obtemPorcentagemDeDano(Cartas[] cartas){
    validaGameObject(cartas);
    Baricentro baricentro = obtemBaricentro(cartas)
    Double gC = calculaGrauDeCerteza(baricentro);
    Double gI = calculaGrauDeIncerteza(baricentro);
    String estadoLogico = descobreEstadoLogico(gC,gI);
    return transformaEstadoLogicoEmPorcentagem(estadoLogico);
}

public void descobreEstadoLogico(Double grauDeCerteza, Double grauDeIncerteza){}

public void transformaEstadoLogicoEmPorcentagem(){}

public Baricentro obtemBaricentro(Cartas[] objetos){}

public void validaGameObject(cartas[] objetos) trows GameObjectInvalido {}

public Double converteNumeros(Integer numeroInteiro){}

public Integer calculaGrauDeCerteza(Baricentro baricentro){}

public Integer calculaGrauDeIncerteza(Baricentro baricentro){}
    
public void descobreEstadoLogico(Double grauDeCerteza, Double grauDeIncerteza){}

}