using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace serializar_deserealizar_XML_JSON
{
    public class Triangulo
    {
        [XmlAttribute("Lado")]
        public decimal Lado { get; set; }

        [XmlAttribute("LadoDos")]
        public decimal LadoDos { get; set; }

        [XmlAttribute("LadoTres")]
        public decimal LadoTres { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Tipo")]
        public string Tipo { get; set; }
        public Triangulo(){}
        public Triangulo(decimal lado, decimal ladoDos, decimal ladoTres, int id, string tipo)
        {
            Lado = lado;
            LadoDos = ladoDos;
            LadoTres = ladoTres;
            Id = id;
            Tipo = tipo;
        }
        public override string ToString()//Método para poder mostrar el contenido de la lista
        {
            return "Lado 1: " + Lado + "  Lado 2: " + LadoDos + " Lado 3: " + LadoTres + " id: " + Id + "Tipo: " + Tipo;
        }
    }
}