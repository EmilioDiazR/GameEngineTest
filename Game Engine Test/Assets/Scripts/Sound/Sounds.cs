using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip Win;
    [SerializeField] private AudioClip Coins;
    [SerializeField] private AudioClip Jump;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void soundWin(){
        audioSource.PlayOneShot(Win);
    }

    public void soundCoins(){
        audioSource.PlayOneShot(Coins);
    }
     public void soundJump(){
        audioSource.PlayOneShot(Jump);
    }
}
