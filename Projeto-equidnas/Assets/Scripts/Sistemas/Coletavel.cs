using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    // O inventário onde o objeto coletável será armazenado
    public GameObject inventario;
    public bool colisao = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colisao = true;

             // Desativa o objeto coletável na cena atual
            gameObject.SetActive(false);

            // Adiciona o objeto ao inventário
            inventario.GetComponent<Inventario>().AdicionarItem(gameObject);

           
        }
    }
}