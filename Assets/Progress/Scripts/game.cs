using UnityEngine;
using System.Collections;

public class game : MonoBehaviour
{
    public LayerMask PlayerLayerMask;

    public static game Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Error, there must be two GameSingletons in the scene!");
            return;
        }

        Instance = this;
    }
}
