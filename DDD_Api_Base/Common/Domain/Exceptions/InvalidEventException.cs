namespace Common.Domain.Exceptions
{
    public class InvalidEventException : Exception
    {
        public InvalidEventException(string mensagem) : base(mensagem) { }
    }
}
