namespace API_Folhas.Utils
{
    public class Calculos
    {
        public static double CalcularSalarioBruto(int horas, double valor)
            => horas * valor;
        public static double CalcularImpostoRenda(double bruto)
        {
            if (bruto <= 1903.98) return Taxas.GetInstance().Ir_abaixo_1903;

            if (bruto <= 2826.65) return bruto * 0.075 - Taxas.GetInstance().Ir_abaixo_2826;

            if (bruto <= 3751.05) return bruto * 0.15 - Taxas.GetInstance().Ir_abaixo_3551;

            if (bruto <= 4664.68) return bruto * 0.225 - Taxas.GetInstance().Ir_abaixo_4664;

            return bruto * 0.275 - Taxas.GetInstance().Ir_acima_4664;
        }

        public static double CalcularImpostoInss(double bruto)
        {
            if (bruto <= 1693.72) return bruto * Taxas.GetInstance().Inss_abaixo_1693;

            if (bruto <= 2822.90) return bruto * Taxas.GetInstance().Inss_abaixo_2822;

            if (bruto <= 5645.80) return bruto * Taxas.GetInstance().Inss_abaixo_5645;

            return Taxas.GetInstance().Inss_acima_5645;

        }

        public static double CalcularFgts(double bruto) =>
            bruto * Taxas.GetInstance().Taxa_Fgts;

        

        public static double CalcularSalarioLiquido
            (double bruto, double renda, double inss) =>
            bruto - renda - inss;
    }
}