using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour {

    public float minMovementSpeed = 3.0f;
    public float maxMovementSpeed = 7.0f;
    public float rotationSpeed = 50.0f;
    public float jumpForce = 2f;
    static float rotSpeed;
    public LayerMask floorMask, wallMask;
    Vector3 jumpVector;
    Rigidbody rb;

    bool doubleJumped;
	void Start () {
        rotSpeed = rotationSpeed;
        rb = gameObject.GetComponent<Rigidbody>();
        jumpVector = new Vector3(0, jumpForce * 10, 0);
	}
	
	void Update () {
        CheckMovement();
        if(Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Space) && CanDoubleJump())
        {
            DoubleJump();
        }
	}

    void CheckMovement()
    {
        float translation = Input.GetAxis("Vertical") * Mathf.Lerp(minMovementSpeed,maxMovementSpeed,2f) * Time.deltaTime;
        float rotation = rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, 0, translation);
        }
        else
            transform.Translate(0, 0, 0);
    }

    void Jump()
    {
        Debug.Log("Jump Da Fak Up!");
        rb.AddForce(jumpVector, ForceMode.Impulse);
    }
    void DoubleJump()
    {
        rb.velocity = Vector3.zero;
        Jump();
    }

    bool CanJump()
    {
        Ray ray = new Ray(transform.position, new Vector3(0,-2,0));
        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(0,-2,0), Color.magenta,1);
        if (Physics.Raycast(ray, out hit, transform.localScale.y, floorMask))
        {
            doubleJumped = false;
            return true;
        }
        return false;
    }

    bool CanDoubleJump()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        bool walled = Physics.Raycast(ray, out hit, transform.localScale.z, wallMask);

        if (walled && !CanJump() && !doubleJumped)
        {
            doubleJumped = true;
            return true;
        }
        else
        {
            return false;
        }
    }

public static float RotationSpeed()
    {
        return rotSpeed;   
    }
}
