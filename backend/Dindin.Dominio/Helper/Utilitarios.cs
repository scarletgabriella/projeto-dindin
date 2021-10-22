using System;

namespace Dindin.Helper
{
    public static class Utilitarios
    {
        public static string ValidarStringVazia(this string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? throw new Exception("Propriedade deve estar preenchida.") : texto;
        }

    }
}
