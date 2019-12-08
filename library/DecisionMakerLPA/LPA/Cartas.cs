namespace DecisionMakerLPA
{
    /// <summary>
    /// Classe Modelo Carta que cont�m oito valores.
    /// </summary>
    public class Carta
    {
        /// <summary>
        /// M�todo Construtor.
        /// </summary>
        /// <param name="mi1">Valor Favor�vel</param>
        /// <param name="lamb1">Valor Desfavor�vel</param>
        /// <param name="mi2">Valor Favor�vel</param>
        /// <param name="lamb2">Valor Desfavor�vel</param>
        /// <param name="mi3"><Valor Favor�vel/param>
        /// <param name="lamb3">Valor Desfavor�vel</param>
        /// <param name="mi4">Valor Favor�vel</param>
        /// <param name="lamb4">Valor Desfavor�vel</param>
        public Carta(int mi1, int lamb1, int mi2, int lamb2, int mi3, int lamb3, int mi4, int lamb4)
        {
            MiAtributo1 = mi1;
            MiAtributo2 = mi2;
            MiAtributo3 = mi3;
            MiAtributo4 = mi4;

            LambAtributo1 = lamb1;
            LambAtributo2 = lamb2;
            LambAtributo3 = lamb3;
            LambAtributo4 = lamb4;
        }

        /// <summary>
        /// Pega o atributo de acordo com �ndice passado por param�tro.
        /// </summary>
        /// <param name="i">�ndice</param>
        /// <returns>
        /// Retorna o atributo selecionado.
        /// </returns>
        public int GetAtributoMi(int i)
        {
            switch (i)
            {
                case 1: return MiAtributo1;
                case 2: return MiAtributo2;
                case 3: return MiAtributo3;
                case 4: return MiAtributo4;
                default: return 0;
            }
        }

        /// <summary>
        /// Pega o atributo de acordo com �ndice passado por param�tro.
        /// </summary>
        /// <param name="i">�ndice</param>
        /// <returns>
        /// Retorna o atributo selecionado.
        /// </returns>
        public int GetAtributoLamb(int i)
        {
            switch (i)
            {
                case 1: return LambAtributo1;
                case 2: return LambAtributo2;
                case 3: return LambAtributo3;
                case 4: return LambAtributo4;
                default: return 0;
            }
        }

        public int MiAtributo1 { get; set; }
        public int MiAtributo2 { get; set; }
        public int MiAtributo3 { get; set; }
        public int MiAtributo4 { get; set; }
        public int LambAtributo1 { get; set; }
        public int LambAtributo2 { get; set; }
        public int LambAtributo3 { get; set; }
        public int LambAtributo4 { get; set; }
    }
}
