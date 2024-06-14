using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色基本信息
public class Bai_Character{
    //姓名
    public string Name ="张三";
    //等级
    public int Level = 1;
    //经验
    public int CurrentExp = 0;
    public int Hp = 0;
    //最大血量
    public int MaxHp{
        get{
            return Level * 10;
            }   
    }
    //升到下一级需要的经验
    public int GetNextLevelExp(){
            return Level * 50;
    }
    //装备 -1代表无
    public int WeaponId = -1;
    public int ClothesId = -1;
    public int ShoesId = -1;
    //技能
    public List<int> SkillList = new List<int>();

}

public class CharacterManager : ManagersSingle<CharacterManager>
{
    //玩家
    public Bai_Character character = new Bai_Character();
    //金钱
    public int Money = 0;
    //当前角色是否可控
    public bool canControl = true;

    //增加/减少金钱
    public void ChangeMoney(int money){
        Money += money;
        if (Money < 0) Money = 0;
    }
    //增加经验
    public void AddExp(int exp){
        character.CurrentExp += exp;
        //判断经验是否升级
        if (character.CurrentExp >= character.GetNextLevelExp()){
            //升级
            character.Level++;
            character.CurrentExp = 0;
        }
    }
    //改变血量
    public void ChangeHp(int hp){
        character.Hp += hp;
        //限制character.Hp的范围[0, character.MaxHp]
        character.Hp = Mathf.Clamp(character.Hp, 0, character.MaxHp);
    }

#region 任务技能
    //添加技能
    public bool AddSkill(int skillld){
        if(character.SkillList.Contains(skillld)){
            return false;
        }
        character.SkillList.Add(skillld);
        return true;
    }

    //是否拥有此技能
    public bool HasSkill(int skillld){
        return character.SkillList.Contains(skillld);
    }

    //移除技能
    public void RemoveSkill(int skillld){
        if (character.SkillList.Contains(skillld)){
            character.SkillList.Remove(skillld);
        }
    }
    //所有技能
    public int[] GetSkills(){
        return character.SkillList.ToArray();
    }

#endregion

#region 人物装备
    //装备武器
    public void AddWeapon(int id){
        //如果背包有这个武器，允许装备
        InventoryItem item = InventoryManager.Instance.GetItem(id);
        if (item!= null)
        {
            InventoryManager.Instance.Removeltem(id,1);
        }
        //如果当前有武器，武器卸载下来放入背包
        if (character.WeaponId > -1){
            InventoryManager.Instance.AddItem(character.WeaponId, 1);
        }
        character.WeaponId = id;
    }
    
    //获取当前武器
    public int GetWeapon(){
        return character.WeaponId;
    }

    //移除当前武器
    public void RemoveWeapon(){
        //如果当前有武器，武器卸载下来放入背包if (character.Weaponld > -1)
        InventoryManager.Instance.AddItem(character.WeaponId,1);
    }
#endregion
}
