using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileTickets.Web.Models
{
    public class Sessao
    {
        public virtual int Id { get; set; }
        public virtual Espetaculo Espetaculo { get; set; }
        public virtual int TotalDeIngressos { get; set; }
        public virtual int IngressosReservados { get; set; }
        public virtual DateTime Inicio { get; set; }

        public virtual bool PodeReservar(int NumeroDesejadosDeIngressos)
        {
            bool ingressosEsgotados = IngressosRestantes(NumeroDesejadosDeIngressos) <= 0;

            return !ingressosEsgotados;
        }

        private int IngressosRestantes(int NumeroDesejadosDeIngressos)
        {
            return IngressosDisponiveis - NumeroDesejadosDeIngressos;
        }


        public virtual int IngressosDisponiveis
        {
            get
            {
                return TotalDeIngressos - IngressosReservados;
            }
        }

        public virtual bool PertoDoLimiteDeSeguranca_NaoUtilizada
        {
            get
            {
                int limite = 3;
                return IngressosDisponiveis > limite;
            }
        }

        public virtual void Reserva(int quantidade)
        {
            // soma quantidade na variavel ingressos reservados
            this.IngressosReservados += quantidade;
        }
    }
}
