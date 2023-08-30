using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class AnimationKeys : MonoBehaviour
{
    
    public Animator Animacion;
    // Start is called before the first frame update
    void Start()
    {
        Animacion = gameObject.GetComponent<Animator>();
        //Npc=GameObject.Find("Paladin").GetComponent<AnimationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")){

            Animacion.SetBool("Walk", true);
            Debug.Log("w key was pressed");

        }else{

            Animacion.SetBool("Walk", false);
        }

        if(Input.GetKey("s")){

            Animacion.SetBool("Run", true);
            Debug.Log("s key was pressed");

        }else{
           
            Animacion.SetBool("Run", false);

        }

        if(Input.GetKey("space")){
           
            Animacion.SetBool("Jump", true);
            Debug.Log("space key was pressed");

        }else{
           
            Animacion.SetBool("Jump", false);

        }
    }
}
