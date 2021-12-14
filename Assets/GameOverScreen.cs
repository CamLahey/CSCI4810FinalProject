using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour {
    public GameObject gameOverScreen;
    public GameObject crosshair;
    public static bool dead = false;
    public TMP_Text time;
    // Start is called before the first frame update
    public void Restart() {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (dead) {
            Debug.Log("alive");
            OnDie();
        }
    }
    void OnDie() {
        string minutes = ((int)Timer.gameTime / 60).ToString();
        string seconds = (Timer.gameTime % 60).ToString("f2");
        time.text = minutes + ":" + seconds;
        Debug.Log("dead");
        //time here
        dead = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        crosshair.SetActive(false);

        gameOverScreen.SetActive(true);

    }
    public void ExitGame() {
        Application.Quit();
    }
}
