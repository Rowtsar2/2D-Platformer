using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundChecker : MonoBehaviour
{
    private int _touchCount;
    
    public bool IsGround => _touchCount > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
            _touchCount++;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
            _touchCount--;
    }
}
