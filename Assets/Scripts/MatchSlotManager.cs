using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MatchSlotManager : MonoBehaviour
{
    public MatchSlotSO[] MatchSlotDatas;
    public MatchSlot MatchSlotPrefab;
    public List<MatchSlot> MatchSlots = new();
    public Sprite[] MatchTypeIcons;
    public static MatchSlotManager instance;
    public GameObject MatchesParent;
    public bool[] TypeActivated;
    public bool[] FormatActivated;
    public List<Sprite> CommandSprites;
    public List<Sprite> CommandLogos;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TypeActivated = new bool[5];
        FormatActivated = new bool[4];
        for (int i = 0; i < MatchSlotDatas.Length; i++)
        {
            var newSlot = Instantiate(MatchSlotPrefab);
            newSlot.transform.parent = MatchesParent.transform;
            newSlot.SetDataValue(MatchSlotDatas[i], GetIcon(MatchSlotDatas[i].SportType));
            MatchSlots.Add(newSlot);
            newSlot.gameObject.SetActive(false);
            //SetLogos(newSlot);
            SetCommandSprites(newSlot);
            //SetNamesToEng(MatchSlotDatas[i], ref MatchSlotDatas[i].Command1);
            //SetNamesToEng(MatchSlotDatas[i], ref MatchSlotDatas[i].Command2);
            //if(MatchSlotDatas[i].MatchTime != string.Empty)
            //{
            //    if (MatchSlotDatas[i].MatchTime[0] == '2')
            //    {
            //        MatchSlotDatas[i].MatchTime = "2 Time";
            //    }
            //}
           
        }
    }

    private void SetNamesToEng(MatchSlotSO slotSO, ref string Name)
    {
        //        Гагарин 3 - Gagarin
        //   Владивосток 13 - Vladivostock
        //Чепаевск 0 - Chepaevsk
        //Норильск 6 - Norilsk
        //Мадрид 4 - Madrid
        //Эспаньоло 2 - Espanyol
        //Департиво 1 - Deportivo
        //Севилья  10 - Sevilla 
        //Вязьма 14 - Vyazma
        //Тула 12 - Tula
        //Сафоново 9 - Safonovo
        //Подольск 8 - Podolsk
        //Москва 5 - Moscow
        //Санкт - Петербург 7 - St. Peterburg
        //Сочи 11 - Sochi
        switch (Name)
        {
            case "Гагарин":
                Name = "Gagarin";
                break;
            case "Владивосток":
                Name = "Vladivostock";
                break;
            case "Чепаевск":
                Name = "Chepaevsk";
                break;
            case "Норильск":
                Name = "Norilsk";
                break;
            case "Мадрид":
                Name = "Madrid";
                break;
            case "Эспаньоло":
                Name = "Espanyol";
                break;
            case "Департиво":
                Name = "Deportivo";
                break;
            case "Севилья":
                Name = "Sevilla";
                break;
            case "Тула":
                Name = "Tula";
                break;
            case "Сафоново":
                Name = "Safonovo";
                break;
            case "Подольск":
                Name = "Podolsk";
                break;
            case "Москва":
                Name = "Moscow";
                break;
            case "Санкт - Петербург":
                Name = "St. Peterburg";
                break;
            case "Санкт-Петербург":
                Name = "St. Peterburg";
                break;
            case "Сочи":
                Name = "Sochi";
                break;
            case "Вязьма":
                Name = "Vyazma";
                break;
            default:
                Debug.Log($"Не найдено имя: {Name} в слоте {slotSO.name}");
                    break;
        }

    }
    private void SetLogos(MatchSlot slot)
    {
        SetLogoForCommand(slot.MatchSlotData.Command1,ref slot.MatchSlotData.Command1Logo, slot);
        SetLogoForCommand(slot.MatchSlotData.Command2,ref slot.MatchSlotData.Command2Logo, slot);
//        Гагарин 3
//   Владивосток 13
//Чепаевск 0
//Норильск 6
//Мадрид 4
//Эспаньоло 2
//Департиво 1
//Севилья  10
//Вязьма 14
//Тула 12
//Сафоново 9
//Подольск 8
//Москва 5
//Санкт - Петербург 7
//Сочи 11

        void SetLogoForCommand(string CommandName, ref Sprite commandSprite, MatchSlot slot)
        {
            switch (CommandName)
            {
                case "Чепаевск":
                    commandSprite = CommandLogos[0];
                    break;
                case "Департиво":
                    commandSprite = CommandLogos[1];
                    break;
                case "Эспаньоло":
                    commandSprite = CommandLogos[2];
                    break;
                case "Гагарин":
                    commandSprite = CommandLogos[3];
                    break;
                case "Мадрид":
                    commandSprite = CommandLogos[4];
                    break;
                case "Москва":
                    commandSprite = CommandLogos[5];
                    break;
                case "Норильск":
                    commandSprite = CommandLogos[6];
                    break;
                case "Санкт - Петербург":
                    commandSprite = CommandLogos[7];
                    break;
                case "Санкт-Петербург":
                    commandSprite = CommandLogos[7];
                    break;
                case "Подольск":
                    commandSprite = CommandLogos[8];
                    break;
                case "Сафоново":
                    commandSprite = CommandLogos[9];
                    break;
                case "Севилья":
                    commandSprite = CommandLogos[10];
                    break;
                case "Сочи":
                    commandSprite = CommandLogos[11];
                    break;
                case "Тула":
                    commandSprite = CommandLogos[12];
                    break;
                case "Владивосток":
                    commandSprite = CommandLogos[13];
                    break;
                case "Вязьма":
                    commandSprite = CommandLogos[14];
                    break;
                default:
                    Debug.Log($"Не найдено имя: {CommandName} у объекта {slot.MatchSlotData.name}" );
                    break;
            }
        }
       
    }
    private void SetCommandSprites(MatchSlot slot)
    {
        slot.Command1Image.sprite = slot.MatchSlotData.Command1Logo;
        slot.Command2Image.sprite = slot.MatchSlotData.Command2Logo;

        //List<Sprite> AvailableSprites = new();
        //AvailableSprites.AddRange(CommandSprites);
        //int RandomSpriteIndex = Random.Range(0, AvailableSprites.Count);
        //slot.Command1Image.sprite = AvailableSprites[RandomSpriteIndex];
        //AvailableSprites.RemoveAt(RandomSpriteIndex);
        //int RandomSpriteIndex2 = Random.Range(0, AvailableSprites.Count);
        //slot.Command2Image.sprite = AvailableSprites[RandomSpriteIndex2];
    }
    private Sprite GetIcon(MatchSlotSO.SportTypeEnum SportType)
    {
        switch (SportType)
        {
            case MatchSlotSO.SportTypeEnum.Football:
                return MatchTypeIcons[0];
            case MatchSlotSO.SportTypeEnum.Tennis:
                return MatchTypeIcons[1];
            case MatchSlotSO.SportTypeEnum.Basketball:
                return MatchTypeIcons[2];
            case MatchSlotSO.SportTypeEnum.Hockey:
                return MatchTypeIcons[3];
            case MatchSlotSO.SportTypeEnum.Volleyball:
                return MatchTypeIcons[4];
            default:
                return null;
        }
    }

    public void ActivateSportTypeButton(int SportTypeIndex)
    {
        TypeActivated[SportTypeIndex] = !TypeActivated[SportTypeIndex];
        ShowThisTypeMatches(SportTypeIndex, TypeActivated[SportTypeIndex]);
    }
    private void ShowThisTypeMatches(int SportTypeIndex, bool Is)
    {
        CanvasManager.instance.SetSportTypeView(TypeActivated);
        for (int i = 0; i < MatchSlots.Count; i++)
        {
            if (((int)MatchSlots[i].MatchSlotData.SportType) == SportTypeIndex)
            {
                if (FormatActivated[((int)MatchSlots[i].MatchSlotData.SportFormat)])
                {
                    MatchSlots[i].gameObject.SetActive(Is);
                }
            }
        }
    }
    public void ShowAllMatches()
    {
        bool IsAllActivated = true;
        for (int i = 0; i < TypeActivated.Length; i++)
        {
            if (TypeActivated[i] == false)
            {
                IsAllActivated = false;
            }
        }
        if (IsAllActivated) // Set All to False
        {
            for (int i = 0; i < TypeActivated.Length; i++)
            {
                ActivateSportTypeButton(i);
            }
        }
        else
        {
            for (int i = 0; i < TypeActivated.Length; i++)
            {
                TypeActivated[i] = false;
                ActivateSportTypeButton(i);
            }
        }
    }
    public void ActivateMatchFormatButton(int SportFormatIndex)
    {
        FormatActivated[SportFormatIndex] = !FormatActivated[SportFormatIndex];
        ShowThisFormatMatches(SportFormatIndex, FormatActivated[SportFormatIndex]);
    }
    private void ShowThisFormatMatches(int SportFormatIndex, bool Is)
    {
        CanvasManager.instance.SetSportFormatView(FormatActivated);
        for (int i = 0; i < MatchSlots.Count; i++)
        {
            if (((int)MatchSlots[i].MatchSlotData.SportFormat) == SportFormatIndex)
            {
                if (TypeActivated[(int)MatchSlots[i].MatchSlotData.SportType])
                {
                    MatchSlots[i].gameObject.SetActive(Is);
                }
            }
        }
    }
}
