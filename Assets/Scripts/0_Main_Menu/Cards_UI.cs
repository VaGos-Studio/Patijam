using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cards_UI : MonoBehaviour
{
    [SerializeField] Button _backButton;
    [SerializeField] GameObject _cardObject;
    [SerializeField] SO_Deck _allCards;
    [SerializeField] Transform _cardsParent;

    private void Awake()
    {
        _backButton.onClick.AddListener(BackMainMenu);
        _backButton.onClick.AddListener(() => AudioController.Instance.SetUI(0));
    }

   

    private void Start()
    {
        BackMainMenu();

        foreach (var cardData in _allCards.Cards)
        {
            GameObject card = Instantiate(_cardObject, _cardObject.transform.position, Quaternion.identity, _cardsParent);
            TMP_Text[] cardTexts = card.GetComponentsInChildren<TMP_Text>();
            cardTexts[0].text = cardData.CardAction.ToString();
            cardTexts[1].text = cardData.CardText;
            card.GetComponent<Button>().enabled = false;
        }
    }

    public void BackMainMenu()
    {
        MainMenuController.Instance.BackMainMenu(gameObject);
    }
}
