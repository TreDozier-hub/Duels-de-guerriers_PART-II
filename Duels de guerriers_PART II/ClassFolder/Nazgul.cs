using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duels_de_guerriers_PART_II.ClassFolder
{
    internal class Nazgul : Guerrier
    {
        public Nazgul(string nom, int pointsDeVie, int nbDesAttaque) : base(nom, pointsDeVie, nbDesAttaque)
        {
        }
        // Réduit les points de vie
        public string SubirDegats(int degats)
        {

            {
                PointsDeVie -= degats + 2 + NbAttaque;
                return "Les dégats sont lourds";
            }


        }
    }       
}


