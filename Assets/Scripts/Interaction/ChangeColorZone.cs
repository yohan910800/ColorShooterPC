using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MankindGames;

public class ChangeColorZone : MonoBehaviour
{
    public PathFinderAI meleeEnemyScript;
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    void MeleEnemyReScanPath()
    {
        meleeEnemyScript.EnemyScanPath();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            gm.ActiveChangeColor();
            MeleEnemyReScanPath();
        }
    }
}
