using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; // Velocidade do movimento
    public float rotationSpeed = 200.0f; // Velocidade da rota��o

    private float _horizontal;
    private float _vertical;

    void Update()
    {
        // Captura entrada do jogador
        _horizontal = Input.GetAxis("Horizontal"); // Rota��o
        _vertical = Input.GetAxis("Vertical"); // Movimento para frente e tr�s

        // Movimenta o jogador para frente e para tr�s no eixo Z
        transform.position += transform.forward * _vertical * speed * Time.deltaTime;

        // Rotaciona o jogador ao redor do eixo Y
        transform.Rotate(Vector3.up * _horizontal * rotationSpeed * Time.deltaTime);
    }
}
