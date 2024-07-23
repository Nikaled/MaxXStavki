using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchSlot : MonoBehaviour
{
    public MatchSlotSO MatchSlotData;
    [SerializeField] Image SportIcon;
    [SerializeField] TextMeshProUGUI MatchName;
    [SerializeField] TextMeshProUGUI MatchType;
    [SerializeField] TextMeshProUGUI Command1;
    [SerializeField] TextMeshProUGUI Command2;
     public Image Command1Image;
     public Image Command2Image;
    [Header("Total")]
    [SerializeField] TextMeshProUGUI P1;
    [SerializeField] TextMeshProUGUI P2;
    [SerializeField] TextMeshProUGUI B_Count;
    [SerializeField] TextMeshProUGUI B_Value;
    [SerializeField] TextMeshProUGUI M_Count;
    [SerializeField] TextMeshProUGUI M_Value;
    private float CurrentCoeff;
    public void SetDataValue(MatchSlotSO data, Sprite icon)
    {
        MatchSlotData = data;
        MatchName.text = data.MatchName;
        MatchType.text = data.MatchTime;
        Command1.text = data.Command1;
        Command2.text = data.Command2;
        P1.text = data.P1.ToString();
        P2.text = data.P2.ToString();
        B_Count.text =$"B({ data.BCount})";
        B_Value.text = data.BValue.ToString();
        M_Count.text = $"M({ data.MCount})";
        M_Value.text = data.MValue.ToString();
        SportIcon.sprite = icon;
    }

    public void SetAsCoeff(int index)
    {
        switch(index)
        {
            case 0:
                CurrentCoeff = MatchSlotData.P1;
                break;
            case 1:
                CurrentCoeff = MatchSlotData.P2;
                break;
            case 2:
                CurrentCoeff = MatchSlotData.BValue;
                break;
            case 3:
                CurrentCoeff = MatchSlotData.MValue;
                break;

        }
    }
    public void OpenBetButton(int CommandIndex)
    {
        BetManager.instance.OpenBet(this, CommandIndex, CurrentCoeff);
    }
}
