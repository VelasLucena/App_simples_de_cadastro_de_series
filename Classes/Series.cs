using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01
{
    public class Series : EntidadeBase
    {
        //Atributos
        private Categorias Genero { get; set; }

        private string descricao { get; set; }

        private string Titulo { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        //Valores

        public Series (int id, string titulo, string descricao, Categorias categorias, int ano)
        {
            this.Id = id;
            this.Ano = ano;
            this.Titulo = titulo;
            this.descricao = descricao;
            this.Genero = categorias;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += "Genero:" + this.Genero + Environment.NewLine;
            retorno += "Titulo:" + this.Titulo + Environment.NewLine;
            retorno += "Descrição:" + this.descricao + Environment.NewLine;
            retorno += "Ano de início:" + this.Ano + Environment.NewLine;
            retorno += "Excluído:" + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }
    }
}
