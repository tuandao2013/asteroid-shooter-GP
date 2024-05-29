using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            // Takes 2 seconds to fade out the asteroid
            other.GetComponent<Animator>().SetTrigger("FadeOut");
            // after 3 seconds destroy the object
            Destroy(other.gameObject, 3f);
        }
    }
}
