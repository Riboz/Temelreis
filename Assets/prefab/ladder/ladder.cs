using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    temelmovement temelmov;
    
    
   
   public void Start()
   {
    temelmov = GameObject.FindGameObjectWithTag ( "Player" ).GetComponent<temelmovement>() ;
   }
    void OnTriggerEnter2D(Collider2D temeldegecek)
    {
     if ( temeldegecek.CompareTag ( "Player" ) )
     {
     temelmov.temelcanclimb ( true ) ;
    

     temelmov.saved = GameObject.FindGameObjectWithTag ( "Player" ).transform ;
     
     }

    }

    
     void OnTriggerExit2D(Collider2D temeldegecek)
    {
     if ( temeldegecek.CompareTag ( "Player" ) )
     {
      temelmov.temelcanclimb ( false ) ;
     
     }

    }

public float timer=0;

    void OnTriggerStay2D(Collider2D temeldegecek)
    {
     if ( temeldegecek.CompareTag ( "Player" ) )
     {
        //if(Vector2.Distance(this.gameObject.transform.position.y,GameObject.FindGameObjectWithTag("Player").transform.position.y))
        //amacım eğer temelreis merdivenin altındaysa o merdivenle aşağı gidememesi ve bunun için burada bir boolu ona göre aktifleştiricem ve temelmovementdeki 
        //downladdere tıklamamasını sağlayacağım
        timer += Time.deltaTime ;
        if ( timer > 2)
        {
          temelmov.temelcanclimb ( true ) ;  
          timer = 0 ;
        }
       
     }
    }
}
