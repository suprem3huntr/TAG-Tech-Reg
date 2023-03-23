using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlue : MonoBehaviour
{
    [SerializeField] float speed=5;
    Rigidbody rb;
    public GameObject sphere;
    [SerializeField] GameController gc; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(KMS),5f);
        rb=GetComponent<Rigidbody>();
        rb.velocity=transform.forward*speed;
        gc=GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {
        
        if (col.gameObject.CompareTag("Blue"))
        {
            Instantiate(sphere,col.gameObject.transform.position,col.gameObject.transform.rotation);
            Destroy(col.gameObject);
            
            gc.blue--;
            gc.Point();
            
        }
        else if (col.gameObject.CompareTag("Red"))
        {
            gc.EndGame();
        }
        Destroy(gameObject);
    }
    
    void KMS()
    {
        Destroy(gameObject);
    }
}
