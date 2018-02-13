using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking_NRP
{
    #region Requisito
    public class Requisito
    {
        public int id_requisito { get; set; }
        public int tempo_custo { get; set; }

        public Requisito(int id, int custo)
        {
            id_requisito = id;
            tempo_custo = custo;
        }
    }
    #endregion

    #region Patrocinador
    public class Patrocinador
    {
        int peso { get; set; }


    }
    #endregion

    public class Program
    {

        #region Monta lista de requisitos
        public List<Requisito> MontaListadeRequisitos()
        {
            List<Requisito> requisitos = new List<Requisito>();
            long totalRequisitos = 0;

            while (totalRequisitos == 0)
            {
                Console.WriteLine("Digite a quantidade de requisitos: ");

                try { totalRequisitos = Convert.ToInt64(Console.ReadLine()); }
                catch (Exception) { totalRequisitos = 0; }
            }


            for (int i = 0; i < totalRequisitos; i++)
                requisitos.Add(new Requisito(i, new Random().Next(1, 5)));

            return requisitos;
        }
        #endregion

        public static void Main(string[] args)
        {
            //Array de requisitos
            List<Requisito> requisitos = new Program().MontaListadeRequisitos();


            const int custo_release = 20;
            Console.WriteLine("---------------------------------------------");
            // Console.WriteLine("requisitos ordenados pela prioridade.");
            Console.WriteLine("Recurso da sprint: " + custo_release);
            Console.WriteLine("---------------------------------------------");

            #region print requisitos
            Console.WriteLine("Requisitos");
            foreach (Requisito r in requisitos)
            {
                Console.WriteLine("Id: " + r.id_requisito + " - Custo: " + r.tempo_custo);
            }
            Console.WriteLine("Pressione qualquer tecla para continuar.....");
            Console.ReadKey();
            #endregion

            int custo_atual = 0;
            while (custo_release > custo_atual)
            {
                custo_atual = +1;
            }

            Console.ReadKey();
        }
    }
}
