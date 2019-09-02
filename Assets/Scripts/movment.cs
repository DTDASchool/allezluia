using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float jumpForce;
	public float speed;
	public Rigidbody rb;
    public bool isJumping;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Balle")
        {
            other.transform.parent = transform;
            other.transform.localPosition = GameObject.Find("Spawn").transform.localPosition;
            Debug.Log("Touchée");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float translationV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float translationH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (transform.position.y <= 2f)
        {
            isJumping = false;
        }

        if (Input.GetKeyDown("space") && isJumping == false)
        {
            rb.AddForce(transform.up * jumpForce);
            isJumping = true;
        }

        //Debug.Log(Time.deltaTime);

        if(translationV != 0 || translationH != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(translationH, 0, translationV));
            transform.position += new Vector3(translationH, 0, translationV);
        }

    }
}
