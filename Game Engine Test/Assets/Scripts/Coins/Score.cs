using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// En este script hace la función de acumular y mostrar la cantidad de monetas obtenidas.
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// Se asignas lo valores publicos para usarse fuera del script.
    /// </summary>
    // instance es un valor publico estatico que se usará para ser invocado en otro script.
    public static Score instance;
    
    // scoreText pide el texto donde se mostrara la cantidad de monedas obtenidas.
    public TextMeshProUGUI scoreText;
    // score es el valor entero que acumulará las monedas.
    private int score = 0;
    public int ScorePriv {
        get{return score; }
        set{score = value;}
    }
    /// <summary>
    /// Función que instancia el valor.
    /// </summary>
    private void Awake(){
        instance = this;
    }
    /// <summary>
    /// Inica con el valor actual de la moneda en el texto asignado.
    /// </summary>
    void Start()
    {
        //Muestra en texto el valor actual del score más un texto COINS para complementarlo.
        scoreText.text = score.ToString() + " COINS";
    }

    /// <summary>
    /// Esta función agrega el valor de score. Además de que esta misma función será llamada en otro script.
    /// </summary>
    public void AddPoint(){
        //Al valor actual de score se le sumara 1.
        score += 1;
        //Muestra en texto el valor actual del score más un texto COINS para complementarlo.
        scoreText.text = score.ToString() + " COINS";
    }
   
}
