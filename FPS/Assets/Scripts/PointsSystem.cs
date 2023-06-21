using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    public int currPoints = 0;
    [SerializeField] private int pointsFromSpider = 100;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update

    public void AddPoints()
    {
        currPoints += pointsFromSpider;
        scoreText.text = currPoints.ToString();
    }

    private int CurrentPoints()
    {
        return currPoints;
    }
}
