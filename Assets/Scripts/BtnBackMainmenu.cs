using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBackMainmenu : ButtonBase
{
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(BackMainmenu);
    }

    private void BackMainmenu()
    {
        AppManage.Ins.Mainmenu();
    }
}
