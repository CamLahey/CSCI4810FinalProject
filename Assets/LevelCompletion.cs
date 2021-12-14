using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour {
    // Start is called before the first frame update
    
    public Transform player;
    private Rigidbody rb;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject hubWorld;


    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update() {
        
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Finish 1") {
            level1.SetActive(false);
            level2.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Finish 2") {
            level2.SetActive(false);
            level3.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Finish 3") {
            level3.SetActive(false);
            level4.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Finish 4") {
            GameOverScreen.dead = true;
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Start 1") {
            hubWorld.SetActive(false);
            level1.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Start 2") {
            hubWorld.SetActive(false);
            level2.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Start 3") {
            hubWorld.SetActive(false);
            level3.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.name == "Start 4") {
            hubWorld.SetActive(false);
            level4.SetActive(true);
            player.position = new Vector3(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }

    }
}
