using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    public float anima;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded();
        Jump();
        Move();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            Debug.Log("jumped???");
            this.rb.AddForce(Vector3.up * 6, ForceMode.Impulse);
            this.anim.SetBool("Jumping", this.grounded);

        }
        
    }

    private void Grounded()
    {
        if(Physics.CheckSphere(this.transform.position + Vector3.down, anima, layerMask))
        {
            this.grounded = true;
            this.anim.SetBool("Jumping", !this.grounded);
        }
        else
        {
            this.grounded = false;
        }
        //this.anim.SetBool("Jumping", !this.grounded);


    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.01f;

        this.anim.SetFloat("Vertical", verticalAxis);
        this.anim.SetFloat("Horizontal", horizontalAxis);
    }


}
