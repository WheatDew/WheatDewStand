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
        UpdataStatusIconJob();
    }

    public void UpdataStatusIconJob()
    {
        Entities.ForEach((CCharacterActionStatus characterActionStatus) =>
        {

            if (fileIO.SpriteAssetsList.ContainsKey(characterActionStatus.CurrentActionStatus))
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
}
