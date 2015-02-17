using UnityEngine;
using System.Collections;

public class RotateOverTime : MonoBehaviour {
    public float speed = 1.0f;
    public GameObject player;

    Vector3 downVect;
    private bool facingDown = false;
	// Use this for initialization
	void Start () {
        if (!UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight()) {
            downVect = new Vector3(player.transform.position.x, player.transform.position.y + 50, 0);
        } else {
            downVect = new Vector3(player.transform.position.x, player.transform.position.y - 50, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //downVect = new Vector3(player.transform.position.x, player.transform.position.y - 50, 0);

        if (!facingDown) {
            
            Vector3 vectorToTarget = downVect - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            /*
            if (angle < 160 && angle > 150) {
                facingDown = true;
            }
             * */
        }
	}
}
