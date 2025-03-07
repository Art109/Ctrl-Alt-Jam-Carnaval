using UnityEngine;

public class ParticleDecalSpawner : MonoBehaviour
{
    public GameObject decalPrefab; // Arraste o prefab do decal aqui
    public LayerMask groundLayer; // Defina a layer do ch�o

    void OnParticleCollision(GameObject other)
    {
        if (((1 << other.layer) & groundLayer) != 0) // Se for ch�o
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f, groundLayer))
            {
                // Instancia o decal na posi��o da colis�o
                GameObject decal = Instantiate(decalPrefab, hit.point, Quaternion.LookRotation(hit.normal));

                // Ajustar rota��o para ficar alinhado ao ch�o
                decal.transform.Rotate(90, 0, 0);

                // Opcional: Destruir o decal ap�s um tempo para evitar sobrecarga na cena
                Destroy(decal, 10f);
            }
        }
    }
}
