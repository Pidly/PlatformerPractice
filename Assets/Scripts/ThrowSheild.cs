using UnityEngine;
using System.Collections;

public class ThrowSheild : MonoBehaviour {
    private GameObject throwShield;
    public GameObject throwShieldPrefab;
    public GameObject holdShield;
    public GameObject shieldSlash;

    public bool throwing = false;
    public bool returning = false;
    public bool holdingShield = true;
    public bool slashing = false;

    public float speed = 1.0f;
    public float secondsThrowing = 1.5f;
    public float slashTime = 0.3f;
    private float currentSeconds = 0.0f;
    private float currentThrowSeconds = 0.0f;

    public bool throwingRight;

	void Start () {
        shieldSlash.SetActive(false);
	}
	

	void Update () {
        if (Input.GetButtonDown("Fire3") && !slashing && holdingShield) {
            if (!throwing) {
                currentSeconds = 0.0f;
                throwingRight = UnitySampleAssets._2D.PlatformerCharacter2D.FacingRight();
                throwing = true;
                throwShield = Instantiate(throwShieldPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
            }
        } 
        if (Input.GetButtonDown("Fire1") && holdingShield && !slashing) {
            slashing = true;
            holdingShield = false;
            shieldSlash.SetActive(true);
            holdShield.SetActive(false);
        }

        if (slashing) {
            currentThrowSeconds += Time.deltaTime;
            if (currentThrowSeconds > slashTime) {
                holdingShield = true;
                holdShield.SetActive(true);
                slashing = false;
                shieldSlash.SetActive(false);
                currentThrowSeconds = 0f;
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

    public void disableHoldShield() {
        if (holdingShield) {
            holdingShield = false;
            holdShield.SetActive(false);
        }
    }

    public void enableHoldShield() {
        if (!holdingShield && !throwing && !slashing && !returning) {
            holdingShield = true;
            holdShield.SetActive(true);
        }
    }
}
