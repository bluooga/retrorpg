using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
public class playerthing : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 inputVector;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontal", inputVector.x);
        animator.SetFloat("vertical", inputVector.y);
        animator.SetFloat("speed", inputVector.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputVector * moveSpeed * Time.fixedDeltaTime);
    }

    public void PlayerMove(InputAction.CallbackContext context)
    {
        
        if (MenuManager.instance.menuOpen == false)
        {
            inputVector = context.ReadValue<Vector2>();

            if (inputVector.x != 0 && inputVector.y != 0)
            {
                inputVector.x = 0;
            }
        }
    }

    public void PlayerGamePause(InputAction.CallbackContext context)
    {

        inputVector = Vector2.zero;
        switch (MenuManager.instance.menuOpen)
        {
            case false: MenuManager.instance.menuOpen = true;
                break;
            case true: MenuManager.instance.menuOpen = false;
                break;
        }
        MenuManager.instance.PlayerMenuToggle();
    }
}
