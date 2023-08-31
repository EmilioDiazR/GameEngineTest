using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Coloca la camara en la posición dada.
/// </summary> 
public class MoveCamera : MonoBehaviour
{

    /// <summary> 
    /// Pide la posición en la que se encontrará la camara.
    /// </summary> 
    public Transform cameraPosition;
 
    /// <summary> 
    /// Actualiza la ubicación de la camara a la posición que se asigno.
    /// </summary> 
    void Update()
    {   
        //La pocición del a camara es igual a la posición asignada.
        transform.position = cameraPosition.position;
    }
}
