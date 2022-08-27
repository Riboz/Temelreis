using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum wihch{sag,sol}
public class bordercode : MonoBehaviour
{
    public  wihch Whivh;
    // Start is called before the first frame update
  
    void OnTriggerEnter2D(Collider2D coll)
    {
       if(coll.gameObject.CompareTag("Player")||coll.gameObject.CompareTag("Boss"))
       {
        if(Whivh==wihch.sag)
        {
            coll.transform.position=new Vector3(-8.8f,coll.transform.position.y,coll.transform.position.z);
        }
       else
        {
            coll.transform.position=new Vector3(8.8f,coll.transform.position.y,coll.transform.position.z);
        }
       }
       
    }
}
