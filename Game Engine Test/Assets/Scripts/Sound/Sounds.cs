using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Se asignan sonidos en metodos para poder invocarse en otros scripts.
/// </summary>
public class Sounds : MonoBehaviour
{   
    /// <summary>
    /// Se crean espacios para asignar los sonidos deseados.
    /// </summary>
    // Valor para el sonido.
    private AudioSource audioSource;
    // Se pedira un clip de audio para cuango el jugador gane.
    [SerializeField] private AudioClip Win;
    // Se pedira un clip de audio para cuando el jugador recolecte una moneda.
    [SerializeField] private AudioClip Coins;
    // Se pedira un clip de audio para cuando el jugaod salte.
    [SerializeField] private AudioClip Jump;
    
    /// <summary>
    /// Inicia con los valores asignados.
    /// </summary>
    void Start()
    {
        //Obtiene los componentes del AudioSource.
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Metodo para reproducir el sonido Win.
    /// </summary>
    public void soundWin(){
        // Reproduce una vez el sonido asignado en Win.
        audioSource.PlayOneShot(Win);
    }
    /// <summary>
    /// Metodo para reproducir el sonido Coins.
    /// </summary>
    public void soundCoins(){
        // Reproduce una vez el sonido asignado en Coins.
        audioSource.PlayOneShot(Coins);
    }
    /// <summary>
    /// Metodo para reproducir el sonido Jump.
    /// </summary>
     public void soundJump(){
        // Reproduce una vez el sonido asignado en Jump.
        audioSource.PlayOneShot(Jump);
    }
}
