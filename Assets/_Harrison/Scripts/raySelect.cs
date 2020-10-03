using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raySelect : MonoBehaviour
{

    public GameObject marker;
    Dictionary<KeyCode, System.Action> keyMap = new Dictionary<KeyCode, System.Action>();

    public GameObject prefabMarker;
    public GameObject prefabMarker1;

    private System.Action thingsToDoLater;

    public enum rayState { none, cube, ball};
    public rayState towerState = rayState.none;

    void stuff(){
        Debug.Log("hi u suck");
    }

    void createRay(){
      RaycastHit hit = new RaycastHit();
      //LayerMask ignoreRay = LayerMask.GetMask("ignore Raycast");
      Physics.Raycast(transform.position, transform.forward, out hit);//, Mathf.Infinity, ignoreRay);
      if(marker){
        marker.transform.position = hit.point;
      }
    }

    void resetMarkerState()
    {
        towerState = rayState.none;
        Destroy(marker);//Destroy the marker
        thingsToDoLater = null;//Unassign the task
        marker = null;//unassign the marker
    }

    void setMarkerState(rayState theState, GameObject theMarker)
    {
        if (towerState != rayState.none)
        {
            Destroy(marker);
            marker = null;
        }
        towerState = theState;
        thingsToDoLater = createRay;//assign the task
        marker = Instantiate(theMarker);//assign the marker
    }

    void keyPressedForTowerState(rayState theState, GameObject theMarker)
    {
        if (towerState != theState)
        {//if the task is unassgined or the task is not the same one
            setMarkerState(theState, theMarker);

        }
        else
        {
            resetMarkerState();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      keyMap[KeyCode.E] = ()=>{
          keyPressedForTowerState(rayState.cube, prefabMarker);
      };
      keyMap[KeyCode.R] = ()=> {
          keyPressedForTowerState(rayState.ball, prefabMarker1);
      };
        keyMap[KeyCode.Mouse0] = () =>
        {
            if (marker)
            {
                GameObject copy = Instantiate(marker);
                copy.GetComponent<rotator>().enabled = true;
                //TODO create feature to upgrade towers
                //TODO partical effects when new tower is created
                //TODO play sounds when tower created
                
            }
            
        };


    }

    // Update is called once per frame
    void Update()
    {

      foreach(KeyValuePair<KeyCode,System.Action> entry in keyMap){
        if(Input.GetKeyDown(entry.Key)){
          entry.Value.Invoke();
        }
      }


    }

    void LateUpdate(){
      if(thingsToDoLater != null){
        thingsToDoLater.Invoke();
        //thingsToDoLater = null;
      }
    }
}
