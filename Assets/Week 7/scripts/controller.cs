using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static float score = 0;
    public Slider chargeSlider;
    float charge;
    public float MaxCharge;
    public float prevScore;
    public static Vector2 direction;
    public static bawlplayer CurrentSelection { get; private set; }
    public static void SetCurrentSelection(bawlplayer player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }
        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }
    private void Start()
    {
        prevScore = score;
        scoreText.SetText("score: " + score);

    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            CurrentSelection.Move(direction);
            direction = Vector2.zero;
        }
    }
    private void Update()
    {
        if (CurrentSelection == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, MaxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)CurrentSelection.transform.position).normalized * charge;
        }
        if (score != prevScore)
        {
            ScoreUpdate();
            prevScore = score;
        }
        

    }
    private void ScoreUpdate()
    {
        scoreText.SetText("score: " + score);
    }

}
