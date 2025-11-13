using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;

        private List<Usuario> usuarios = new List<Usuario>();
        private List<Aeropuerto> aeropuertos = new List<Aeropuerto>();
        private List<Vuelo> vuelos = new List<Vuelo>();
        private List<Pasaje> pasajes = new List<Pasaje>();
        private List<Avion> aviones = new List<Avion>();
        private List<Ruta> rutas = new List<Ruta>();

        private static Random random = new Random();

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }
        private Sistema()
        {
            // Clientes Premium (5)
            Premium p1 = new Premium("bruno1@mail.com", "pass1", "11111111", "Bruno Uno", "Uruguayo", 10);
            Premium p2 = new Premium("bruno2@mail.com", "pass2", "22222222", "Bruno Dos", "Argentino", 15);
            Premium p3 = new Premium("bruno3@mail.com", "pass3", "33333333", "Bruno Tres", "Chileno", 5);
            Premium p4 = new Premium("bruno4@mail.com", "pass4", "44444444", "Bruno Cuatro", "Paraguayo", 20);
            Premium p5 = new Premium("bruno5@mail.com", "pass5", "55555555", "Bruno Cinco", "Uruguayo", 12);

            AgregarClientesPremium(p1);
            AgregarClientesPremium(p2);
            AgregarClientesPremium(p3);
            AgregarClientesPremium(p4);
            AgregarClientesPremium(p5);

            // Clientes Ocasionales (5)
            Ocasional o1 = new Ocasional("juan1@mail.com", "1234", "66666666", "Juan Uno", "Uruguaya", true);
            Ocasional o2 = new Ocasional("juan2@mail.com", "1234", "77777777", "Juan Dos", "Argentina", false);
            Ocasional o3 = new Ocasional("juan3@mail.com", "1234", "88888888", "Juan Tres", "Brasilera", true);
            Ocasional o4 = new Ocasional("juan4@mail.com", "1234", "99999999", "Juan Cuatro", "Chilena", false);
            Ocasional o5 = new Ocasional("juan5@mail.com", "1234", "10101010", "Juan Cinco", "Uruguaya", true);

            AgregarClientesOcasionales(o1);
            AgregarClientesOcasionales(o2);
            AgregarClientesOcasionales(o3);
            AgregarClientesOcasionales(o4);
            AgregarClientesOcasionales(o5);

            // Administradores (2)
            Administrador admin1 = new Administrador("admin1@mail.com", "admin1", "adminOne");
            Administrador admin2 = new Administrador("admin2@mail.com", "admin2", "adminTwo");

            AgregarAdmin(admin1);
            AgregarAdmin(admin2);

            // Aviones (4)
            Avion av1 = new Avion("Boeing", "737", 200, 5000, 10000);
            Avion av2 = new Avion("Airbus", "A320", 200, 4500, 9000);
            Avion av3 = new Avion("Embraer", "E190", 200, 3000, 12000);
            Avion av4 = new Avion("Bombardier", "CRJ900", 200, 2800, 11000);

            AgregarAviones(av1);
            AgregarAviones(av2);
            AgregarAviones(av3);
            AgregarAviones(av4);

            // Aeropuertos (20)
            Aeropuerto a1 = new Aeropuerto("MVD", "Montevideo", 5000, 2000);
            Aeropuerto a2 = new Aeropuerto("EZE", "Buenos Aires", 5100, 2100);
            Aeropuerto a3 = new Aeropuerto("SCL", "Santiago", 5200, 2200);
            Aeropuerto a4 = new Aeropuerto("LIM", "Lima", 5300, 2300);
            Aeropuerto a5 = new Aeropuerto("BOG", "Bogotá", 5400, 2400);
            Aeropuerto a6 = new Aeropuerto("UIO", "Quito", 5500, 2500);
            Aeropuerto a7 = new Aeropuerto("CCS", "Caracas", 5600, 2600);
            Aeropuerto a8 = new Aeropuerto("PTY", "Panamá", 5700, 2700);
            Aeropuerto a9 = new Aeropuerto("ASU", "Asunción", 5800, 2800);
            Aeropuerto a10 = new Aeropuerto("LPB", "La Paz", 5900, 2900);
            Aeropuerto a11 = new Aeropuerto("MAD", "Madrid", 6000, 3000);
            Aeropuerto a12 = new Aeropuerto("BCN", "Barcelona", 6100, 3100);
            Aeropuerto a13 = new Aeropuerto("MIA", "Miami", 6200, 3200);
            Aeropuerto a14 = new Aeropuerto("NYC", "New York", 6300, 3300);
            Aeropuerto a15 = new Aeropuerto("YYZ", "Toronto", 6400, 3400);
            Aeropuerto a16 = new Aeropuerto("CDG", "París", 6500, 3500);
            Aeropuerto a17 = new Aeropuerto("LHR", "Londres", 6600, 3600);
            Aeropuerto a18 = new Aeropuerto("FCO", "Roma", 6700, 3700);
            Aeropuerto a19 = new Aeropuerto("NRT", "Tokio", 6800, 3800);
            Aeropuerto a20 = new Aeropuerto("SYD", "Sídney", 6900, 3900);

            AgregarAeropuerto(a1); AgregarAeropuerto(a2); AgregarAeropuerto(a3); AgregarAeropuerto(a4); AgregarAeropuerto(a5);
            AgregarAeropuerto(a6); AgregarAeropuerto(a7); AgregarAeropuerto(a8); AgregarAeropuerto(a9); AgregarAeropuerto(a10);
            AgregarAeropuerto(a11); AgregarAeropuerto(a12); AgregarAeropuerto(a13); AgregarAeropuerto(a14); AgregarAeropuerto(a15);
            AgregarAeropuerto(a16); AgregarAeropuerto(a17); AgregarAeropuerto(a18); AgregarAeropuerto(a19); AgregarAeropuerto(a20);

            // Rutas (30)
            Ruta r1 = new Ruta(a1, a2, 700);
            Ruta r2 = new Ruta(a2, a3, 800);
            Ruta r3 = new Ruta(a3, a4, 900);
            Ruta r4 = new Ruta(a4, a5, 1000);
            Ruta r5 = new Ruta(a5, a6, 1100);
            Ruta r6 = new Ruta(a6, a7, 1200);
            Ruta r7 = new Ruta(a7, a8, 1300);
            Ruta r8 = new Ruta(a8, a9, 1400);
            Ruta r9 = new Ruta(a9, a10, 1500);
            Ruta r10 = new Ruta(a10, a11, 1600);
            Ruta r11 = new Ruta(a11, a12, 1700);
            Ruta r12 = new Ruta(a12, a13, 1800);
            Ruta r13 = new Ruta(a13, a14, 1900);
            Ruta r14 = new Ruta(a14, a15, 2000);
            Ruta r15 = new Ruta(a15, a16, 2100);
            Ruta r16 = new Ruta(a16, a17, 2200);
            Ruta r17 = new Ruta(a17, a18, 2300);
            Ruta r18 = new Ruta(a18, a19, 2400);
            Ruta r19 = new Ruta(a19, a20, 2500);
            Ruta r20 = new Ruta(a20, a1, 2600);
            Ruta r21 = new Ruta(a1, a3, 1350);
            Ruta r22 = new Ruta(a2, a4, 1450);
            Ruta r23 = new Ruta(a3, a5, 1550);
            Ruta r24 = new Ruta(a4, a6, 1650);
            Ruta r25 = new Ruta(a5, a7, 1750);
            Ruta r26 = new Ruta(a6, a8, 1850);
            Ruta r27 = new Ruta(a7, a9, 1950);
            Ruta r28 = new Ruta(a8, a10, 2050);
            Ruta r29 = new Ruta(a9, a11, 2150);
            Ruta r30 = new Ruta(a10, a12, 2250);

            AgregarRutas(r1); AgregarRutas(r2); AgregarRutas(r3); AgregarRutas(r4); AgregarRutas(r5);
            AgregarRutas(r6); AgregarRutas(r7); AgregarRutas(r8); AgregarRutas(r9); AgregarRutas(r10);
            AgregarRutas(r11); AgregarRutas(r12); AgregarRutas(r13); AgregarRutas(r14); AgregarRutas(r15);
            AgregarRutas(r16); AgregarRutas(r17); AgregarRutas(r18); AgregarRutas(r19); AgregarRutas(r20);
            AgregarRutas(r21); AgregarRutas(r22); AgregarRutas(r23); AgregarRutas(r24); AgregarRutas(r25);
            AgregarRutas(r26); AgregarRutas(r27); AgregarRutas(r28); AgregarRutas(r29); AgregarRutas(r30);

            // Vuelos (30)
            Vuelo v1 = new Vuelo("V100", r1, av1, new List<DayOfWeek> { DayOfWeek.Monday });
            Vuelo v2 = new Vuelo("V101", r2, av2, new List<DayOfWeek> { DayOfWeek.Tuesday });
            Vuelo v3 = new Vuelo("V102", r3, av3, new List<DayOfWeek> { DayOfWeek.Wednesday });
            Vuelo v4 = new Vuelo("V103", r4, av4, new List<DayOfWeek> { DayOfWeek.Thursday });
            Vuelo v5 = new Vuelo("V104", r5, av1, new List<DayOfWeek> { DayOfWeek.Friday });
            Vuelo v6 = new Vuelo("V105", r6, av2, new List<DayOfWeek> { DayOfWeek.Saturday });
            Vuelo v7 = new Vuelo("V106", r7, av3, new List<DayOfWeek> { DayOfWeek.Sunday });
            Vuelo v8 = new Vuelo("V107", r8, av4, new List<DayOfWeek> { DayOfWeek.Monday });
            Vuelo v9 = new Vuelo("V108", r9, av1, new List<DayOfWeek> { DayOfWeek.Tuesday });
            Vuelo v10 = new Vuelo("V109", r10, av2, new List<DayOfWeek> { DayOfWeek.Wednesday });
            Vuelo v11 = new Vuelo("V110", r11, av3, new List<DayOfWeek> { DayOfWeek.Thursday });
            Vuelo v12 = new Vuelo("V111", r12, av4, new List<DayOfWeek> { DayOfWeek.Friday });
            Vuelo v13 = new Vuelo("V112", r13, av1, new List<DayOfWeek> { DayOfWeek.Saturday });
            Vuelo v14 = new Vuelo("V113", r14, av2, new List<DayOfWeek> { DayOfWeek.Sunday });
            Vuelo v15 = new Vuelo("V114", r15, av3, new List<DayOfWeek> { DayOfWeek.Monday });
            Vuelo v16 = new Vuelo("V115", r16, av4, new List<DayOfWeek> { DayOfWeek.Tuesday });
            Vuelo v17 = new Vuelo("V116", r17, av1, new List<DayOfWeek> { DayOfWeek.Wednesday });
            Vuelo v18 = new Vuelo("V117", r18, av2, new List<DayOfWeek> { DayOfWeek.Thursday });
            Vuelo v19 = new Vuelo("V118", r19, av3, new List<DayOfWeek> { DayOfWeek.Friday });
            Vuelo v20 = new Vuelo("V119", r20, av4, new List<DayOfWeek> { DayOfWeek.Saturday });
            Vuelo v21 = new Vuelo("V120", r21, av1, new List<DayOfWeek> { DayOfWeek.Sunday });
            Vuelo v22 = new Vuelo("V121", r22, av2, new List<DayOfWeek> { DayOfWeek.Monday });
            Vuelo v23 = new Vuelo("V122", r23, av3, new List<DayOfWeek> { DayOfWeek.Tuesday });
            Vuelo v24 = new Vuelo("V123", r24, av4, new List<DayOfWeek> { DayOfWeek.Wednesday });
            Vuelo v25 = new Vuelo("V124", r25, av1, new List<DayOfWeek> { DayOfWeek.Thursday });
            Vuelo v26 = new Vuelo("V125", r26, av2, new List<DayOfWeek> { DayOfWeek.Friday });
            Vuelo v27 = new Vuelo("V126", r27, av3, new List<DayOfWeek> { DayOfWeek.Saturday });
            Vuelo v28 = new Vuelo("V127", r28, av4, new List<DayOfWeek> { DayOfWeek.Sunday });
            Vuelo v29 = new Vuelo("V128", r29, av1, new List<DayOfWeek> { DayOfWeek.Monday });
            Vuelo v30 = new Vuelo("V129", r30, av2, new List<DayOfWeek> { DayOfWeek.Tuesday });

            AgregarVuelos(v1); AgregarVuelos(v2); AgregarVuelos(v3); AgregarVuelos(v4); AgregarVuelos(v5);
            AgregarVuelos(v6); AgregarVuelos(v7); AgregarVuelos(v8); AgregarVuelos(v9); AgregarVuelos(v10);
            AgregarVuelos(v11); AgregarVuelos(v12); AgregarVuelos(v13); AgregarVuelos(v14); AgregarVuelos(v15);
            AgregarVuelos(v16); AgregarVuelos(v17); AgregarVuelos(v18); AgregarVuelos(v19); AgregarVuelos(v20);
            AgregarVuelos(v21); AgregarVuelos(v22); AgregarVuelos(v23); AgregarVuelos(v24); AgregarVuelos(v25);
            AgregarVuelos(v26); AgregarVuelos(v27); AgregarVuelos(v28); AgregarVuelos(v29); AgregarVuelos(v30);

            // Pasajes (25) — usamos o1 y p1 como pasajeros para simplificar
            Pasaje pasaje1 = new Pasaje(Pasaje.TipoEquipaje.light, v1, new DateTime(2025, 5, 15), o1, 150);
            Pasaje pasaje2 = new Pasaje(Pasaje.TipoEquipaje.cabina, v2, new DateTime(2025, 5, 16), p1, 160);
            Pasaje pasaje3 = new Pasaje(Pasaje.TipoEquipaje.bodega, v3, new DateTime(2025, 5, 17), o1, 170);
            Pasaje pasaje4 = new Pasaje(Pasaje.TipoEquipaje.light, v4, new DateTime(2025, 5, 18), p1, 180);
            Pasaje pasaje5 = new Pasaje(Pasaje.TipoEquipaje.cabina, v5, new DateTime(2025, 5, 19), o1, 190);
            Pasaje pasaje6 = new Pasaje(Pasaje.TipoEquipaje.bodega, v6, new DateTime(2025, 5, 20), p1, 200);
            Pasaje pasaje7 = new Pasaje(Pasaje.TipoEquipaje.light, v7, new DateTime(2025, 5, 21), o1, 210);
            Pasaje pasaje8 = new Pasaje(Pasaje.TipoEquipaje.cabina, v8, new DateTime(2025, 5, 22), p1, 220);
            Pasaje pasaje9 = new Pasaje(Pasaje.TipoEquipaje.bodega, v9, new DateTime(2025, 5, 23), o1, 230);
            Pasaje pasaje10 = new Pasaje(Pasaje.TipoEquipaje.light, v10, new DateTime(2025, 5, 24), p1, 240);
            Pasaje pasaje11 = new Pasaje(Pasaje.TipoEquipaje.cabina, v11, new DateTime(2025, 5, 25), o1, 250);
            Pasaje pasaje12 = new Pasaje(Pasaje.TipoEquipaje.bodega, v12, new DateTime(2025, 5, 26), p1, 260);
            Pasaje pasaje13 = new Pasaje(Pasaje.TipoEquipaje.light, v13, new DateTime(2025, 5, 27), o1, 270);
            Pasaje pasaje14 = new Pasaje(Pasaje.TipoEquipaje.cabina, v14, new DateTime(2025, 5, 28), p1, 280);
            Pasaje pasaje15 = new Pasaje(Pasaje.TipoEquipaje.bodega, v15, new DateTime(2025, 5, 29), o1, 290);
            Pasaje pasaje16 = new Pasaje(Pasaje.TipoEquipaje.light, v16, new DateTime(2025, 5, 30), p1, 300);
            Pasaje pasaje17 = new Pasaje(Pasaje.TipoEquipaje.cabina, v17, new DateTime(2025, 5, 31), o1, 310);
            Pasaje pasaje18 = new Pasaje(Pasaje.TipoEquipaje.bodega, v18, new DateTime(2025, 6, 1), p1, 320);
            Pasaje pasaje19 = new Pasaje(Pasaje.TipoEquipaje.light, v19, new DateTime(2025, 6, 2), o1, 330);
            Pasaje pasaje20 = new Pasaje(Pasaje.TipoEquipaje.cabina, v20, new DateTime(2025, 6, 3), p1, 340);
            Pasaje pasaje21 = new Pasaje(Pasaje.TipoEquipaje.bodega, v21, new DateTime(2025, 6, 4), o1, 350);
            Pasaje pasaje22 = new Pasaje(Pasaje.TipoEquipaje.light, v22, new DateTime(2025, 6, 5), p1, 360);
            Pasaje pasaje23 = new Pasaje(Pasaje.TipoEquipaje.cabina, v23, new DateTime(2025, 6, 6), o1, 370);
            Pasaje pasaje24 = new Pasaje(Pasaje.TipoEquipaje.bodega, v24, new DateTime(2025, 6, 7), p1, 380);
            Pasaje pasaje25 = new Pasaje(Pasaje.TipoEquipaje.light, v25, new DateTime(2025, 6, 8), o1, 390);

            // Agregar todos los pasajes
            AgregarPasajes(pasaje1); AgregarPasajes(pasaje2); AgregarPasajes(pasaje3); AgregarPasajes(pasaje4); AgregarPasajes(pasaje5);
            AgregarPasajes(pasaje6); AgregarPasajes(pasaje7); AgregarPasajes(pasaje8); AgregarPasajes(pasaje9); AgregarPasajes(pasaje10);
            AgregarPasajes(pasaje11); AgregarPasajes(pasaje12); AgregarPasajes(pasaje13); AgregarPasajes(pasaje14); AgregarPasajes(pasaje15);
            AgregarPasajes(pasaje16); AgregarPasajes(pasaje17); AgregarPasajes(pasaje18); AgregarPasajes(pasaje19); AgregarPasajes(pasaje20);
            AgregarPasajes(pasaje21); AgregarPasajes(pasaje22); AgregarPasajes(pasaje23); AgregarPasajes(pasaje24); AgregarPasajes(pasaje25);

        }
        //conseguir lista de clientes
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (Usuario unUsuario in usuarios)
            {
                if (unUsuario is Cliente unCliente) clientes.Add(unCliente);
            }
            return clientes;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public Cliente? DevolverCliente(string correo)
        {
            foreach(Cliente unC in ObtenerClientes())
            {
                if(unC.Correo == correo) return unC;
            }
            return null;
        }

        public List<Cliente> ObtenerClientesOrdenados()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Sort();

            foreach (Usuario unUsuario in usuarios)
            {
                if (unUsuario is Cliente unCliente) clientes.Add(unCliente);
            }
            return clientes;
        }

        public Usuario? DevolverUsuario(string correo, string contraseña)
        {
            foreach (Usuario unS in ObtenerUsuarios())
            {
                if (unS.Correo == correo && unS.Contraseña == contraseña)
                {
                    return unS;
                }
            }
            return null;
        }

        public Vuelo? DevolverVueloPorNum(string numeroVuelo)
            {
                foreach (Vuelo vuelo in vuelos)
                {
                    if (vuelo.NumeroVuelo.ToLower() == numeroVuelo.ToLower())
                    {
                        return vuelo;
                    }
                }
                return null;
            }

        public List<Vuelo> VuelosPorRuta(string codigoIATA)
        {
            List<Vuelo> resultado = new List<Vuelo>();

            if (string.IsNullOrEmpty(codigoIATA))
            {
                return resultado; // devuelve lista vacía si no se ingresó nada
            }

            codigoIATA = codigoIATA.ToUpper(); 

            foreach (Vuelo v in vuelos)
            {
                if (v.Ruta.AeropuertoSalida.CodigoIATA.ToUpper().Contains(codigoIATA) ||
                    v.Ruta.AeropuertoLlegada.CodigoIATA.ToUpper().Contains(codigoIATA))
                {
                    resultado.Add(v);
                }
            }

            return resultado;
        }


        public List<Vuelo> DevolverVuelos()
        {
            return vuelos;
        }

        public List<Pasaje> DevolverPasajesPorCliente(Cliente cliente)
        {
            Pasaje.OrdenarPorPrecio();
            pasajes.Sort();
            List<Pasaje> resultado = new List<Pasaje>();
            foreach (Pasaje p in pasajes)
            {
                if (p.Pasajero != null && p.Pasajero.Equals(cliente))
                {
                    resultado.Add(p);
                }
            }
            return resultado;
        }

        public List<Vuelo> VuelosPorAeropuerto(string codigoIATA)
        {
            List<Vuelo> resultado = new List<Vuelo>();

            foreach (Vuelo unVuelo in vuelos)
            {
                //va comparando codigos IATA y si coinciden los agrega a la lista
                if (unVuelo.Ruta.AeropuertoSalida.CodigoIATA == codigoIATA || unVuelo.Ruta.AeropuertoLlegada.CodigoIATA == codigoIATA)
                {
                    resultado.Add(unVuelo);
                }
            }
            return resultado;
        }

        public void ExisteOcasional(Ocasional unOcasional)
        {
            if (usuarios.Contains(unOcasional)) throw new Exception("Ya existe este ocasional");
        }
        public void AltaClienteOcasional(string correo, string contraseña, string documento, string nombre, string nacionalidad)
        {
            bool elegible = random.Next(2) == 1;

            Ocasional nuevoOcacional = new Ocasional(correo, contraseña, documento, nombre, nacionalidad, elegible);

            nuevoOcacional.Validar();
            ExisteOcasional(nuevoOcacional);
            usuarios.Add(nuevoOcacional);
        }

        public void EmitirPasaje(Pasaje.TipoEquipaje equipaje, Vuelo vuelo, DateTime fecha, Cliente pasajero)
        {
            //valido la frecuencia del vuelo
            bool valido = false;
            foreach(DayOfWeek dia in vuelo.Frecuencia)
            {
                if(dia == fecha.DayOfWeek)
                {
                    valido = true;
                    break;
                }
            }
            if (!valido) throw new Exception("fecha no valida para este vuelo");

            //creo el pasaje sin precio para ir calculandolo despues
            Pasaje nuevoPasaje = new Pasaje(equipaje, vuelo, fecha, pasajero, 0);

            decimal costoBase = nuevoPasaje.CalcularCostoBase();
            decimal ganancia = nuevoPasaje.CalcularGanancia(costoBase);
            decimal subtotal = costoBase + ganancia;
            decimal recargo = pasajero.CalcularRecargoEquipaje(equipaje, subtotal);
            decimal precioFinal = subtotal + recargo;

            nuevoPasaje.Precio = precioFinal;
            nuevoPasaje.Validar();
            AgregarPasajes(nuevoPasaje);
        }

        public List<Pasaje> PasajesEntreFechas(DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Pasaje> resultado = new List<Pasaje>();

            foreach (Pasaje unPasaje in pasajes)
            {
                //tomo en cuenta las posibilidades de que cualquier fecha sea mayor o menor que la otra
                if (unPasaje.Fecha >= fechaInicio && unPasaje.Fecha <= fechaFinal) resultado.Add(unPasaje);
            }
            return resultado;
        }

        public List<Pasaje> DevolverPasajesOrdenadosPorFecha()
        {
            Pasaje.OrdenarPorFecha();
            pasajes.Sort(); 
            return pasajes;
        }


        public void AgregarAeropuerto(Aeropuerto a)
        {
            if (a == null) throw new Exception("El aeropuerto no puede ser nulo");
            if (aeropuertos.Contains(a)) throw new Exception("Ya existe este aeropuerto");
            aeropuertos.Add(a);
        }

        public void AgregarClientesPremium(Premium p)
        {
            if (p == null) throw new Exception("El cliente premium no puede ser nulo");
            if (usuarios.Contains(p)) throw new Exception("Ya existe este cliente premium");
            usuarios.Add(p);
        }

        public void AgregarClientesOcasionales(Ocasional o)
        {
            if (o == null) throw new Exception("El cliente ocasional no puede ser nulo");
            ExisteOcasional(o);
            usuarios.Add(o);
        }

        public void AgregarAdmin(Administrador a)
        {
            if (a == null) throw new Exception("El administraor no puede ser nulo");
            if (usuarios.Contains(a)) throw new Exception("Ya existe este administrador");
            usuarios.Add(a);
        }

        public void AgregarAviones(Avion av)
        {
            if (av == null) throw new Exception("El avion no puede ser nulo");
            if (aviones.Contains(av)) throw new Exception("Ya existe este avion");
            aviones.Add(av);
        }

        public void AgregarRutas(Ruta r)
        {
            if (r == null) throw new Exception("La ruta no puede ser nula");
            if (rutas.Contains(r)) throw new Exception("Ya existe esta ruta");
            rutas.Add(r);
        }

        public void AgregarVuelos(Vuelo v)
        {
            if (v == null) throw new Exception("El vuelo no puede ser nulo");
            if (vuelos.Contains(v)) throw new Exception("Ya existe este vuelo");
            vuelos.Add(v);
        }

        public void AgregarPasajes(Pasaje pa)
        {
            if (pa == null) throw new Exception("El pasaje no puede ser nulo");
            if (pasajes.Contains(pa)) throw new Exception("Ya existe este pasaje");
            pasajes.Add(pa);
        }
    }
}
