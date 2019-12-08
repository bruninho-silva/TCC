
namespace DecisionMakerLPA
{
    /// <summary>
    /// Classe estática que possui as constantes da biblioteca.
    /// </summary>
    public static class Constante
    {
        public const double VCVE = 0.9; //Var de controle de Veracidade
        public const double VCFA = -0.5; //Var de controle de Falsidade

        public const double VCIC = 0.5; //var de conttole de Inconsistencia
        public const double VCPA = -0.5; //var de controle de Paracompleto

        public const string verdade = "VERDADE";
        public const string falso = "FALSO";
        public const string inconsistente = "INCONSISTENTE";
        public const string paracompleto = "PARACOMPLETO";
        public const string quaseVerdadeInconsistente = "QUASE_VERDADE_TENDENDO_A_INCONSISTENTE";
        public const string inconsistenteVerdade = "INCONSISTENTE_TENDENDO_A_VERDADE";
        public const string quaseVerdadeParacompleto = "QUASE_VERDADE_TENDENDO_A_PARACOMPLETO";
        public const string paracompletoVerdade = "PARACOMPLETO_TENDENTO_A_VERADADE";
        public const string quaseFalsoParacompleto = "QUASE_FALSO_TENDENDO_PARACOMPLETO";
        public const string paracompletoFalso = "PARACOMPLETO_TENDENDO_A_FALSO";
        public const string quaseFalsoInconsistente = "QUASE_FALSO_TEDENDO_A_INCONSISTENTE";
        public const string inconsistenteFalso = "INCONSISTENTE_TENDENDO_A_FALSO";
        public const string indefinido = "INDEFINIDO";
    }
}