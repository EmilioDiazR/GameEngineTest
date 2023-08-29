using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class AnimationKeys : MonoBehaviour
{
    public AnimationPlayer Npc;
    // Start is called before the first frame update
    void Start()
    {
        Npc=GameObject.Find("Paladin").GetComponent<AnimationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")){
            Npc.Walk();
            Debug.Log("w key was pressed");
        }else{
            Npc.WalkOff();
        }

        if(Input.GetKey("s")){
            Npc.Run();
            Debug.Log("s key was pressed");
        }else{
            Npc.RunOff();
        }

        if(Input.GetKeyDown("space")){
            Npc.Jump();
            Debug.Log("space key was pressed");
        }else{
            Npc.JumpOff();
        }
    }
}
