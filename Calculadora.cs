namespace EspacioCalculadora
{
    public enum TipoOperacion 
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }
    public class Calculadora
    {
        double dato;
         public double Resultado {get=> dato;}
        private List<Operacion>historial;
        public List<Operacion> Historial { get => historial; set => historial = value; }

        // Operaciones

        public void Sumar (double termino)
        {
            double anterior= dato; 
            dato = dato + termino;
            TipoOperacion operacion=TipoOperacion.Suma;
            Operacion realizoOp = new Operacion(anterior, dato,operacion);

            if (Historial== null)
            {
                Historial= new List<Operacion>();
            }
            Historial.Add(realizoOp);
        }

        public void Resta (double termino)
        {
            double anterior= dato; 
            dato = dato - termino;
            TipoOperacion operacion=TipoOperacion.Suma;
            Operacion realizoOp = new Operacion(anterior, dato,operacion);

            if (Historial== null)
            {
                Historial= new List<Operacion>();
            }
            Historial.Add(realizoOp);

        }

        public void Multiplicacion( double termino)
        {
            double anterior= dato; 
            dato = dato * termino;
            TipoOperacion operacion=TipoOperacion.Suma;
            Operacion realizoOp = new Operacion(anterior, dato,operacion);

            if (Historial== null)
            {
                Historial= new List<Operacion>();
            }
            Historial.Add(realizoOp);
        }

        public void Division (double termino)
        {
            if (termino!=0)
            { 

            double anterior= dato; 
            dato = dato / termino;
            TipoOperacion operacion=TipoOperacion.Suma;
            Operacion realizoOp = new Operacion(anterior, dato,operacion);

            if (Historial== null)
            {
                Historial= new List<Operacion>();
            }
            Historial.Add(realizoOp);

            } else
            {
                Console.WriteLine("No se puede divir en 0");
            }
        }

        public void Limpiar()
        {
            double anterior= dato; 
            dato = 0;
            TipoOperacion operacion=TipoOperacion.Suma;
            Operacion realizoOp = new Operacion(anterior, dato,operacion);

            if (Historial== null)
            {
                Historial= new List<Operacion>();
            }
            Historial.Add(realizoOp);
        }
    

      public class Operacion 
     {
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion operacion;
        
        public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
        public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
        public TipoOperacion OperacionRealizar { get => operacion; set => operacion = value; }

        public Operacion (double resulAnt, double resulNuevo, TipoOperacion operacion) 
        {
            ResultadoAnterior= resulAnt;
            NuevoValor=resulNuevo;
            OperacionRealizar=operacion;

        }
    }
   }
}