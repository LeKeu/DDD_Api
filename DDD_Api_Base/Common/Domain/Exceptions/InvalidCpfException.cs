namespace Common.Domain.Exceptions
{
    public class InvalidCpfException : Exception
    {
        public InvalidCpfException(string mensagem) : base(mensagem) { }
    }
}
