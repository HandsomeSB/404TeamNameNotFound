using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct a
{
    public byte x, y, z;
}

public class owner
{
    private a v;
    public a V
    {
        get { return v; }//returns a pointer to v
        set { v = value; }
    }
}

public class enemyMove : MonoBehaviour
{
    public Vector3 velocity = new Vector3(-1f, 0f, 0f);
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //owner MrV = new owner();//every variable of a class is a point to the "new" class, except for struct. Struct is passed by value not by pointer, a copy of the data. Struct is a little faster
        //MrV.V.x += 1;
        //MrV.V = new a(); Error
        velocity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += velocity * Time.deltaTime;
        //transform.position.x += 1; Error because position is return as a value, x is a copy of the position, not the pointer to the actual position
        GetComponent<Rigidbody>().velocity = velocity * speed;
    }
}


