using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    // Start is called before the first frame update
    
    Animator animator;
    private string currentstate;

    [Header("lover")]
     const string walkl="walk";
     const string kiss="kiss";


     [Header("fatbadboy")]
     const string walkf="walk";
     const string throwf="throw";
     const string lookaround="lookaround";
     const string punchup="punchup";
     const string punchdown="punchdown";
     const string winf="win";
     const string fallf="fall";



    
    void Start()
    {
        animator=GetComponent<Animator>();
       
    }
public void AnimationState(string newstate)
{
    if(currentstate==newstate)return;

    animator.Play(newstate);
    currentstate=newstate;

}
    // Update is called once per frame
   
}
