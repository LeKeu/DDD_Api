namespace Common.Domain.Exceptions
{
    public class InvalidEventSectionException : Exception
    {
        public InvalidEventSectionException(string mensagem) : base(mensagem) { }
    }
}
