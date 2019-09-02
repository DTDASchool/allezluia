using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityMax : MonoBehaviour
{
	public GameObject ground;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < (ground.transform.position.y + ground.transform.localScale.y/2 + transform.localScale.y/2)){
			transform.position = new Vector3(transform.position.x,(ground.transform.position.y + ground.transform.localScale.y/2 + transform.localScale.y/2),transform.position.z);
		}
    }
}
