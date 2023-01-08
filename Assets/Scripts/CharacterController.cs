using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    
    public float speed = 5.0f;  // Speed will be constant throughout the game.  
    public static bool gameOver = false;
    private Vector3 targetDirection;    // This will hold the position of the mouse, raycasted into the world. 
                                        // It determines the movement direction.
    private Rigidbody playerRigidbody;   // This will hold the rb component of the player character.
    [SerializeField] private int layer = 7; // This is the layer we want to isolate for raycasting.
                                            // 6: Ring, 7: Ground
    private int layerAsLayerMask; 
    private bool onRing = true;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Caching the rb component.
        layerAsLayerMask = (1 << layer);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (CountDownTimer.countDownTime == -1)
        {
            if (Physics.Raycast(ray, out hit, 100, layerAsLayerMask) && onRing)
            {
                Debug.DrawLine(ray.origin, hit.point);
                targetDirection = hit.point;
                targetDirection = new Vector3 (targetDirection.x, transform.position.y, targetDirection.z);
                transform.LookAt(targetDirection);
                playerRigidbody.velocity = transform.forward * speed;
            }
            else if (Physics.Raycast(ray, out hit, 100, layerAsLayerMask) && onRing!)
            {
                Debug.DrawLine(ray.origin, hit.point);
                targetDirection = hit.point;
                transform.LookAt(targetDirection);
                playerRigidbody.velocity = transform.forward * speed;
            }
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Walls")
        {
            onRing = false;
        }

        if (other.gameObject.tag == "Ground")
        {
            gameOver = true;
        }

    }

}
