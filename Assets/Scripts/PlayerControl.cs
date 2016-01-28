using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 movement;
    public float Power;
    public float JumpPower;
    private int floorMask;
    private float hor;
    private float ver;
    
	void Awake ()
	{
	    rb = GetComponent<Rigidbody>();
	    floorMask = LayerMask.GetMask("Floor");
	}
	
	void Update ()
	{
	    
	}

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized*Power*Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, 100f))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Debug.Log(playerToMouse);

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(Vector3.up * JumpPower);
        }

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        Move(hor, ver);
        Turn();
    }
}
