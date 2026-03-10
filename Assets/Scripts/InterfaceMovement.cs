using UnityEngine;

public class InterfaceMovement : MonoBehaviour
{
    [Header("Configurações de movimento")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    [Header("Configurações de tremida")]
    public float shakeAmount = 10f; // Intensidade da tremida
    public float shakeSpeed = 20f; // Velocidade da tremida
    
    private Vector3 originalPosition;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Efeito de tremida usando Perlin Noise
        float shakeX = Mathf.PerlinNoise(Time.time * shakeSpeed, 0) * shakeAmount - (shakeAmount / 2);
        float shakeY = Mathf.PerlinNoise(Time.time * shakeSpeed, 1) * shakeAmount - (shakeAmount / 2);
        
        rectTransform.anchoredPosition = originalPosition + new Vector3(shakeX, shakeY, 0);
    }
}