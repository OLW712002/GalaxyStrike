using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] int lasermode = 1;
    [SerializeField] ParticleSystem[] lasers1;
    [SerializeField] ParticleSystem[] lasers2;

    List<ParticleSystem[]> laserGroup = new List<ParticleSystem[]>();
    bool isFiring = false;
    bool isWeaponChange = false;
    ParticleSystem.EmissionModule laserControl;

    void Awake()
    {
        laserGroup.Add(lasers1);
        laserGroup.Add(lasers2);
    }

    void Update()
    {
        ProcessChangeWeapon(lasermode);
        ProcessFiring();
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessChangeWeapon(int newlasermode)
    {
        if (isWeaponChange)
        {
            foreach (ParticleSystem[] lasers in laserGroup)
            {
                foreach (ParticleSystem laser in lasers)
                {
                    laserControl = laser.emission;
                    laserControl.enabled = false;
                }
            }
            isWeaponChange = false;
        }
    }

    public void NeedChangeWeapon(int newLasermode)
    {
        isWeaponChange = true;
        lasermode = newLasermode;
    }

    void ProcessFiring()
    {
        foreach (ParticleSystem laser in lasers1)
        {
            laserControl = laser.emission;
            laserControl.enabled = isFiring;
        }
    }
}
