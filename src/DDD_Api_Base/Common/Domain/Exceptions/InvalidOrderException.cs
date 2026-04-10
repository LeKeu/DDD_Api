namespace Common.Domain.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException(string mensagem) : base(mensagem) { }
    }
}
