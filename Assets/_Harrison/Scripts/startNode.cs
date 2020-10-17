using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNode : MonoBehaviour
{
    public List<pathNode> travelLog = new List<pathNode>();
    [ContextMenuItem("Do Travel Algorithm", "travel")]
    public int maxTravel = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        
    }

    public void travel()
    {
        int counter = 0;
        travelLog.Clear();
        pathNode here = GetComponent<pathNode>();
        while (here != null)
        {
            if (!travelLog.Contains(here))
            {
                travelLog.Add(here);
            }
            
            int neighbor = 0;
            pathNode iWasHere = here;
            while (neighbor < here.next.Count)
            {
                pathNode there = here.next[neighbor];
                if (travelLog.Contains(there))
                {
                    neighbor++;
                }
                else
                {
                    here = there;
                    break;
                }
            }
            if(here == iWasHere)
            {
                int index = travelLog.IndexOf(here);
                if (index == 0)
                {
                    Debug.Log("back track all the way");
                    here = null;
                }
                else
                {
                    here = travelLog[index - 1];
                }
            }
            
            if (counter++ > maxTravel)
            {
                throw new System.Exception("travel may have found an inf loop haha");
            } 
        }
        





    }
}
