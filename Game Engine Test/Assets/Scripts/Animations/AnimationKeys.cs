using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

/// <summary> 
/// Controla las animaciones del modelo por medio de Keys del teclado.
/// </summary> 
public class AnimationKeys : MonoBehaviour
{
    
    /// <summary> 
    /// Pide el animator que contiene las animaciones creadas.
    /// </summary> 
    private Animator Animacion;
    
    /// <summary> 
    /// Inicia con las condiciones necesarias para las animaciones.
    /// </summary> 
    void Start()
    {
        //Optiene los componentes del animator asignado.
        Animacion = gameObject.GetComponent<Animator>();
        
    }

    /// <summary> 
    /// Actualiza las animaciones que se estarian ejecutando.
    /// </summary> 
    void Update()
    {   
        //Si se deja precionado W se activa la animacion de caminar, si no se desactiva.
        if(Input.GetKey("w")){

            Animacion.SetBool("Walk", true);
            Debug.Log("w key was pressed");

        }else{

            Animacion.SetBool("Walk", false);
        }

        //Si se deja precionado S se activa la animacion de correr, si no se desactiva.
        if(Input.GetKey("s")){

            Animacion.SetBool("Run", true);
            Debug.Log("s key was pressed");

        }else{
           
            Animacion.SetBool("Run", false);

        }

        //Si se deja precionado SPACE se activa la animacion de saltar, si no se desactiva.
        if(Input.GetKey("space")){
           
            Animacion.SetBool("Jump", true);
            Debug.Log("space key was pressed");

        }else{
           
            Animacion.SetBool("Jump", false);

        }
    }
}
