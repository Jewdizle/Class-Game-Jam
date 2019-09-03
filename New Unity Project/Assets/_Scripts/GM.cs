using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    public GameObject playerWins;
    public Text playerWinsText;

    public int requiredScoreToWin;

    public List<ship> ships;
    public string winner;

    public GameObject cloneStar;
    public GameObject star;

    private Vector3 starPosition;
    private bool starspawned;

    private void Start()
    {
        SpawnCollectableThing();
    }

    private void Update()
    {
        checkForWinner();

        if (starspawned == true)
        {
            starspawned = false;
            Invoke("SpawnCollectableThing", 3);
        }
    }


    public void checkForWinner()
    {
        foreach(ship s in ships)
        {
            if(s.score >= requiredScoreToWin)
            {
                winner = s.p.ToString();
                playerWinsText.text = winner + " wins!";
                playerWins.SetActive(true);
                Invoke("Reset", 3);
            }

        }
    }

    private void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void SpawnCollectableThing()
    {
        starPosition.x = Random.Range(-17f, 17f);
        starPosition.y = 0.36f;
        starPosition.z = Random.Range(-8f, 8f);

        cloneStar = Instantiate(star, new Vector3(starPosition.x, starPosition.y, starPosition.z), Quaternion.identity);
        starspawned = true;
    }
}
