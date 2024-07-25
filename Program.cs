// See https://aka.ms/new-console-template for more information


using GestionTareas

Console.WriteLine("=======TP4- LISTAS Y CLASES CON C#==========");
Console.WriteLine("---EJERCICIO 1-----");



GestorDeTareas GestorTareas = new GestorDeTareas();
List<Tareas> ListaTareasPendientes = new List<Tareas>();
List<Tareas> ListaTareasRealizadas = new List<Tareas>();
string op;
int operacion;
do{
    do
    {
        Console.WriteLine("\nIndique que tarea desea realizar: \n1.Agregar Tareas\n2.Mostrar Lista de tareas pendientes\n3.Mostrar Lista de tareas realizadas\n4.Tranferir tarea de pendientes a realizado\n5.Buscar tarea por palabra clave\n6.Finalizar");
        op = Console.ReadLine();
        
    } while (!int.TryParse(op, out operacion));

    switch (operacion)
    {
    case 1:
            Console.WriteLine("\nIndique la cantidad de tareas que desea ingresar");
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
            Console.WriteLine("\nTareas pendientes");
            foreach (Tareas tarea in ListaTareasPendientes)
            {
                j++;
                Console.WriteLine($"\nTarea {j}");
                Console.WriteLine($"\nID: {tarea.TareaID}");
                Console.WriteLine($"\nDescripcion: {tarea.Descripcion}");
                Console.WriteLine($"\nDuracion: {tarea.Duracion}");
            }
            break;
    case 3:
            int k = 0;
            foreach (Tareas tarea in ListaTareasRealizadas)
            {
                k++;
                Console.WriteLine($"\nTarea {k}");
                Console.WriteLine($"\nID: {tarea.TareaID}");
                Console.WriteLine($"\nDescripcion: {tarea.Descripcion}");
                Console.WriteLine($"\nDuracion: {tarea.Duracion}");
            }
            break;
    case 4:
            string id;
            int Id;
            do
            {
                
                Console.WriteLine("\nIngrese el id de la tarea que desea marcar como realizado y transferirlo a la lista correspondiente: ");
                id = Console.ReadLine();
            } while (!int.TryParse(id, out Id));

            GestorTareas.TranferirTareaRealizadaporId(ListaTareasPendientes,ListaTareasRealizadas,Id);
            break;
    case 5:
            Console.WriteLine("\nIngrese la descripcion de la tarea que desea buscar");
            string descripcion = Console.ReadLine();
            Tareas TareaBuscada = GestorTareas.BuscarTareaPorDescripcion(ListaTareasPendientes,descripcion);
            if(TareaBuscada != null)
            {
                Console.WriteLine("\nLa tarea buscada es: ");
                Console.WriteLine($"\nID: {TareaBuscada.TareaID}");
                Console.WriteLine($"\nDescripcion: {TareaBuscada.Descripcion}");
                Console.WriteLine($"\nDuracion: {TareaBuscada.Duracion}");
            }else
            {
                Console.WriteLine("\nLa descripcion ingresada no se corresponde con ninguna tarea");
            }
            break;
    }
}while(operacion!=6);

