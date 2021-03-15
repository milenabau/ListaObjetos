using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AppListObjetos
{
    class Program
    {
        static Validaciones Vericar = new Validaciones();
        static List<Alumno> ListaAlumnos = new List<Alumno>();

      

        static void Main(string[] args)
        {
            int OpcMen;
            int numero;
            int opc1;

            string temporal;

            do
            {
                do
                {
                    bool EntradaValida = false;
                    Console.Clear();
                    gui.Marco(1, 110, 1, 25);
                    gui.BorrarLinea(40, 22, 80);
                    Console.SetCursorPosition(40, 5); Console.Write("*** Aplicación 1 *** ");
                    gui.Linea(20, 80, 6);
                    Console.SetCursorPosition(40, 7); Console.Write("1. Quienes somos");
                    Console.SetCursorPosition(40, 8); Console.Write("2. Menu aplicaciones");
                    Console.SetCursorPosition(40, 9); Console.Write("0. Salir");
                    do
                    {
                        gui.BorrarLinea(40, 15, 80);
                        Console.SetCursorPosition(40, 15); Console.Write("Escoja Opcion: ");
                        temporal = Console.ReadLine();
                        if (!Vericar.Vacio(temporal))
                            if (Vericar.TipoNumero(temporal))
                                EntradaValida = true;
                    } while (!EntradaValida);

                    numero = Convert.ToInt32(temporal);
                    opc1 = numero;
                    Console.SetCursorPosition(49, 19);
                    Console.WriteLine(numero);

                    if (numero == 1)
                    {
                        Console.Clear();
                        Console.Clear();
                        gui.Marco(1, 110, 1, 25);
                        Console.SetCursorPosition(45, 2); Console.Write("Participantes");
                        int altura = 6;
                        gui.Linea(3, 107, 3);
                        Console.SetCursorPosition(40, 8); 
                        Console.Write("Andres Steven Otalora Bernal");
                        Console.SetCursorPosition(39, 9);
                        Console.Write("Johanna Milena Garcia Bautista");
                        Console.SetCursorPosition(37, 20);
                        Console.WriteLine("Pulse cualquier tecla para continuar: ");
                        Console.SetCursorPosition(75, 20);
                        Console.ReadLine();

                    }
                } while  ((numero!=2) && (numero!=0));

                


                //------------------- 
                if (numero == 2)
                {


                    do
                    {
                        bool EntradaValida = false;
                        Console.Clear();
                        gui.Marco(1, 110, 1, 25);
                        gui.BorrarLinea(40, 22, 80);
                        Console.SetCursorPosition(40, 5); Console.Write("*** Menu Principal *** ");
                        gui.Linea(40, 80, 6);
                        Console.SetCursorPosition(40, 7); Console.Write("1. Insertar Alumno");
                        Console.SetCursorPosition(40, 8); Console.Write("2. Listar Alumnos");
                        Console.SetCursorPosition(40, 9); Console.Write("3. Buscar Alumnos");
                        Console.SetCursorPosition(40, 10); Console.Write("4. Menú principal");


                        do
                        {
                            gui.BorrarLinea(40, 15, 80);
                            Console.SetCursorPosition(40, 15); Console.Write("Escoja Opcion: ");
                            temporal = Console.ReadLine();
                            if (!Vericar.Vacio(temporal))
                                if (Vericar.TipoNumero(temporal))
                                    EntradaValida = true;
                        } while (!EntradaValida);


                        OpcMen = Convert.ToInt32(temporal);

                        switch (OpcMen)
                        {
                            case 1:
                                InsertarNombre();
                                break;
                            case 2:
                                ListarNombres();
                                break;
                            case 3:
                                BuscarNombre();
                                break;
                            case 8:
                                LeerArchivoXml();
                                break;
                            case 9:
                                EscrirArchivoXml();
                                break;
                            case 4:
                                gui.BorrarLinea(40, 22, 80);
                                break;
                            default:
                                {
                                    gui.BorrarLinea(40, 22, 80);
                                    Console.SetCursorPosition(40, 22); Console.Write(" Opcion Invalida");
                                }
                                break;

                        }
                        gui.BorrarLinea(40, 23, 80);
                        //Console.SetCursorPosition(40, 23); Console.Write("presione cualquier tecla para continuar");
                        //Console.ReadKey();
                    } while (OpcMen !=4);
                }
            } while (numero>0);
            Console.SetCursorPosition(40, 22); Console.Write(" ... Gracias por usar el programa");

        }
        static void InsertarNombre()
        {
            bool EntradaValidaNombre = false;
            bool EntradaValidaCodigo = false;
            bool EntradaValidaSalario = false;
            bool EntradaValidaCaja = false;

            string codigo;
            string nombre;
            string salario;
            string caja;

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Insertardo Alumno");
            gui.Linea(40, 6, 30);

           
            do 
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo de la ficha del Alumno: ");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (!Existe(Convert.ToInt32(codigo))) {  
                do 
            {
                    gui.BorrarLinea(33, 9, 64);
                    Console.SetCursorPosition(10, 9); Console.Write("Digite solo Nombres Alumno:");
                nombre = Console.ReadLine();
                if (!Vericar.Vacio(nombre))
                    if (Vericar.TipoTexto(nombre))
                        EntradaValidaNombre = true;
            } while (!EntradaValidaNombre);

            do 
            {
                    gui.BorrarLinea(37, 10, 64);
                    Console.SetCursorPosition(10, 10); Console.Write("Digite apellidos: ");
                salario = Console.ReadLine();
                if (!Vericar.Vacio(salario))
                    if (Vericar.TipoTexto(salario))
                        EntradaValidaSalario = true;
            } while (!EntradaValidaSalario);

            do 
            {
                    gui.BorrarLinea(34, 11, 64);
                    Console.SetCursorPosition(10, 11); Console.Write("Alumno Tiene Caja Compensacion S/N: ");
                caja = Console.ReadLine();
                if (!Vericar.Vacio(caja))
                    if (Vericar.sino(caja))
                        EntradaValidaCaja = true;
            } while (!EntradaValidaCaja);
                //..........................................





            Alumno myAlumno = new Alumno(); 
            myAlumno.Codigo = Convert.ToInt32(codigo);
            myAlumno.Nombre = nombre;
            myAlumno.Salario =salario;
            if (caja.ToLower() == "s")
                myAlumno.Caja = "Si";
            else
                myAlumno.Caja = "No";

           
                ListaAlumnos.Add(myAlumno);
            }  
            else
                Console.WriteLine("El usuario con el codigo " + codigo + " Ya Existe en el sistema");

        }

        static void ListarNombres()
        {
            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 2); Console.Write(" Cantidad de Alumnos: " + ListaAlumnos.Count);
            int altura = 6;
            gui.Linea(3, 107, 3);

            Console.SetCursorPosition(20, 5); Console.Write("CODIGO");
            Console.SetCursorPosition(40, 5); Console.Write("NOMBRES");
            Console.SetCursorPosition(60, 5); Console.Write("APELLIDOS");
            Console.SetCursorPosition(80, 5); Console.Write("EPS");
          

            foreach (Alumno ObjetoAlumno in ListaAlumnos)
            {


                Console.SetCursorPosition(20, altura); Console.Write(ObjetoAlumno.Codigo);
                Console.SetCursorPosition(40, altura); Console.Write(ObjetoAlumno.Nombre);
                Console.SetCursorPosition(60, altura); Console.Write(ObjetoAlumno.Salario);
                Console.SetCursorPosition(80, altura); Console.Write(ObjetoAlumno.Caja);
               

                altura++;
            }
            Console.SetCursorPosition(29, 19);
            Console.WriteLine("Pulse cualquier tecla para continuar");
            Console.SetCursorPosition(66, 19);
            Console.ReadLine();
        }

        static void BuscarNombre()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            gui.Marco(1, 110, 1, 25);
            Console.SetCursorPosition(40, 5); Console.WriteLine("Insertardo Alumno");
            gui.Linea(40, 6, 30);

            do // pedir el codigo
            {
                gui.BorrarLinea(34, 8, 64);
                Console.SetCursorPosition(10, 8); Console.Write("Digite Codigo Alumno");
                codigo = Console.ReadLine();
                if (!Vericar.Vacio(codigo))
                    if (Vericar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Alumno myAlumno = ObtenerDatos(Convert.ToInt32(codigo));

                int altura = 11;
                gui.Linea(3, 107, 9);
                gui.Linea(3, 107, 12);

                Console.SetCursorPosition(2, 10); Console.Write("CODIGO");
                Console.SetCursorPosition(10, 10); Console.Write("NOMBRE");
                Console.SetCursorPosition(30, 10); Console.Write("APELLIDOS");
                Console.SetCursorPosition(42, 10); Console.Write("EPS");
                
                Console.SetCursorPosition(2, altura); Console.Write(myAlumno.Codigo);
                Console.SetCursorPosition(10, altura); Console.Write(myAlumno.Nombre);
                Console.SetCursorPosition(30, altura); Console.Write(myAlumno.Salario);
                Console.SetCursorPosition(40, altura); Console.Write(myAlumno.Caja);
                


            }
            else { 
                gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" El usuario del codigo " + codigo + " No existe");
            }





        }

        static bool Existe(int cod)
        {
            bool aux = false;

            foreach (Alumno myAlumno in ListaAlumnos)
            {
                if (myAlumno.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        static Alumno ObtenerDatos(int cod)
        {
            foreach (Alumno myAlumno in ListaAlumnos)
            {
                if (myAlumno.Codigo == cod)
                    return myAlumno;
            }
            return null;

        }

        static void EscrirArchivoXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<Alumno>));
            TextWriter escribirXml = new StreamWriter("D:/datosapp/ArchivoAlumnos.xml");
            codificador.Serialize(escribirXml, ListaAlumnos);
            escribirXml.Close();

            gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" Archivo guardado con exito .... ");
        }

        static void LeerArchivoXml()
        {
            if (File.Exists("D:/datosapp/ArchivoAlumnos.xml")) {
            ListaAlumnos.Clear();
            XmlSerializer codificador = new XmlSerializer(typeof(List<Alumno>));
            FileStream leerXml = File.OpenRead("D:/datosapp/ArchivoAlumnos.xml");
            ListaAlumnos = (List<Alumno>)codificador.Deserialize(leerXml);
            leerXml.Close();
        }


            gui.BorrarLinea(40, 22, 80);
            Console.SetCursorPosition(40, 22); Console.Write(" Archivo cargado con exito .... ");
        }



    }
}
