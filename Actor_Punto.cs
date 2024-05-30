using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Punto : BaseActor
{
    public Vector3 Punto;
    public TipoDePunto tipoDePunto = TipoDePunto.Ventana;

    [Header("Variables Para La Categoria Ventana: El Punto sera considerado un Objeto Transparente y por lo tanto tendra dos lugares para Instanciar")]
    public float DistanciaRespectoAlPunto = 4f;
    public DirPrinVentana direccionCaraDeLaVentana = DirPrinVentana.EjeX;
    public override void Activar()
    {
        throw new System.NotImplementedException();
    }

    public override void Desactivar()
    {
        throw new System.NotImplementedException();
    }

    public Vector3 GetPuntoCorrecto(Vector3 PosicionTarget)
    {
        if(tipoDePunto == TipoDePunto.Ventana)
        {
            Vector3 pos1,pos2;

            switch (direccionCaraDeLaVentana)
            {
                case DirPrinVentana.EjeX:
                    pos1 = new Vector3(transform.position.x - DistanciaRespectoAlPunto, transform.position.y, transform.position.z);
                    pos2 = new Vector3(transform.position.x + DistanciaRespectoAlPunto, transform.position.y, transform.position.z);
                    //Implementar
                    break;
                case DirPrinVentana.EjeY:
                    break;
                case DirPrinVentana.EjeZ:
                    break;
            }
            
        }
        return Punto;
    }
}
public enum TipoDePunto
{
    Ventana,
    Efecto,
    // Agrega más categorías según tus necesidades
}
public enum DirPrinVentana
{
    EjeX,
    EjeY,
    EjeZ,
}