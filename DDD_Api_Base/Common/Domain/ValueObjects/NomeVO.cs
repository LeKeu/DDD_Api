namespace Common.Domain.ValueObjects
{
    public class NomeVO : ValueObject<string>
    {
        //depois gerar o teste dele no proj de teste!! só preciso resolver o bo do teste
        public NomeVO(string nome) : base(nome)
        {
            if (!IsValid())
                throw new ArgumentException("Nome não é válido!");
        }

        protected override bool IsValid()
        { // faço minhas validações internas do nome, o que eu quiser
            if (Value.Length <= 3) // esse 'Value' pega o que foi passado no base()
                return false;

            // quaisquer outras validações no futuro

            return true;
        }
    }
}
