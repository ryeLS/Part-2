using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public static float score = 0;
    public Slider chargeSlider;
    float charge;
    public float MaxCharge;
    Vector2 direction;
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
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
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
    }
    public void CalculateScore()
    {
        score++;
    }

}
