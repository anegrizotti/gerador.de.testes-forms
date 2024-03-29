﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.WinApp.Compartilhado;

namespace GeradorDeTestes.WinApp.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl
    {

        public TabelaQuestaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGrid();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina.Nome", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado", HeaderText = "Enunciado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Resposta", HeaderText = "Alternativa Correta"}

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();
            foreach (Questao q in questoes)
            {
                grid.Rows.Add(q.Numero, q.Disciplina.Nome, q.Materia, q.Enunciado, q.Resposta);
            }
        }

        public int ObtemNumeroQuestaoSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
