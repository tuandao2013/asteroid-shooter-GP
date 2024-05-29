using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;

    [SerializeField] private int baseScore;

    [SerializeField] private GameController gameController;

    [SerializeField] private GameObject popupCanvas;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void AsteroidDestroyed()
    {
        Instantiate(asteroidExplosion, transform.position, transform.rotation);

        if (GameController.currentGameStatus == GameController.GameState.Playing)
        {
            // Calculate the score for hitting this asteroid
            // Getting the distance from player to asteroid
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoint = (int) distanceFromPlayer;

            int asteroidScore = baseScore * bonusPoint;

            // Set text for the popup
            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
            // Instantiate popup canvas
            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);

            // Adjust the scale of the popup
            asteroidPopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 5),
                                                            transform.localScale.y * (distanceFromPlayer / 5),
                                                            transform.localScale.z * (distanceFromPlayer / 5));

            // Pass Score to GameController
            gameController.UpdatePlayerScore(asteroidScore);
        }

        Destroy(this.gameObject);
    }
}
