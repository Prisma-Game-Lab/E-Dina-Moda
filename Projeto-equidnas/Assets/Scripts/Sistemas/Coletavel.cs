using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    // O inventário onde o objeto coletável será armazenado
    
    public bool colisao = false;
    public GameObject roupa;
    public Inventario inventario;

    void Start()
    {
        GameObject inventarioObject = GameObject.Find("Inventario");
        inventario = inventarioObject.GetComponent<Inventario>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colisao = true;
            AudioManager.instance.Play("captura_sobrinho");
             // Desativa o objeto coletável na cena atual
            gameObject.SetActive(false);

            // Adiciona o objeto ao inventário
            inventario.AdicionarItem(roupa);

        }
    }
}
