using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Cuando el jugador se acerca a la moneda, lo toma y se acumula la cantidad de esta misma.
/// </summary> 
public class ColletingItems : MonoBehaviour
{

    /// <summary> 
    /// Asigna los valores enteros para las monedas y un valor para el audio.
    /// </summary> 
    // Asigna un valor entero para las monedas.
    public int coins;
    // scoreWin es el valor entero que se requiere para ganar el juego.
    int scoreWin = 4;
    //sound es en valor que agarra del script sound para invocar otras funciones.
    public Sounds sound;
    
    /// <summary> 
    /// Al iniciar, agarra los valores asignados para el codigo.
    /// </summary> 
    void Start() {
        //Obtiene los componentes del sript Sound.
         sound=GameObject.Find("AudioEffects").GetComponent<Sounds>();
    }

    /// <summary>
    /// Metodo que, al momento de que la moneda entre en colisión con otro objeto ejecute las funciones.
    /// </summary>
    public void OnTriggerEnter(Collider Col){

        //Si un objeto colisiona con otro objeto con el tag Coin se hace llamar la función de agregar moneda, ejecuta un sonido y se destruye.
        if(Col.gameObject.tag == "Coin"){
            Debug.Log("Coin collected");
            Score.instance.AddPoint();
            sound.soundCoins();
            Destroy(Col.gameObject);
        }

        //Si la cantidad acumulada del score es mayor o igual al valor de scoreWin, ejecutara el sonido de victoria.
        if (Score.instance.score >= scoreWin){
            sound.soundWin();
        }
    }

}
