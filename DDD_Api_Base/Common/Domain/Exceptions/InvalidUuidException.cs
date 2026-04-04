namespace Common.Domain.Exceptions
{
    public class InvalidUuidException : Exception
    {
        public InvalidUuidException(string mensagem) : base(mensagem) { }
    }
}
