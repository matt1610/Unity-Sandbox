using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;
    public float Power;
    public float JumpPower;
    private float hor;
    private float ver;
    
	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
	    hor = Input.GetAxis("Horizontal");
	    ver = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Power * ver * Time.deltaTime);
        transform.Translate(Vector3.right * Power * hor * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(Vector3.up * JumpPower);
        }
    }
}
