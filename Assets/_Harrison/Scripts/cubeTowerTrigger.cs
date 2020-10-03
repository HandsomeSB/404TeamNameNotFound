using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTowerTrigger : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.parent.LookAt(target.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO Sub hit point using a hitpoint script
        //TODO turn to the enemy
        transform.parent.GetComponent<rotator>().enabled = false;
        if (!target && other.gameObject.GetComponent<enemyMove>())
        {
            target = other.gameObject;
        }
        
        
        
    }
}
