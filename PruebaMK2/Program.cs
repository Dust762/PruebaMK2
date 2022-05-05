using PruebaMK2Modelo.DAL;
using PruebaMK2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2
{
    class Program
    {
        private static TicketDAL tiDAL = new TicketDAL();
        private static TecnicoDAL tDAL = new TecnicoDAL();
        private static CategoriaDAL catDAL = new CategoriaDAL();
        static void Main(string[] args)
        {
            while (menuPrincipal()) ;
        }

        public static bool menuPrincipal()
        {
            bool continuar = true;
            String op;
            do
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Menu principal");
                Console.WriteLine("1.Supervisor");
                Console.WriteLine("2.Tecnico");
                Console.WriteLine("3.Usuario");
                Console.WriteLine("4.Salir");
                Console.WriteLine("-------------");
                op = Console.ReadLine().Trim();
                Console.Clear();
            } while (noVacio(op));
            switch (op)
            {
                case "1":
                    while (menuSupervisor()) ;
                    break;
                case "2":
                    while (menuTecnico()) ;
                    break;
                case "3":
                    while (menuUsuario()) ;
                    break;
                case "4":
                    Console.WriteLine("Saliendo...");
                    continuar = false;
                    break;
                case "20352":
                    modoDev();
                    break;
                default:
                    Console.WriteLine("Valor no valido");
                    break;

            }



            return continuar;
        }
        public static bool menuSupervisor()
        {
            bool continuar = true;

            String op;
            do
            {
                Console.WriteLine("Menu supervisor");
                Console.WriteLine("-------------");
                Console.WriteLine("1. Crear Tecnico");
                Console.WriteLine("2. Asignar ticket");
                Console.WriteLine("3. Responder Mensaje");
                Console.WriteLine("4. Modificar Ticket");
                Console.WriteLine("5. Crear categorias");
                Console.WriteLine("6. Consultar Tecnicos");
                Console.WriteLine("7. Mostrar tickets");
                Console.WriteLine("8. Salir al menu principal");

                Console.WriteLine("-------------");
                op = Console.ReadLine().Trim();
                Console.Clear();
            } while (noVacio(op));
            switch (op)
            {
                case "1":
                    Console.WriteLine("Se creo un tecnico");
                    crearTecnico();
                    break;
                case "2":
                    Console.WriteLine("Se asigno un ticket");
                    asigarTicket();
                    break;
                case "3":
                    Console.WriteLine("Se respondio un ticket");
                    break;
                case "4":
                    Console.WriteLine("Se modifico un ticket");
                    break;
                case "5":
                    Console.WriteLine("Se creo una categoria");
                    crearCategoria();
                    break;
                case "6":
                    Console.WriteLine("Se consultaron los tecnicos");
                    consultarTecnicos();
                    break;
                case "7":
                    Console.WriteLine("Se muestran los tickets");
                    mostrarTickets();
                    break;
                case "8":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }


            Console.Clear();
            return continuar;
        }

        public static void crearTecnico()
        {
            String rut, nombre, apellido, sexo;
            Console.WriteLine("Creando un tecnico");
            do
            {
                Console.WriteLine("Ingrese el RUT");
                rut = Console.ReadLine().Trim();
            } while (noVacio(rut));

            do
            {
                Console.WriteLine("Ingrese el nombre");
                nombre = Console.ReadLine().Trim();
            } while (noVacio(nombre));

            do
            {
                Console.WriteLine("Ingrese el apellido");
                apellido = Console.ReadLine().Trim();
            } while (noVacio(apellido));
            bool sexoValido;



            do
            {

                Console.WriteLine("Ingrese sexo (F-M)");
                sexo = Console.ReadLine().Trim().ToUpper();

                sexoValido = sexo.Equals("F") || sexo.Equals("M") ? sexoValido = true : sexoValido = false;

            } while (!sexoValido);

            Tecnico tec = new Tecnico(rut, nombre, apellido, sexo);
            tDAL.agregarTecnico(tec);
            Console.WriteLine(tec.ToString());
            Console.ReadKey();

        }

        public static void asigarTicket()
        {
            List<Ticket> tickets = tiDAL.mostrarTicket();
            List<Tecnico> tecnicos = tDAL.mostrarTecnicos();
            int op;
            bool opValida;
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets");
            }
            else if (tecnicos.Count < 1)
            {
                Console.WriteLine("No hay tecnicos");
            }
            else
            {
                for (int i = 0; i < tickets.Count; i++)
                {
                    if (tickets[i].NombreTecnico.Equals(""))
                    {
                        Console.WriteLine("Tickets sin asignar");
                        Console.WriteLine(tickets[i].ToString());
                        for (int f = 0; f < tecnicos.Count; f++)
                        {
                            Console.WriteLine("Tecnicos disponibles");
                            Console.WriteLine(tecnicos[i].ToString());
                        }
                        do
                        {
                            Console.WriteLine("Ingrese el id del tecnico a asignar");
                            opValida = int.TryParse(Console.ReadLine().Trim(), out op);

                        } while (tecnicos.Count < op);


                    }
                    else
                    {

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Ticket ya asignados: ");
                        Console.WriteLine(tickets[i].ToString());
                    }

                }

            }


        }

        public static void crearCategoria()
        {
            Console.WriteLine("Creando categoria");
            String nombreCategoria;
            do
            {
                Console.WriteLine("Ingrese el nombre de la categoria:");
                nombreCategoria = Console.ReadLine().Trim();
            } while (noVacio(nombreCategoria));
            Categoria c = new Categoria(nombreCategoria);
            catDAL.agregarCategoria(c);
        }

        public static void consultarTecnicos()
        {
            List<Tecnico> tecnicos = tDAL.mostrarTecnicos();
            if (tecnicos.Count < 1)
            {
                Console.WriteLine("No hay tecnicos");
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < tecnicos.Count; i++)
                {

                    Console.WriteLine(tecnicos[i].ToString());
                    if (tecnicos[i].TicketsAsignados.Count < 1)
                    {
                        Console.WriteLine("No tiene tickets asignados");

                    }
                    else
                    {
                        for (int f = 0; f < tecnicos[i].mostrarTicketsAsignados().Count; f++)
                        {
                            Console.WriteLine(tecnicos[i].mostrarTicketsAsignados()[f].ToString());
                            Console.ReadKey();
                        }
                    }

                }
                Console.ReadKey();
            }
        }

        public static void mostrarTickets()
        {

            if (tiDAL.mostrarTicket().Count < 1)
            {
                Console.WriteLine("No hay tickets");
            }
            foreach (var Ticket in tiDAL.mostrarTicket())
            {
                Console.WriteLine(Ticket.ToString());
                Console.WriteLine(Ticket.Prioridad.Nombre);
                Console.WriteLine(Ticket.Estado.estadoNombre);
            }
            Console.ReadKey();

        }
        public static bool menuTecnico()
        {
            bool continuar = true;
            String op;
            do
            {
                Console.WriteLine("Menu tecnico");
                Console.WriteLine("-------------");
                Console.WriteLine("1.Consultar ticket");
                Console.WriteLine("2.Cambiar estado ticket");
                Console.WriteLine("3.Consultar comentarios");
                Console.WriteLine("4.Salir");

                Console.WriteLine("-------------");
                op = Console.ReadLine().Trim();
                Console.Clear();
            } while (noVacio(op));
            switch (op)
            {
                case "1":
                    Console.WriteLine("Se consulto un ticket");
                    break;
                case "2":
                    Console.WriteLine("Se cambio el estado del ticket");
                    break;
                case "3":
                    Console.WriteLine("Se consultaron los comentarios");
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
            Console.Clear();
            return continuar;
        }
        public static bool menuUsuario()
        {
            bool continuar = true;
            String op;
            do
            {
                Console.WriteLine("Menu Usuario");
                Console.WriteLine("-------------");
                Console.WriteLine("1.Crear ticket");
                Console.WriteLine("2.Consultar ticket");
                Console.WriteLine("3.Cerrar ticket");
                Console.WriteLine("4.Ver mensajes");
                Console.WriteLine("5.Enviar mensaje");
                Console.WriteLine("6.Salir");

                Console.WriteLine("-------------");
                op = Console.ReadLine().Trim();
                Console.Clear();
            } while (noVacio(op));
            switch (op)
            {
                case "1":
                    Console.WriteLine("Se creo un ticket");
                    crearTicket();
                    break;
                case "2":
                    Console.WriteLine("Se consulto un ticket");

                    break;
                case "3":
                    Console.WriteLine("Se cerro un ticket");
                    break;
                case "4":
                    Console.WriteLine("Se ven los mensajes");
                    break;
                case "5":
                    Console.WriteLine("Se envia un mensaje");
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

            Console.Clear();
            return continuar;
        }

        public static void crearTicket()
        {
            String descripcion;
            String nombreUsuario;
            String nombreTecnico = "";
            String categoria;
            String priori;
            List<Categoria> categorias = catDAL.mostrarCategorias();
            int codPrio;
            int codCate;
            int codEsta;
            bool codValido;
            bool prioValido;
            do
            {
                Console.WriteLine("Ingrese el nombre del usuario");
                nombreUsuario = Console.ReadLine().Trim();

            } while (noVacio(nombreUsuario));

            if (categorias.Count < 1)
            {
                Console.WriteLine("No hay categorias");
                Console.ReadKey();


            }
            else
            {
                for (int i = 0; i < categorias.Count; i++)
                {
                    Console.WriteLine(categorias[i].ToString());
                }

                do
                {
                    Console.WriteLine("Ingrese el id categoria");
                    categoria = Console.ReadLine().Trim();
                    codValido = int.TryParse(categoria, out codCate);
                } while (!codValido);
                for (int i = 0; i < categorias.Count; i++)
                {
                    if (categorias[i].CodCategoria == codCate)
                    {
                        categoria = categorias[i].NombreCategoria;
                        break;
                    }
                }

                do
                {
                    Console.WriteLine("Ingrese la descripcion del ticket:");
                    descripcion = Console.ReadLine().Trim();
                } while (noVacio(descripcion));


                do
                {
                    Console.WriteLine("Ingrese prioridad: ");
                    Console.WriteLine("1.Emergencia");
                    Console.WriteLine("2.Necesaria");
                    Console.WriteLine("3.Optativa");
                    priori = Console.ReadLine().Trim();
                    prioValido = int.TryParse(priori, out codPrio);
                    if (codPrio > 3)
                    {
                        prioValido = false;

                    }
                } while (!prioValido);

                Random rd = new Random();
                codEsta = rd.Next(5);


                Ticket t = new Ticket(nombreUsuario, nombreTecnico, descripcion, categoria);
                t.Estado = TicketDAL.Pendiente;
                switch (codEsta)
                {
                    case 1:
                        t.Estado = TicketDAL.EnProgreso;
                        break;
                    case 2:
                        t.Estado = TicketDAL.Pendiente;
                        break;
                    case 3:
                        t.Estado = TicketDAL.Bloqueado;
                        break;
                    case 4:
                        t.Estado = TicketDAL.Cerrado;
                        break;
                    default:
                        t.Estado = TicketDAL.Pendiente;
                        break;
                }
                switch (codPrio)
                {
                    case 1:
                        t.Prioridad = TicketDAL.Emergencia;
                        break;
                    case 2:
                        t.Prioridad = TicketDAL.Necesaria;
                        break;
                    case 3:
                        t.Prioridad = TicketDAL.Opcional;
                        break;
                    default:
                        Console.WriteLine("Prioridad no valida");
                        break;
                }

                tiDAL.agregarTicket(t);

            }





            //Ticket t = new Ticket("A","B",descripcion,"epico");
            //do
            //{
            //    Console.WriteLine("Ingrese una observacion");
            //    observacion = Console.ReadLine().Trim();
            //} while (noVacio(observacion));
            //t.agregarObservacion(observacion);

            //tiDAL.agregarTicket(t);
            //Console.WriteLine(t.ToString());
            //if (t.mostrarObservaciones().Count < 1)
            //{
            //    Console.WriteLine("Vacio");
            //    Console.ReadKey();
            //}
            //else
            //{
            //    for (int i = 0; i < t.mostrarObservaciones().Count(); i++)
            //    {
            //        Console.WriteLine(t.mostrarObservaciones()[i].ToString());

            //    }
            //    Console.ReadKey();
            //    agregarComentario();
            //}

        }

        public static void agregarComentario()
        {
            List<Ticket> tempo = tiDAL.mostrarTicket();
            Ticket temporal = null;
            for (int i = 0; i < tempo.Count; i++)
            {
                String com1 = "Comentario 1", com2 = "Comentario 2", com3 = "comentario 3";
                tempo[i].ListaDeObservaciones.Add(com1);
                tempo[i].ListaDeObservaciones.Add(com2);
                tempo[i].ListaDeObservaciones.Add(com3);
                temporal = tempo[i];

            }
            for (int i = 0; i < temporal.ListaDeObservaciones.Count(); i++)
            {

                Console.WriteLine("------------------");
                Console.WriteLine(temporal.mostrarObservaciones()[i].ToString());
            }

            for (int i = 0; i < tempo.Count; i++)
            {
                Console.WriteLine(tempo[i].ToString());
                for (int f = 0; f < tempo[i].ListaDeObservaciones.Count; f++)
                {

                    Console.WriteLine(tempo[i].mostrarObservaciones()[f].ToString());
                    Console.ReadKey();
                }
            }

            Console.ReadKey();
        }



        public static bool modoDev()
        {
            bool continuar = true;
            String op;
            Console.WriteLine("modo dev");
            Console.WriteLine("Para facilitar el testing");
            do
            {
                Console.WriteLine("Realizar preCarga de datos(Categoria, tickets y tecnicos) Si - No");
                op = Console.ReadLine().Trim().ToUpper();
            } while (!(op.Equals("SI") || op.Equals("NO")));
            if (op.Equals("SI"))
            {
                preCarga();
                Console.WriteLine("Se ha realizado la precarga");
                continuar = false;
            }
            Console.ReadKey();
            Console.Clear();

            return continuar;
        }



        public static bool noVacio(String s)
        {
            bool empty = false;
            if (s.Equals(""))
            {

                empty = true;
                return empty;

            }
            return empty;
        }
        // Prueba
        public static void preCarga()
        {
            for (int i = 0; i < 10; i++)
            {
                Categoria ejemploCat = new Categoria("EjemploCategoria" + i);
                
                catDAL.agregarCategoria(ejemploCat);
            }
            for (int i = 0; i < 10; i++)
            {

                Tecnico tecjemplo = new Tecnico("20" + i, "Ejemplo", "Tecnico", "F");
                tDAL.agregarTecnico(tecjemplo);

            }

            for (int i = 0; i < 10; i++)
            {
                Ticket ejemplo = new Ticket("Usuario" + i, "", "Ejemplo" + i, "Ejemplo");
                ejemplo.Estado = TicketDAL.Pendiente;
                ejemplo.Prioridad = TicketDAL.Emergencia;
                tiDAL.agregarTicket(ejemplo);
            }

        }

    }
}
