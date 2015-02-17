using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 1.0f;
    public float jumpHeight = 1.0f;
    public bool jumping = false;

    public GameObject pointer;

    private float coolDownTime = 0.1f;
    private float currentCoolDown = 0.0f;

    Vector2 faceDirection;

    Vector2 currentPosition;
    Vector2 lastPosition;

	void Start () {
        currentPosition = gameObject.transform.position;
        lastPosition = gameObject.transform.position;
	}
	
	void Update () {
        currentPosition = gameObject.transform.position;
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (Input.GetButtonDown("Fire1")) {
            if (!jumping) {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
                jumping = true;
                /*
                Vector2 jumpForce = Vector2.up;
                jumpForce.y = jumpForce.y * this.jumpForce;
                rigidbody2D.AddForce(jumpForce);
                jumping = true;
                 */
            } 
        } 
        
        if(jumping){
            currentCoolDown += Time.deltaTime;
            if (currentCoolDown > coolDownTime) {
                jumping = false;
                currentCoolDown = 0.0f;
            }
        }

        if (currentPosition.x > lastPosition.x) {
            pointer.transform.position = gameObject.transform.position;
            Vector2 pos = new Vector2(pointer.transform.position.x + 2, pointer.transform.position.y);
            pointer.transform.position = pos;
        } 
        else if(currentPosition.x < lastPosition.x) {
            pointer.transform.position = gameObject.transform.position;
            Vector2 pos = new Vector2(pointer.transform.position.x - 2, pointer.transform.position.y);
            pointer.transform.position = pos;
        } else {
            Vector2 pos = new Vector2(pointer.transform.position.x, gameObject.transform.position.y);
            pointer.transform.position = pos;
        }

        lastPosition = currentPosition;
	}
}
