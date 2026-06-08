namespace Clases
{
    public class Persona
    {
        public int dni;
        public string nombre;

        public override string ToString()
        {
            return $"{dni}\t|\t{nombre}";
        }
        public static bool operator >(Persona p1, Persona p2)
        {
            if (p1.dni > p2.dni)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Persona p1, Persona p2)
        {
            if (p1.dni<p2.dni) return true;
            return false;
        }
    }
}