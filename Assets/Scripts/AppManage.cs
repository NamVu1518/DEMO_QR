using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManage : Singleton<AppManage>
{
    private void Start()
    {
        UIManager.Ins.OpenUI<UIMainmenu>();
    }

    public void Scan()
    {
        UIManager.Ins.CloseUI<UIMainmenu>();
        UIManager.Ins.OpenUI<UIScaning>();
    }

    public void Mainmenu()
    {
        UIManager.Ins.CloseUI<UIScaning>();
        UIManager.Ins.OpenUI<UIMainmenu>();
    }
}
