using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backtracking_NRP
{
    #region Requisito
    public class Requisito
    {
        public long id_requisito { get; set; }
        public long custo { get; set; }
        public long valor_interesse { get; set; }
        public Requisito dependente { get; set; }

        //public List<Requisito> dependentes { get; set; }

        public Requisito(long id, long custo, long interesse = 0, Requisito pDependente = null)
        {
            this.id_requisito = id;
            this.custo = custo;
            this.valor_interesse = interesse;
            this.dependente = pDependente;
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
        public int GetVlMaxInteresseReq(StreamWriter _console)
        {
            int vl_max_interesse_req = 0;
            while (vl_max_interesse_req == 0)
            {
                _console.WriteLine("Digite o valor máximo de INTERESSE para os requisitso: ");
                Console.WriteLine("Digite o valor máximo de INTERESSE para os requisitso: ");

                try { vl_max_interesse_req = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { vl_max_interesse_req = 0; }
            }
            _console.WriteLine(vl_max_interesse_req);
            return vl_max_interesse_req;
        }
        #endregion

        #region GET VL MAXIMO DE CUSTO DOS REQUISITOS
        public int GetVlMaxCustoReq(StreamWriter _console)
        {
            int vl_max_custo_req = 0;
            while (vl_max_custo_req == 0)
            {
                _console.WriteLine("Digite o valor máximo de CUSTO para os requisitos: ");
                Console.WriteLine("Digite o valor máximo de CUSTO para os requisitos: ");

                try { vl_max_custo_req = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { vl_max_custo_req = 0; }
            }
            _console.WriteLine(vl_max_custo_req);
            return vl_max_custo_req;
        }
        #endregion

        #region GET VL MAXIMO DE PESO DO PATROCINADOR
        public int GetVlMaxPesoPatro(StreamWriter _console)
        {
            int vl_max_peso_patr = 0;
            while (vl_max_peso_patr == 0)
            {
                _console.WriteLine("Digite o valor máximo do PESO do patrocinador: ");
                Console.WriteLine("Digite o valor máximo do PESO do patrocinador: ");

                try { vl_max_peso_patr = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { vl_max_peso_patr = 0; }
            }
            _console.WriteLine(vl_max_peso_patr);
            return vl_max_peso_patr;
        }
        #endregion

        #region GET TOTAL REQUISITOS
        public long GetTotalRequisitos(StreamWriter _console)
        {
            long totalRequisitos = 0;

            while (totalRequisitos == 0)
            {
                _console.WriteLine("\nDigite a quantidade de REQUISITOS: ");
                Console.WriteLine("\nDigite a quantidade de REQUISITOS: ");

                try { totalRequisitos = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception) { totalRequisitos = 0; }
            }
            _console.WriteLine(totalRequisitos);
            return totalRequisitos;
        }
        #endregion

        #region  GET TOTAL PATROCINADORES
        public long GetTotalPatrocinadores(long qtdRequisitos, StreamWriter _console)
        {
            long totalPatrocinadores = 0;
            _console.WriteLine("\nSe deseja usar a quantidade default (metade da quantidade de requisítos) de patrocinadores digite: 1, senão digite: 0");
            Console.WriteLine("\nSe deseja usar a quantidade default (metade da quantidade de requisítos) de patrocinadores digite: 1, senão digite: 0");

            if (Convert.ToInt64(Console.ReadLine()) == 1)
            {
                totalPatrocinadores = qtdRequisitos / 2;
                _console.WriteLine(totalPatrocinadores);
            }
            else
            {

                while (totalPatrocinadores == 0)
                {
                    _console.WriteLine("\nDigite a quantidade de PATROCINADORES: ");
                    Console.WriteLine("\nDigite a quantidade de PATROCINADORES: ");

                    try { totalPatrocinadores = Convert.ToInt64(Console.ReadLine()); }
                    catch (Exception) { totalPatrocinadores = 0; }
                }
            }
            _console.WriteLine(totalPatrocinadores);
            return totalPatrocinadores;
        }

        #endregion

        #region CRIA UMA LISTA DE REQUISITOS
        public List<Requisito> CriarListadeRequisitos(int vl_max_custo_req, long totalRequisitos, StreamWriter _console)
        {
            List<Requisito> requisitos = new List<Requisito>();
            long qtd_dependentes = (((totalRequisitos / 3) > 0) ? (totalRequisitos / 3) : (totalRequisitos / 2));
            _console.WriteLine("Gerando requisitos aleatorios.");
            Console.Write("Gerando requisitos aleatorios.");

            for (int i = 1; i <= totalRequisitos; i++)
            {
                //     if (requisitos.Count >= qtd_dependentes && totalRequisitos > requisitos.Count + qtd_dependentes)
                //    {
                //        requisitos.Add(new Requisito(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_custo_req)), 0, requisitos.FirstOrDefault() ));
                //         System.Threading.Thread.Sleep(10);
                //         qtd_dependentes--;
                //      }
                //     else
                //     {
                requisitos.Add(new Requisito(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_custo_req))));
                System.Threading.Thread.Sleep(10);
                //     }
                _console.Write(".");
                Console.Write(".");

            }
            _console.WriteLine("Gerando requisitos aleatorios.");
            return requisitos;
        }
        #endregion

        #region CRIA UMA LISTA DE PATROCINADORES
        public List<Patrocinador> CriarListaPatrocinadores(List<Requisito> requisitos, int vl_max_peso_patr, int vl_max_interesse, long totalPatrocinadores, StreamWriter _console)
        {
            List<Patrocinador> patrocinadores = new List<Patrocinador>();
            _console.Write("Gerando patrocinadores aleatorios.");
            Console.Write("Gerando patrocinadores aleatorios.");
            totalPatrocinadores = 100;
            for (int i = 1; i <= totalPatrocinadores; i++)
            {
                List<Requisito> new_requisitos = new List<Requisito>();

                #region set valor de interesse
                foreach (Requisito r in requisitos)
                {
                    int vl_interesse = (new Random(DateTime.Now.Millisecond).Next(0, vl_max_interesse));
                    //    System.Threading.Thread.Sleep(100);
                    new_requisitos.Add(new Requisito(r.id_requisito, r.custo, vl_interesse));
                }
                #endregion

                patrocinadores.Add(new Patrocinador(i, (new Random(DateTime.Now.Millisecond).Next(1, vl_max_peso_patr)), new_requisitos.OrderByDescending(p => p.valor_interesse).ToList()));
                System.Threading.Thread.Sleep(1);
                _console.Write(".");
                Console.Write(".");
            }
            _console.WriteLine(patrocinadores);
            return patrocinadores;
        }
        #endregion

        #region PRINT REQUISITOS
        public string PrintRequisitos(List<Requisito> requisitos, StreamWriter _console)
        {
            String printRequisitos = "     REQUISITOS";

            foreach (Requisito r in requisitos)
            {
                printRequisitos = printRequisitos + "\n         Id: " + r.id_requisito + " - Custo: " + r.custo + ((r.valor_interesse > 0) ? " - Valor de interesse: " + r.valor_interesse : "");
                if (r.dependente != null)
                    printRequisitos = printRequisitos + "\n                 Id: " + r.dependente.id_requisito + " - Custo: " + r.dependente.custo + ((r.dependente.valor_interesse > 0) ? " - Valor de interesse: " + r.dependente.valor_interesse : "");

            }

            _console.WriteLine(printRequisitos);
            return printRequisitos;
        }
        #endregion

        #region PRINT PATROCINADORES
        public void PrintPatrocinadores(List<Patrocinador> patrocinadores, StreamWriter _console)
        {
            _console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            foreach (Patrocinador p in patrocinadores)
            {
                _console.WriteLine("\nPATROCINADOR - Id: " + p.id + " - Peso: " + p.peso);
                Console.WriteLine("\nPATROCINADOR - Id: " + p.id + " - Peso: " + p.peso);
                //new Program().PrintRequisitos(p.list_interesse_requi);
                _console.WriteLine("     REQUISITOS");
                Console.WriteLine("     REQUISITOS");
                foreach (Requisito r in p.list_interesse_requi)
                {
                    _console.WriteLine("         Id: " + r.id_requisito + " - Custo: " + r.custo + " - Valor de interesse: " + r.valor_interesse);
                    Console.WriteLine("         Id: " + r.id_requisito + " - Custo: " + r.custo + " - Valor de interesse: " + r.valor_interesse);
                }
            }
            _console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
        }
        #endregion

        #region MAIN
        public static void Main(string[] args)
        {
            StreamWriter _console = new StreamWriter("./log.txt", true, Encoding.ASCII);

            #region VISUAL
            _console.WriteLine("Se deseja continuar pelo console digite: 1, senão digite para continuar pelo visual(incompleto): 0 ");
            Console.WriteLine("Se deseja continuar pelo console digite: 1, senão digite para continuar pelo visual (incompleto): 0 ");

            if (Convert.ToInt32(Console.ReadLine()) == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            #endregion
            else
            {
                #region VALORES - CUSTO - INTERESSE - PESO
                _console.WriteLine("Se deseja usar os dados default digite: 1 se deseja inserir os propios dados digite: 0");
                Console.WriteLine("Se deseja usar os dados default digite: 1 se deseja inserir os propios dados digite: 0");

                int vl_max_interesse_req = 5;
                int vl_max_custo_req = 10;
                int vl_max_peso_patr = 5;

                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    _console.WriteLine("::::::::::::::::::::::::::::::::::\nInteresse dos patrocinadores 0-5 \nCusto dos requisítos 0-10 \nPeso do patrocinador 0-5 \n::::::::::::::::::::::::::::::::::");
                    Console.WriteLine("::::::::::::::::::::::::::::::::::\nInteresse dos patrocinadores 0-5 \nCusto dos requisítos 0-10 \nPeso do patrocinador 0-5 \n::::::::::::::::::::::::::::::::::");
                }
                else
                {
                    // VALORES MAX RANDOM
                    vl_max_interesse_req = new Program().GetVlMaxInteresseReq(_console);
                    vl_max_custo_req = new Program().GetVlMaxCustoReq(_console);
                    vl_max_peso_patr = new Program().GetVlMaxPesoPatro(_console);
                }
                #endregion

                //LISTAS DE REQUISITOS E PATROCINADORES
                List<Requisito> requisitos = new Program().CriarListadeRequisitos(vl_max_custo_req, new Program().GetTotalRequisitos(_console), _console);
                List<Patrocinador> patrocinadores = new Program().CriarListaPatrocinadores(requisitos, vl_max_peso_patr, vl_max_interesse_req, new Program().GetTotalPatrocinadores(requisitos.Count, _console), _console).OrderByDescending(x => x.peso).ToList();

                #region CUSTO DA RELEASE
                long custo_release = 0;

                _console.WriteLine("\nSe deseja usar o valor default do custo total da release digite: 1, senão digite: 0 ");
                Console.WriteLine("\nSe deseja usar o valor default do custo total da release digite: 1, senão digite: 0 ");
                if (Convert.ToInt64(Console.ReadLine()) == 1)
                {
                    custo_release = requisitos.Count * 2;
                }
                else
                {
                    while (custo_release == 0)
                    {
                        _console.WriteLine("\nDigite o custo total da release: ");
                        Console.WriteLine("\nDigite o custo total da release: ");

                        try { custo_release = Convert.ToInt64(Console.ReadLine()); }
                        catch (Exception) { custo_release = 0; }
                    }
                }
                #endregion

                _console.WriteLine("---------------------------------------------\nRECURSO DA RELEASE: " + custo_release);
                Console.WriteLine("---------------------------------------------\nRECURSO DA RELEASE: " + custo_release);

                #region PRINT REQUISITOS
                //  Console.WriteLine(new Program().PrintRequisitos(requisitos));
                //    Console.WriteLine("\n\nPressione qualquer tecla para continuar.....");
                //    Console.ReadKey();
                #endregion

                #region PRINT PATROCINADORES
                //  new Program().PrintPatrocinadores(patrocinadores);
                _console.WriteLine("\n\nPressione qualquer tecla para GERAR a proxima release.....");
                Console.WriteLine("\n\nPressione qualquer tecla para GERAR a proxima release.....");
                Console.ReadKey();
                #endregion

                // Cria o StopWatch
                Stopwatch sw = new Stopwatch();
                // Começa a contar o tempo
                sw.Start();
                //List<Requisito> prox_release = 
                new Program().Backtracking(custo_release, requisitos, patrocinadores, _console);
                sw.Stop();

                TimeSpan tempo = sw.Elapsed;
                _console.WriteLine("\n:::::Tempo de execucao: " + tempo + ":::::");
                Console.WriteLine("\n:::::Tempo de execucao: " + tempo + ":::::");

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

                _console.WriteLine("\n\nPressione qualquer tecla para Finalizar.....");
                Console.WriteLine("\n\nPressione qualquer tecla para Finalizar.....");
                Console.ReadKey();
                #endregion

                _console.Close();
            }
        }
        #endregion

        #region Backtracking
        public string Backtracking(long custo_release, List<Requisito> requisitos, List<Patrocinador> patrocinadores, StreamWriter _console)
        {

            long custo_atual = 0;
            Requisito r = null;
            try
            {
                if (custo_release >= custo_atual && requisitos.Count >= 0 && patrocinadores.Count >= 0)
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
                                if (p.list_interesse_requi.Count > 0 && p2.list_interesse_requi.Count > 0)
                                {
                                    // Processa a solução, ou seja, retorna o requisito de maior prioridade
                                    r = new Program().ProcessaSolucao(p, p2);
                                    if (r == null)
                                        break;

                                    // Remove o requisito que já foi atribuido a release das listas do patrocinador
                                    p.list_interesse_requi.RemoveAll(x => x.id_requisito == r.id_requisito);
                                    p2.list_interesse_requi.RemoveAll(x => x.id_requisito == r.id_requisito);
                                }
                                else { break; }
                            }
                            if (r != null)
                                if (custo_release >= custo_atual + r.custo)
                                {
                                    // calcula o custo dos requisitos que já estão na release com o que esta sendo adicionado agora
                                    custo_atual = custo_atual + r.custo;

                                    // É "impresso" o requisito de retorno do backtraking, e realiza uma chamada recussiva para o 
                                    // próprio método passando os parametros sem o requisito que já está na release

                                    string out_release = Backtracking(custo_release - custo_atual, requisitos, patrocinadores, _console);
                                    _console.Write(out_release);
                                    Console.Write(out_release);
                                    _console.Write(r.id_requisito.ToString() + " - ");
                                    return r.id_requisito.ToString() + " - ";
                                }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
        #endregion

        #region ProcessaSolucao
        public Requisito ProcessaSolucao(Patrocinador p, Patrocinador p2)
        {
            try
            {
                // Se existir um requisito de um patrocinador com mesmo peso ou menor, mas com interesse maior, retorna esse requisito
                return (p.list_interesse_requi.Max(m => m.valor_interesse) >= p2.list_interesse_requi.Max(m => m.valor_interesse))
                   ? p.list_interesse_requi.FirstOrDefault() : p2.list_interesse_requi.FirstOrDefault();
            }
            catch (Exception ex) { return null; }

        }
        #endregion

        #region Sample - Fibonacci
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
        #endregion

        #region SaveConsoleInTxt
        public void SaveConsoleInTxt()
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine("This is a line of text");
            Console.WriteLine("Everything written to Console.Write() or");
            Console.WriteLine("Console.WriteLine() will be written to a file");
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");
        }
        #endregion
    }
}
