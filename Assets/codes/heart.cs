using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    GameManager gameManager;
    public void Start()
    {
    gameManager=GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
         gameManager.gamepoint(true);
         Destroy(this.gameObject);
        }
    }
}
