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

	//���ڿ��� ���������� ��ȯ�ϴ� �ż���
	public void InitalizedEnums()
	{
		if(Enum.TryParse(itemTypeString, out ItemType parsedType))
		{
			itemType = parsedType
		}

		 else
		 {
			 Debug.LogError($"������ '{itemName}'�� ��ȿ���� ���� ������ Ÿ�� : {itemTypeSring}")
			 //�⺻�� ����
			 itemType = itemType.Consumable;
		 }
}
