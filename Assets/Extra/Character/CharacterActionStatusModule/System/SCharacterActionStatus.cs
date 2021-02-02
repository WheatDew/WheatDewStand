using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SCharacterActionStatus : ComponentSystem
{
    public CharacterActionStatusModuleFileIO fileIO;

    protected override void OnStartRunning()
    {
        
    }
    protected override void OnUpdate()
    {
        CommandJob();
        UpdataStatusIconJob();
    }

    public void UpdataStatusIconJob()
    {
        Entities.ForEach((CCharacterActionStatus characterActionStatus) =>
        {
            if (characterActionStatus.CurrentActionStatus > 0 && characterActionStatus.CurrentActionStatus < fileIO.SpriteAssetsList.Count)
            {
                characterActionStatus.characterActionStatusBubble.gameObject.SetActive(true);
                //controllerStatus.StatusBubbleObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                //根据角色动作信息在图标字典中获取图标纹理
                
                characterActionStatus.characterActionStatusBubble.Bubble.material
                .SetTexture(1, fileIO.SpriteAssetsList[characterActionStatus.CurrentActionStatus]);
            }
            else
            {
                characterActionStatus.characterActionStatusBubble.gameObject.SetActive(false);
            }
        });
    }

    public void CommandJob()
    {
        Entities.ForEach((CCharacterActionStatusModuleCommand commandComponet,CCharacterActionStatus characterActionStatus) =>
        {
            switch (commandComponet.Command.Substring(0, 2))
            {
                case "01":
                    int command01_para01;
                    if (int.TryParse(commandComponet.Command.Substring(2, 2),out command01_para01))
                    {
                        characterActionStatus.CurrentActionStatus = command01_para01;
                    }
                    break;
            }
        });
    }

    #region 命令处理
    #endregion
}
