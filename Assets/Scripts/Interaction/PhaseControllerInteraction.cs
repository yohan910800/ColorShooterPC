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
        //player.GetHit(100);
        mapManager.ActivatePhase(mapManager.phase);
        mapManager.phase++;
        if (collision.tag == "Player")
        {
            //saveSystemManager.OnHitSaveData(collision);
        }
        
    }
}
