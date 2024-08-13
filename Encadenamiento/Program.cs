using System.Net.WebSockets;

namespace Encadenamiento
{
    public class Program
    namespace Encadenamiento
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var hechos = new HashSet<string> { "fiebre", "tos" };

                var reglas = new List<Regla>
            {
                new Regla(
                    new HashSet<string> {"fiebre"},
                    "infeccion"
                    ),
                 new Regla(
                    new HashSet<string> {"dolor de cabeza","fiebre"},
                    "gripe"
                    ),
                  new Regla(
                    new HashSet<string> {"tos","fiebre"},
                    "neumonia"
                    ),
            };

                var conclusiones = EncadenamientoHaciaAdelante(hechos, reglas);

                Console.WriteLine("Posible diagnostico");
                foreach (var conclusion in conclusiones)
                {
                    Console.WriteLine(conclusion);
                }

            }

            static HashSet<string> EncadenamientoHaciaAdelante(HashSet<string> hechos, List<Regla> reglas)
            {
                var conclusiones = new HashSet<string>();

                bool nuevoHechoAgregado;

                do
                {
                    nuevoHechoAgregado = false;

                    foreach (var regla in reglas)
                    {
                        if (regla.Condiciones.IsSubsetOf(hechos) &&
                            !hechos.Contains(regla.Conclusion))
                        {

                            hechos.Add(regla.Conclusion);
                            conclusiones.Add(regla.Conclusion);
                            nuevoHechoAgregado = true;
                        }
                    }

                } while (nuevoHechoAgregado);

                return conclusiones;
            }

        }



        class Regla
        {
            public HashSet<string> Condiciones { get; set; }

            public string Conclusion { get; }

            public Regla(HashSet<string> condiciones, string conclusion)
            {
                Condiciones = condiciones;
                Conclusion = conclusion;
            }

        }
    }
   