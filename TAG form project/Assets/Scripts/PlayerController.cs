using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mouseSens=2.0f;
    [SerializeField] float speed=5;
    public GameObject mainCamera;
    public GameObject redBullet;
    public GameObject blueBullet;
    float camYPos;
    public GameObject shootPoint;
    float jumpTime;
    [SerializeField] float jumpspeed;
    Rigidbody rb;
    FloorCheck fc;
    float moveX,moveZ;
    bool jump;
    float mouseY;
    float mouseX;
    float yturn;
    [SerializeField] GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        
        fc=GetComponentInChildren<FloorCheck>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc.paused)
        {
            mouseX=Input.GetAxis("Mouse X");
            mouseY=Input.GetAxis("Mouse Y");
            yturn=yturn+(mouseX*mouseSens)%360;
            camYPos-=(mouseY*mouseSens);
            mainCamera.transform.localEulerAngles=Vector3.right*Mathf.Clamp(camYPos,-90f,90f);
            
            
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(blueBullet,shootPoint.transform.position,shootPoint.transform.rotation);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(redBullet,shootPoint.transform.position,shootPoint.transform.rotation);
            }
            if (Input.GetKeyDown(KeyCode.Space) && fc.isGrounded)
            {
                jump=true;
            }
        }
        
    }
    
    void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(0,yturn,0));
        
        moveX=Input.GetAxis("Horizontal");
        moveZ=Input.GetAxis("Vertical");
        rb.velocity=new Vector3 (0,rb.velocity.y,0)+(transform.forward*moveZ*speed)+(transform.right*moveX*speed);
        if (jump)
        {
            jump=false;
            rb.velocity=Vector3.up*jumpspeed;
            
        }
    }
}
