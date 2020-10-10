using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerTrigger : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        fakeOnTrigger();
    }

    public void fakeOnTrigger()
    {
        SphereCollider myCollider = GetComponent<SphereCollider>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, myCollider.radius);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == gameObject)
            {
                continue;
            }
            OnTriggerEnter(colliders[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.parent.LookAt(target.transform);
        }
        else
        {
            transform.parent.GetComponent<rotator>().enabled = true;
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
    private void OnTriggerExit(Collider other)
    {
        if(target.gameObject == other.gameObject)
        {
            target = null;
            fakeOnTrigger();
        }
    }
}
