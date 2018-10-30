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
    Vector3 doubleJumpVector;
    Rigidbody rb;
    Vector3 rayOrigin;

    bool doubleJumped;
	void Start () {
        rotSpeed = rotationSpeed;
        rb = gameObject.GetComponent<Rigidbody>();
        jumpVector = new Vector3(0, jumpForce * 10, 0);
        doubleJumpVector = new Vector3(0, jumpForce * 10, 10);
    }
	
	void Update () {
        CheckMovement();
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanDoubleJump())
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
        rb.velocity = Vector3.zero;
        rb.AddForce(jumpVector, ForceMode.Impulse);
    }
    void DoubleJump()
    {
        rb.velocity = Vector3.zero;
        //RotateWalled();
        rb.AddForce(doubleJumpVector, ForceMode.Impulse);
    }

    bool CanJump()
    {
        Ray ray = new Ray(transform.position, new Vector3(0,-1,0));
        Debug.DrawRay(transform.position, new Vector3(0, -2, 0), Color.magenta,1);
      
        if (Physics.Raycast(ray, 2, floorMask))
        {
            doubleJumped = false;
            return true;
        }
        return false;
    }

    bool CanDoubleJump()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        bool walled = Physics.Raycast(ray, 1, wallMask);

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

    void RotateWalled()
    {
        transform.rotation = new Quaternion(transform.rotation.x, -transform.rotation.y, transform.rotation.z,1);
    }
}
