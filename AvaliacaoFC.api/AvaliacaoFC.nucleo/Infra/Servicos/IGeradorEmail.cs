namespace AvaliacaoFC.Nucleo.Infra.Servicos
{
    public interface IGeradorEmail
    {
        void Enviar(IEnumerable<string> emails, string assunto, string menssagem, IEnumerable<string>? anexos);
    }
}
