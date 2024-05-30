using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Objeto : BaseActor
{
    
    public CategoriaObjeto Categoria;

    // Variables específicas para Tirar Objetos
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
        // Implementa la lógica para activar el movimiento del objeto
    }

    public override void Desactivar()
    {
        // Implementa la lógica para desactivar el movimiento del objeto
    }
}
public enum CategoriaObjeto
{
    Tirable,
    Destructible,
    Animado,
    // Agrega más categorías según tus necesidades
}
// Agrega más clases derivadas para cada categoría de evento según tus necesidades
