using AvaliacaoFC.Nucleo.Aplicacao;

namespace AvaliacaoFC.Nucleo.Infra.Servicos
{
    public class GeradorTemplate : IGeradorTemplate
    {
        public string GerarTemplate(IEnumerable<string> valores, string nomeTemplate)
        {
            string resultado = Templates.ResourceManager.GetString(nomeTemplate) ?? string.Empty;

            if (valores != null)
            {
                foreach (var item in valores.Select((value, i) => new { i, value }))
                {
                    resultado = resultado.Replace("{" + item.i + "}", item.value);
                } 
            }

            return resultado;
        }
    }
}
