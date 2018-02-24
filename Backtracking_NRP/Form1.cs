using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backtracking_NRP
{
    public partial class Form1 : Form
    {
        Program _program = new Program();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter _console = new StreamWriter("./log.txt", true, Encoding.ASCII);

            List<Requisito> requisitos = _program.CriarListadeRequisitos(Convert.ToInt32(txtCustoRequisito.Text), _program.GetTotalRequisitos(_console), _console);
                 List<Patrocinador> patrocinadores = _program.CriarListaPatrocinadores(requisitos, Convert.ToInt32(txtPesoPatrocinador.Text), Convert.ToInt32(txtInteresseRequisito.Text), new Program().GetTotalPatrocinadores(requisitos.Count, _console), _console);



               lblPrintRequisitos.Text = _program.PrintRequisitos(requisitos, _console);
        }
    }
}
