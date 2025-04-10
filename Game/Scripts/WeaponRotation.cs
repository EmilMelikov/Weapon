using UnityEngine;
public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private float minAngle = -90f;
    [SerializeField] private float maxAngle = 90f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 direction = touchPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}