using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace serializar_deserealizar_XML_JSON
{
    public class Circulo
    {
        [XmlAttribute("Radio")]
        public decimal Radio { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        public Circulo(){}
        public Circulo(decimal radio, int id)
        {
            Radio = radio;
            Id = id;
        }
        public override string ToString()//Método para poder mostrar el contenido de la lista
        {
            return "Radio: " + Radio + " id: " + Id;
        }
    }
}