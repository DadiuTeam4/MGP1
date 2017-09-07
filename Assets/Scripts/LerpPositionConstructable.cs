using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPositionConstructable : MonoBehaviour, Constructable {
    [Tooltip("Step is the amount that the object moves from A to B in the lerp")]
    [Range(0.0f, 1.0f)]
    public float step;

    [Tooltip("The position that the object will have at T = 1. The object will start at the position you place it at, which will be T = 0")]
    public Transform endPosition;
    private float t = 0.0f;
    private Vector3 startPosition;

    void start(){
        startPosition = transform.position;
    }

    public void Construct(){
        t += step;
        transform.position = Vector3.Lerp(startPosition, endPosition.position, t);
    }
}