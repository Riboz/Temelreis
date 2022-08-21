using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover : MonoBehaviour
{
   //kız her 2 saniyede 1 durup kalp spawnlar sonra kalp spawnladıktan 1 saniye sonra random bi şekilde sağa ya da sola koşar ve 2 saniye sonra bunları tekrarlar
public Transform[] posr;
public Transform[] posl;
public bool calis=true;
   public void Start()
   {
   StartCoroutine ( kizMechanic() ) ;
   }
   private IEnumerator kizMechanic()
   {
   
   while(calis)
   {

 
     int way = Random.Range( 0 , 2 );
    Debug.Log(way);
     yield return new WaitForSeconds( 2f ) ;
    
     
    if( way == 1 )
    {
    // for döngüsüyle karakteri sola yürüt tabikide movetowards la belirli bir sınıra kadar gidebilsin

    int transright=Random.Range( 0 , 3 );
    Debug.Log("r"+transright);

    for( int i = 0 ; i >= 0 ; i++ )
    {
       
      if( this.gameObject.transform.position != posr[transright].position ) 
      { 
        this.gameObject.transform.position= Vector3.MoveTowards( this.transform.position , posr[transright].position , 0.2f )  ;   
      }
      else
      {
        yield return new WaitForSeconds(1f);
      way=Random.Range(0,2);
      break;
      }

      yield return new WaitForSeconds(0.1f);


    } 
    }
    if( way == 0 )
    {
    int transleft = Random.Range( 0 ,3) ;
     Debug.Log("l"+transleft);
    for( int i = 0 ; i >= 0 ; i++ )
    {
      if ( this.gameObject.transform.position != posl[transleft].position ) 
      {
         this.gameObject.transform.position = Vector3.MoveTowards( this.transform.position , posl[transleft].position  , 0.2f ) ;  
      }
      else 
      {
            yield return new WaitForSeconds(1f);
        way=Random.Range(0,2);
         break;
        
      }
      yield return new WaitForSeconds( 0.1f );

      

    }
    
    }
     }

   //kız karakter durur ve öpücük atar
   }

}
