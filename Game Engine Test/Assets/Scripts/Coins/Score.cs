using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI scoreText;

    public int score = 0;
    

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " COINS";
    }

    public void AddPoint(){
       score += 1;
       scoreText.text = score.ToString() + " COINS";
    }
   
}
