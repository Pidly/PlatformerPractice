using UnityEngine;
using System.Collections;

public class ThrowSheild : MonoBehaviour {
    private GameObject throwShield;
    public GameObject throwShieldPrefab;
    public GameObject holdShield;

    public bool throwing = false;
    public bool returning = false;
    public bool holdingShield = true;

    public float speed = 1.0f;
    public float secondsThrowing = 1.5f;
    private float currentSeconds = 0.0f;

    public bool throwingRight;

	void Start () {
	
	}
	

	void Update () {
        if (Input.GetButtonDown("Fire3")) {
            if (!throwing) {
                currentSeconds = 0.0f;
                throwingRight = UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight();
                throwing = true;
                throwShield = Instantiate(throwShieldPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
            }
        }
        if (throwing) {
            if (holdingShield) {
                holdShield.SetActive(false);
                holdingShield = false;
            }
            if (throwingRight && !returning) {
                currentSeconds += Time.deltaTime;
                currentSeconds += Time.deltaTime;
                Vector2 rightMovement = new Vector2(throwShield.transform.position.x + (Time.deltaTime * speed), throwShield.transform.position.y);
                throwShield.transform.position = rightMovement;
                
                if (currentSeconds > secondsThrowing) {
                    returning = true;
                }
            } else if (!throwingRight && !returning) {
                currentSeconds += Time.deltaTime;
                currentSeconds += Time.deltaTime;
                Vector2 rightMovement = new Vector2(throwShield.transform.position.x - (Time.deltaTime * speed), throwShield.transform.position.y);
                throwShield.transform.position = rightMovement;

                if (currentSeconds > secondsThrowing) {
                    returning = true;
                }
            } else {
                throwShield.transform.position = Vector3.MoveTowards(throwShield.transform.position, gameObject.transform.position, speed * Time.deltaTime);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (returning && other.gameObject.tag == "Shield") {
            throwing = false;
            returning = false;
            GameObject.Destroy(other.gameObject);
            if (!holdingShield) {
                holdShield.SetActive(true);
                holdingShield = true;
            }
        }
    }
}
