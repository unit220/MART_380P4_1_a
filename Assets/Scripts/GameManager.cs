using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded = false;
    public Seeker seeker;
    public GameObject gameOverUI;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    void Start() {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update() {
        if (gameEnded)
            return;

        if (seeker.hitPlayer == true){
            EndGame();
        }
    }

    void EndGame() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        controller.m_MouseLook.lockCursor = false;
        gameEnded = true;
        gameOverUI.SetActive(true);
        // controller.m_MouseLook.lockCursor = false;
    }
}
