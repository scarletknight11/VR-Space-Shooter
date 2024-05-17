using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;

    private AudioSource laserAudioSource;

    private RaycastHit hit;

    private void Awake()
    {
        laserAudioSource.GetComponent<AudioSource>();
    }

    public void LaserGunFire()
    {
        //Animate the gun
        laserAnimator.SetTrigger("Fire");


        //Play laser gun SFX
        laserAudioSource.PlayOneShot(laserSFX);

        //raycast
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 500f))
        {
            if (hit.transform.GetComponent<AsteroidHit>() != null)
            {
                hit.transform.GetComponent<AsteroidHit>().AsteroidDestroyed();
            }
        }
    }
}
