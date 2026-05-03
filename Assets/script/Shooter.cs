using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public Transform shootpoint;
    public GameObject target;
    public Rigidbody2D bulletPrefab;
   
    void Update()
    {
        Vector2 screePos = Mouse.current.position.ReadValue();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(screePos);
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.red, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("Hit: " + hit.collider.name);

                Vector2 projectileVelocity = CalculateProjectileVelocity(shootpoint.position,hit.point, 1f);

                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootpoint.position, Quaternion.identity);
                shootBullet.linearVelocity = projectileVelocity;
            }
        }
    }
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
      Vector2 distance = target - origin;
        return new Vector2(distance.x / time, distance.y / time - 0.5f * Physics2D.gravity.y * time);
    }
}
