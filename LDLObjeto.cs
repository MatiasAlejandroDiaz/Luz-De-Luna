using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ObjetosLDL
{
    public class LDLObjeto
    {
        public LDLObjeto(string name, string description, Vector3 position, LDLModelo model)
        {
            Name = name;
            Description = description;
            Position = position;
            Model = model;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Vector3 Position { get; set; }
        public LDLModelo Model { get; set; }

        public GameObject CreateObjectInstance(Vector3 position, Quaternion rotation)
        {
            return Model.CreateInstance(position, rotation);
        }

    }


}
