using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFixed : MonoBehaviour
{
    CharacterController characterController;

    private TextMesh scoreText;
    private string score;

    void Start() {
        scoreText = transform.Find("ScoreText").GetComponent<TextMesh>();
        SetScore("Pending...");
    }

    private void SetScore(string s) {
        score = s;
        scoreText.text = score;
    }

    public void TrueAns() {
        SetScore("True");
    }
    public void FalseAns() {
        SetScore("False");
    }
}
