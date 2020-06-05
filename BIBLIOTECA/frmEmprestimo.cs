using BIBLIOTECA.RELATORIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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

            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
            cmbLivro.DisplayMember = "titulo";
            cmbLivro.ValueMember = "id";
            cmbLivro.DataSource = bllLivro.Select(); 
        }

       

        private void limparEmprestimo()
        {
            lblEmpID.Text = "-1";
            dtpData.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }

        private void limparItem()
        {
            lblItemID.Text = "-1";
            dtpEntrega.Value = Convert.ToDateTime("1/1/1900");
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvEmprestimo_DoubleClick(object sender, EventArgs e)
        {
            lblEmpID.Text = dgvEmprestimo.SelectedRows[0].Cells["id"].Value.ToString();
            txtClienteID.Text = dgvEmprestimo.SelectedRows[0].Cells["clienteID"].Value.ToString();
            cmbCliente.SelectedValue = dgvEmprestimo.SelectedRows[0].Cells["clienteID"].Value;
            dtpData.Value = Convert.ToDateTime(dgvEmprestimo.SelectedRows[0].Cells["data"].Value.ToString());

            CAMADAS.BLL.Itens bllItens = new CAMADAS.BLL.Itens();
            dgvItens.DataSource = bllItens.SelectByEmp(Convert.ToInt32(lblEmpID.Text));
        }

        private void btnItemNovo_Click(object sender, EventArgs e)
        {
            if (lblEmpID.Text != "-1" && lblEmpID.Text != "")
            {
                limparItem();
                cmbLivro.Focus();
            }
            else MessageBox.Show("Não há empréstimo selecionado!!!"); 
        }

        private void cmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLivroID.Text = cmbLivro.SelectedValue.ToString(); 
        }

        private void verificaLivro() {
            int id = Convert.ToInt32(txtLivroID.Text);
            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
            List<CAMADAS.MODEL.Livros> lstLivros = bllLivro.SelectByID(id);
            if (lstLivros.Count()!=0)
            {
                if (lstLivros[0].situacao != 1)
                {
                    MessageBox.Show("Livro " + lstLivros[0].titulo.Trim() + " Emprestado");
                    cmbLivro.Focus(); 
                }
                cmbLivro.SelectedValue = id;
            }
            else
            {
                MessageBox.Show("Livro Invalido!!!");
                cmbLivro.Focus(); 
            }
        
        }

        private void txtLivroID_Leave(object sender, EventArgs e)
        {
            verificaLivro();
            
        }

        private void txtLivroID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLivro_Leave(object sender, EventArgs e)
        {
            verificaLivro(); 
        }

        private void btnItemGravar_Click(object sender, EventArgs e)
        {
            CAMADAS.MODEL.Itens item = new CAMADAS.MODEL.Itens();
            CAMADAS.BLL.Itens bllItens = new CAMADAS.BLL.Itens();
            item.id = Convert.ToInt32(lblItemID.Text);
            item.emprestimoID = Convert.ToInt32(lblEmpID.Text); 
            item.livroID = Convert.ToInt32(txtLivroID.Text);
            item.entrega = Convert.ToDateTime("1/1/1900");

            bllItens.Insert(item);
            dgvItens.DataSource = bllItens.SelectByEmp(Convert.ToInt32(lblEmpID.Text));  

        }

        private void dgvItens_DoubleClick(object sender, EventArgs e)
        {
            lblItemID.Text = dgvItens.SelectedRows[0].Cells["id"].Value.ToString();
            cmbLivro.SelectedValue = dgvItens.SelectedRows[0].Cells["livroID"].Value;
            txtLivroID.Text = dgvItens.SelectedRows[0].Cells["livroID"].Value.ToString();
            dtpEntrega.Value = Convert.ToDateTime(dgvItens.SelectedRows[0].Cells["entrega"].Value.ToString());
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (lblItemID.Text != "-1" && dtpEntrega.Value == Convert.ToDateTime("1/1/1900"))
            {
                CAMADAS.BLL.Itens bllItens = new CAMADAS.BLL.Itens();
                CAMADAS.MODEL.Itens item = new CAMADAS.MODEL.Itens();
                item.id = Convert.ToInt32(lblItemID.Text);
                item.emprestimoID = Convert.ToInt32(lblEmpID.Text);
                item.livroID = Convert.ToInt32(txtLivroID.Text);

                bllItens.Devolver(item);

                dgvItens.DataSource = bllItens.SelectByEmp(item.emprestimoID);
            }
            else MessageBox.Show("Livro invalido ou já foi devolvido!!!"); 
        }
    }
}
