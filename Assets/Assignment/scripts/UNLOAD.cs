using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//SCRIPT FOR GOING BACK TO START SCREEN
public class UNLOAD : MonoBehaviour
{
    public void IGiveUp()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;//GOES BACK A SCENE
        SceneManager.LoadScene(nextSceneIndex);
    }
}
