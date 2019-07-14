using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
	public float speed;
	public Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translationV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float translationH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		
		if (Input.GetKeyDown("space"))
        {
             rb.AddForce(transform.up * 200.0f);
        }
		
		transform.position += new Vector3(translationH,0,translationV);
		
		Debug.Log(Time.deltaTime);
    }
}
