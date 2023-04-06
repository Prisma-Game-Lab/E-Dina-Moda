using UnityEngine;

public class GravityField : MonoBehaviour
{
    public Vector2 gravityBoxSize = new Vector2(10, 2);
    public float gravityForce = 9.8f;
    public float minDistanceFromCenter = 1.0f;
    public string playerTag = "Player";

    private float playerY;

    void FixedUpdate()
    {
        // Obtenha todos os colliders dentro da caixa de colisão do campo gravitacional
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, gravityBoxSize, 0);

        foreach (Collider2D collider in colliders)
        {
            // Obtenha a tag do collider
            string tag = collider.gameObject.tag;

            // Se a tag for diferente da tag do jogador, continue para o próximo collider
            if (tag != playerTag)
            {
                continue;
            }

            // Obtenha o componente Rigidbody2D do collider
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            // Se o collider não tiver um Rigidbody2D, continue para o próximo
            if (rb == null)
            {
                continue;
            }

            // Calcule o vetor de força para puxar o jogador
            playerY = collider.transform.position.y;

            // Calcule a distância do jogador em relação ao centro do campo gravitacional
            float distanceFromCenter = Mathf.Abs(playerY - transform.position.y);

            // Se o jogador estiver perto o suficiente do centro do campo gravitacional, pare de aplicar a força
            if (distanceFromCenter <= minDistanceFromCenter)
            {
                continue;
            }

            Vector2 forceDirection = Vector2.down * playerY;
            Vector2 gravityForceVector = forceDirection.normalized * gravityForce;

            // Aplica a força no jogador apenas no eixo Y
            rb.AddForce(gravityForceVector.y * Vector2.up, ForceMode2D.Force);

        }
    }
}
