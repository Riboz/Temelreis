using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    // Start is called before the first frame update
    
    Animator animator;
    private string currentstate;    
    
    void Start()
    {
        animator=GetComponent<Animator>();
       
    }
public void AnimationState( string newstate )
{
    if ( currentstate == newstate ) return ;

    animator.Play ( newstate ) ;
    currentstate = newstate ;

}
    // Update is called once per frame
   
}
