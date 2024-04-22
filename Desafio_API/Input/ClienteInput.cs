namespace Desafio_API.Input
{
    public class ClienteInput
    {
        public required string Nome { get; set; }
        public required int CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
