using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//SCRIPT FOR CHANGING FROM TITLE SCREEN TO PLAY SCREEN

public class LOADUP : MonoBehaviour
{
    public void LoadEpicFight()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;//GOES DOWN A SCENE
        SceneManager.LoadScene(nextSceneIndex);
    }
}
