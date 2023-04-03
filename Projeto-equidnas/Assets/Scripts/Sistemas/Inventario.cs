using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    // A lista de itens do inventário
    private List<GameObject> itens = new List<GameObject>();

    // Adiciona um item ao inventário
    public void AdicionarItem(GameObject item)
    {
        itens.Add(item);
    }

    // Remove um item do inventário
    public void RemoverItem(GameObject item)
    {
        itens.Remove(item);
    }

    // Retorna a lista de itens do inventário
    public List<GameObject> GetItens()
    {
        return itens;
    }
}