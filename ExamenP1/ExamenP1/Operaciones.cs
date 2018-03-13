using System;
namespace ExamenP1
{
    public class Operaciones
    {
        public double numero1
        {
            get;
            set;
        }

        public double numero2
        {
            get;
            set;
        }

        public Operaciones()
        {
            
        }

        public Operaciones (double numero1, double numero2){
            this.numero1 = numero1;
            this.numero2 = numero2;
        }

        public double Suma(double numero1, double numero2){
            return numero1 + numero2;
        }

        public double Resta(double numero1, double numero2)
        {
            return numero1 - numero2;
        }

        public double Multi(double numero1, double numero2)
        {
            return numero1 * numero2;
        }

        public double Divi(double numero1, double numero2)
        {
            return numero1 / numero2;
        }
    }
}
