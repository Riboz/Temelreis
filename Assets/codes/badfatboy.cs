using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badfatboy : MonoBehaviour
{
    // Start is called before the first frame update
    public  static bool gamestart=false;
    public bool dursun=false;
    [Header("fatbadboy")]
    public const string walk="walk";
    public const string throws="throw";
    public const string lookaround="lookaround";
    public const string punchup="punchup";
    public const string punchdown="punchdown";
    public const string win="win";
    public const string fall="fall";
    public const string love="love";
    public animations statemac;
    public GameObject badboyheart,bubble,realgirl,visualgirl,rose,temelreis;
    public GameObject[]heartbroken;
    Rigidbody2D rb;
    Collider2D coll;

    public void Start()
    {
      
        StartCoroutine(badboyloveshow());

        rb=GetComponent<Rigidbody2D>();

        coll=GetComponent<Collider2D>();

    }
    public bool notdownorup,vursun;
    public IEnumerator badboyloveshow()
    {
      
        statemac.AnimationState ( love ) ;

        yield return new WaitForSeconds ( 0.5f ) ;
        //kalp spawnlasın 
        
        badboyheart.SetActive ( true ) ;
        //kalp setactive true olsun 
        yield return new WaitForSeconds ( 1f ) ;

        rose.SetActive(true);

        temelreis.SetActive(false);

         yield return new WaitForSeconds ( 1f ) ;

           bubble.SetActive ( true ) ;

           badboyheart.SetActive ( false ) ;
         
           for ( int i = 0 ; i <= 1 ; i++ )
          {
            heartbroken [ i ].SetActive ( true ) ;
          }

          visualgirl.transform.localScale=new Vector3(-1,1,1);
         
          yield return new WaitForSeconds(0.5f);

          statemac.AnimationState ( punchup ) ;
          
          for( int i = 0 ; i <= 1 ; i++ )
          {

            heartbroken [ i ].SetActive ( false ) ;

          }

        yield return new WaitForSeconds(0.5f);

        rb.AddForce(Vector2.up*160);

        rb.AddForce(Vector2.left*30);

        coll.isTrigger=true;

        yield return new WaitForSeconds(1f);
       
        coll.isTrigger=false;
        
        rose.SetActive(false);
        
        temelreis.SetActive(true);
        
        bubble.SetActive ( false ) ;

        realgirl.SetActive ( true ) ;
       
        visualgirl.SetActive ( false ) ;

        gamestart = true ;

        yield return new WaitForSeconds(0.7f);

        statemac.AnimationState(lookaround);
        yield break;
    }
     public void Badboyall()
     {
        if(gamestart)
        {
            //distance dikey kontrolcüsü
         Distancey ( ) ;
     

    
        if ( !justone && notdownorup&&!dursun)
        {
        
            StartCoroutine ( Randomwaywalk ( ) ) ;
             justone = true ;          
        }
        else if(!notdownorup && !notdownicin&&!dursun)
        {
        StartCoroutine(Jumping());
        }
     
     if(dursun)
     {
        StopCoroutine(Randomwaywalk());
       
     }
         //random 2 değer arasından seçme
      //boss random bi şekilde belirli bir süre bir tarafa gitmeli 
      //boss her katta yaklaşık 6-9 saniye arası kalıcak
      //boss eğer temelle aynı kattaysa dolaşmak yerine şişe atabilir
      //boss temelin üstünde veya altında ise boss oraya doğru saldırıcaktır
        }
     }
     IEnumerator Jumping()
     {
        if ( distancey.y < -2 )
        {
            notdownorup = true ;
            coll.isTrigger = true ;
            statemac.AnimationState(punchup);
            rb.AddForce ( Vector2.up * 220 ) ;
            yield return new WaitForSeconds ( 1.25f ) ;
            statemac.AnimationState(walk);
            coll.isTrigger = false;
            yield break;
        }
        else
        {
             
            notdownorup = true ;

            coll.isTrigger = true ;

            rb.AddForce ( Vector2.up * 440 ) ;
           statemac.AnimationState(punchup);
            yield return new WaitForSeconds ( 1.2f ) ;
         statemac.AnimationState(walk);
            coll.isTrigger = false;

            yield break;
        
        }
     }
     
     Vector3 distancey , distancex ;
     public bool notdownicin = true ;
    IEnumerator Notdownfonk ( )
    {
       
     
        yield return new WaitForSeconds ( 12f ) ;
        notdownicin = true ;
        notdownorup = false ;
        yield break ;
    }
     public void Distancey ( )
     {
      distancey = new Vector3 ( 0 ,temelreis.transform.position.y - this.transform.position.y , 0 ) ;

      distancex = new Vector3 ( this.transform.position.y - temelreis.transform.position.y , 0 , 0 ) ;
      
    if ( distancey.y > 0.2f || distancey.y < - 0.2f )
    {
        //aynı katmanda
        if ( notdownicin )
        {

         notdownicin = false ;
    
         StartCoroutine ( Notdownfonk ( ) ) ;

        }
     
    }
    else 
    {
        //farklı katmanda
        notdownorup = true ;
    }
      
    
     //eğer y dan kücükse yeri süpürsün
      
     }
     int walkdirection;
     bool justone=false,punchs=true;
     public LayerMask temel;
     public Transform u1,u2,d1,d2;
     public IEnumerator Randomwaywalk()
     {
        walkdirection=Random.Range(0,100);

        yield return new WaitForSeconds(1f);
        if(walkdirection<50)
        {
            statemac.AnimationState(walk);
           for(int i=0;i<=40;i++)
            {
                this.transform.localScale=new Vector3(-1,1,1);
                 if(dursun){break;}
                this.gameObject.transform.position=Vector2.MoveTowards(this.gameObject.transform.position,new Vector3(10.15f,this.gameObject.transform.position.y,this.transform.position.z),0.2f);
                yield return new WaitForSeconds(0.1f); 
            }
          
        }
        
         if(walkdirection>=50)
        {
            statemac.AnimationState(walk);
           for(int i=0;i<=40;i++)
            {   
                this.transform.localScale=new Vector3(1,1,1);
                if(dursun){break;}
                this.gameObject.transform.position=Vector2.MoveTowards(this.gameObject.transform.position,new Vector3(-10.15f,this.gameObject.transform.position.y,this.transform.position.z),0.2f);
                yield return new WaitForSeconds(0.1f); 
            }
          
            
        }
        justone=false;
       
        
        yield break;
     }
    // Update is called once per frame
    //2 tane raycast atıcağım raycaste değildiğinde üste zıplayacak ya da alta zıplayacak
    public bool a=false;
      public void raycasts()
      {
        if(gamestart)
        {
       RaycastHit2D hita=Physics2D.Linecast(u1.position,u2.position,temel);
       Debug.DrawLine(u1.position,u2.position,Color.red);
       if(hita.collider!=null)
       {
        // ienumerator le zıplatarak vursun
        if(!a)
        {
       StartCoroutine(jumpoattack());
        a=true;
        dursun=true;
        
       }
       }
       
       RaycastHit2D hits=Physics2D.Linecast(d1.position,d2.position,temel);
       Debug.DrawLine(d1.position,d2.position,Color.red);
       if(hits.collider!=null)
       {
        
        if(!a)
        {
       StartCoroutine(supurme());
       a=true;
       dursun=true;
        }
       

       }
        
        }
      }
      
      IEnumerator jumpoattack()
      {
             
            statemac.AnimationState(lookaround);
            yield return new WaitForSeconds ( 0.75f ) ; 
            coll.isTrigger =true;
            statemac.AnimationState(punchup);
            rb.AddForce ( Vector2.up * 300 ) ;
           
            
            yield return new WaitForSeconds ( 1.20f ) ;
            statemac.AnimationState(walk);
            coll.isTrigger =false;
            dursun=false;
            a=false;
            yield break;
      }
      IEnumerator supurme()
      {
        statemac.AnimationState(lookaround);
         yield return new WaitForSeconds ( 0.75f ) ; 
         coll.isTrigger =true;
         rb.gravityScale=0;
        statemac.AnimationState(punchdown);
        this.transform.position=this.transform.position+new Vector3(0,-1f,0);
        yield return new WaitForSeconds ( 1f ) ; 
        statemac.AnimationState(lookaround);
        
         this.transform.position=this.transform.position+new Vector3(0,1f,0);
        yield return new WaitForSeconds ( 1f ) ; 

         coll.isTrigger = false;
         rb.gravityScale=1;
         dursun=false;
         a=false;
         yield break;


      }
    void FixedUpdate()
    {
        raycasts();
        Badboyall();
        //gamestart true olduğunda 
    }
}
