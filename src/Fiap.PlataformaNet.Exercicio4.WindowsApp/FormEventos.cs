using Fiap.PlataformaNet.Exercicio4.Classes;
using Fiap.PlataformaNet.Exercicio4.Classes.Dados;
using Fiap.PlataformaNet.Exercicio4.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fiap.PlataformaNet.Exercicio4.WindowsApp
{
    public partial class FormEventos : Form
    {
        private int eventoId = 0;

        public FormEventos()
        {
            InitializeComponent();
        }

        private void FormEventos_Load(object sender, EventArgs e)
        {
            var dao = new DaoEventos();
            var eventos = dao.Listar();

            AtualizarGridEventos(eventos);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarEventos();
        }

        private void txtPesquisar_Enter(object sender, EventArgs e)
        {
            PesquisarEventos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            PesquisarEventos();
        }

        private void incluirEventoButton_Click(object sender, EventArgs e)
        {
            try
            {
                var data = DateTime.Parse(dataMaskedTextBox.Text);
                var descricao = descricaoTextBox.Text;
                var responsavel = responsavelTextBox.Text;

                var evento = new Evento()
                {
                    Id = this.eventoId,
                    Data = data,
                    Descricao = descricao,
                    Responsavel = responsavel
                };

                var dao = new DaoEventos();

                if (evento.Id == 0)
                {
                    dao.Incluir(evento);
                }
                else
                {
                    dao.Atualizar(evento);
                }

                var eventos = dao.Listar();

                AtualizarGridEventos(eventos);

                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                eventoId = (int)dataGridEventos.Rows[e.RowIndex].Cells["Id"].Value;
                dataMaskedTextBox.Text = ((DateTime)dataGridEventos.Rows[e.RowIndex].Cells["Data"].Value).ToShortDateString();
                descricaoTextBox.Text = (string)dataGridEventos.Rows[e.RowIndex].Cells["Descricao"].Value;
                responsavelTextBox.Text = (string)dataGridEventos.Rows[e.RowIndex].Cells["Responsavel"].Value;
            }
        }

        private void LimparFormulario()
        {
            dataMaskedTextBox.Clear();
            descricaoTextBox.Clear();
            responsavelTextBox.Clear();
            txtPesquisar.Clear();
            this.eventoId = 0;
        }

        private void PesquisarEventos()
        {
            var pesquisa = txtPesquisar.Text;

            var dao = new DaoEventos();
            var eventos = dao.Buscar(a => a == pesquisa);

            AtualizarGridEventos(eventos);
        }

        private void AtualizarGridEventos(IEnumerable<Evento> eventos)
        {
            dataGridEventos.AutoGenerateColumns = false;
            dataGridEventos.Columns["Id"].DataPropertyName = "Id";
            dataGridEventos.Columns["Data"].DataPropertyName = "Data";
            dataGridEventos.Columns["Descricao"].DataPropertyName = "Descricao";
            dataGridEventos.Columns["Responsavel"].DataPropertyName = "Responsavel";

            dataGridEventos.DataSource = eventos;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
    }
}
