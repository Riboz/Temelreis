using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerfalse : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D coll)
  {
    if(coll.gameObject.CompareTag("Player"))
    { if(!coll.gameObject.GetComponent<temelmovement>().isdead)
        {
        coll.gameObject.GetComponent<Collider2D>().isTrigger=false;
        }
    }
  }
}
