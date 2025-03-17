using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdata
{
	public int id;
	public string itemName;
	public string description;
	public string nameEng;
	public string itemTypeSring;
	[NonSerialized]
	public ItemType itemType;
	public int price;
	public int power;
	public int level;
	public bool isStackable;
	public string iconPath;

	//문자열을 열거형으로 변환하는 매서드
	public void InitalizedEnums()
	{
		if(Enum.TryParse(itemTypeString, out ItemType parsedType))
		{
			itemType = parsedType
		}

		 else
		 {
			 Debug.LogError($"아이템 '{itemName}'에 유효하지 않은 아이템 타입 : {itemTypeSring}")
			 //기본값 설정
			 itemType = itemType.Consumable;
		 }
}
