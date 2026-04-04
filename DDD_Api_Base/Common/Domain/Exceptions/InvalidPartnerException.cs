namespace Common.Domain.Exceptions
{
    public class InvalidPartnerException : Exception
    {
        public InvalidPartnerException(string mensagem) : base(mensagem) { }
    }
}
