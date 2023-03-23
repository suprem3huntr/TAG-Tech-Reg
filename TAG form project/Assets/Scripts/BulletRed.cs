using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : MonoBehaviour
{
   [SerializeField] float speed=5;
    Rigidbody rb;
    [SerializeField] GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        gc=GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
        rb.velocity=transform.forward*speed;
        Invoke(nameof(KMS),5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {
        
        if (col.gameObject.CompareTag("Red"))
        {
            
            Destroy(col.gameObject);
            
            gc.red--;
            gc.Point();
            
        }
        else if (col.gameObject.CompareTag("Blue"))
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
