using UnityEngine;
public abstract class Projectile : MonoBehaviour
{
    protected Vector2 Direction;
    public virtual void Launch(Vector2 direction) => Direction = direction;
}