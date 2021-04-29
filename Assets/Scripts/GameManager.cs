using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded = false;
    public Seeker seeker;
    public Trigger trigger;
    public GameObject gameOverUI;
    public GameObject victoryUI;
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
        else if (trigger.inTrigger) {
            WinGame();
        }
    }

    void EndGame() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        controller.m_MouseLook.lockCursor = false;
        gameEnded = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        // controller.m_MouseLook.lockCursor = false;
    }

    void WinGame() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        controller.m_MouseLook.lockCursor = false;
        gameEnded = true;
        victoryUI.SetActive(true);
        Time.timeScale = 0;
    }
}
