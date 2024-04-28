using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIGun : MonoBehaviour
{
    public Transform gun; // Silahın Transform bileşeni
    float rotationSpeed = 10f;
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateGun(mousePos);
    }

    void RotateGun(Vector3 lookPoint)
    {
        Vector3 distanceVector = lookPoint - gun.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
    }
}
