using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traductor
{
    class Program
    {
        static List<Traduccion> lstTraducciones;
        static void Main(string[] args)
        {
            lstTraducciones = new List<Traduccion>();
            InicializarDiccionario();

            string strInput = "a";
            while (!string.IsNullOrEmpty(strInput))
            {
                Console.WriteLine("Introduzca una palabra en Español");
                strInput = Console.ReadLine();
                Console.WriteLine(TraducirEspañol(strInput));
                Console.WriteLine("Introduzca una palabra en Ingles o Nada para salir");
                strInput = Console.ReadLine();
                Console.WriteLine(TraducirIngles(strInput));
            }
        }

        static string TraducirEspañol(string Español)
        {
            string ret = "La palabra no existe en el diccionario";
            IEnumerable<Traduccion> tradPalabra = from trad in lstTraducciones
                                                  where trad.strEspañol == Español
                                                  select trad;
            foreach (var palabra in tradPalabra)
            {
                ret = palabra.strIngles;
            }
            return ret;
        }

        static string TraducirIngles(string Ingles)
        {
            string ret = "La palabra no existe en el diccionario";
            IEnumerable<Traduccion> tradPalabra = from trad in lstTraducciones
                                                  where trad.strIngles == Ingles
                                                  select trad;
            foreach (var palabra in tradPalabra)
            {
                ret = palabra.strEspañol;
            }
            return ret;
        }

        static void InicializarDiccionario()
        {
            lstTraducciones.Add(new Traduccion("hola", "hello"));
            lstTraducciones.Add(new Traduccion("noche", "night"));
            lstTraducciones.Add(new Traduccion("niño", "child"));
            lstTraducciones.Add(new Traduccion("lapiz", "pencil"));
            lstTraducciones.Add(new Traduccion("pulsera", "bracelet"));
            lstTraducciones.Add(new Traduccion("reloj", "clock"));
            lstTraducciones.Add(new Traduccion("bebe", "baby"));
            lstTraducciones.Add(new Traduccion("escuela", "school"));
            lstTraducciones.Add(new Traduccion("calle", "street"));
            lstTraducciones.Add(new Traduccion("ciudad", "city"));
        }
    }


    class Traduccion
    {
        public Traduccion(string Español, string Ingles)
        {
            strEspañol = Español;
            strIngles = Ingles;
        }
        public string strEspañol { get; set; }
        public string strIngles { get; set; }
    }
}
