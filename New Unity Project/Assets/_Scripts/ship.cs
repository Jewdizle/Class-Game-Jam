using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum players
{
    blue, red, green, yellow
}

public class ship : MonoBehaviour
{
    public GameObject crashParticles;
    public GameObject collectParticles;
    // "active" is required to prevent the ships from collecting stars or spinning at the start of the game.
    private bool active = false;
    public players p;
    public float rotateSpeed;
    public float speed;
    public Rigidbody rb;
    public KeyCode actionButton;
    private bool rotateDirection = true;
    public int score;
    public Text scoreText;
    public GameObject bullet;

    float x;
    float z;
    public float radius;
    


    void Start()
    {
        if (p == players.blue)
        {
            actionButton = KeyCode.Q;
        }
        else if (p == players.red)
        {
            actionButton = KeyCode.P;
        }
        else if (p == players.green)
        {
            actionButton = KeyCode.Z;
        }
        else if (p == players.yellow)
        {
            actionButton = KeyCode.M;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(actionButton))
        {
            active = true;
        }

        if (active == true)
        {
            //MOVE
            if (Input.GetKey(actionButton))
            {
                rb.AddForce(transform.forward * -speed);
            }
            //ROTATE
            else
            {
                if (rotateDirection == true)
                {
                    gameObject.transform.Rotate(0, -rotateSpeed, 0);
                }
                else if (rotateDirection == false)
                {
                    gameObject.transform.Rotate(0, rotateSpeed, 0);
                }
            }
            //REVERSE ROTATION OF SHIP
            if (Input.GetKeyDown(actionButton))
            {
                rotateDirection = !rotateDirection;
            }

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

            if (Input.GetKeyUp(actionButton))
            {
                float rotation = transform.rotation.y * Mathf.Rad2Deg;

                x = Mathf.Sin(rotation) * radius;
                z = Mathf.Cos(rotation) * radius;

                Debug.Log(x);
                Debug.Log(z);

                Instantiate(bullet, new Vector3((transform.position.x + x), transform.localPosition.y, (transform.position.z + z)), transform.rotation);

            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active == true)
        {
            if (other.gameObject.tag == "Collectable")
            {
                score++;
                Destroy(other.gameObject);
                scoreText.text = "" + score;
                Instantiate(collectParticles, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        SceneCamera.instance.shakeDuration = 0.2f;
        Instantiate(crashParticles, transform.position, Quaternion.identity);
    }
}