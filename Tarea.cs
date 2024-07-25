namespace GestionTareas
{
    class Tarea
    {
        private int id; 
        private string descripcion; 
        private int duracion; 
        private Estados estado;


        
        public int ID { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }
        public Estados Estado { get => estado; set => estado = value; }

        public Tarea (int id, string descripcion, int curacion, Estados estado)
        {
            ID=id;
            Descripcion=descripcion;
            Duracion=duracion;
            Estado=estado;

        }
    }; // Fin primera clase

   
    class GestorDeTareas
    {
        public List<Tarea> crearNTareas(int n)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            int id = 1000;
            var semilla = Environment.TickCount;
            var random = new Random(semilla);
            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nIngrese la descripcion de la tarea {i+1}");
                string descripcion = Console.ReadLine();
                int duracion = random.Next(10, 101);

                Tarea tarea = new Tarea(id, descripcion, duracion, Estados.Pendiente);

                listaTareas.Add(tarea);

                id++;
            }
            return listaTareas;
        }

        public void moverTareasARealizadasId(List<Tarea> pendientes, List<Tarea> realizadas, int id)
        {
            int i = 0;

            while (i < pendientes.Count && pendientes[i].ID != id)i++;
            if (pendientes[i].ID == id)
            {
                Tarea tareaATransferir= pendientes[i];

                tareaATransferir.Estado = Estados.Realizada;

                realizadas.Add(tareaATransferir);
                pendientes.Remove(tareaATransferir);

            } else
            {
                Console.WriteLine("\nNo existe una tarea con ese ID");
            }
        }

           public Tarea BuscarTareaPorDescripcion(List<Tarea> Pendientes, string descripcion)
       {
          Tarea TareaBuscada = null;
          foreach (Tarea tarea in Pendientes)
          {
            if(tarea.Descripcion == descripcion)
            {
                TareaBuscada = tarea;
            }
          }
          return TareaBuscada;
       }

    }
}