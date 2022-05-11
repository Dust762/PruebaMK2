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
        private static MensajeDAL menDAL = new MensajeDAL();
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
                    responderMensajes();
                    break;
                case "4":
                    Console.WriteLine("Se modifico un ticket");
                    modificarTicket();
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
            Console.Clear();
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
            Console.Clear();
            List<Ticket> tickets = tiDAL.mostrarTicket();
            List<Tecnico> tecnicos = tDAL.mostrarTecnicos();
            int op;
            bool opValida;
            String resp;
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets");
                Console.ReadKey();
            }
            else if (tecnicos.Count < 1)
            {
                Console.WriteLine("No hay tecnicos");
                Console.ReadKey();
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
                            Console.WriteLine(tecnicos[f].ToString());
                        }
                        do
                        {
                            do
                            {
                                Console.WriteLine("Ingrese el id del tecnico a asignar");
                                resp = Console.ReadLine().Trim();
                            } while (noVacio(resp));

                            opValida = int.TryParse(resp, out op);

                        } while (tecnicos.Count < op);
                        for (int c = 0; c < tecnicos.Count; c++)
                        {
                            if (tecnicos[c].IdTecnico == op)
                            {
                                tickets[i].NombreTecnico = tecnicos[c].Nombre;
                                tecnicos[c].agregarTicket(tickets[i]);
                            }



                        }
                        Console.Clear();




                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Ticket ya asignados: ");
                        Console.WriteLine(tickets[i].ToString());
                    }

                }

            }


        }

        public static void responderMensajes()
        {
            List<Mensaje> msgs = menDAL.mostrarMensajes();
            String nombre, resp;
            int nro = 0;
            if (msgs.Count < 1)
            {
                Console.WriteLine("No hay mensajes");
            }
            else
            {
                do
                {
                    Console.WriteLine("Ingrese su nombre");
                    nombre = Console.ReadLine().Trim();
                } while (noVacio(nombre));

                for (int i = 0; i < msgs.Count; i++)
                {
                    if (msgs[i].Receptor.Equals(nombre))
                    {
                        ++nro;
                        Console.WriteLine("Mensaje nro: " + nro);
                        Console.WriteLine(msgs[i].ToString());
                        do
                        {
                            Console.WriteLine("Ingrese su respuesta: ");
                            resp = Console.ReadLine().Trim();
                        } while (noVacio(resp));
                        Mensaje msg = new Mensaje(nombre, msgs[i].Emisor, resp);
                        menDAL.crearMensaje(msg);
                        Console.WriteLine("---------------");

                    }
                }
                Console.ReadKey();
            }

        }
        public static void modificarTicket()
        {
            Console.Clear();
            List<Ticket> tickets = tiDAL.mostrarTicket();
            List<Tecnico> tecnicos = tDAL.mostrarTecnicos();
            List<Categoria> categorias = catDAL.mostrarCategorias();
            String op;
            int codti, opTec, codCat, codEsta;
            String nombre, desc, observacion;
            bool codVal, opTecValido, catVal, codEstaVal;
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets para modificar");
                Console.ReadKey();
            }
            else
            {
                do
                {

                    Console.WriteLine("Actualizar ticket");
                    Console.WriteLine("1. Cambiar nombre de usuario");
                    Console.WriteLine("2. Cambiar tecnico");
                    Console.WriteLine("3. Cambiar descripcion");
                    Console.WriteLine("4. Cambiar categoria");
                    Console.WriteLine("5. Cambiar estado");
                    Console.WriteLine("6. Salir");
                    op = Console.ReadLine().Trim();

                    switch (op)
                    {
                        case "1":
                            for (int i = 0; i < tickets.Count; i++)
                            {
                                Console.WriteLine(tickets[i].ToString());
                            }
                            Console.WriteLine("Ingrese el id del ticket a modificar");
                            codVal = int.TryParse(Console.ReadLine().Trim(), out codti);
                            for (int i = 0; i < tickets.Count; i++)
                            {
                                if (tickets[i].IdTicket == codti)
                                {
                                    do
                                    {
                                        Console.WriteLine("Ingrese el nombre: ");
                                        nombre = Console.ReadLine().Trim();
                                    } while (noVacio(nombre));
                                    Ticket temp = null;
                                    temp = tickets[i];
                                    tiDAL.actualizarTicket(temp, nombre, op);
                                    //tickets[i].NombreUsuario = nombre;
                                    Console.WriteLine("Nombre cambiado");
                                    Console.ReadKey();

                                    break;


                                }
                            }
                            Console.Clear();
                            break;
                        case "2":
                            if (tDAL.mostrarTecnicos().Count < 1)
                            {
                                Console.WriteLine("No hay tecnicos disponibles");
                                Console.ReadKey();
                                break;
                            }
                            for (int i = 0; i < tickets.Count; i++)
                            {
                                Console.WriteLine(tickets[i].ToString());
                            }

                            do
                            {
                                Console.WriteLine("Ingrese el id del ticket a modificar");
                                codVal = int.TryParse(Console.ReadLine().Trim(), out codti);

                            } while (!codVal);
                            for (int i = 0; i < tickets.Count; i++)
                            {
                                if (tickets[i].IdTicket == codti)
                                {
                                    Console.WriteLine("Tecnicos disponibles");
                                    for (int f = 0; f < tecnicos.Count; f++)
                                    {
                                        Console.WriteLine(tecnicos[f].ToString());

                                    }
                                    do
                                    {
                                        Console.WriteLine("Ingrese el id del tecnico que desea");
                                        opTecValido = int.TryParse(Console.ReadLine().Trim(), out opTec);

                                    } while (!opTecValido);
                                    for (int f = 0; f < tecnicos.Count; f++)
                                    {
                                        if (tecnicos[f].IdTecnico == opTec)
                                        {
                                            Ticket temp = tickets[i];
                                            tiDAL.actualizarTicket(temp, tecnicos[f].Nombre, op);
                                            Console.WriteLine("Tecnico cambiado");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }

                                }

                            }
                            Console.Clear();
                            break;
                        case "3":
                            if (tickets.Count < 1)
                            {
                                Console.WriteLine("No hay tickets");
                                Console.ReadKey();
                                break;
                            }
                            for (int i = 0; i < tickets.Count; i++)
                            {
                                Console.WriteLine(tickets[i].ToString());
                            }
                            do
                            {
                                Console.WriteLine("Ingrese el id del ticket a modificar");
                                codVal = int.TryParse(Console.ReadLine().Trim(), out codti);
                            } while (!codVal);

                            for (int i = 0; i <= tickets.Count; i++)
                            {
                                if (tickets[i].IdTicket == codti)
                                {
                                    do
                                    {
                                        Console.WriteLine("Ingrese la nueva descripcion");
                                        desc = Console.ReadLine().Trim();
                                    } while (noVacio(desc));
                                    Ticket temp = tickets[i];
                                    tiDAL.actualizarTicket(temp, desc, op);
                                    break;
                                }
                            }
                            Console.Clear();
                            break;


                        case "4":
                            if (catDAL.mostrarCategorias().Count < 1)
                            {
                                Console.WriteLine("No hay categorias");
                                break;
                            }
                            else
                            {
                                for (int i = 0; i < tickets.Count; i++)
                                {
                                    Console.WriteLine(tickets[i].ToString());
                                }
                                do
                                {
                                    Console.WriteLine("Ingrese el id del ticket a modificar");
                                    codVal = int.TryParse(Console.ReadLine().Trim(), out codti);
                                } while (!codVal);

                                for (int i = 0; i < tickets.Count; i++)
                                {
                                    if (tickets[i].IdTicket == codti)
                                    {
                                        for (int f = 0; f < categorias.Count; f++)
                                        {
                                            Console.WriteLine(categorias[f].ToString());
                                        }
                                        do
                                        {
                                            Console.WriteLine("Ingrese el id de la categoria");
                                            catVal = int.TryParse(Console.ReadLine().Trim(), out codCat);
                                        } while (!catVal);

                                        for (int g = 0; g <= categorias.Count; g++)
                                        {
                                            if (categorias[g].CodCategoria == codCat)
                                            {
                                                Ticket temp = tickets[i];
                                                tiDAL.actualizarTicket(temp, categorias[g].NombreCategoria, op);
                                                Console.WriteLine("Categoria cambiada");
                                                Console.ReadKey();
                                                break;
                                            }

                                        }
                                    }
                                }
                            }
                            Console.Clear();
                            break;
                        case "5":
                            if (tickets.Count < 1)
                            {
                                Console.WriteLine("No hay tickets");
                            }
                            else
                            {
                                for (int i = 0; i < tickets.Count; i++)
                                {
                                    Console.WriteLine(tickets[i].ToString() + ", Estado: " + tickets[i].Estado.estadoNombre);
                                }
                                do
                                {
                                    Console.WriteLine("Ingrese el id del ticket a modificar");
                                    codVal = int.TryParse(Console.ReadLine().Trim(), out codti);
                                } while (!codVal);
                                for (int i = 0; i < tickets.Count; i++)
                                {
                                    if (tickets[i].IdTicket == codti)
                                    {
                                        do
                                        {
                                            Console.WriteLine("Ingrese el estado a establecer");
                                            Console.WriteLine("1. En progreso");
                                            Console.WriteLine("2. Pendiente");
                                            Console.WriteLine("3. Bloqueado");
                                            Console.WriteLine("4. Cerrado");
                                            Console.WriteLine("5. Terminado");
                                            codEstaVal = int.TryParse(Console.ReadLine().Trim(), out codEsta);
                                        } while (codEsta < 0 || codEsta > 6);
                                        switch (codEsta)
                                        {
                                            case 1:
                                                tickets[i].Estado = TicketDAL.EnProgreso;
                                                break;
                                            case 2:
                                                tickets[i].Estado = TicketDAL.Pendiente;
                                                break;
                                            case 3:
                                                tickets[i].Estado = TicketDAL.Bloqueado;
                                                do
                                                {
                                                    Console.WriteLine("Ingrese el motivo del bloqueo");
                                                    observacion = Console.ReadLine().Trim();
                                                } while (noVacio(observacion));
                                                tickets[i].agregarObservacion(observacion);
                                                break;
                                            case 4:
                                                tickets[i].Estado = TicketDAL.Cerrado;
                                                break;
                                            case 5:
                                                tickets[i].Estado = TicketDAL.Terminado;
                                                break;
                                            default:
                                                Console.WriteLine("Valor no valido");
                                                Console.ReadKey();
                                                break;
                                        }
                                        Console.Clear();
                                    }
                                }
                            }
                            Console.Clear();
                            break;
                    }
                } while (op != "6");
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
                if (Ticket.ListaDeObservaciones.Count >= 1)
                {
                    for (int i = 0; i < Ticket.mostrarObservaciones().Count; i++)
                    {
                        Console.WriteLine(Ticket.mostrarObservaciones()[i].ToString());
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

        }
        //Menu tecnico
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
                    consultarTicketTec();
                    break;
                case "2":
                    Console.WriteLine("Se cambio el estado del ticket");
                    cambiarEstado();
                    break;
                case "3":
                    Console.WriteLine("Se consultaron los comentarios");
                    verObservaciones();
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

        public static void consultarTicketTec()
        {
            List<Ticket> tickets = tiDAL.mostrarTicket();
            int codTi;
            bool codVal;
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets a consultar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Tickets creados");
                for (int i = 0; i < tickets.Count; i++)
                {
                    Console.WriteLine(tickets[i].ToString());
                }
                Console.ReadKey();
            }
        }
        public static void cambiarEstado()
        {
            List<Ticket> tickets = tiDAL.mostrarTicket();
            int codTi;
            bool codVal;
            String op, observacion;
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets a modificar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Tickets disponibles");
                for (int i = 0; i < tickets.Count; i++)
                {
                    Console.WriteLine(tickets[i].ToString());
                    Console.WriteLine(tickets[i].Estado.estadoNombre);
                    Console.WriteLine(tickets[i].Prioridad.Nombre);
                }
                do
                {
                    Console.WriteLine("Ingrese el id del ticket a cambiar");
                    codVal = int.TryParse(Console.ReadLine().Trim(), out codTi);

                } while (!codVal && tickets.Count <= codTi);
                for (int i = 0; i < tickets.Count; i++)
                {
                    if (tickets[i].IdTicket == codTi)
                    {
                        do
                        {
                            Console.WriteLine("Ingrese el estado a seleccionar");
                            Console.WriteLine("1. En progreso");
                            Console.WriteLine("2. Bloqueado");
                            Console.WriteLine("3. Terminado");
                            op = Console.ReadLine().Trim();
                        } while (noVacio(op));
                        switch (op)
                        {
                            case "1":
                                tickets[i].Estado = TicketDAL.EnProgreso;
                                break;
                            case "2":
                                tickets[i].Estado = TicketDAL.Bloqueado;
                                do
                                {
                                    Console.WriteLine("Ingrese el motivo del bloqueo");
                                    observacion = Console.ReadLine().Trim();
                                } while (noVacio(observacion));
                                tickets[i].agregarObservacion("Motivo de bloqueo: " + observacion);
                                break;
                            case "3":
                                tickets[i].Estado = TicketDAL.Terminado;
                                break;
                            default:
                                Console.WriteLine("Opcion no valida");
                                break;
                        }
                    }
                }

                Console.ReadKey();
            }

        }

        public static void verObservaciones()
        {
            List<Ticket> tickets = tiDAL.mostrarTicket();
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets");
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < tickets.Count; i++)
                {
                    if (tickets[i].ListaDeObservaciones.Count > 0)
                    {
                        for (int f = 0; f < tickets[i].ListaDeObservaciones.Count; f++)
                        {
                            Console.WriteLine(tickets[i].ToString() + ", Estado: " + tickets[i].Estado.estadoNombre);
                            Console.WriteLine(tickets[i].Prioridad.Nombre + "}");
                            Console.WriteLine(tickets[i].mostrarObservaciones()[f].ToString());
                        }
                        Console.ReadKey();
                    }

                }
            }


        }
        // Menu del usuario
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

                    crearTicket();
                    break;
                case "2":

                    consultarTicket();
                    break;
                case "3":
                    cerrarTicket();
                    break;
                case "4":
                    verMensajes();
                    break;
                case "5":
                    enviarMensaje();
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


                Ticket t = new Ticket(nombreUsuario, nombreTecnico, descripcion, categoria);
                t.Estado = TicketDAL.Pendiente;


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

        }

        public static void consultarTicket()
        {
            List<Ticket> tickets = tiDAL.mostrarTicket();
            int codTi;
            bool codVal;
            if (tickets.Count < 1)
            {
                Console.WriteLine("No hay tickets al cual consultar");
            }
            else
            {
                for (int i = 0; i < tickets.Count; i++)
                {
                    Console.WriteLine(tickets[i].ToString());
                }
                do
                {
                    Console.WriteLine("Ingrese el id del ticket a consultar a detalle");
                    codVal = int.TryParse(Console.ReadLine().Trim(), out codTi);
                } while (!codVal);

                for (int i = 0; i < tickets.Count; i++)
                {
                    if (tickets[i].IdTicket == codTi)
                    {
                        Console.WriteLine(tickets[i].ToString() + ", Estado: " + tickets[i].Estado.estadoNombre);
                        Console.WriteLine(tickets[i].Prioridad.Nombre + "}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
            }
        }

        public static void cerrarTicket()
        {
            List<Ticket> tickets = tiDAL.mostrarTicket();

            int codTi;
            bool codVal;
            if (tickets.Count > 0)
            {
                for (int i = 0; i < tickets.Count; i++)
                {
                    if (tickets[i].Estado.estadoNombre.Equals("Terminado"))
                    {
                        Console.WriteLine("Tickets terminados");
                        Console.WriteLine(tickets[i].ToString());


                    }

                }
                do
                {
                    Console.WriteLine("Ingrese el id del ticket a cerrar");
                    codVal = int.TryParse(Console.ReadLine().Trim(), out codTi);

                } while (!codVal);

                for (int f = 0; f < tickets.Count; f++)
                {
                    if (tickets[f].IdTicket == codTi)
                    {
                        tickets[f].Estado = TicketDAL.Cerrado;
                        Console.WriteLine("Ticket cerrado");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay tickets");
                Console.ReadKey();
            }


        }

        public static void verMensajes()
        {
            List<Mensaje> msgs = menDAL.mostrarMensajes();
            String nombre, op, resp;
            if (msgs.Count < 1)
            {
                Console.WriteLine("No hay mensajes");
                Console.ReadKey();
            }
            else
            {
                do
                {
                    Console.WriteLine("Ingrese su nombre");
                    nombre = Console.ReadLine().Trim();
                } while (noVacio(nombre));

                for (int i = 0; i < msgs.Count; i++)
                {
                    if (msgs[i].Receptor.Equals(nombre))
                    {

                        Console.WriteLine(msgs[i].ToString());
                        Console.WriteLine("--------------");
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine("Desea responder el mensaje?");
                            op = Console.ReadLine().Trim().ToUpper();
                        } while (!(op.Equals("SI") || op.Equals("NO")));
                        if (op.Equals("SI"))
                        {
                            Console.WriteLine("Ingrese su respuesta: ");
                            resp = Console.ReadLine().Trim();
                            Mensaje m = new Mensaje(nombre, msgs[i].Emisor, resp);
                            menDAL.crearMensaje(m);
                        }
                    }


                }

                Console.ReadKey();
            }

        }

        public static void enviarMensaje()
        {
            List<Mensaje> msgs = menDAL.mostrarMensajes();
            String nombreUsu, nombreDes, mensaje;
            do
            {
                Console.WriteLine("Ingrese su nombre de usuario");
                nombreUsu = Console.ReadLine().Trim();
            } while (noVacio(nombreUsu));
            do
            {
                Console.WriteLine("Ingrese el nombre del destinatario");
                nombreDes = Console.ReadLine().Trim();
            } while (noVacio(nombreDes));

            do
            {
                Console.WriteLine("Ingrese el mensaje");
                mensaje = Console.ReadLine().Trim();
            } while (noVacio(mensaje));
            Mensaje m = new Mensaje(nombreUsu, nombreDes, mensaje);
            menDAL.crearMensaje(m);
            Console.WriteLine("Mensaje enviado");
            Console.ReadKey();
            Console.Clear();
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

                Tecnico tecjemplo = new Tecnico("20" + i, "Ejemplo" + i, "Tecnico", "F");
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
