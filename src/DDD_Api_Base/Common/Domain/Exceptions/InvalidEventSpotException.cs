namespace Common.Domain.Exceptions
{
    public class InvalidEventSpotException : Exception
    {
        public InvalidEventSpotException(string mensagem) : base(mensagem) { }
    }
}
