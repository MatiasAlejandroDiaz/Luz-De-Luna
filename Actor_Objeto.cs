using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Objeto : BaseActor
{
    
    public CategoriaObjeto Categoria;

    // Variables espec�ficas para Tirar Objetos
    public Vector3 direccionMovimiento;
    public float fuerzaMovimiento;
    private Rigidbody rigidbodyObjeto;

    //Variables Especificas para Destruir Objetos
    public bool destruir;
    public float tiempoDeRetardoDestruccion;

    //Variables Animar Objeto
    private Animator animadorObjeto;
    public string nombreDeLaAnimacionDelObjeto;

    public override void Activar()
    {
        // Implementa la l�gica para activar el movimiento del objeto
    }

    public override void Desactivar()
    {
        // Implementa la l�gica para desactivar el movimiento del objeto
    }
}
public enum CategoriaObjeto
{
    Tirable,
    Destructible,
    Animado,
    // Agrega m�s categor�as seg�n tus necesidades
}
// Agrega m�s clases derivadas para cada categor�a de evento seg�n tus necesidades
