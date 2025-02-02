using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Mover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform mesh;
    [SerializeField] Weapon weapon;
    public static PlayerController Singleton;
    private Mover mover;

    // Start is called before the first frame update
    void Awake()
    {
        mover = GetComponent<Mover>();
        Singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
        RotateTowardMousePos();
    }

    private void ApplyMovement()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) { dir += Vector3.forward; }
        if (Input.GetKey(KeyCode.A)) { dir += Vector3.left; }
        if (Input.GetKey(KeyCode.S)) { dir -= Vector3.forward; }
        if (Input.GetKey(KeyCode.D)) { dir += Vector3.right; }

        if (Input.GetMouseButtonDown(0)) { weapon.enabled = true; }
        if (Input.GetMouseButtonUp(0)) { weapon.enabled = false; }

        mover.Move(dir, speed);
    }

    private void RotateTowardMousePos()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Initialise the enter variable
        float enter = 0.0f;
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(r, out enter))
        {
            //Get the point that is clicked
            Vector3 hitPoint = r.GetPoint(enter);
            hitPoint = new Vector3(hitPoint.x, 0, hitPoint.z);

            mover.RotateChildTowards(mesh, hitPoint * 1000);
        }
    }
}
