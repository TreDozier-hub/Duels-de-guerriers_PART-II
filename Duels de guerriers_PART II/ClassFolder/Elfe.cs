﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duels_de_guerriers_PART_II.ClassFolder
{
    internal class Elfe : Guerrier
    {

        public Elfe(string nom, int pointsDeVie, int nbDesAttaque) : base(nom, pointsDeVie, nbDesAttaque)
        {
            TypeGuerrier = "Elfe";
        }

        //int PointsDeVie = newPv - 10;

        // Réduit les points de vie
        public override void SubirDegats(int degats)
        {
            //int newPv = PointsDeVie - 10;
            PointsDeVie -= degats - 2;
            return;
        }

    }
}
