using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Energas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ideNum, UltiDig, Totdomi, Domicilios ;
            double ActMed, AntMed, metrosCs, ConsumDom, desc100, precioM3, totGeneral, promDomi;
            double porcentaje, desc8, totalPagar, recauTotal, acum100, acum8, porcen100, montoPd;

            Totdomi = 0;
            totGeneral = 0;

            Console.WriteLine("Ingrese valor del metro cubico: ");
            precioM3 = Convert.ToDouble(Console.ReadLine());

            Domicilios = 0;
            recauTotal = 0;
            desc100 = 0;
            desc8 = 0;
            montoPd = 0;
            acum100 = 0;
            acum8 = 0;

            Console.WriteLine("Ingrese identificador numerico del medidor: (0 para terminar de ingresar domicilios)");
            ideNum = Convert.ToInt32(Console.ReadLine());

            while (ideNum != 0)
            {
                Console.WriteLine("Ingrese el consumo del mes actual: ");
                ActMed = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingrese el consumo del mes anterior: ");
                AntMed = Convert.ToDouble(Console.ReadLine());
                UltiDig = Convert.ToInt32(ideNum % 10);
                metrosCs = ActMed - AntMed;
                ConsumDom = metrosCs * precioM3;

                UltiDig = Convert.ToInt32(ideNum % 10);
                if (UltiDig == 4 || UltiDig == 9)
                {

                    porcentaje = 100;
                    desc100++;
                    montoPd = ConsumDom;
                    acum100 = acum100 + montoPd;
                }
                else if (UltiDig == 5)
                {
                    porcentaje = 8;
                    desc8++;
                    montoPd = (ConsumDom * 0.08);
                    acum8 = acum8 + montoPd;
                }
                else
                {
                    porcentaje = 0;
                    montoPd = 0;
                }
                totalPagar = ConsumDom - montoPd;
                Domicilios = Domicilios + 1;
                recauTotal = recauTotal + totalPagar;

                Console.WriteLine("Identificador numerico del medidor: " + ideNum);
                Console.WriteLine("Precio del metro cubico: " + precioM3);
                Console.WriteLine("Cantidad de metros cubicos suministrados: " + metrosCs);
                Console.WriteLine("Monto por el suminstro: " + ConsumDom);
                Console.WriteLine("Monto en concepto al descuento correspondiente: " + montoPd);
                Console.WriteLine("Porcentaje de descuento aplicado: " + porcentaje + "%");
                Console.WriteLine("Monto final a pagar: {0:f2}", totalPagar);

                Console.WriteLine("Ingrese identificador numerico del medidor: (0 para terminar de ingresar domicilios)");
                ideNum = Convert.ToInt32(Console.ReadLine());
            }
            Totdomi = Totdomi + Domicilios;
            totGeneral = totGeneral + recauTotal;
            porcen100 = (desc100 * 100) / Totdomi;

            Console.WriteLine("Cantidad de domicilios procesados: " + Totdomi);
            Console.WriteLine("Recaudacion total: " + recauTotal);
            Console.WriteLine("Cantidad de descuentos del 100% aplicados: " + desc100);
            Console.WriteLine("Monto total de descuentos del 100% aplicados: {0:f2}", acum100);
            Console.WriteLine("Cantidad de descuentos del 8% aplicados: {0}", desc8);

            if (porcen100 > 50)
            {
                Console.WriteLine("ALERTA. Supero la cantidad de descuentos admitidos.");
            }

            promDomi = totGeneral / Totdomi;
            Console.WriteLine("Cantidad de domicilios procesados: " + Totdomi);
            Console.WriteLine("Recaudacion total: " + recauTotal);
            Console.WriteLine("Recaudacion promedio por domicilio: {0:f2}", promDomi);

            Console.ReadKey();
        }
    }
}
