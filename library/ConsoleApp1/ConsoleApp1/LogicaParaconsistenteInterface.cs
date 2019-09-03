interface TomadaDeDecisao{

public Integer obtemPorcentagemDeDano(Cartas[] cartas){}

public Baricentro obtemValorMiELambida(Cartas[] objetos){}

public void validaGameObject(cartas[] objetos) trows GameObjectInvalido {}

public Double converteNumeros(Integer numeroInteiro){}

public Integer calculaGrauDeCerteza(Double valorFavoravel,Double valorDesfavoravel){}

public Integer calculaGrauDeIncerteza(Double valorFavoravel,Double valorDesfavoravel){}
    
public void descobreEstadoLogico(Double grauDeCerteza, Double grauDeIncerteza){}

}