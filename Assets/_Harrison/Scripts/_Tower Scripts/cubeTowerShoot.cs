using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTowerShoot : MonoBehaviour
{
    public GameObject cubeTower;
    GameObject target;
    public float fireRate = 1f;
    public float damage = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float timePastedBetweenFire;
    void Update()
    {
        if (cubeTower.GetComponentInChildren<towerTrigger>().target)
        {
            target = cubeTower.GetComponentInChildren<towerTrigger>().target;
        }
        else
        {
            target = null;
        }
        timePastedBetweenFire += Time.deltaTime;
        if(timePastedBetweenFire >= fireRate && target)
        {
            target.GetComponent<enemyHealth>().currentHealth -= damage;
            timePastedBetweenFire = 0f;
            print("fired");
        }
    }
}
