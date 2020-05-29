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
    public partial class frmEmprestimo : Form
    {
        public frmEmprestimo()
        {
            InitializeComponent();
        }

        private void frmEmprestimo_Load(object sender, EventArgs e)
        {
            CAMADAS.BLL.Emprestimo bllEmp = new CAMADAS.BLL.Emprestimo();
            dgvEmprestimo.DataSource = ""; 
            dgvEmprestimo.DataSource = bllEmp.Select();

            CAMADAS.DAL.Clientes dalCli = new CAMADAS.DAL.Clientes();
            cmbCliente.DisplayMember = "nome";
            cmbCliente.ValueMember = "id";
            cmbCliente.DataSource = dalCli.Select(); 
        }

        private void limparEmprestimo()
        {
            lblEmpID.Text = "-1";
            dtpData.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }

        private void limparItem()
        {
            lblItemID.Text = "-1";
            dtpEntrega.Value = Convert.ToDateTime("1/1//1900");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtClienteID.Text = cmbCliente.SelectedValue.ToString();
        }

        private void txtClienteID_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCliente.SelectedValue = Convert.ToInt32(txtClienteID.Text);
            }
            catch 
            {
                MessageBox.Show("Cliente Inválido");
                cmbCliente.Focus(); 
               
            }

             
        }

        private void txtClienteID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                txtClienteID.Text = cmbCliente.SelectedValue.ToString();    
            }
            catch
            {
                MessageBox.Show("Cliente Inválido");
                cmbCliente.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparEmprestimo();
            cmbCliente.Focus(); 
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            CAMADAS.MODEL.Emprestimo emprestimo = new CAMADAS.MODEL.Emprestimo();
            emprestimo.id = Convert.ToInt32(lblEmpID.Text);
            emprestimo.clienteID = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
            emprestimo.data = dtpData.Value;

            CAMADAS.BLL.Emprestimo bllEmp = new CAMADAS.BLL.Emprestimo();

            if (lblEmpID.Text == "-1")
                bllEmp.Insert(emprestimo);
            else bllEmp.Update(emprestimo);

            List<CAMADAS.MODEL.Emprestimo> lstEmp = bllEmp.Select();
            dgvEmprestimo.DataSource = "";
            dgvEmprestimo.DataSource = lstEmp;

            
        }
    }
}
