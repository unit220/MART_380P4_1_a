using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded = false;
    public Seeker seeker;
    public GameObject gameOverUI;

    // Update is called once per frame
    void Update() {
        if (gameEnded)
            return;

        if (seeker.hitPlayer == true){
            EndGame();
        }
    }

    void EndGame() {
        gameEnded = true;
        gameOverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
