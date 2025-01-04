using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duels_de_guerriers_PART_II.ClassFolder
{
    internal class Nain : Guerrier
    {
        private bool portArmure;
        public Nain(string nom, int pointsDeVie, int nbDesAttaque, bool portArmure) : base(nom, pointsDeVie, nbDesAttaque)
        {
            TypeGuerrier = "Nain";
        }

        private bool ArmureLourde()
        {
            Random avecSans = new Random();
            int portArmure = avecSans.Next(0, 2);
            return portArmure == 1; // Si "1" amrure porté - True
        }

        // Réduit les points de vie
        public override void SubirDegats(int degats)
        {
            if (ArmureLourde())
            {
                PointsDeVie -= degats / 2;
                Console.WriteLine($"{NomGuerrier} subit {degats / 2} dégâts grâce à l'armure de la mort");
            }
            else
            {
                PointsDeVie -= degats;
                PointsDeVie.ToString();// les dégâts change pas si l'armure est false
            }

        }
    }
}
