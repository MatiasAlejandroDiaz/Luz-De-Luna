using UnityEngine;

 namespace ObjetosLDL
    {
        public class LDLModelo
        {
        public LDLModelo(GameObject modelPrefab, Material materialOverride, Vector3 scale)
        {
            ModelPrefab = modelPrefab;
            MaterialOverride = materialOverride;
            Scale = scale;
        }

        public GameObject ModelPrefab { get; set; } // Prefab del modelo 3D
            public Material MaterialOverride { get; set; } // Material opcional para reemplazar el material original
            public Vector3 Scale { get; set; } // Escala del modelo en el mundo

            public GameObject CreateInstance(Vector3 position, Quaternion rotation)
            {
                GameObject instance = Object.Instantiate(ModelPrefab, position, rotation);
                instance.transform.localScale = Scale;

                // Aplica el material si hay un override
                if (MaterialOverride != null)
                {
                    Renderer renderer = instance.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = MaterialOverride;
                    }
                }

                return instance;
            }
        }

    }
