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

        //public List<Requisito> dependentes { get; set; }

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
                #endregion

                patrocinadores.Add(new Patrocinador(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_peso_patr)), new_requisitos.OrderByDescending(p => p.valor_interesse).ToList()));
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
                Console.WriteLine("         Id: " + r.id_requisito + " - Custo: " + r.custo + ((r.valor_interesse > 0) ? " - Valor de interesse: " + r.valor_interesse : ""));
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
            //new Program().PrintRequisitos(requisitos);
            //Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
            //Console.ReadKey();
            #endregion

            #region PRINT PATROCINADORES
            new Program().PrintPatrocinadores(patrocinadores);
            Console.WriteLine("\n\nPressione qualquer tecla para GERAR a próxima release.....");
            Console.ReadKey();
            #endregion


            //List<Requisito> prox_release = 
            new Program().Backtracking(custo_release, requisitos, patrocinadores);

            #region SET REQUISITO IN RELEASE
            //long custo_atual = 0;
            //foreach (Requisito r in prox_release)
            //{
            //    custo_atual = custo_atual + r.custo;
            //}
            #endregion

            //Console.WriteLine("\n\nPressione qualquer tecla para VER a próxima release.....");
            //Console.ReadKey();

            #region PRINT REQUISITOS DA SPRINT
            //Console.WriteLine("\n\n---------------------------------------------");
            //Console.WriteLine("RECURSO DA SPRINT: " + custo_release + " Custo atual: " + custo_atual);
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("REQUISITOS PARA PRÓXIMA RELEASE");
            //new Program().PrintRequisitos(prox_release);
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

        #region Backtracking
        public string Backtracking(long custo_release, List<Requisito> requisitos, List<Patrocinador> patrocinadores)
        {
            long custo_atual = 0;
            Requisito r = null;
            try
            {
                if (custo_release >= custo_atual)
                {
                    foreach (Requisito release in requisitos)
                    {
                        foreach (Patrocinador p in patrocinadores)
                        {
                            #region Patrocinadores sem o atual
                            List<Patrocinador> patrocinadores_sem_atual = patrocinadores.ToList();
                            patrocinadores_sem_atual.Remove(p);
                            #endregion

                            foreach (Patrocinador p2 in patrocinadores_sem_atual)
                            {
                                if (p.list_interesse_requi.Count > 0 && p.list_interesse_requi.Count > 0)
                                {
                                    // Processa a solução, ou seja, retorna o requisito de maior prioridade
                                    r = new Program().ProcessaSolucao(p, p2);
                                    
                                    // Remove o requisito que já foi atribuido a release das listas do patrocinador
                                    p.list_interesse_requi.RemoveAll(x => x.id_requisito == r.id_requisito);
                                    p2.list_interesse_requi.RemoveAll(x => x.id_requisito == r.id_requisito);
                                }
                                else { break; }
                            }

                            if (custo_release >= custo_atual + r.custo)
                            {
                                // calcula o custo dos requisitos que já estão na release com o que esta sendo adicionado agora
                                custo_atual = custo_atual + r.custo;

                                // É "impresso" o requisito de retorno do backtraking, e realiza uma chamada recussiva para o 
                                // próprio método passando os parametros sem o requisito que já está na release
                                Console.Write(Backtracking(custo_release - custo_atual, requisitos, patrocinadores));

                                return r.id_requisito.ToString();
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                Console.WriteLine("Error");
            }
        }
        #endregion

        #region ProcessaSolucao
        public Requisito ProcessaSolucao(Patrocinador p, Patrocinador p2)
        {
            // Se existir um requisito de um patrocinador com mesmo peso ou menor, mas com interesse maior, retorna esse requitio
            return (p.list_interesse_requi.Max(m => m.valor_interesse) >= p2.list_interesse_requi.Max(m => m.valor_interesse))
               ? p.list_interesse_requi.FirstOrDefault() : p2.list_interesse_requi.FirstOrDefault();


        }
        #endregion



        static int Fibonacci(int x) // A variável ‘x’ assume o valor da varíável ‘number’
        {
            // Aqui a lógica é simples, se ‘x’ for menor ou igual a 1 o valor 1 será retornado
            if (x <= 1)
            {
                return 1;
            }
            // Aqui a recursividade é usada para "buscar" o termo que foi inserido na variável ‘number’ e que foi atribuida por ‘x’
            // O método Fibonacci será executado até que o termo solicitado seja alcançado
            return Fibonacci(x - 1) + Fibonacci(x - 2);
        }

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
            Console.WriteLine("Problema NRP com Backtracking....");
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Concluido.....");
        }
        #endregion
    }
}
