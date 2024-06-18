using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMovement : MonoBehaviour
{
    private bool b = true;
    private int i = 10;
    private float f = 4.6f;

    private string s = "hello";
    private char character = 'c';

    private Vector3 v = new Vector3(0f, 0f, 0f);

    private Rigidbody2D rig;

    private float movementValue;

    [SerializeField] float speed;
    [SerializeField] float jumpHeight;

    [SerializeField] private Transform transformGroundCheck;
    private bool isGrounded;
    [SerializeField] private LayerMask layermaskGround;
    [SerializeField] private bool isFacingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(movementValue, rig.velocity.y);

        if (movementValue>0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (movementValue<0 && isFacingRight)
        {
            FlipCharacter();
        }
    }

    void FlipCharacter()
    {
        //store current scale of the object
        Vector3 currentScale = transform.localScale;
        //flipping the scale on the x-axis
        currentScale.x = currentScale.x * -1;
        //applying scale to the transform
        transform.localScale = currentScale;
        
        //updating the 'isfacing' variable
        isFacingRight = !isFacingRight;
    }

    void OnMove(InputValue inputValue)
    {
        //Debug.Log("move" + inputValue.Get<float>());
        movementValue = inputValue.Get<float>() * speed;
    }

    void OnJump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.2f, layermaskGround))
        {
            rig.velocity = new Vector2(0f, jumpHeight);
        }
        
        //Debug.Log("jump");
    }
    
}
