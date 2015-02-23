using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject arrow;
    public GameObject holdShield;
    public GameObject player;

    public float fireTimeCooldown = 1.0f;

    public bool firing = false;
    private float fireTime = 0.0f;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire2") && !firing) {
            Vector2 direction;
            if (UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight()) {
                direction = Vector2.right;
            } else {
                direction = Vector2.right;
            }
            player.SendMessage("disableHoldShield");
            firing = true;
            GameObject arrowShot = Instantiate(arrow, player.transform.position, Quaternion.Euler(direction)) as GameObject;
        }

        if (firing) {
            fireTime += Time.deltaTime;
            if (fireTime > fireTimeCooldown) {
                firing = false;
                fireTime = 0.0f;
                player.SendMessage("enableHoldShield");
            }
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
