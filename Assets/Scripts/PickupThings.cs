using UnityEngine;
using UnityEngine.UI;

public class PickupThings : MonoBehaviour
{

    public int coinScore;
    public int scoreAmount;
    public Text scoreText;
    public GameObject scoreEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + coinScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Instantiate(scoreEffect, other.transform.position, Quaternion.identity);
            coinScore += scoreAmount;
            scoreText.text = "SCORE: " + coinScore.ToString();
            Destroy(other.gameObject);
        }
    }
}
