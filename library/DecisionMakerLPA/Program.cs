using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            LogicaParaconsistente lpa = new LogicaParaconsistente();
            Carta[] cartas = new Carta[]{
                new Carta(100,100,100,100,100,100,100,100),
                new Carta(60,63,75,15,60,65,40,30),
                new Carta(23,1,80,60,34,70,30,20),
                new Carta(68,50,55,40,64,60,30,69),
                new Carta(72,50,56,48,58,55,59,35),
                new Carta(23,68,44,31,39,68,77,0),
                new Carta(26,50,45,70,34,80,50,50),
                new Carta(53,67,53,10,53,57,53,52)
                };
            Console.WriteLine(lpa.ObtemPorcentagemDeDano(cartas));
        }
    }
}
