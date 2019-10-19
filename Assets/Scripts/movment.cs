using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float jumpForce;
	public float speed;
	public Rigidbody rb;
    public Animator animator;
    public bool isJumping;

	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        animator.SetTrigger("Land");
        animator.SetBool("Grounded", true);
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

    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
        isJumping = true;
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
            Jump();
            /*animator.Play("jump-up");
            animator.Play("jump-float");
            animator.Play("jump-down");*/
        }

        //Debug.Log(Time.deltaTime);

        if(translationV != 0 || translationH != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(translationH, 0, translationV));
            transform.position += new Vector3(translationH, 0, translationV);
            animator.SetFloat("MoveSpeed", (translationH + translationV)*10f);
        }

    }
}
