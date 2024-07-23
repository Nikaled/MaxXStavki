using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class CanvasManager : MonoBehaviour
{
    [Header("Types and Formats")]
    public Image[] SportTypeBacksWithoutAll;
    public TextMeshProUGUI[] SportTypeTexts;
    public TextMeshProUGUI AllSportTypeText;
    public Image SportTypeBackAll;
    public Image[] SportFormatBacks;
    public TextMeshProUGUI[] SportFormatTexts;
    public static CanvasManager instance;
    public Sprite SportTypeBackPrefabInactive;
    public Sprite SportTypeBackPrefabActive;
    public Sprite SportFormatBackPrefabActive;
    public Sprite SportFormatBackPrefabInactive;
    public Color ActiveTextColor;
    public Color InactiveTextColor;
    private Sequence MoveUpBet;
    [Header("BetUI")]
    public GameObject BetUI;
    public GameObject BetUIMovingPanel;
    public Button BetUIBackgroundButton;
    public Transform BetUIPanel_ActivePosition;
    public Transform BetUIPanel_InactivePosition;
    private void Awake()
    {
        instance = this;
        //     MoveUpBet = DOTween.Sequence();
    }
    private void Start()
    {
        bool[] EmptyArr = new bool[SportTypeBacksWithoutAll.Length];
        SetSportTypeView(EmptyArr);
        bool[] EmptyArrFormat = new bool[SportFormatBacks.Length];
        SetSportFormatView(EmptyArrFormat);
    }
    public void SetSportTypeView(bool[] ActivatedArray)
    {
        bool IsAllActivated = true;
        for (int i = 0; i < SportTypeBacksWithoutAll.Length; i++)
        {
            if (ActivatedArray[i])
            {
                SportTypeBacksWithoutAll[i].sprite = SportTypeBackPrefabActive;
                SportTypeTexts[i].color = ActiveTextColor;
            }
            else
            {
                SportTypeBacksWithoutAll[i].sprite = SportTypeBackPrefabInactive;
                SportTypeTexts[i].color = InactiveTextColor;
            }
            if (ActivatedArray[i] == false)
            {
                IsAllActivated = false;
            }
        }
        if (IsAllActivated)
        {
            SportTypeBackAll.sprite = SportTypeBackPrefabActive;
            AllSportTypeText.color = ActiveTextColor;
        }
        else
        {
            SportTypeBackAll.sprite = SportTypeBackPrefabInactive;
            AllSportTypeText.color = InactiveTextColor;
        }
    }
    public void SetSportFormatView(bool[] ActivatedFormats)
    {
        for (int i = 0; i < SportFormatBacks.Length; i++)
        {
            if (ActivatedFormats[i])
            {
                SportFormatBacks[i].sprite = SportFormatBackPrefabActive;
                SportFormatTexts[i].color = ActiveTextColor;

            }
            else
            {
                SportFormatBacks[i].sprite = SportFormatBackPrefabInactive;
                SportFormatTexts[i].color = InactiveTextColor;
            }
        }
    }

    public void ShowBetUI(bool Is)
    {

        DOTween.Kill(BetUIMovingPanel.transform);
        if (Is)
        {
            BetUI.SetActive(Is);
            BetUIMovingPanel.transform.position = BetUIPanel_InactivePosition.position;
            BetUIMovingPanel.transform.DOMove(BetUIPanel_ActivePosition.position, 0.5f);
        }
        else
        {
            BetUIBackgroundButton.enabled = false;
            BetUIMovingPanel.transform.position = BetUIPanel_ActivePosition.position;
            BetUIMovingPanel.transform.DOMove(BetUIPanel_InactivePosition.position, 0.5f).OnComplete(HidePanel);
            void HidePanel()
            {
                BetUI.SetActive(false);
                BetUIBackgroundButton.enabled = true;
            }
        }
    }
    public void HideBetUIWithoutAnimation()
    {
        BetUI.SetActive(false);
    }
}
