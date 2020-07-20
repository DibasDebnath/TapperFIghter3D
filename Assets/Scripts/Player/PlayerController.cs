using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("PlayerMovement")]
    //public Variables;
    public float speed = 1f;
    public float turnSmoothTime = 0.08f;
    public Transform camTransform;
    public CharacterController characterController;
    //private Variables;
    float horizontal;
    float vertical;
    float turnSmoothVelocity;
    [Header("PlayerAnimation")]
    public PlayerAnimationControllerScript playerAnimationControllerScript;



    
    [Header("Joystick")]
    public Joystick joystick;

    private void Awake()
    {
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
        
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getJoysticInput();
        //Debug.Log(joystick.Horizontal);
        if(horizontal !=0f && vertical != 0f)
        {
            movePlayer(horizontal, vertical);
        }
        else
        {
            playerAnimationControllerScript.playerMovement(0, 0);
        }
        
    }




    void movePlayer(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(moveDirection * speed * Time.deltaTime);
            
        }
        //characterController.ho
    }
    void rotatePlayer()
    {

    }


    void getJoysticInput()
    {
        horizontal = joystick.Direction.x;
        vertical = joystick.Direction.y;
    }

    void normalizeInput()
    {
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

    }
    
}
