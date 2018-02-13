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
        public long id_requisito { get; set; }
        public long custo { get; set; }
        public long valor_interesse { get; set; }

        public Requisito(long id, long custo, long interesse = 0)
        {
            this.id_requisito = id;
            this.custo = custo;
            this.valor_interesse = valor_interesse;
        }
    }
    #endregion

    #region Patrocinador
    public class Patrocinador
    {
        public long id { get; set; }
        public long peso { get; set; }

        public List<Requisito> list_interesse_requi;

        public Patrocinador(long id, long peso, List<Requisito> list_interesse_requi)
        {
            this.id = id;
            this.peso = peso;
            this.list_interesse_requi = list_interesse_requi;
        }




    }
    #endregion

    public class Program
    {

        #region GET VL MAXIMO DE INTERESSE DOS REQUISITOS
        public int GetVlMaxInteresseReq()
        {
            int vl_max_interesse_req = 0;
            while (vl_max_interesse_req == 0)
            {
                Console.WriteLine("Digite o valor máximo de INTERESSE para os requisitso: ");

                try { vl_max_interesse_req = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { vl_max_interesse_req = 0; }
            }
            return vl_max_interesse_req;
        }
        #endregion

        #region GET VL MAXIMO DE CUSTO DOS REQUISITOS
        public int GetVlMaxCustoReq()
        {
            int vl_max_custo_req = 0;
            while (vl_max_custo_req == 0)
            {
                Console.WriteLine("Digite o valor máximo de CUSTO para os requisitos: ");

                try { vl_max_custo_req = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { vl_max_custo_req = 0; }
            }
            return vl_max_custo_req;
        }
        #endregion

        #region GET VL MAXIMO DE PESO DO PATROCINADOR
        public int GetVlMaxPesoPatro()
        {
            int vl_max_peso_patr = 0;
            while (vl_max_peso_patr == 0)
            {
                Console.WriteLine("Digite o valor máximo do PESO do patrocinador: ");

                try { vl_max_peso_patr = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { vl_max_peso_patr = 0; }
            }
            return vl_max_peso_patr;
        }
        #endregion

        #region CRIA UMA LISTA DE REQUISITOS
        public List<Requisito> CriarListadeRequisitos(int vl_max_custo_req)
        {
            List<Requisito> requisitos = new List<Requisito>();
            long totalRequisitos = 0;

            while (totalRequisitos == 0)
            {
                Console.WriteLine("Digite a quantidade de REQUISITOS: ");

                try { totalRequisitos = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { totalRequisitos = 0; }
            }

            for (int i = 1; i <= totalRequisitos; i++)
            {
                requisitos.Add(new Requisito(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_custo_req))));
                System.Threading.Thread.Sleep(10);
            }
            return requisitos;
        }
        #endregion

        #region CRIA UMA LISTA DE PATROCINADORES
        public List<Patrocinador> CriarListaPatrocinadores(List<Requisito> requisitos, int vl_max_peso_patr, int vl_max_interesse)
        {
            List<Patrocinador> patrocinadores = new List<Patrocinador>();

            long totalPatrocinadores = 0;

            while (totalPatrocinadores == 0)
            {
                Console.WriteLine("Digite a quantidade de PATROCINADORES: ");

                try { totalPatrocinadores = Convert.ToInt64(Console.ReadLine()); }
                catch (Exception) { totalPatrocinadores = 0; }
            }

            for (int i = 1; i <= totalPatrocinadores; i++)
            {
                #region set valor de interesse
                foreach (var r in requisitos)
                {
                    r.valor_interesse = (new Random(DateTime.Now.Millisecond).Next(0, vl_max_interesse));
                    System.Threading.Thread.Sleep(10);
                }
                #endregion

                patrocinadores.Add(new Patrocinador(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_peso_patr)), requisitos));
                System.Threading.Thread.Sleep(10);
            }

            return patrocinadores;
        }
        #endregion

        #region PRINT REQUISITOS
        public void PrintRequisitos(List<Requisito> requisitos)
        {
            Console.WriteLine("     REQUISITOS");
            foreach (Requisito r in requisitos)
                Console.WriteLine("         Id: " + r.id_requisito + " - Custo: " + r.custo + " - Valor de interesse: " + r.valor_interesse);
        }
        #endregion

        #region PRINT PATROCINADORES
        public void PrintPatrocinadores(List<Patrocinador> patrocinadores)
        {
            Console.WriteLine("---------------------------------------------");
            foreach (Patrocinador p in patrocinadores)
            {
                Console.WriteLine("\nPATROCINADOR");
                Console.WriteLine("     Id: " + p.id + " - Peso: " + p.peso);
                new Program().PrintRequisitos(p.list_interesse_requi);
            }

            Console.WriteLine("---------------------------------------------");
        }
        #endregion

        public static void Main(string[] args)
        {
            // VALORES MAX RANDOM
            int vl_max_interesse_req = new Program().GetVlMaxInteresseReq();
            int vl_max_custo_req = new Program().GetVlMaxCustoReq();
            int vl_max_peso_patr = new Program().GetVlMaxPesoPatro();

            //LISTAS DE REQUISITOS E PATROCINADORES
            List<Requisito> requisitos = new Program().CriarListadeRequisitos(vl_max_custo_req);
            List<Patrocinador> patrocinadores = new Program().CriarListaPatrocinadores(requisitos, vl_max_peso_patr, vl_max_interesse_req);

            #region CUSTO DA RELEASE
            long custo_release = 0;
            while (custo_release == 0)
            {
                Console.WriteLine("Digite o custo total da release: ");

                try { custo_release = Convert.ToInt64(Console.ReadLine()); }
                catch (Exception) { custo_release = 0; }
            }
            #endregion

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("RECURSO DA SPRINT: " + custo_release);

            #region PRINT REQUISITOS
            //        new Program().PrintRequisitos(requisitos);
            //        Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
            //       Console.ReadKey();
            #endregion

            #region PRINT PATROCINADORES
            new Program().PrintPatrocinadores(patrocinadores);
            Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
            Console.ReadKey();
            #endregion

            long custo_atual = 0;
            List<Requisito> prox_release = new List<Requisito>();
            try
            {
                //while (custo_release >= custo_atual)
                //{
                foreach (Requisito r in requisitos)
                {
                    long aux = custo_atual + r.custo;
                    if (custo_release >= aux)
                    {
                        prox_release.Add(r);
                        custo_atual = custo_atual + r.custo;
                    }

                }
                //}
            }
            catch (Exception) { Console.WriteLine("Error"); }

            #region PRINT REQUISITOS DA SPRINT
            Console.WriteLine("\n\n---------------------------------------------");
            Console.WriteLine("RECURSO DA SPRINT: " + custo_release + " / CONSUMIDO: " + custo_atual);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("REQUISITOS PARA PRÓXIMA RELEASE");
            new Program().PrintRequisitos(prox_release);

            Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
            Console.ReadKey();
            #endregion
        }
    }
}
