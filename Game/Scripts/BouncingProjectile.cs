using UnityEngine;
public class BouncingProjectile : Projectile
{
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime);
        Vector2 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
        {
            Direction = Vector2.Reflect(Direction, GetNormal(viewportPos));
        }
    }

    private Vector2 GetNormal(Vector2 viewportPos)
    {
        if (viewportPos.x < 0 || viewportPos.x > 1) return Vector2.right;
        return Vector2.up;
    }
}