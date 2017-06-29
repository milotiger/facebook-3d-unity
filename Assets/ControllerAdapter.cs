using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAdapter : MonoBehaviour
{
    public float rotate_offset = 10f;
    public float move_speed = 0.001f;
    public KeyCode left_key = KeyCode.A;
    public KeyCode right_key = KeyCode.D;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(left_key))
	    {
	        transform.Rotate(0, -rotate_offset, 0);
	    }
        if (Input.GetKey(right_key))
        {
            transform.Rotate(0, rotate_offset, 0);
        }
	    transform.position += Vector3.Scale(transform.position, transform.forward*Input.GetAxis("Vertical")*move_speed);
	}
}
