using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    class OrbitMap
    {
        public Dictionary<string, Orbit> orbitMap;
        string[] orbits;

        public OrbitMap(string[] _orbits)
        {
            orbitMap = new Dictionary<string, Orbit>();
            orbits = _orbits;
        }

        public int countIndirectOrbits(Orbit orb)
        {
            int indirectCount = 0;

            //count backwards from orb until we hit a node with no parent (the root)

            bool atRoot = false;
            Orbit currentOrbit = orbitMap[orb.id];

            while (!atRoot)
            {   
                if(currentOrbit.parent == null)
                {
                    atRoot = true;
                }                 
                else
                {
                    indirectCount++;
                    currentOrbit = orbitMap[currentOrbit.parent.id];
                }
            }

            return indirectCount;
        }

        public int findIntersect(Orbit orb1, Orbit orb2)
        {
            int indirectCount = 0;

            //count backwards from orb until we hit a node with no parent (the root)

           
           

            return indirectCount;
        }

        public void mapOrbits()
        {
            foreach(string s in orbits)
            {
                string[] orbitSplit = s.Split(')');

                Orbit newOrbit;
                Orbit childOrbit;

                //Find out if either of the two new objects exists already
                if(!orbitMap.ContainsKey(orbitSplit[0]))
                {
                    //object 1 doesn't exist, so create it, in this case we won't have parents for it
                    newOrbit = new Orbit(orbitSplit[0]);
                    orbitMap.Add(newOrbit.id, newOrbit);
                }
                else
                {
                    newOrbit = orbitMap[orbitSplit[0]];
                }

                if (!orbitMap.ContainsKey(orbitSplit[1]))
                {
                    //object 2 doesn't exist, so create it
                    childOrbit = new Orbit(orbitSplit[1], orbitMap[orbitSplit[0]]);
                    orbitMap.Add(childOrbit.id, childOrbit);
                }
                else
                {
                    childOrbit = orbitMap[orbitSplit[1]];
                    childOrbit.parent = orbitMap[orbitSplit[0]];
                }

                Orbit parent = childOrbit.parent;
                parent.addChild(childOrbit);
            }
        }
    }
}
