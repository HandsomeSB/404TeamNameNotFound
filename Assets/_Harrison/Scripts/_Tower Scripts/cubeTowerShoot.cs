using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTowerShoot : MonoBehaviour
{
    public GameObject cubeTower;
    GameObject target;
    public float fireRate = 1f;
    public float damage = 30f;

    private NS.Lines.Wire laser;
    // Start is called before the first frame update
    void Start()
    {
        laser = NS.Lines.MakeForcedUnregistered("Shoot");
        
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
            laser.Line(transform.position, target.transform.position, Color.red);
        }else if(timePastedBetweenFire >= fireRate && target == null)
        {
            laser.Line(transform.position, transform.position, Color.red);
        }
    }
}
