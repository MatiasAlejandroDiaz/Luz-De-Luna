using AdapterLDL;
using System.Diagnostics;

namespace PlayerLDL
{
    /// <summary>
    /// Clase que representa la acci�n de Dash en el jugador.
    /// </summary>
    public class Dash : PlayerAction 
    {
        // Atributos privados de la acci�n Dash

        private Stopwatch dashTimerColdown = null; // Cron�metro para controlar el cooldown del Dash.
        private bool isDashing = false; // Indica si el jugador est� actualmente realizando el Dash.
        private float dashTimer = 0f; // Tiempo transcurrido durante el Dash.
        private AVector3 dashStartPos = AVector3.Zero(); // Posici�n inicial del jugador antes de comenzar el Dash.
        private AVector3 dashEndPos = AVector3.Zero(); // Posici�n final del jugador despu�s de completar el Dash.
        private AVector3 playerVelocity = AVector3.Zero(); // Velocidad del jugador durante el Dash.

        private const string NAMEACTION = "Dash";
        private const string PARAMDISTANCENAME = "dashDistance";
        private const string PARAMDURATIONNAME = "dashDuration";
        private const string PARAMCOLDOWNNAME = "dashColdown";
        private const string PARAMPLAYERMOVNAME = "movement";
        private const string PARAMDIRECTIONNAME = "Direction";

        /// <summary>
        /// Constructor de la clase Dash.
        /// </summary>
        /// <param name="movement">Instancia del Movimiento que maneja La unidad.</param>
        /// <param name="DashDir">Direcci�n del Dash.</param>
        /// <param name="dashDistance">Distancia del Dash.</param>
        /// <param name="dashDuration">Duraci�n del Dash.</param>
        /// <param name="dashColdown">Cooldown del Dash.</param>
        public Dash(IMovement movement, AVector3 DashDir, float dashDistance, float dashDuration, int dashColdown)
            : base(NAMEACTION)
        {
            // Agregar los atributos espec�ficos de Dash a la lista de par�metros
            Parametros.AddParameter(PARAMDISTANCENAME, dashDistance);
            Parametros.AddParameter(PARAMDURATIONNAME, dashDuration);
            Parametros.AddParameter(PARAMCOLDOWNNAME, dashColdown);
            // Qui�n Maneja el Movimiento del Objeto
            Parametros.AddParameter(PARAMPLAYERMOVNAME, movement);
            Parametros.AddParameter(PARAMDIRECTIONNAME, DashDir);
        }

        /// <summary>
        /// M�todo que se ejecuta cuando se habilita la acci�n Dash.
        /// </summary>
        public override void OnEnableAction()
        {
            // Iniciar el cron�metro para el cooldown del Dash.
            dashTimerColdown = new Stopwatch();
            dashTimerColdown.Start();
        }

        /// <summary>
        /// M�todo que se ejecuta al activar la acci�n Dash.
        /// </summary>
        public override void StartAction()
        {
            // Verificar si el cooldown ha terminado y el jugador no est� actualmente realizando un Dash.
            if (!dashTimerColdown.IsRunning) dashTimerColdown.Start();
            if (isDashing) return;

            // Comprobar si ha transcurrido el cooldown requerido para activar el Dash.
            if (dashTimerColdown.Elapsed.Seconds >= Parametros.GetParameter<int>(PARAMCOLDOWNNAME))
            {
                // Iniciar el Dash.
                isDashing = true;
                // Congelar el movimiento del jugador mientras realiza el Dash.
                Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).Freeze = true;
                dashStartPos = Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).playerTransform.Position;
                dashEndPos =AVector3.Sum(dashStartPos , AVector3.Prod(Parametros.GetParameter<AVector3>(PARAMDIRECTIONNAME) , Parametros.GetParameter<float>(PARAMDISTANCENAME)));
                dashTimer = 0f;

                // Reiniciar el cron�metro de cooldown.
                dashTimerColdown.Reset();
                dashTimerColdown.Start();
            }

        }

        /// <summary>
        /// M�todo que se ejecuta cada frame mientras se est� realizando el Dash.
        /// </summary>
        public override void UpdateActions()
        {
            // Verificar si el jugador est� actualmente realizando el Dash.
            if (isDashing)
            {
                // Realizar el Dash.
                PerformDash();
                return;
            }
        }

        /// <summary>
        /// Realiza el Dash, moviendo al jugador desde la posici�n inicial hacia la posici�n final.
        /// </summary>
        private void PerformDash()
        {
            // Verificar si el Dash ha alcanzado su duraci�n m�xima.
            if (dashTimer < Parametros.GetParameter<float>(PARAMDURATIONNAME))
            {
                // Calcular la posici�n intermedia del jugador durante el Dash.
                float t = dashTimer / Parametros.GetParameter<float>(PARAMDURATIONNAME);
                AVector3 newPosition = AVector3.Lerp(dashStartPos, dashEndPos, t);
                // Calcular la velocidad del jugador durante el Dash.
                playerVelocity = (AVector3.Div(AVector3.Res(newPosition , Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).playerTransform.Position) , UnityEngine.Time.deltaTime));
                dashTimer += UnityEngine.Time.deltaTime;

                // Aplicar la nueva posici�n calculada al jugador.
                Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).MoveInDirection(AVector3.Res(newPosition , Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).playerTransform.Position));
            }
            else
            {
                // Finalizar el Dash.
                StopAction();
            }
        }

        /// <summary>
        /// M�todo que se ejecuta al finalizar la acci�n Dash.
        /// </summary>
        public override void StopAction()
        {
            // Finalizar el Dash.
            isDashing = false;
            Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).playerTransform.Position = dashEndPos;
            playerVelocity = AVector3.Zero();
            // Reactivar el movimiento del jugador despu�s del Dash.
            Parametros.GetParameter<PlayerMovement>(PARAMPLAYERMOVNAME).Freeze = false;
        }

        /// <summary>
        /// M�todo que se ejecuta cuando se deshabilita la acci�n Dash.
        /// </summary>
        public override void OnDisableAction()
        {
            // Detener el Dash y el cron�metro de cooldown.
            StopAction();
            dashTimerColdown.Stop();
        }

        /// <summary>
        /// M�todo que se ejecuta cuando se destruye la acci�n Dash.
        /// </summary>
        public override void OnDestroyAction() => OnDisableAction();
        
    }
}