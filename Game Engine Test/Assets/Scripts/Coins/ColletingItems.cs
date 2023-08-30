using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletingItems : MonoBehaviour
{
    public int coins;
    int scoreWin = 4;
    public Sounds sound;
    // Start is called before the first frame update
    void Start() {
         sound=GameObject.Find("AudioEffects").GetComponent<Sounds>();
    }
    public void OnTriggerEnter(Collider Col){
        if(Col.gameObject.tag == "Coin"){
            Debug.Log("Coin collected");
            Score.instance.AddPoint();
            sound.soundCoins();
            //coins = coins + 1;
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }

        if (Score.instance.score >= scoreWin){
            sound.soundWin();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
