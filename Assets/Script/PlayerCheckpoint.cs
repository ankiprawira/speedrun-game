using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public GameObject flag;
    private PlayerMovement pm;
    private Rigidbody rb;
    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
        pm.readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            spawnPoint = flag.transform.position;
            Destroy(flag);
        }
    }

    public void Respawn()
    {
        gameObject.transform.position = spawnPoint;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
