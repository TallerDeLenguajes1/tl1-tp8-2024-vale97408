// See https://aka.ms/new-console-template for more information


using GestionTareas;
using EspacioCalculadora;

Console.WriteLine("=======TP4- LISTAS Y CLASES CON C#==========");
Console.WriteLine("---EJERCICIO 1-----");

//int op;
int operacion;

// Listas
GestorDeTareas GestorTareas = new GestorDeTareas();
List<Tarea> ListaTareasPendientes = new List<Tarea>();
List<Tarea> ListaTareasRealizadas = new List<Tarea>();

string op;
do{
    do
    {
  
         Console.WriteLine("\n\n------OPERACIONES A REALIZAR-----");
      Console.WriteLine("1). Agregar una nueva tarea a Pendientes");
      Console.WriteLine("2). Mostrar lista de tareas pendientes");
      Console.WriteLine("3). Mostrar lista de tareas realizadas");
      Console.WriteLine("4). Transferir tareas de la lista Pendientes a Realizadas por ID");
      Console.WriteLine("5). Buscar Tarea Por palabra  clave");
      Console.WriteLine("6). Finalizar");
      Console.WriteLine("Seleccione una opcion: ");
        
        op = Console.ReadLine();
        
    } while (!int.TryParse(op, out operacion));

    switch (operacion)
    {
    case 1:
            Console.WriteLine("\nTAREAS QUE DESEA INGRESAR:");
            int cantidad;
            string ingresa;

            do
            {
                ingresa = Console.ReadLine();
                if(!int.TryParse(ingresa, out cantidad))
                {
                    Console.WriteLine("\nNo ha ingresado una cantidad valida");
                }

            } while (!int.TryParse(ingresa, out cantidad));
            ListaTareasPendientes = GestorTareas.crearNTareas(cantidad);

           break;

    case 2:
            int j = 0;
            Console.WriteLine("\n---Tareas pendientes");
            foreach (Tarea tarea in ListaTareasPendientes)
            {
                j++;
                Console.WriteLine($"\nTarea {j}");
                Console.WriteLine($"\nID: {tarea.ID}");
                Console.WriteLine($"\nDescripcion: {tarea.Descripcion}");
                Console.WriteLine($"\nDuracion: {tarea.Duracion}");
            }
            break;
    case 3:
            int m = 0;
            Console.WriteLine("\n---Tareas realizadas");
            foreach (Tarea tarea in ListaTareasRealizadas)
            {
                m++;
                Console.WriteLine($"\nTarea {m}");
                Console.WriteLine($"\nID: {tarea.ID}");
                Console.WriteLine($"\nDescripcion: {tarea.Descripcion}");
                Console.WriteLine($"\nDuracion: {tarea.Duracion}");
            }
            break;
    case 4:
            string id;
            int Id;
            do
            {
                
                Console.WriteLine("\nID de la tarea que desea tranferir a TAREAS REALIZADAS: ");
                id = Console.ReadLine();
            } while (!int.TryParse(id, out Id));

            GestorTareas.moverTareasARealizadasId(ListaTareasPendientes,ListaTareasRealizadas,Id);
            break;
    case 5:
            Console.WriteLine("\nDescripcion de la tarea a buscar");
            string descripcion = Console.ReadLine();
            Tarea TareaBuscada = GestorTareas.BuscarTareaPorDescripcion(ListaTareasPendientes,descripcion);
            if(TareaBuscada != null)
            {
                Console.WriteLine("\n-Tarea: ");
                Console.WriteLine($"\n-ID: {TareaBuscada.ID}");
                Console.WriteLine($"\n-Descripcion: {TareaBuscada.Descripcion}");
                Console.WriteLine($"\n-Duracion: {TareaBuscada.Duracion}");
            }else
            {
                Console.WriteLine("\nLa descripcion ingresada no se corresponde con ninguna tarea");
            }
            break;
            }
    
 }while(operacion!=6);


 Console.WriteLine("-------EJERCICIO 2-------");

 // lista 
 Calculadora nuevaCalculadora = new Calculadora();

 int control;
        Console.WriteLine("\n=============CALCULADORA===============\n");
        do
        {
            Console.WriteLine("\n1)Suma");
            Console.WriteLine("\n2) Resta");
            Console.WriteLine("\n3) Multiplicacion");
            Console.WriteLine("\n4)Division");
            Console.WriteLine("\n5)Limpiar");
            Console.WriteLine("\n6)Historial");
            Console.WriteLine("\nOperacion a realizar: ");
            //string Respuesta = Console.ReadLine();

            double num = 0;
            int valorOperacion;

            if (int.TryParse(Console.ReadLine(), out valorOperacion))
            {
                if (valorOperacion <= 6 && valorOperacion > 0)
                {
                    if (valorOperacion != 5)
                    {
                        //string numero1;
                        do
                        {
                            Console.WriteLine("\nIngrese el primer numero: ");
                           // numero1 = Console.ReadLine();
                        } while (!double.TryParse(Console.ReadLine(), out num));
                    }

                    switch (valorOperacion)
                    {
                        case 1:
                            nuevaCalculadora.Sumar(num);
                            Console.WriteLine("\nLa suma de los numeros es " + nuevaCalculadora.Resultado);
                            break;
                        case 2:
                            nuevaCalculadora.Resta(num);
                            Console.WriteLine("\nLa diferencia de los numeros es " + nuevaCalculadora.Resultado);
                            break;
                        case 3:
                            nuevaCalculadora.Multiplicacion(num);
                            Console.WriteLine("\nEl producto de los numeros es " + nuevaCalculadora.Resultado);
                            break;
                        case 4:
                            nuevaCalculadora.Division(num);
                            Console.WriteLine("\nEl cociente de los numeros es " + nuevaCalculadora.Resultado);
                            break;
                        case 5:
                             nuevaCalculadora.Limpiar();
                            Console.WriteLine("\nEl dato limpio es: " + nuevaCalculadora.Resultado);
                            break;
                        case 6:
                             int m=1;

                              if (nuevaCalculadora.Historial != null)
                              {

                             foreach(Calculadora.Operacion oper in nuevaCalculadora.Historial)
                             {
                                Console.WriteLine($"\n--Operacion Nro {m}");
                                Console.WriteLine($"\nDato de entrada: {oper.ResultadoAnterior}");
                                Console.WriteLine($"\n Operacion realizada: : {oper.OperacionRealizar}");
                                Console.WriteLine($"\nResultado: {oper.NuevoValor}");
                                
                                m++;

                             }

                              } else
                              {
                                Console.WriteLine($"Historial vacio.");
                               }
                              break;

                    }
                }
                else
                {
                    Console.WriteLine("\nOperacion invalida (1-6)");
                }
            }
            else
            {
                Console.WriteLine("\n Nro ingresado invalido.");
            }

            Console.WriteLine("\nDesea seguir operando? 1)Si/ 0)No");
            //string seguirOperando = Console.ReadLine();
            if (!int.TryParse(Console.ReadLine(), out control))
            {
                control = 1;
            }

        } while (control != 0);
 
