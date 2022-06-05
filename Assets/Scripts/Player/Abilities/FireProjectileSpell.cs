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
    [SerializeField]
    private Transform playerArm;

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
        var rotation = Quaternion.LookRotation(new Vector3(destination.x - transform.position.x, destination.y - transform.position.y - 90f, destination.z - transform.position.z));
        var projectileObject = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObject.transform.localRotation = rotation;
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
