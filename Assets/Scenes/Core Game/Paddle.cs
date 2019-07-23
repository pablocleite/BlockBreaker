using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float positionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        positionInUnits = Mathf.Clamp(positionInUnits, minX, maxX);
        Vector2 coordinates = new Vector2(positionInUnits, transform.position.y);
        transform.position = coordinates;
	}
}
