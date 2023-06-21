using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    private int currPoints = 0;
    [SerializeField] private int pointsFromSpider = 100;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update

    public void AddPoints()
    {
        currPoints += pointsFromSpider;
        scoreText.text = currPoints.ToString();
    }

    public int CurrentPoints()
    {
        return currPoints;
    }
}
