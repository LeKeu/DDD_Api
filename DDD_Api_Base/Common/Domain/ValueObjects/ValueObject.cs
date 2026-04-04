using System.Text.Json;

namespace Common.Domain.ValueObjects
{
    public abstract class ValueObject<TValue>
    {
        //readonly = equivalente ao readonly + deepFreeze do TS
        protected readonly TValue _value;

        public ValueObject(TValue value)
        {
            _value = value;
        }

        public TValue GetValue() => _value;
        // ou
        public TValue Value => _value;

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var other = obj as ValueObject<TValue>;
            if (other is null) // isso aqui pega os dois de cima juntos, mas vou deixar por causa da aula
                return false;

            return JsonSerializer.Serialize(_value) == JsonSerializer.Serialize(other.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); // verificar!!
        } // coloquei pois, uma vez que fiz o override do Equals, ele criticou que precisa desse tbm

        public override string ToString()
        {
            if (_value is not object || _value is string)
                return _value?.ToString() ?? string.Empty;

            return JsonSerializer.Serialize(_value);
        }

        protected abstract bool IsValid();

        // ele faz um método deepfreeze que, pesquisando, vi que no c# já tem algo nativo pra isso, que é setar como init.
    }
}
