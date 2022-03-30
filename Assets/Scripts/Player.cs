using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float boostSpeed = 20.0f;
    public float fireRate = 0.25f;
    public float canFire = 0.0f;
    // can fire in 0.25f
    public GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // current position = new position spawn
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ShootLaser();       
    }

    void PlayerMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * xInput * Time.deltaTime);

        float yInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * yInput * Time.deltaTime);

        // lock Y at 4.12f > set player postition Y to 4.12f

        if (transform.position.y > 4.12f)
        {
            transform.position = new Vector3(transform.position.x, 4.12f, 0);
        }
        else if (transform.position.y < -4.12f)
        {
            transform.position = new Vector3(transform.position.x, -4.12f, 0);
        }

        if (transform.position.x > 8.24f)
        {
            transform.position = new Vector3(8.24f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.24f)
        {
            transform.position = new Vector3(-8.24f, transform.position.y, 0);
        }
    }

    void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(-0.07f, 2.06f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }
}

