using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControllerInteraction : Interactable
{
    MapManager mapManager;
    //public SaveSystemManager saveSystemManager;
    protected override void Start()
    {
        base.Start();
        if (GameObject.Find("MapManager").GetComponent<MapManager>() != null)// edited_dohan- caused an error in redCityMap. This would fix it while un-effecting other scenes
        {
            mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        mapManager.ActivatePhase(mapManager.phase);
        mapManager.phase++;
        //will be uncoment when we will reactivate the save system
        //if (collision.tag == "Player")
        //{
            
        //    //saveSystemManager.OnHitSaveData(collision);
        //}
        
    }
}
