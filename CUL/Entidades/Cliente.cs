﻿using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Cliente {
		public Cliente() { }
		public Cliente(string id) {
			this.id = id;
		}
		public Cliente(string id, string nombre, string apellido, string domicilio, string telefono) {
			setIdCliente(id);
			this.nombre = nombre;
			this.apellido = apellido;
			setDomicilioCliente(domicilio);
            setTelefonoCliente(telefono);
        }
		private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private string _nombre;

		public string nombre {
			get { return _nombre; }
			set { _nombre = value; }
		}
		private string _apellido;

		public string apellido {
			get { return _apellido; }
			set { _apellido = value; }
		}
		private string _domicilio;

		public string domicilio {
			get { return _domicilio; }
			set { _domicilio = value; }
		}
		private string _telefono;

		public string telefono {
			get { return _telefono; }
			set { _telefono = value; }
		}
		public void setIdCliente(string idAEncriptar) {
			Encriptador encriptador = new Encriptador();
			id = encriptador.encriptarReversible(idAEncriptar);
		}
		public void setDomicilioCliente(string domicilioAEncriptar) {
			Encriptador encriptador = new Encriptador();
			domicilio = encriptador.encriptarReversible(domicilioAEncriptar);
		}
		public void setTelefonoCliente(string telefonoAEncriptar) {
			Encriptador encriptador = new Encriptador();
			telefono = encriptador.encriptarReversible(telefonoAEncriptar);
		}
	}
}
