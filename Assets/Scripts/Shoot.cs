using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject arrow;
    public GameObject holdShield;
    public GameObject player;
	void Start () {
	
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire2")) {
            Vector2 direction;
            if (UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight()) {
                direction = Vector2.right;
            } else {
                direction = Vector2.right;
            }
            GameObject arrowShot = Instantiate(arrow, player.transform.position, Quaternion.Euler(direction)) as GameObject;
        }
        Vector2 position;
        if (UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight()) {
            position = new Vector2(player.transform.position.x + .7f, player.transform.position.y);
        } else {
            position = new Vector2(player.transform.position.x + -.7f, player.transform.position.y);
        }
        holdShield.transform.position = position;
	}
}
