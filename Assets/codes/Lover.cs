using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover : MonoBehaviour
{
   //kız her 2 saniyede 1 durup kalp spawnlar sonra kalp spawnladıktan 1 saniye sonra random bi şekilde sağa ya da sola koşar ve 2 saniye sonra bunları tekrarlar
public Transform[] posr ;
[Header("lover")]
public const string walk = "walk" ;
public const string kiss = "kiss" ;
public Transform[] posl ;
public GameObject hearth;
public Transform heartspawn;
public bool calis = true ;
public animations animstate ;
int way,newway;

   public void Start()
   {
  // gamestart olunca spawnlarım yükseklik 5 olucak
    way=0;
   StartCoroutine ( kizMechanic() ) ;
   }
   private IEnumerator kizMechanic()
   {

   while(calis)
   { 

    if( way == 1 )

    {

    int transright = Random.Range ( 0 , 3 ) ;

    
 
    if(Vector2.Distance(this.gameObject.transform.position,posr[transright].position)>0)
    
    {
    
     this.gameObject.transform.localScale =new Vector3(1,1,1) ;

    }

    else
    
    {
    
         this.gameObject.transform.localScale =new Vector3(-1,1,1) ;
    
    }

    for( int i = 0 ; i >= 0 ; i++ )
    {
       
      if( this.gameObject.transform.position != posr[ transright ].position ) 
    
      { 
           
        this.gameObject.transform.position= Vector3.MoveTowards( this.transform.position , posr[transright].position , 0.2f )  ;   
      
      }
      
      else
      
      {
        
         animstate.AnimationState ( kiss ) ;
      
         GameObject kalp=Instantiate(hearth,heartspawn.position,Quaternion.identity)as GameObject;
   
         yield return new WaitForSeconds ( 1f ) ;
       
         animstate.AnimationState ( walk ) ;
      
         int newway = Random.Range ( 0 , 2 ) ;
    
      if( newway == way )
     
     {
        if ( newway == 1 )
       
        {
           way = 0 ;
          
           break ;
       
        } 
       
        else if ( newway == 0 )
        {
             way = 1 ;
             break ;
        }
      }
       else way = newway ;
       break ;
      
      }

      yield return new WaitForSeconds ( 0.1f ) ;


    } 
    }
    if ( way == 0 )
    {

    int transleft = Random.Range( 0 , 3 ) ;

     

     if( Vector2.Distance ( this.gameObject.transform.position , posl[ transleft ].position ) > 0 )
    {
         this.gameObject.transform.localScale = new Vector3 ( -1 , 1 , 1 ) ;
    }
    else
    {
         this.gameObject.transform.localScale = new Vector3 ( 1 , 1 , 1 );
    }

    for ( int i = 0 ; i >= 0 ; i++ )

    {
      if ( this.gameObject.transform.position != posl[ transleft ].position ) 
     
      {
       
         this.gameObject.transform.position = Vector3.MoveTowards( this.transform.position , posl[transleft].position  , 0.3f ) ;  
      
      }
    
      else 
    
      {
        
        int newway = Random.Range ( 0 , 2 ) ;

        animstate.AnimationState ( kiss ) ;

        GameObject kalp=Instantiate(hearth,heartspawn.position,Quaternion.identity)as GameObject;

        yield return new WaitForSeconds ( 1f ) ;

        animstate.AnimationState ( walk ) ;

         if ( newway == way )
       {
         
        if( newway == 1 )
        {
            way = 0;
             break ;
        } 
        else if( newway == 0 ) 
        {
             way = 1 ;

              break ;
        }

       }
      else way = newway ;

      break ;
        
      }

      yield return new WaitForSeconds( 0.1f ) ;

    }
    
    }

     }
     
   }

}
