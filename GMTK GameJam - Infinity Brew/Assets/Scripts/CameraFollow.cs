using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform currentCamPos;
    public Transform PlayerOneTrans;
    public Transform PlayerTwoTrans;
    private Vector2 CenterPoint;
    private Vector2 currVel = new Vector2(0, 0);

    void Start(){
        currentCamPos = gameObject.GetComponent<Transform>();
    }

    void Update(){
        CenterPoint = new Vector2((PlayerOneTrans.position.x + PlayerTwoTrans.position.x) / 2, (PlayerOneTrans.position.y + PlayerTwoTrans.position.y) / 2);

        Vector2 newPos = Vector2.SmoothDamp(new Vector2(currentCamPos.position.x, currentCamPos.position.y), CenterPoint, ref currVel, moveSpeed, 1000);
        currentCamPos.position = new Vector3(newPos.x, newPos.y, -10);
    }
}
