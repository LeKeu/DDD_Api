using System.Text.Json;

namespace Common.Domain
{
    public abstract class Entity
    {
        // abstrata pq todas as entidades vão herdar dela
        // aqui vão ficar comportamentos comuns que toda entidade vai usar (é né)

        public abstract string ToJson();

    }
}
