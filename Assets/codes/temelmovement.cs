using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temelmovement : MonoBehaviour
{
public animations statemac;
public Transform saved;
Collider2D colliders;

bool tirmaniyorzaten=false;
bool canclimb;
private Rigidbody2D rb;

[Header("Temelreis")]
    const string walk="walk";
    const string punch="punch";
    const string basamak="basamak";
    const string ladder="ladder";
    const string fall="fall";
    const string win="win";
    const string idle="idle";
    public bool goup,godown;
[SerializeField]float hiz=2.5f;
float inputhorizontal;

Vector3 flips;

public void temelcanclimb ( bool canclimbs )
{


  
   canclimb = canclimbs ;
  
  
}
IEnumerator ColliderOpenClose()
{
GameObject[]ladders=GameObject.FindGameObjectsWithTag("Ladder");
    for(int i=0;i<=ladders.Length-1;i++)
    {
        Collider2D coll=ladders[i].GetComponent<Collider2D>();
        coll.enabled=false;
        

    }
    yield return new WaitForSeconds(1f);
      for(int i=0;i<=ladders.Length-1;i++)
    {
        Collider2D coll=ladders[i].GetComponent<Collider2D>();
        coll.enabled=true;
        

    }
    yield break;
}
public void laddercontrol()
{
    StartCoroutine(ColliderOpenClose());

}
//butun ladderşerin colliderlerini kapat acma fonksiyonu
public bool notdown(bool iscandow){godown=iscandow; return iscandow;}
public bool notup(bool iscando){ goup=iscando; return iscando;}
    void Start()
    {
        rb = GetComponent < Rigidbody2D > () ;
          colliders = GetComponent < Collider2D > () ;
    }

    void Update()
    {
        
     if ( canclimb && !tirmaniyorzaten )
     {
       if ( Input.GetKeyDown ( KeyCode.UpArrow ) && goup )
       {
         tirmaniyorzaten = true ;
         
         laddercontrol();
        statemac.AnimationState ( ladder ) ;
        StartCoroutine ( upladdergo ( ) ) ;
       
        canclimb = false ;
       }
         if( Input.GetKeyDown ( KeyCode.DownArrow ) && godown )
       {
         tirmaniyorzaten = true ;
        laddercontrol();
         statemac.AnimationState( ladder ) ;
        StartCoroutine ( downladdergo ( ) ) ;
       
        canclimb = false;
       }
     }
    
    }
    
    public IEnumerator upladdergo()
    {
        
        for ( int i = 0 ; i >= 0 ; i++ )
        {
            colliders.isTrigger = true ;

            rb.constraints = RigidbodyConstraints2D.FreezePositionX ;
             rb.gravityScale = 0 ;
            this.transform.position = Vector2.MoveTowards( this.transform.position , saved.position + new Vector3 ( 0 , 2 , 0 ) , 0.3f ) ;
            yield return new WaitForSeconds ( 0.1f ) ;
           if ( i > 7 )
           {
            break;
           }
        }
        
        rb.gravityScale = 1;
        
        colliders.isTrigger = false ;
        
        tirmaniyorzaten = false ;
        
        rb.constraints = RigidbodyConstraints2D.None ;
        
        rb.constraints = RigidbodyConstraints2D.FreezeRotation ;

       
        
        yield break ;
    }

    public IEnumerator downladdergo()
    {
         
        for ( int i = 0 ; i >= 0 ; i++ )
        {
            rb.constraints=RigidbodyConstraints2D.FreezePositionX;
       
            colliders.isTrigger=true;
       
            rb.gravityScale=0;
       
            this.transform.position=Vector2.MoveTowards ( this.transform.position , saved.position - new Vector3 ( 0 , 2 , 0 ) , 0.3f ) ;
       
            yield return new WaitForSeconds ( 0.1f ) ;
       
           if ( i > 7 )
           {
            break;
           }
        }
          rb.gravityScale = 1 ;
       
          tirmaniyorzaten = false ;
       
          rb.constraints = RigidbodyConstraints2D.None ;
       
          rb.constraints = RigidbodyConstraints2D.FreezeRotation ;
       
          colliders.isTrigger = false ;

        
        
      

          yield break ;
    }
    void FixedUpdate()
    {
     movement ( ) ;   
    }
    private void movement()
    {
        float inputhorizontal = Input.GetAxis( "Horizontal" ) ;

        rb.velocity = new Vector2 ( inputhorizontal * hiz , rb.velocity.y ) ;


        if( inputhorizontal < 0 || inputhorizontal > 0 && !tirmaniyorzaten )
        {
        if( inputhorizontal < 0 )
        {
            flip( -1 ); 
            
        }
        else if( inputhorizontal > 0)
        {

            flip( 1 ); 
        }
        if(!tirmaniyorzaten)
        {
           statemac.AnimationState( walk ) ; 
        }
        
        
        }

       if( inputhorizontal == 0 && !tirmaniyorzaten )
       {

        statemac.AnimationState( idle ) ;
        
       } 


    }
    private void flip( float flip )
    {

    flips = new Vector3 ( flip , 1 , 0 );
    
    this.gameObject.transform.localScale = flips;
    
    }
}
