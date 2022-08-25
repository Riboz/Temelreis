using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badfatboy : MonoBehaviour
{
    // Start is called before the first frame update
    public  static bool gamestart=false;
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
     public void badboymovement()
     {
        /*
        bossumuz rastgele olduğu katmanda temeli takip etmelidir ayrıca bossumuz temelin olduğu kata her 5-6 saniyede bir çıkmalıdır boss temelin katına çıkınca
        iki şeyden birini yapmalıdır ya katın bossa yakın olan köşesine geçip temele doğrı şişe atmalı ya da temele doğru yürümeli ve temele yaklaşınca yumruk atmalı
        ayrıca eğer temel bossun üstüne gelirse boss yukarı zıplayarak yumruk atmalı veya aşağı doğru süpürme hareketi yapmalı
        */
     }
    // Update is called once per frame
    void FixedUpdate()
    {
        //gamestart true olduğunda 
    }
}
