using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    int scoreRed;
    int scoreBlue;
    int scoreYellow;
    int scoreGreen;

    public ship redShip;
    public ship blueShip;
    public ship yellowShip;
    public ship greenShip;

    public List<ship> ships;
    public string winner;

    public GameObject cloneStar;
    public GameObject star;

    private Vector3 starPosition;

    private void Start()
    {
        SpawnCollectableThing();
    }

    private void Update()
    {
        checkForWinner();
    }

    public void checkForWinner()
    {
        foreach(ship s in ships)
        {
            if(s.score >= 1)
            {
                winner = s.p.ToString();
            }
        }
    }

    public void SpawnCollectableThing()
    {
        starPosition.x = Random.Range(-19f, 19f);
        starPosition.y = 0.36f;
        starPosition.z = Random.Range(-10f, 10f);

        cloneStar = Instantiate(star, new Vector3(starPosition.x, starPosition.y, starPosition.z), Quaternion.identity);
    }
}
