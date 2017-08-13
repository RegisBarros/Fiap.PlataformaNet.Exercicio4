using System;
using System.Collections.Generic;

namespace Fiap.PlataformaNet.Exercicio4.Classes.Entidades
{
    public class Evento
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public string Responsavel { get; set; }

        public IEnumerable<Convidado> Convidados { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Descricao: {Descricao} - Data: {Data:dd/MM/yyyy}";
        }

        public static bool operator ==(Evento a, string b)
        {
            if (string.IsNullOrEmpty(b))
                return true;

            var criterio = b.ToLower();

            if (a.Id.ToString() == criterio)
                return true;

            if (a.Data.ToString().Contains(criterio))
                return true;

            if (a.Descricao.ToLower().Contains(criterio))
                return true;

            if (a.Responsavel.ToLower().Contains(criterio))
                return true;

            return false;
        }

        public static bool operator !=(Evento a, string b)
        {
            return !(a == b);
        }
    }
}
