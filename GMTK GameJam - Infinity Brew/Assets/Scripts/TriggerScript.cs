using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool hold = false;
    public bool active = false;
    public Tilemap Background_Map;
    public Tilemap Colider_Map;
    
    public Tile tile; 

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            Background_Map.SetTile(new Vector3Int(-9, -3, 0), tile);
            Colider_Map.SetTile(new Vector3Int(-9, -3, 0), null);
            Debug.Log("Active");
        }
    }
}
