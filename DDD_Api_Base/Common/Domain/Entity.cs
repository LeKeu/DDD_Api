
namespace Common.Domain
{
    public abstract class Entity
    {
        // abstrata pq todas as entidades vão herdar dela
        // aqui vão ficar comportamentos comuns que toda entidade vai usar (é né)

        public abstract object Id { get; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = obj as Entity;
            if (other is null) // isso aqui pega os dois de cima juntos, mas vou deixar por causa da aula
                return false;

            return true;
        }

        public abstract string ToJson();

    }
}
