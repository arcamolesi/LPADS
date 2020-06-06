using BIBLIOTECA.RELATORIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLIOTECA
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(); 

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmCli = new frmClientes();
            frmCli.MdiParent = this; 
            frmCli.Show(); 
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLivros frmLiv = new frmLivros();
            frmLiv.MdiParent = this;
            frmLiv.Show(); 
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frmSb = new frmSobre();
            frmSb.ShowDialog(); 

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void empréstimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmprestimo frmEmp = new frmEmprestimo();
            frmEmp.MdiParent = this;
            frmEmp.Show(); 
        }

        private void livrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //chamada do relatório de livros. 
            RELATORIOS.RelGerais.relLivro(); 
        }

        private void estatisticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelEmp frmRemp = new frmRelEmp();
            frmRemp.MdiParent = this;
            frmRemp.Show(); 
        }
    }
}
