﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    public float scaler = 2;
    public Prect paddleL;
    private Color lPaddleColor = new Color(1,1,0,1);
    // Start is called before the first frame update
    void Start()
    {
        paddleL = new Prect("left Paddle", 50, 100, 10, 30, true, "PADDLE");
        if (paddleL.rect.y < 30) paddleL.rect.y = 30;
        Manager.colliderPrects.Add(paddleL);
    }

    // Update is called once per frame
    void Update()
    {
        paddleL.rect.y += -scaler * Input.GetAxis("Vertical");
        if (paddleL.rect.y < 30) paddleL.rect.y = 30;
        if (paddleL.rect.y > Screen.height - 50) paddleL.rect.y = Screen.height - 50;

    }
    private void OnGUI()
    {
        Manager.GUIDrawRect(paddleL.rect, lPaddleColor);
    }
}
