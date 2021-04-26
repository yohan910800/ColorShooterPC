using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MankindGames;
using System;

public class Interactable : MonoBehaviour {

    public event Action OnTrigger;

    protected Player player;
    
    protected TestInteractionManager interactionManager;


    protected virtual void Start(){
        //added_dohan--------------------------------------------
        player = GameObject.Find("Player").GetComponent<Player>();
        //-------------------------------------------------------

        Init();
    }
    protected virtual void Init() { }

    protected virtual void OnTriggered(){
        if(OnTrigger != null) OnTrigger();
    }
}
