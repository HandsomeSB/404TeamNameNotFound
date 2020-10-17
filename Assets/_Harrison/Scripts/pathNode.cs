using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NS;

public class pathNode : MonoBehaviour
{
    public List<pathNode> next;
    private Lines.Wire[] wire;

    private GameObject[] path;
    // Start is called before the first frame update
    void Start()
    {
        wire = new Lines.Wire[next.Count];
        path = new GameObject[next.Count];
        for(int i = 0; i < wire.Length; i++)
        {
            wire[i] = Lines.MakeForcedUnregistered();
        }
        
        for(int i = 0; i < next.Count; i++)
        {
            path[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 delta = next[i].transform.position - this.transform.position;
            float distance = Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y + delta.z * delta.z);
            Vector3 direction = new Vector3(delta.x / distance, delta.y / distance, delta.z / distance);
            path[i].transform.position = this.transform.position + delta / 2 + Vector3.down;
            path[i].transform.rotation = Quaternion.LookRotation(direction);
            path[i].transform.localScale = new Vector3(1, 0.1f, distance);
            path[i].GetComponent<BoxCollider>().isTrigger = true;
            path[i].AddComponent<pathMark>();


        }
        
        
    }

    public class pathMark : MonoBehaviour
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < next.Count; i++)
        {
            if (next[i])
            {
                wire[i].Arrow(transform.position, next[i].transform.position, Color.black);
            }
            else
            {
                wire[i].Line(transform.position, transform.position);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        enemyMove e = other.GetComponent<enemyMove>();
        if (e && next.Count != 0)
        {
            int nextIndex = Random.Range(0, next.Count);
            pathNode n = next[nextIndex];
            Vector3 delta = n.transform.position - e.transform.position;//normalized
            float distance = Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y + delta.z * delta.z);
            Vector3 direction = new Vector3(delta.x / distance, delta.y / distance, delta.z / distance);//normalized
            e.velocity = direction;
            //e.velocity = delta.normalized;
        }
    }

}
