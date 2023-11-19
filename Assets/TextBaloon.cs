using UnityEngine;
using TMPro;

public class TextBaloon : MonoBehaviour
{
    public Transform characterTransform; // Metnin konumunu belirlemek için karakterin transformu
    public string textToDisplay = "Merhaba!"; // Yazılacak metin

    public TMP_Text textMeshProComponent;

    void Start()
    {
        
        if (textMeshProComponent == null)
        {
            Debug.LogError("TextMeshPro component not found!");
            return;
        }

        // Metni karakterin üstüne yerleştirme
        if (characterTransform != null)
        {
            // Metni karakterin üstüne konumlandırma
            textMeshProComponent.transform.position = characterTransform.position + Vector3.up * 2f; // Örnek olarak yukarıda 2 birim yukarı konumlandırıldı

            // Metni ayarlama
            textMeshProComponent.text = textToDisplay;
        }
        else
        {
            Debug.LogError("Character transform not assigned!");
        }
    }
}
