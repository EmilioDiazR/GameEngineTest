using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permite al jugador usar el cursor para mover la rotación de la camara en el mapa.
/// </summary>
public class PlayerCam : MonoBehaviour
{
    /// <summary>
    /// Se asignan los valores para la rotación de la camara.
    /// </summary>
    // sensX es el valor de la sensibilidad en X.
    private float sensX = 400;
    // sensY es el valor de la sensibilidad en Y.
    private float sensY = 400;
    // orientation pedirá la orientación donde el jugador podrá mover la camara. 
    public Transform orientation;
    //xRotation es el valor en rotación en X.
    private float xRotation;
    //yRotation es el valor en rotación en Y.
    private float yRotation;

    /// <summary>
    /// Activa los valores asigandos para el cursor.
    /// </summary>
    private void Start()
    {
        //El cursor se bloquea y no se movera fuera de su lugar de manera visual.
        Cursor.lockState = CursorLockMode.Locked;
        //El cursor no será visible en el juego.
        Cursor.visible = false;
    }

    /// <summary>
    /// Acualiza el movimiento de la camara del jugador.
    /// </summary>
    private void Update()
    {   
        // Asigna los valores de la sensibiidad en x & y.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        // La rotación en y es aumentada a la posición del cursor en x.
        yRotation += mouseX;
        // La rotación en x es restada a la posición del cursor en y.
        xRotation -= mouseY;
        // regresa el valore que se asiganaron en la rotación.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rota la camara y la orientación.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
