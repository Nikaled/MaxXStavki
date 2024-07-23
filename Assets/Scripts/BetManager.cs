using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetManager : MonoBehaviour
{
    public static BetManager instance;
    public MatchSlotSO MatchSlotData;
    public MatchSlot currentMatchSlot;
    private float CurrentBetModificator;
    public int Bet
    {
        get
        {
            return _betDontUse;
        }
        set { _betDontUse = value; SetBetText(_betDontUse); PromisedValueCount = (int)(Bet * CurrentBetModificator); }
    }
    private int _betDontUse;
    public int CurrentCoins
    {
        get
        {
            return _coinsDontUse;
        }
        set { _coinsDontUse = value; SetCoinsText(_coinsDontUse); }
    }
    private int _coinsDontUse;
    public int PlayerPromisedCurrentBetTeamWinner;
    public int PromisedValueCount
    {
        get
        {
            return _promisedValue;
        }
        set { _promisedValue = value; SetPromiseValueText(_promisedValue); }
    }
    private int _promisedValue;
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] TextMeshProUGUI CoinsMainUI;
    [SerializeField] TextMeshProUGUI BetCoinCount;
    [SerializeField] TextMeshProUGUI PromisedValue;
    [SerializeField] TextMeshProUGUI CommandNames;
    [SerializeField] TextMeshProUGUI CoeffText;


    [SerializeField] GameObject StartedBetUI;
    [SerializeField] Image Command1Image;
    [SerializeField] Image Command2Image;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI Command1Name;
    [SerializeField] TextMeshProUGUI Command2Name;
    [SerializeField] GameObject EndBetUI;
    [SerializeField] TextMeshProUGUI CommandWinnerName;
    [SerializeField] Image WinnerImage;
    [SerializeField] GameObject WinBetUI;
    [SerializeField] GameObject LoseBetUI;
    [SerializeField] TextMeshProUGUI RewardOrLostCountText;
    private void Awake()
    {
        instance = this;
        CurrentCoins = 300;
    }
    public void OpenBet(MatchSlot pushedMatchSlot, int CommandIndex, float Coeff)
    {
        CanvasManager.instance.ShowBetUI(true);
        PlayerPromisedCurrentBetTeamWinner = CommandIndex;
        currentMatchSlot = pushedMatchSlot;
        MatchSlotData = currentMatchSlot.MatchSlotData;
        CurrentBetModificator = Coeff;
        CoeffText.text = CurrentBetModificator.ToString();
        Bet = 0;

        CommandNames.text = $"{MatchSlotData.Command1} - {MatchSlotData.Command2} ";
        Command1Name.text = $"{MatchSlotData.Command1}";
        Command2Name.text = $"{MatchSlotData.Command2}";
        Command1Image.sprite = currentMatchSlot.Command1Image.sprite;
        Command2Image.sprite = currentMatchSlot.Command2Image.sprite;
    }

    public void ChangeBetOnCount(int AddedCount)
    {
        Bet += AddedCount;
        if(Bet < 0)
        {
            Bet = 0;
        }
    }
    private void SetPromiseValueText(int CurrentCoins)
    {
        PromisedValue.text = CurrentCoins.ToString();
    }
    private void SetCoinsText(int CurrentCoins)
    {
        Coins.text = CurrentCoins.ToString();
        CoinsMainUI.text = CurrentCoins.ToString();
    }
    private void SetBetText(int CurrentCoins)
    {
        BetCoinCount.text = CurrentCoins.ToString();
    }
    public void QuickBet(int BetCount)
    {
        Bet = BetCount;
        StartBet();
    }
    public void StartBet()
    {
        if(Bet == 0)
        {
            return;
        }
        CanvasManager.instance.HideBetUIWithoutAnimation();
        StartedBetUI.SetActive(true);
        StartCoroutine(BeginBetTimer());
    }
    private IEnumerator BeginBetTimer()
    {
        int Timer = 5;
        TimerText.text = Timer.ToString();
        while (Timer > 0)
        {
            yield return new WaitForSeconds(1);
            Timer--;
            TimerText.text = Timer.ToString();
        }
        ShowResults();

    }
    private void ShowResults()
    {
        StartedBetUI.SetActive(false);
        EndBetUI.SetActive(true);
        int RandomWinner = Random.Range(0, 2);
        Debug.Log("RandomWinnerIndex" + RandomWinner);
        SetWinnerImage(RandomWinner);
        if (RandomWinner == PlayerPromisedCurrentBetTeamWinner)
        {
            CurrentCoins += PromisedValueCount;
            if(RandomWinner == 0)
            {
                WinnerImage.sprite = currentMatchSlot.Command1Image.sprite;
                CommandWinnerName.text = MatchSlotData.Command1;
            }
            else
            {
                WinnerImage.sprite = currentMatchSlot.Command2Image.sprite;
                CommandWinnerName.text = MatchSlotData.Command2;
            }
            RewardOrLostCountText.text = PromisedValueCount.ToString();
            WinBetUI.SetActive(true);
            LoseBetUI.SetActive(false);

        }
        else
        {
            WinBetUI.SetActive(false);
            LoseBetUI.SetActive(true);
            if (RandomWinner == 0)
            {
                WinnerImage.sprite = currentMatchSlot.Command1Image.sprite;
                CommandWinnerName.text = MatchSlotData.Command1;
            }
            else
            {
                WinnerImage.sprite = currentMatchSlot.Command2Image.sprite;
                CommandWinnerName.text = MatchSlotData.Command2;
            }
            RewardOrLostCountText.text = Bet.ToString();
            CurrentCoins -= Bet;
        }
    } 
    private void SetWinnerImage(int WinnerIndex)
    {
        if (WinnerIndex == 0)
        {
            WinnerImage.sprite = currentMatchSlot.Command1Image.sprite;
        }
        else
        {
            WinnerImage.sprite = currentMatchSlot.Command2Image.sprite;
        }
    }
}
