namespace ConversorDeMoedas
{
    public static class ConversorDeMoedas
    {
        public static double ConverterMoeda(int moedaOrigem, int moedaDestino, double valor)
        {
            // Se as moedas forem iguais, não há necessidade de conversão
            if (moedaOrigem == moedaDestino)
            {
                return valor;
            }

            switch (moedaOrigem)
            {
                case 1: // Dólar (USD)
                    if (moedaDestino == 2) return valor * (Moedas.UsdToBrl / Moedas.EurToBrl); // USD -> EUR
                    if (moedaDestino == 3) return valor * Moedas.UsdToBrl; // USD -> BRL
                    break;

                case 2: // Euro (EUR)
                    if (moedaDestino == 1) return valor * (Moedas.EurToBrl / Moedas.UsdToBrl); // EUR -> USD
                    if (moedaDestino == 3) return valor * Moedas.EurToBrl; // EUR -> BRL
                    break;

                case 3: // Real (BRL)
                    if (moedaDestino == 1) return valor * Moedas.BrlToUsd; // BRL -> USD
                    if (moedaDestino == 2) return valor * Moedas.BrlToEur; // BRL -> EUR
                    break;
            }

            return 0;
        }
    }
}
