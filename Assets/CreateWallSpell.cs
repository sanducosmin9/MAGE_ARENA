using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallSpell : MonoBehaviour
{
    private PlayerInput controls;
    private Camera cam;

    [SerializeField] private GameObject wall;

    private Vector3 destination;

    private float fireCooldown = 1;
    private float timeUntilAbleToFire;
    private void Awake()
    {
        controls = new PlayerInput();
        cam = transform.Find("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        bool canFire = controls.Player.Mouse2.triggered && Time.time > timeUntilAbleToFire;
        if (canFire)
        {
            timeUntilAbleToFire = Time.time + 1 / fireCooldown;
            CreateWall();
        }        
    }

    private void CreateWall()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        InstantiateWall(hit.point);
    }

    private void InstantiateWall(Vector3 point)
    {
        var wallObject = Instantiate(wall, point, Quaternion.identity) as GameObject;
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
