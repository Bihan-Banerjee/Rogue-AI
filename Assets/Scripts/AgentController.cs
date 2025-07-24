using UnityEngine;

public class AgentController : MonoBehaviour
{
    public float moveCooldown = 0.2f;
    float timer;
    public GridManager grid;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        Vector3 dir = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector3.up;
        if (Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector3.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector3.right;
        if (dir != Vector3.zero && CanMove(dir))
        {
            transform.position += dir;
            timer = moveCooldown;
        }
    }

    bool CanMove(Vector3 dir)
    {
        Vector3 newPos = transform.position + dir;
        return newPos.x >= 0 && newPos.x < grid.width && newPos.y >= 0 && newPos.y < grid.height;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Reward"))
        {
            // Handle reward logic (add score, respawn reward, etc.)
            Destroy(col.gameObject);
            Debug.Log("Collected Reward!");
        }
        else if (col.CompareTag("Enemy"))
        {
            // Handle game over logic
            Debug.Log("Hit Enemy!");
        }
    }
}
