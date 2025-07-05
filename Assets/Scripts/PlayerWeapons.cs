using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] int lasermode = 1;
    [SerializeField] ParticleSystem[] lasers1;
    [SerializeField] ParticleSystem[] lasers2;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    List<ParticleSystem[]> laserGroup = new List<ParticleSystem[]>();
    bool isFiring = false;
    bool isWeaponChange = false;
    ParticleSystem.EmissionModule laserControl;

    void Awake()
    {
        laserGroup.Add(lasers1);
        laserGroup.Add(lasers2);
        ResetWeapon();
        Cursor.visible = false;
    }

    void Update()
    {
        MoveCrosshair();
        MoveTargetPoint();
        ProcessFiring(lasermode);
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void OnChangeWeapon()
    {
        lasermode++;
        if (lasermode > laserGroup.Count) lasermode = 1;
        isWeaponChange = true;
    }

    void ProcessFiring(int lasermode)
    {
        if (isWeaponChange)
        {
            ResetWeapon();
            isWeaponChange = false;
        }
        foreach (ParticleSystem laser in laserGroup[lasermode-1])
        {
            laserControl = laser.emission;
            laserControl.enabled = isFiring;
        }
    }

    void ResetWeapon()
    {
        foreach (ParticleSystem[] lasers in laserGroup)
        {
            foreach (ParticleSystem laser in lasers)
            {
                laserControl = laser.emission;
                laserControl.enabled = false;
            }
        }
    }

    public void NeedChangeWeapon(int newLasermode)
    {
        isWeaponChange = true;
        lasermode = newLasermode;
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPos);
    }
}
