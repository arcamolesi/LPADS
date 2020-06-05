using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLIOTECA
{
    public partial class frmLivros : Form
    {
        public frmLivros()
        {
            InitializeComponent();
        }

        private void frmLivros_Load(object sender, EventArgs e)
        {
            habilitaControles(false);
            habilitaBotoes(true);

            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
            dgvLivros.DataSource = "";
            dgvLivros.DataSource = bllLivro.Select();
            limparControles(); 
        }

        private void habilitaControles(bool status)
        {
            txtTitulo.Enabled = status;
            txtEditora.Enabled = status;
            txtAutor.Enabled = status;
            txtValor.Enabled = status;
            txtSituacao.Enabled = status; 
        }

        private void habilitaBotoes(bool status) {
            btnInserir.Enabled = status;
            btnEditar.Enabled = status; 
            btnRemover.Enabled = status;
            btnCancelar.Enabled = !status;
            btnGravar.Enabled = !status; 
        }

        private void limparControles()
        {
            lblID.Text = "-1";
            txtTitulo.Text = "";
            txtEditora.Text = string.Empty;
            txtAutor.Text = null;
            txtValor.Text = "";
            txtSituacao.Text = ""; 

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose(); // libera o formulário da memória, libera memória da maquina
            //this.Close(); // fecha o formulário, permanecendo o objeto/estrutura na memória
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            limparControles(); 
            habilitaControles(true);
            habilitaBotoes(false);
            txtTitulo.Focus(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "-1")
            {
                habilitaControles(true);
                habilitaBotoes(false);
                txtTitulo.Focus(); 
            }
            else MessageBox.Show("Não há dados para atualizar", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparControles(); 
            habilitaControles(false);
            habilitaBotoes(true);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
           
            string msg = "";
            if (lblID.Text == "-1")
                msg = "Deseja Inserir um Novo Livro?";
            else msg = "Deseja Alterar o Livro atual?";
            DialogResult resposta = MessageBox.Show(msg, "Gravar", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resposta == DialogResult.Yes)
            {
                CAMADAS.MODEL.Livros livro = new CAMADAS.MODEL.Livros();
                livro.id = Convert.ToInt32(lblID.Text);
                livro.titulo = txtTitulo.Text.Trim();
                livro.editora = txtEditora.Text.Trim();
                livro.autor = txtAutor.Text;
                livro.valor = Convert.ToSingle(txtValor.Text);
                livro.situacao = Convert.ToInt32(txtSituacao.Text);
                if (lblID.Text == "-1")
                    bllLivro.Insert(livro);
                else bllLivro.Update(livro);
              //  MessageBox.Show("Dados Gravados", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          //  else MessageBox.Show("Dados Não Gravados", "Gravar", MessageBoxButtons.OK,MessageBoxIcon.Warning);

            dgvLivros.DataSource = "";
            dgvLivros.DataSource = bllLivro.Select(); 
           
            limparControles(); 
            habilitaControles(false);
            habilitaBotoes(true);
        }

        private void dgvLivros_DoubleClick(object sender, EventArgs e)
        {
            lblID.Text = dgvLivros.SelectedRows[0].Cells["id"].Value.ToString();
            txtTitulo.Text = dgvLivros.SelectedRows[0].Cells["titulo"].Value.ToString(); 
            txtEditora.Text = dgvLivros.SelectedRows[0].Cells["editora"].Value.ToString();
            txtAutor.Text = dgvLivros.SelectedRows[0].Cells["autor"].Value.ToString();
            txtValor.Text = dgvLivros.SelectedRows[0].Cells["valor"].Value.ToString();
            txtSituacao.Text = dgvLivros.SelectedRows[0].Cells["situacao"].Value.ToString();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros(); 

            if (lblID.Text != "-1")
            {
                string msg = "Deseja Remover o atual livro?";
                DialogResult resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                {
                    int idLivro = Convert.ToInt32(lblID.Text);
                    bllLivro.Delete(idLivro);
                }
            }
            else MessageBox.Show("Não há dados para Remover", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            dgvLivros.DataSource = "";
            dgvLivros.DataSource = bllLivro.Select();
            limparControles(); 
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            gpbPesquisa.Visible = !gpbPesquisa.Visible; 
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltrar.Text = "Informe o ID?";
            txtFiltro.Text = null; 
            lblFiltrar.Visible = true;
            txtFiltro.Visible = true;
            txtFiltro.Focus(); 
        }

        private void rdbTitulo_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltrar.Text = "Informe o Título?";
            txtFiltro.Text = string.Empty; 
            lblFiltrar.Visible = true;
            txtFiltro.Visible = true;
            txtFiltro.Focus(); 
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltrar.Visible = false;
            txtFiltro.Visible = false;

            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
            List<CAMADAS.MODEL.Livros> lstLivros = new List<CAMADAS.MODEL.Livros>();
            lstLivros = bllLivro.Select();
            dgvLivros.DataSource = "";
            dgvLivros.DataSource = lstLivros;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
            List<CAMADAS.MODEL.Livros> lstLivros = new List<CAMADAS.MODEL.Livros>();
            if (rdbTodos.Checked)
                lstLivros = bllLivro.Select();
            else if (rdbTitulo.Checked)
                    lstLivros = bllLivro.SelectByTitulo(txtFiltro.Text);
                 else { int id = Convert.ToInt32(txtFiltro.Text);
                        lstLivros = bllLivro.SelectByID(id);
                      }

            dgvLivros.DataSource = "";
            dgvLivros.DataSource = lstLivros; 
        }

        private void gpbPesquisa_Enter(object sender, EventArgs e)
        {

        }
    }
}
