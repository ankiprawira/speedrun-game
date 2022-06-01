using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpoint : MonoBehaviour
{
    private GameObject flag;
    private Rigidbody rb;
    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        TimerController.instance.BeginTimer();
        spawnPoint = gameObject.transform.position;
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
            flag = other.gameObject;
            spawnPoint = other.transform.position;
            Destroy(flag);
        } else if (other.gameObject.CompareTag("Deathpoint"))
        {
            Respawn();
        } else if (other.gameObject.CompareTag("Finishpoint"))
        {
            TimerController.instance.EndTimer();
            SceneManager.LoadScene("LevelFinishScene");
        }
    }

    public void Respawn()
    {
        gameObject.transform.position = spawnPoint;
        // rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
