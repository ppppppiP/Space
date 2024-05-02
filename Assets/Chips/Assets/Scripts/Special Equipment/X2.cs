using UnityEngine;

public class X2: MonoBehaviour
{
    public int Multiplier;
    [SerializeField] float m_Duration;

    public static X2 Instance;

    private int _oldPrice;

    private void Awake()
    {
        Instance = this;
       _oldPrice = MonyPrice.Instance.Price;
    }


    public void Muliply()
    {
        MonyPrice.Instance.Price *= Multiplier;
        StartCoroutine(Duration());
    }

    public System.Collections.IEnumerator Duration()
    {
        yield return new WaitForSeconds(m_Duration);

        MonyPrice.Instance.Price = _oldPrice;
    }

}