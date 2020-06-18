using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rb;

    public Text countText;

    float rot;
    public float rotateAmount;

    private int count;
    // Start is called before the first frame update


    public Text gameOver;

    void RotateRight()
    {
        rot = rotateAmount;
        transform.Rotate(0, rot, 0);
    }

    void RotateLeft()
    {
        rot = -rotateAmount;
        transform.Rotate(0, rot, 0);
    }

    void Start()
    {
        gameOver.enabled = false;
        count = 0;
        rb = GetComponent<Rigidbody>();
        countText.text = "Score: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((Input.mousePosition.x - Screen.width / 2 > 0))
            {
                RotateRight();
            } else
            {
                RotateLeft();
            }


        } 
    }

    void FixedUpdate()
    {

        // rb.AddForce(0,0,moveSpeed);
        rb.velocity = transform.forward * moveSpeed;
       // Vector3 movement = new Vector3(1.0f, 1.0f, 1.0f);
       // rb.AddForce(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameOver.enabled = true;
            Time.timeScale = 0;

        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");

        if (other.gameObject.CompareTag("Food"))
        {
            count += 1;
            other.gameObject.SetActive(false);
            countText.text = "Score: " + count.ToString();

        }


        
    }
}
