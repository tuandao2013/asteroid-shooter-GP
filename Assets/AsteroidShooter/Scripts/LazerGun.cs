using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LazerGun : MonoBehaviour
{
    [SerializeField] private Animator LaserAnimator;
    [SerializeField] private AudioClip LaserSFX;
    [SerializeField] private Transform RaycastOrigin;

    private AudioSource laserAudioSource;

    private RaycastHit hit;

    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }
    public void LaserGunFired()
    {
        // Animate the gun
        LaserAnimator.SetTrigger("Fire");
        // Play laser gun SFX
        laserAudioSource.PlayOneShot(LaserSFX);
        // Raycast
        if (Physics.Raycast(RaycastOrigin.position, RaycastOrigin.forward, out hit, 800f))
        {
            if (hit.transform.GetComponent<AsteroidHit>() != null)
            {
                hit.transform.GetComponent<AsteroidHit>().AsteroidDestroyed();
            }
            else if (hit.transform.GetComponent<IRaycastInterface>() != null)
            {
                hit.transform.GetComponent<IRaycastInterface>().HitByRaycast();
            }
        }
    }
}
