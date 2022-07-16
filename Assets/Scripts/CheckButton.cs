using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private Button buttonGenerate;
    [SerializeField] private Button buttonMix;

    public void OffButton()
    {
        buttonGenerate.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        buttonMix.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);

        buttonGenerate.interactable = false;
        buttonMix.interactable = false;
    }

    public void OnButton()
    {
        buttonGenerate.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        buttonMix.GetComponent<Image>().color = new Color(1, 1, 1, 1f);

        buttonGenerate.interactable = true;
        buttonMix.interactable = true;
    }
}
