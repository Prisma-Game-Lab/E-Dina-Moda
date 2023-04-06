using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject player;

    private float distanceToGround;
    private float playerY;

    private void FixedUpdate()
    {
        playerY = player.transform.position.y;
        distanceToGround = Mathf.Abs(playerY);

        if (playerY > 0)
        {
            player.transform.position -= new Vector3(0f, Mathf.Min(distanceToGround, moveSpeed * Time.fixedDeltaTime), 0f);
        } else if (playerY < 0)
        {
            player.transform.position += new Vector3(0f, Mathf.Min(distanceToGround, moveSpeed * Time.fixedDeltaTime), 0f);
        }
    }
}
