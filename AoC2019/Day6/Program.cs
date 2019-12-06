using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = File.ReadAllLines(@"C:\Users\matt.hurdle\source\repos\AoC2019\AoC2019\input.txt");
            string[] input = File.ReadAllLines(@"C:\Users\matt.hurdle\source\repos\AoC2019\AoC2019\input-real.txt");

            int count = 0;

            OrbitMap om = new OrbitMap(input);
            om.mapOrbits();

            foreach(KeyValuePair<string, Orbit> orb in om.orbitMap)
            {
                int countOrbits = om.countIndirectOrbits(orb.Value);
                count += countOrbits;
            }

            Orbit santa = om.orbitMap["SAN"];
            Orbit me = om.orbitMap["YOU"];

            om.distanceToSanta(me, santa);

            int a = 3;
        }
    }
}
