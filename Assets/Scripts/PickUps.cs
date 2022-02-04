using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public ScoreController scoreController;
    public void PickUp()
    {
        scoreController.IncreaseScore(10);
    }
}
