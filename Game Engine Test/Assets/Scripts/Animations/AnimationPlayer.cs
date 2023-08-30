using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator Animacion;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        Animacion = gameObject.GetComponent<Animator>();
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walk (){
        Animacion.SetBool("Walk", true);
    }
    public void WalkOff (){
        Animacion.SetBool("Walk", false);
    }

    public void Run (){
        Animacion.SetBool("Run", true);
    }
    public void RunOff (){
        Animacion.SetBool("Run", false);
    }

    public void Jump (){
        Animacion.SetBool("Jump", true);
    }
    public void JumpOff (){
        Animacion.SetBool("Jump", false);
    }

}
