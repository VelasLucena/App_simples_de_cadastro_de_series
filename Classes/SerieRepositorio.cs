using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> ListaSerie = new List<Series>();

        public void Atualiza(int id, Series entidade)
        {
            ListaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Exclui();
        }

        public void Insere(Series entidade)
        {
            ListaSerie.Add(entidade);
        }

        public List<Series> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return this.ListaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}
