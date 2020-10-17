using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphGenerator : MonoBehaviour
{
    [ContextMenuItem("Generate", "Start")]
    public int count = 20;
    public float radius = 3;
    public GameObject nodePrefab;
    public BoxCollider area;
    public List<pathNode> allNodes = new List<pathNode>();
    // Start is called before the first frame update
    void Start()
    {
        allNodes.ForEach(n => DestroyImmediate(n.gameObject));
        allNodes.Clear();
        for(int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(Random.value, Random.value, Random.value);
            position.Scale(area.size);
            GameObject node = Instantiate(nodePrefab, position + area.transform.position + area.center - area.size/2, Quaternion.identity);
            allNodes.Add(node.GetComponent<pathNode>());
        }
        for(int i = 0; i < allNodes.Count; i++)
        {
            pathNode n = allNodes[i];
            for(int v = 0; v < allNodes.Count; v++)
            {
                if(v == i)
                {
                    continue;
                }
                pathNode p = allNodes[v];
                float dist = Vector3.Distance(n.transform.position, p.transform.position);
                if(dist < radius)
                {
                    n.next.Add(p);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
