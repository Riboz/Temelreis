using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Laddertype{laddernormal,ladderspecial}
public class ladder : MonoBehaviour
{
    public Laddertype lad;
    temelmovement temelmov;
    
    GameObject temel;
   
   public void Start()
   {
    temel=GameObject.FindGameObjectWithTag("Player");
    temelmov = GameObject.FindGameObjectWithTag ( "Player" ).GetComponent<temelmovement>() ;
   }
    void OnTriggerEnter2D(Collider2D temeldegecek)
    {
     if ( temeldegecek.CompareTag ( "Player" ) )
     {
     temelmov.temelcanclimb ( true ) ;
     
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
        
        //eğer 1 kere inmiş ve distance i0 dan küçükse aşağı inemesin distance i 0 dan büyükse 1 kere inebilsin
        
      if(lad==Laddertype.ladderspecial)
        {
         if ( temel.transform.position.y - this.transform.position.y < 0 )
      {
        //aşağı inemesin boolu aktif
        temelmov.notdown ( false ) ;
        Debug.Log ( "asagi gidemez" ) ;
      }
      else
      {
        Debug.Log ( "asagi gider" ) ;
        temelmov.notdown ( true ) ;
      }
       if ( temel.transform.position.y - this.transform.position.y > 0 )
      {
        //aşağı inemesin boolu aktif
        temelmov.notup ( false ) ;
        Debug.Log ( "yukarı çıkamaz" ) ;
      }
      else
      {
        Debug.Log ( "yukarı gider" ) ;
        temelmov.notup ( true ) ;
      }
        }
        if(lad==Laddertype.laddernormal)
     {
    
         temelmov.notup ( true) ;
         temelmov.notdown ( true ) ;
     }
     
     
    
        if ( timer > 2)
        {
          temelmov.temelcanclimb ( true ) ;  
          timer = 0 ;
        }
       
     }

    }
}
