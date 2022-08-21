using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temelmovement : MonoBehaviour
{
public animations statemac;
private Rigidbody2D rb;
[Header("Temelreis")]
    const string walk="walk";
    const string punch="punch";
    const string basamak="basamak";
    const string ladder="ladder";
    const string fall="fall";
    const string win="win";
    const string idle="idle";
[SerializeField]float hiz=2.5f;
float inputhorizontal;
Vector3 flips;

    void Start()
    {
        rb = GetComponent <Rigidbody2D> () ;

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
     movement ( ) ;   
    }
    private void movement()
    {
        float inputhorizontal = Input.GetAxis("Horizontal") ;

        rb.velocity = new Vector2 ( inputhorizontal * hiz , rb.velocity.y ) ;


        if( inputhorizontal < 0 || inputhorizontal > 0)
        {
        if( inputhorizontal < 0 )
        {
            flip( -1 ); 
            
        }
        else if( inputhorizontal > 0)
        {

            flip( 1 ); 
        }
        statemac.AnimationState( walk ) ;
        
        }

       if( inputhorizontal == 0)
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
