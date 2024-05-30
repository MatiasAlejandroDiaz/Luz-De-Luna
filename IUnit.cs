using AdapterLDL;
using PlayerLDL;

namespace UnitsLDL
{
    //TODO HACERLA INTERFAZ
    public abstract class IUnit
    {
        //SUBSISTEMAS
        ////Global
        protected int id;
        //Interactuable
        protected Interactable interactuable;
        ////COMBATE

        ////ESTADISTICAS
        protected IAtributos unitAtributos;
        ////GRAFICO
        protected AGameObject gameObject;
        ////HABILIDADES y Acciones
        protected UnitActions actions;
        ////MOVIMIENTOS
        protected IMovement movement;
        ////IA
        //protected IAI ai;
        //////SONIDOS
        //protected ISoundEmisor sonido;
        //////INTERFAZ
        //protected IInterfaz interfaz;
        //////MISIONES
        //protected IMision mision;
        //////OBJETOS
        //protected IObjetos objetos;
        //////RECURSOS
        //protected IResources recursos;
        ///
        /// //Metodos generales para todas las unidades
        ///
        public IUnit(int unitId, AGameObject gameObject)
        {
            id = unitId;
            this.gameObject = gameObject;
        }

        #region UnityMethod

        public void Freeze()
        {
            actions.Active = false;
        }
        public void OnDestroy() => actions.OnDestroy();
        public void OnDisable() => actions.OnDisable();
        public void Start()
        {
            actions.Start();
        }
        public void UnFreeze()
        {
            actions.Active = true;
        }
        public void Update()
        {
            //movement.ProcessMovement();
            actions.Update();
        } 
        #endregion

        //// Propiedades para acceder a los subsistemas
        //public AGameObject GameObject => gameObject;
        //public IActions Actions => actions;
        //public IMovement Movement => movement;
        //public IAI AI => ai;
        //public ISoundEmisor Sonido => sonido;
        //public IInterfaz Interfaz => interfaz;
        //public IMision Mision => mision;
        //public IResources Recursos => recursos;
    }
}

