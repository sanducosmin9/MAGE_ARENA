using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileSpell : MonoBehaviour
{
    private PlayerInput controls;
    private Camera cam;

    private Vector3 destination;

    [SerializeField] 
    private GameObject projectile;
    [SerializeField]
    private Transform firePoint;

    private float fireCooldown = 2f;
    private float timeUntilAbleToFire;

    private float projectileSpeed = 40f;
    private void Awake()
    {
        controls = new PlayerInput();
        cam = transform.Find("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        bool canFire = controls.Player.Mouse1.IsPressed() && Time.time >= timeUntilAbleToFire;
        if (canFire)
        {
            timeUntilAbleToFire = Time.time + 1 / fireCooldown;
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjectile();
    }

    private void InstantiateProjectile()
    {
        var projectileObject = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
        projectileObject.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
