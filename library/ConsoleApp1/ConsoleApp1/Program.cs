using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicaParaconsistente lpa = new LogicaParaconsistente();
            Cartas[] cartas = new Cartas[]{
                new Cartas(80,67,20,10,70,68,30,0),
                new Cartas(60,63,75,15,60,65,40,30),
                new Cartas(23,60,80,60,34,70,30,20),
                new Cartas(68,50,55,40,64,60,30,69),
                new Cartas(72,50,56,48,58,55,59,35),
                new Cartas(23,68,44,31,39,68,77,0),
                new Cartas(26,50,45,70,34,80,50,50),
                new Cartas(53,67,53,10,53,57,53,52)
                };
            Console.WriteLine(lpa.ObtemPorcentagemDeDano(cartas));
        }
    }
}
