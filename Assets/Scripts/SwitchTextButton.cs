using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchTextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text textMesh;
    public string originalText;
    public string alternateText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(string.IsNullOrEmpty(originalText)) {
            originalText = textMesh.text;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if(textMesh.text != alternateText) {
            textMesh.text = alternateText;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if(textMesh.text != originalText) {
            textMesh.text = originalText;
        }
    }
}
