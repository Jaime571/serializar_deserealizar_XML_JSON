using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using Newtonsoft.Json;

namespace serializar_deserealizar_XML_JSON
{
    class Program
    {
        static void Main(string[] args)
        {   
            string rutaJson = Combine(CurrentDirectory, "circulo.json");//Ruta para archivo Json del circulo
            string rutaJsonRectangulo = Combine(CurrentDirectory, "rectangulo.json");//Ruta para archivo Json del rectangulo
            string rutaJsonTriangulo = Combine(CurrentDirectory, "triangulo.json");//Ruta para archivo Json del circulo
            string opcPrimaria;
            do{

                Write("¿Que desea hacer?\n1: Circulo\n2: Rectangulo\n3: Triangulo\n4: Areas\nPresione cualquier tecla para salir...\n-> ");
                string opcion = ReadLine();
                switch(opcion)
                {
                    #region Circulo
                    case "1": //Circulo
                        int idCirculo = 0;
                        string decisionA;
                        var circulo = new List<Circulo>();
                        do{
                            Write("Radio: ");
                            decimal.TryParse(ReadLine(), out decimal radio);
                            idCirculo++;
                            circulo.Add(new Circulo(radio, idCirculo));
                            Write("¿Desea ingresar otra figura? [s/n]?\n-> ");
                            decisionA = ReadLine();
                        }while(decisionA == "s");

                        Json(circulo, rutaJson);//Funcion para serializar la lista
                        
                    break;  
                    #endregion

                    #region Rectangulo
                    case "2": //Rectangulo
                        //Se crea una lista de objetos en la que almacena los datos
                        int idRectangulo = 0;
                        string decisionB;
                        var rectangulo = new List<Rectangulo>();
                        do
                        {
                        Write("Base: ");
                        decimal.TryParse(ReadLine(), out decimal plataforma);
                        Write("Altura: ");
                        decimal.TryParse(ReadLine(), out decimal altura);
                        idRectangulo++;
                        rectangulo.Add(new Rectangulo(plataforma, altura, idRectangulo));//Agrega a la lista un nuevo objeto

                        Write("¿Desea ingresar otra figura? [s/n]\n-> ");
                        decisionB = ReadLine();
                        }while(decisionB == "s");

                        JsonRectangulo(rectangulo, rutaJsonRectangulo);
                        /* foreach (Rectangulo rectangulos in rectangulo)//Muestra el contenido de la lista
                        {
                            WriteLine(rectangulos);
                        } */
                    break;
                    #endregion

                    #region Triangulo
                    case "3": 
                        int idTriangulo = 0;
                        string decisionC;
                        var triangulo = new List<Triangulo>();
                        do{
                            Write("Lado A: ");
                            decimal lado = decimal.Parse(ReadLine());
                            Write("Lado B: ");
                            decimal ladoDos = decimal.Parse(ReadLine());
                            Write("Lado C: ");
                            decimal ladoTres = decimal.Parse(ReadLine());
                            idTriangulo++;
                            string tipo = TipoTriangulo(lado, ladoDos, ladoTres);//Define el tipo de triangulo
                            triangulo.Add(new Triangulo(lado, ladoDos, ladoTres, idTriangulo, tipo));//Agrega a la lista un nuevo objeto
                        Write("¿Desea ingresar otra figura? [s/n]");
                        decisionC = ReadLine();
                        }while(decisionC == "s");

                        JsonTriangulo(triangulo, rutaJsonTriangulo);
                        /* foreach (Triangulo triangulos in triangulo)//Muestra el contenido de la lista
                        {
                            WriteLine(triangulos);
                        } */
                    break;
                    #endregion

                    case "4":
                        Write("Obtener area de:\nTodas las figuras -> a\nPor indice        -> b\nPor tipo          -> c\n-> ");
                        string opc;
                        opc = ReadLine();
                        switch (opc)
                        {
                            case "a":
                                WriteLine("\nCirculos:\n");
                                Deserializar(rutaJson);
                                WriteLine("\nRectangulos:\n");
                                DeserializarRectangulo(rutaJsonRectangulo);
                                WriteLine("\nTriangulos:\n");
                                DeserializarTriangulo(rutaJsonTriangulo);
                            break;

                            case "b":
                                string opt;
                                do{
                                    Write("Indique el tipo de figura:\nCirculo    -> c\nRectangulo -> r\nTriangulo  -> t\n-> ");
                                    string selec;
                                    selec = ReadLine();
                                    switch (selec)
                                    {
                                        case "c"://Circulo
                                        string dec;
                                        var indiceA = new List<int>();//Lista para indicar el indice
                                        int index;
                                        do{
                                            Write("Indice de figura: ");
                                            index = int.Parse(ReadLine());
                                            indiceA.Add(index);
                                            Write("¿Desea agregar otro indice? [s/n]?\n-> ");
                                            dec = ReadLine();
                                        }while(dec == "s");

                                        using (var jsonDeserealizado = new StreamReader(rutaJson))
                                        {
                                            //Creamos una variable para obtener la informacion
                                            var informacionJson = jsonDeserealizado.ReadToEnd();
                                            //Casteamos al tipo de informacion a la que se debe de deserealizar
                                            //<List<Figuras>> Indica el tipo de dato que queremos deserealizar
                                            var deserealizacion = (List<Circulo>)JsonConvert.DeserializeObject<List<Circulo>>(informacionJson);
                                            foreach(var inde in indiceA)
                                            {
                                                foreach(var item in deserealizacion)
                                                {
                                                    if(item.Id == inde)
                                                    {
                                                        decimal area = item.Radio * item.Radio * (decimal)3.14;//Se obtiene el area del circulo
                                                        WriteLine($"El circulo {item.Id} tiene un radio de: {item.Radio}, y un area de: {area}");
                                                    }
                                                }
                                            }
                                        }
                                        break;

                                        case "r":
                                        string decB;
                                        var indiceB = new List<int>();//Lista para guardar el indice
                                        int indexB;
                                        do{
                                            Write("Indice de figura: ");
                                            indexB = int.Parse(ReadLine());
                                            indiceB.Add(indexB);
                                            Write("¿Desea agregar otro indice? [s/n]?\n-> ");
                                            decB = ReadLine();
                                        }while(decB == "s");

                                        using (var jsonDeserealizado = new StreamReader(rutaJsonRectangulo))
                                        {
                                            //Creamos una variable para obtener la informacion
                                            var informacionJson = jsonDeserealizado.ReadToEnd();
                                            //Casteamos al tipo de informacion a la que se debe de deserealizar
                                            //<List<Figuras>> Indica el tipo de dato que queremos deserealizar
                                            var deserealizacion = (List<Rectangulo>)JsonConvert.DeserializeObject<List<Rectangulo>>(informacionJson);
                                            foreach(var inde in indiceB)
                                            {
                                                foreach(var item in deserealizacion)
                                                {
                                                    if(item.Id == inde)
                                                    {
                                                        decimal area = item.Plataforma * item.Altura;//Se obtiene el area del circulo
                                                        WriteLine($"El rectangulo {item.Id} tiene una base de: {item.Plataforma}, y un area de: {area}");
                                                    }
                                                }
                                            }
                                        }
                                        break;

                                        case "t":
                                        string decC;
                                        var indiceC = new List<int>();//Lista para guardar el indice
                                        int indexC;
                                        do{
                                            Write("Indice de figura: ");
                                            indexC = int.Parse(ReadLine());
                                            indiceC.Add(indexC);
                                            Write("¿Desea agregar otro indice? [s/n]?\n-> ");
                                            decC = ReadLine();
                                        }while(decC == "s");

                                        using (var jsonDeserealizado = new StreamReader(rutaJsonTriangulo))
                                        {
                                            //Creamos una variable para obtener la informacion
                                            var informacionJson = jsonDeserealizado.ReadToEnd();
                                            //Casteamos al tipo de informacion a la que se debe de deserealizar
                                            //<List<Figuras>> Indica el tipo de dato que queremos deserealizar
                                            var deserealizacion = (List<Triangulo>)JsonConvert.DeserializeObject<List<Triangulo>>(informacionJson);
                                            foreach(var inde in indiceC)
                                            {
                                                foreach(var item in deserealizacion)
                                                {
                                                    if(item.Id == inde)
                                                    {
                                                        decimal area = (item.Lado * item.LadoDos)/2;
                                                        WriteLine($"El Triangulo {item.Id} tiene un lado de: {item.Lado}, un lado de: {item.LadoDos}, un lado de: {item.LadoTres} y un area de: {area}, y es tipo: {item.Tipo}");
                                                    }
                                                }
                                            }
                                        }
                                        break;

                                        default:
                                        WriteLine("Opción no valida");
                                        break;
                                    }
                                Write("¿Desea buscar otra figura por su indice? [s/n]\n-> ");
                                opt = ReadLine();
                                }while(opt == "s");
                            break;

                            case "c":
                                Write("Indique el tipo de figura:\nCirculo    -> c\nRectangulo -> r\nTriangulo     -> t\n-> ");
                                string seleccion;
                                seleccion = ReadLine();
                                switch (seleccion)
                                {
                                    case "c":
                                    Deserializar(rutaJson);
                                    break;

                                    case "r":
                                    DeserializarRectangulo(rutaJsonRectangulo);
                                    break;

                                    case "t":
                                    DeserializarTriangulo(rutaJsonTriangulo);
                                    break;
                                }
                            break;
                            default:
                            WriteLine("Opcion no valida");
                            break;
                        }
                    break;

                    default:
                            WriteLine("Adios...");
                            break;
                }
                Write("¿Desea escoger alguna otra opcion?[s/n]:\n-> ");
                opcPrimaria = ReadLine();
            }while(opcPrimaria == "s");
        }
        static void Json(List<Circulo> circulo, string rutaJson)//Serializa y deserializa
        {
            //Abrimos el archivo en el que escribiremos la serializacion
            using (StreamWriter datosJson = File.CreateText(rutaJson))
            {
                //Instancia del metodo
                var jsonSerializado = new Newtonsoft.Json.JsonSerializer();
                //En este metodo indicamos a donde estamos enviando y que estamos enviando
                jsonSerializado.Serialize(datosJson, circulo);
            }
        }
        static void Deserializar(string rutaJson)
        {
            using (var jsonDeserealizado = new StreamReader(rutaJson))
            {
                //Creamos una variable para obtener la informacion
                var informacionJson = jsonDeserealizado.ReadToEnd();
                //Casteamos al tipo de informacion a la que se debe de deserealizar
                //<List<Figuras>> Indica el tipo de dato que queremos deserealizar
                var deserealizacion = (List<Circulo>)JsonConvert.DeserializeObject<List<Circulo>>(informacionJson);
                foreach(var item in deserealizacion)
                {
                    decimal area = item.Radio * item.Radio * (decimal)3.14;//Se obtiene el area del circulo
                    WriteLine($"El circulo {item.Id} tiene un radio de: {item.Radio}, y un area de: {area}");
                }
            }
        } 
        static void JsonRectangulo (List<Rectangulo> rectangulo, string rutaJsonRectangulo)
        {
            //Abrimos el archivo en el que escribiremos la serializacion
            using (StreamWriter datosJson = File.CreateText(rutaJsonRectangulo))
            {
                //Instancia del metodo
                var jsonSerializado = new Newtonsoft.Json.JsonSerializer();
                //En este metodo indicamos a donde estamos enviando y que estamos enviando
                jsonSerializado.Serialize(datosJson, rectangulo);
            }
        }
        static void DeserializarRectangulo(string rutaJsonRectangulo)
        {
            using (var jsonDeserealizado = new StreamReader(rutaJsonRectangulo))
            {
                //Creamos una variable para obtener la informacion
                var informacionJson = jsonDeserealizado.ReadToEnd();
                //Casteamos al tipo de informacion a la que se debe de deserealizar
                //<List<Figuras>> Indica el tipo de dato que queremos deserealizar
                var deserealizacion = (List<Rectangulo>)JsonConvert.DeserializeObject<List<Rectangulo>>(informacionJson);
                foreach(var item in deserealizacion)
                {
                    decimal area = item.Plataforma * item.Altura;
                    WriteLine($"El rectangulo {item.Id} tiene un una base de: {item.Plataforma}, una altura de: {item.Altura} y un area de: {area}");
                }
            }
        }
        static void JsonTriangulo(List<Triangulo> triangulo, string rutaJsonTriangulo)
        {
            //Abrimos el archivo en el que escribiremos la serializacion
            using (StreamWriter datosJson = File.CreateText(rutaJsonTriangulo))
            {
                //Instancia del metodo
                var jsonSerializado = new Newtonsoft.Json.JsonSerializer();
                //En este metodo indicamos a donde estamos enviando y que estamos enviando
                jsonSerializado.Serialize(datosJson, triangulo);
            }
        }
        static void DeserializarTriangulo(string rutaJsonTriangulo)
        {
            using (var jsonDeserealizado = new StreamReader(rutaJsonTriangulo))
            {
                //Creamos una variable para obtener la informacion
                var informacionJson = jsonDeserealizado.ReadToEnd();
                //Casteamos al tipo de informacion a la que se debe de deserealizar
                //<List<Figuras>> Indica el tipo de dato que queremos deserealizar
                var deserealizacion = (List<Triangulo>)JsonConvert.DeserializeObject<List<Triangulo>>(informacionJson);
                foreach(var item in deserealizacion)
                {
                    WriteLine($"El Triangulo {item.Id} tiene un lado de: {item.Lado}, un lado de: {item.LadoDos}, un lado de: {item.LadoTres} y un area de: y es tipo: {item.Tipo}");
                }
            }
        }
        static string TipoTriangulo (decimal lado, decimal ladoDos, decimal ladoTres)
        {
            string tipo = "No disponible";

            if (lado == ladoDos && lado == ladoTres)
                return "Rectangulo";

            if(lado != ladoDos && lado != ladoTres)
                tipo = "Escaleno";
            
            if(lado == ladoDos && lado != ladoTres)
                tipo = "Isosceles";

            return tipo;
        }
    }
}