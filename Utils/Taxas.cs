namespace API_Folhas.Utils
{
    public sealed class Taxas
    {
        private static Taxas _instance;

        private Taxas(){
            this.Taxa_Fgts = 0.08;
            this.Inss_abaixo_1693 = 0.08;
            this.Inss_abaixo_2822 = 0.09;
            this.Inss_abaixo_5645 = 0.11;
            this.Inss_acima_5645 = 621.03;
            this.Ir_abaixo_1903 = 0;
            this.Ir_abaixo_2826 = 142.8;
            this.Ir_abaixo_3551 = 354.8;
            this.Ir_abaixo_4664 = 636.13;
            this.Ir_acima_4664 = 869.36;
        }

        //implementando Singleton
        public static Taxas GetInstance()
        {
        
            if(_instance == null)
            {
                _instance = new Taxas();
            }
            return _instance;
            
        }

        public double Taxa_Fgts {get;}
        public double Inss_abaixo_1693 {get; }
        public double Inss_abaixo_2822 {get; }
        public double Inss_abaixo_5645 {get; }
        public double Inss_acima_5645 {get; }
        public double Ir_abaixo_1903 {get;}
        public double Ir_abaixo_2826 {get;}
        public double Ir_abaixo_3551 {get; }
        public double Ir_abaixo_4664 {get;}
        public double Ir_acima_4664 {get;}

       



    }
}