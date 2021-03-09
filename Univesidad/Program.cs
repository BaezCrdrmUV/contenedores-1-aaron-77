using System;
using System.Collections.Generic;


namespace Univesidad
{
    class Program
    {
        static void Main(string[] args)
        {
            BdManager bdManager = new BdManager();
             int respuestaUsuario = 0;
            do {
                mostrarMenu();
                
                try{
                    string nombre = "";
                    string apellido = "";
                    string query = "";
                    respuestaUsuario = Int32.Parse(Console.ReadLine());
                    switch(respuestaUsuario){
                        case 1:
                            Console.WriteLine("inserta el nombre del maestro");
                            nombre = Console.ReadLine();
                             Console.WriteLine("inserta el apellido del maestro");
                            apellido = Console.ReadLine();
                            query = "insert into maestros(nombre,apellido) values("+"\""+nombre+"\""+","+"\""+apellido+"\""+")";
                            bdManager.ExecuteQuery(query);
                        break;
                        case 2:
                            Console.WriteLine("inserta el nombre del alumno");
                            nombre = Console.ReadLine().Trim();
                            Console.WriteLine("inserta el apellido del alumno");
                            apellido = Console.ReadLine().Trim();
                            mostrarProfesoresDisponibles(bdManager);
                            Console.WriteLine("Selecciona el profesor que asignaras al alumno");
                            int fkMaestro = Int32.Parse(Console.ReadLine());                       
                            query = "insert into alumnos(fkIdMaestro,nombre,apellido) values("+fkMaestro+","+"\""+nombre+"\""+","+"\""+apellido+"\""+")";
                            bdManager.ExecuteQuery(query);

                        break;
                        case 3:
                            Console.WriteLine("selecciona el maestro del que quieres consultar alumnos");
                            mostrarProfesoresDisponibles(bdManager);
                            int maestroSeleccionado = Int32.Parse(Console.ReadLine());
                            obtenerAlumnosDeProfesor(bdManager,maestroSeleccionado);

                        break;


                    }
                }catch(FormatException){
                    Console.WriteLine("Error al introducir los datos");
                }
            }while(respuestaUsuario > 0 && respuestaUsuario < 4  );


            

        }

        private static void mostrarMenu(){
            Console.WriteLine("que deseas realizar");
            Console.WriteLine("1 agregar un maestro");
            Console.WriteLine("2 agregar un alumno");
            Console.WriteLine("3 consultar los alumnos de un maestro");
            Console.WriteLine("cuanquier otra tecla SALIR");

        }
        private static void mostrarProfesoresDisponibles(BdManager bdManager){
            
            List<string> values = bdManager.ExecuteReader("select * from maestros");
            Console.WriteLine("============================MAESTROS=====================");
            imprimirResultados(values);
            Console.WriteLine("==========================================================");
        }

        private static void obtenerAlumnosDeProfesor(BdManager bdManager,int fkIdMaestro){
            List<string> values = bdManager.ExecuteReader("select * from alumnos where fkIdMaestro ="+fkIdMaestro);
           Console.WriteLine("============================ALUMNOS=====================");
           imprimirResultados(values);
           Console.WriteLine("========================================================");
        }

        private static void imprimirResultados(List<string> values){
             foreach (string item in values)
            {
                int n;
                if(Int32.TryParse(item,out n)){
                    Console.Write("{0}: {1}  ", "id", item);
                }else{
                      Console.Write("{0}: {1}  ", "nombre", item);
                      Console.WriteLine();
                }
               
            }
           
        }
        
    }

    
}
