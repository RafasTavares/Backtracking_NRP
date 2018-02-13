using System;
using System.Collections.Generic;
using System.IO;
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
            this.valor_interesse = interesse;
        }
    }
    #endregion

    #region Patrocinador
    public class Patrocinador
    {
        public long id { get; set; }
        public long peso { get; set; }

        public List<Requisito> list_interesse_requi { get; set; }

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
                List<Requisito> new_requisitos = new List<Requisito>();
                #region set valor de interesse

                foreach (Requisito r in requisitos)
                {
                    int vl_interesse = (new Random(DateTime.Now.Millisecond).Next(0, vl_max_interesse));
                    System.Threading.Thread.Sleep(1);
                    new_requisitos.Add(new Requisito(r.id_requisito, r.custo, vl_interesse));
                }

                //for (int j = 1; j <= requisitos.Count; j++)
                //{
                //    int vl_interesse = (new Random(DateTime.Now.Millisecond).Next(0, vl_max_interesse));
                //    System.Threading.Thread.Sleep(1);
                //    Requisito aux = new Requisito(i, 0, vl_interesse);
                //    new_requisitos.Add(aux);


                //    // Console.WriteLine(r.id_requisito + " - " + r.custo + " - " + r.valor_interesse);
                //    // Console.WriteLine(aux.id_requisito + " - " + aux.custo + " - " + aux.valor_interesse + "\n");
                //    // Console.ReadKey();
                //}
                #endregion

                patrocinadores.Add(new Patrocinador(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_peso_patr)), new_requisitos));
                System.Threading.Thread.Sleep(1);
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
                Console.WriteLine("\nPATROCINADOR - Id: " + p.id + " - Peso: " + p.peso);
                //new Program().PrintRequisitos(p.list_interesse_requi);
                Console.WriteLine("     REQUISITOS");
                foreach (Requisito r in p.list_interesse_requi)
                    Console.WriteLine("         Id: " + r.id_requisito + " - Custo: " + r.custo + " - Valor de interesse: " + r.valor_interesse);
            }

            Console.WriteLine("---------------------------------------------");
        }
        #endregion

        #region MAIN
        public static void Main(string[] args)
        {

            // VALORES MAX RANDOM
            int vl_max_interesse_req = new Program().GetVlMaxInteresseReq();
            int vl_max_custo_req = new Program().GetVlMaxCustoReq();
            int vl_max_peso_patr = new Program().GetVlMaxPesoPatro();

            //LISTAS DE REQUISITOS E PATROCINADORES
            List<Requisito> requisitos = new Program().CriarListadeRequisitos(vl_max_custo_req);
            List<Patrocinador> patrocinadores = new Program().CriarListaPatrocinadores(requisitos, vl_max_peso_patr, vl_max_interesse_req).OrderByDescending(x => x.peso).ToList();

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
            new Program().PrintRequisitos(requisitos);
            Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
            Console.ReadKey();
            #endregion

            #region PRINT PATROCINADORES
            //    new Program().PrintPatrocinadores(patrocinadores);
            //  Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
            //Console.ReadKey();
            #endregion

            foreach (var p in patrocinadores) { }

            long custo_atual = 0;

            List<Requisito> prox_release = new List<Requisito>();
            try
            {
                foreach (Requisito r in requisitos)
                {
                    Console.WriteLine("Requisito: " + r.id_requisito + " - Custo: " + r.custo);
                    foreach (Patrocinador p in patrocinadores)
                    {
                        var req_patr = p.list_interesse_requi.Where(req => req.id_requisito == r.id_requisito).First();
                        if (r.id_requisito == req_patr.id_requisito)
                        {
                            Console.WriteLine("     Patrocinador: " + p.id + " - Peso: " + p.peso + " - Interesse: " + req_patr.valor_interesse);
                        }
                    }
                    Console.WriteLine("\n\n");

                    #region SET REQUISITO IN RELEASE
                    long aux = custo_atual + r.custo;
                    if (custo_release >= aux)
                    {
                        prox_release.Add(r);
                        custo_atual = custo_atual + r.custo;
                    }
                    #endregion
                }

            }
            catch (Exception) { Console.WriteLine("Error"); }

            Console.ReadKey();

            #region PRINT REQUISITOS DA SPRINT
            Console.WriteLine("\n\n---------------------------------------------");
            Console.WriteLine("RECURSO DA SPRINT: " + custo_release + " / CONSUMIDO: " + custo_atual);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("REQUISITOS PARA PRÓXIMA RELEASE");
            new Program().PrintRequisitos(prox_release);
            #endregion

            #region SAVE CONSOLE

            //Console.ReadKey();

            /*  bool? salvar = null;
              Console.WriteLine("Deseja salvar os dados do console em arquivo? (1-SIM / 0-NÃO) : ");
              while (salvar == null)
              {
                  //Console.WriteLine("1 = SIM / 0 = NÃO : ");
                  try { salvar = Convert.ToBoolean(Console.ReadLine()); }
                  catch (Exception) { salvar = null; }
              }

              if (salvar == true)
                  new Program().SaveConsoleInTxt();
              #endregion
      */
            Console.WriteLine("\n\nPressione qualquer tecla para Finalizar.....");
            Console.ReadKey();
            #endregion
        }
        #endregion

        #region SaveConsoleInTxt
        public void SaveConsoleInTxt()
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./NRP_Dados.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao salvar dados do console");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine("Problema NRL com Backtracking....");
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Concluido.....");
        }
        #endregion
    }
}
