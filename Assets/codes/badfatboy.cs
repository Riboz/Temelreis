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
    public GameObject badboyheart,bubble,realgirl,visualgirl,rose,temelres;
    public GameObject[]heartbroken;

    public void Start()
    {
      
        StartCoroutine(badboyloveshow());
       

    }
    public IEnumerator badboyloveshow()
    {
      
     statemac.AnimationState ( love ) ;
     yield return new WaitForSeconds ( 0.5f ) ;
        //kalp spawnlasın 
        
        badboyheart.SetActive ( true ) ;
        //kalp setactive true olsun 
        yield return new WaitForSeconds ( 0.5f ) ;
        rose.SetActive(true);
        temelres.SetActive(false);
         yield return new WaitForSeconds ( 0.5f ) ;

          badboyheart.SetActive ( false ) ;
          //gülü setacite true et

          for ( int i = 0 ; i <= 1 ; i++ )
          {
            heartbroken[i].SetActive ( true ) ;
          }
         //kalp kırılsın  adam sinirlensin kalp sonra yok olsun
          
           yield return new WaitForSeconds ( 1f ) ;

           statemac.AnimationState ( punchup ) ;

           bubble.SetActive ( true ) ;

           visualgirl.transform.localScale=new Vector3(-1,1,1);

           for( int i = 0 ; i <= 1 ; i++ )
          {
            heartbroken [ i ].SetActive ( false ) ;
          }
        yield return new WaitForSeconds(2f);
        //aşşağı atlama for loopla
         rose.SetActive(false);
        temelres.SetActive(true);
        //gülü setacite false et
       bubble.SetActive ( false ) ;

       realgirl.SetActive ( true ) ;
       
       visualgirl.SetActive ( false ) ;

       gamestart = true ;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}