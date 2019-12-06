using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    class Orbit
    {
        public Orbit parent;
        public List<Orbit> children;

        public string id;

        public Orbit(string _id, Orbit _parent)
        {
            id = _id;
            parent = _parent;
            children = new List<Orbit>();
        }

        public Orbit(string _id)
        {
            id = _id;
            children = new List<Orbit>();
            parent = null;
        }

        public void addChild(Orbit _child)
        {
            children.Add(_child);
        }


    }
}
