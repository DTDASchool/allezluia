using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{

    private _manager manager;
    public int team;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<_manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Balle")
        {
            manager.displayScore(1, team);
            other.transform.position = new Vector3(0f, 0f, 0f);
            other.transform.parent = transform.root;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
