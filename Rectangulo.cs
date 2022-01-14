using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace serializar_deserealizar_XML_JSON
{
    public class Rectangulo
    {
        [XmlAttribute("Plataforma")]
        public decimal Plataforma { get; set; }

        [XmlAttribute("Altura")]
        public decimal Altura { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        public Rectangulo(){}
        public Rectangulo(decimal plataforma, decimal altura, int id)
        {
            Plataforma = plataforma;
            Altura = altura;
            Id = id;
        }
        public override string ToString()//Método para poder mostrar el contenido de la lista
        {
            return "Base: " + Plataforma + "   Altura: " + Altura + " id: " + Id;
        }
    }
}