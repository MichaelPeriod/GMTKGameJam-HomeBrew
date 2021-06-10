using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ManageEvents : MonoBehaviour
{
    public Tilemap Background_Map;
    public Tilemap Colider_Map;
    public Tile[] openDoorTiles; 
    // Start is called before the first frame update

    public void manageTriggerPress(int triggerID){
        //Take in button presses and act acordingly
        switch(triggerID){
            case 1:
                openDoor(-6, 1, openDoorTiles[0]);
                openDoor(-5, 1, openDoorTiles[1]);
                break;
            //Default way to add
            /*case {ID number}:
                Actions
                break;*/
            default:
                Debug.Log("Forgot to set TriggerID");
                break;
        }
    }

    public void manageTriggerRelease(int triggerID){
        //If it is a toggleable trigger, manage here
        switch(triggerID){
            case 1:
                //Nothing
                break;
        }
    }

    private void openDoor(int x, int y, Tile openDoor){
        Background_Map.SetTile(new Vector3Int(x, y, 0), openDoor);
        //Note: Only works on vertical doors unless colider map is chaanged
        Colider_Map.SetTile(new Vector3Int(x, y - 1, 0), null);
    }
}
