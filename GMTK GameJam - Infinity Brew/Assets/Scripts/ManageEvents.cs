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
        switch(triggerID){
            case 1:
                openDoor(-8, -3, openDoorTiles[2]);
                break;
            default:
                Debug.Log("Forgot to set TriggerID");
                break;
        }
    }

    public void manageTriggerRelease(int triggerID){
        switch(triggerID){
            case 1:
                //Nothing
                break;
        }
    }

    private void openDoor(int x, int y, Tile openDoor){
        Background_Map.SetTile(new Vector3Int(x, y, 0), openDoor);
        Colider_Map.SetTile(new Vector3Int(x, y, 0), null);
    }
}
