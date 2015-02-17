using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float speed = 1.0f;
    public GameObject direction;
    private bool movingRight;
	// Use this for initialization
	void Start () {
        movingRight = UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight();
	}
	
	// Update is called once per frame
	void Update () {
        if(movingRight)
            transform.position += transform.right * Time.deltaTime * speed;
        else {
            transform.position += -transform.right * Time.deltaTime * speed;
        }
	}
}
