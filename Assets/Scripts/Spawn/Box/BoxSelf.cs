using UnityEngine;

public class BoxSelf : MonoBehaviour
{
    private string ranText = "abcdefghijklmnopqrstuvwxyz";

    [SerializeField] private string selfLetter;

    [SerializeField] private TMPro.TextMeshProUGUI selfText;

    void Start()
    {
        selfLetter = ranText[Random.Range(0, ranText.Length - 1)].ToString();
        selfText.text = selfLetter;
    }

    #region forEvents

    // event_destroyAllBox
    public void DestroyBox(Spawner spawner)
    {
        spawner.event_destroyAllBox -= DestroyBox;
        Destroy(gameObject);
    }

    #endregion
}
