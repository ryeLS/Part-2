using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scenename : MonoBehaviour
{
    TextMeshProUGUI sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = GetComponent<TextMeshProUGUI>();
        sceneName.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
