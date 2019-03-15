using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraController : MonoBehaviour {
    public Transform transform;
    public TurnManager turn;
    public float durationMove = 0.5f;
    public float durationRotate = 0.5f;

    void Start()
    {
        turn = FindObjectOfType<TurnManager>();
        transform = FindObjectOfType<Transform>();
    }

    void Update()
    {
        ToRotateCamera();
    }

    public void ToRotateCamera()
    {

        if (turn.isTurn == false)
        {
       
            transform.DOMove(new Vector3(11, 5, 10), durationMove);
            transform.DOLocalRotate(new Vector3(20, -136, 7), durationRotate);
        }
        if(turn.isTurn == false)
        {
            transform.DOMove(new Vector3(1, 5, 1), durationMove);
            transform.DOLocalRotate(new Vector3(30, 45, 0 ), durationRotate);
        }
    }
    

}
