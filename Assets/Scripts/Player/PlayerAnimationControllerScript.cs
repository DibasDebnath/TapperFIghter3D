using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerScript : MonoBehaviour
{

    public Animator animCon;



    private static string Horizontal = "Horizontal";
    private static string Vertical = "Vertical";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerMovement(float v, float h)
    {
        animCon.SetFloat(Vertical, v);
        animCon.SetFloat(Horizontal, h);

    }


    
}
