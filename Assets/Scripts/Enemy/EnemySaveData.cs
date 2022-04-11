using CI.QuickSave;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemySaveData : Data
{

    // public float positionx;
    // public float positiony;
    // public float positionz;
    public Vector3 position;
    public Quaternion quaternion;
    public float hp;
    public bool isAttacking;
    public bool isAlive;
    public int enemyId;

    public EnemySaveData(Enemy enemy)
    {
        enemyId = enemy.GetInstanceID();
        position = enemy.transform.position;
        ///positionx = enemy.transform.position.x;
        //positiony = enemy.transform.position.y;
        //positionz = enemy.transform.position.z;
        //rotationx = enemy.transform.rotation.x;
        //rotationy = enemy.transform.rotation.y;
        // rotationz = enemy.transform.rotation.z;
        quaternion = enemy.transform.rotation;
        hp = enemy.GetHp();
        isAlive = enemy.IsAlive();
        isAttacking = enemy.IsAttacking();


    }
    public void CommitParameters()
    {
        QuickSaveWriter writter = QuickSaveWriter.Create($"{enemyId.ToString()}");
        writter.Write<int>("Id", enemyId);
        writter.Write<float>("hp", hp);
        writter.Write<Vector3>("position", position);
        writter.Write<Quaternion>("rotation", quaternion);
        writter.Write<bool>("isAlive", isAlive);
        writter.Write<bool>("isAttacking", isAttacking);
        writter.Commit();
    }
    public void ReadData(QuickSaveReader reader) 
    {
        reader.Read<float>("hp", r => { hp = r; });
        reader.Read<Vector3>("position", r => { position = r; });
        reader.Read<Quaternion>("rotation", r => { quaternion = r; });
        reader.Read<bool>("isAlive", r => { isAlive = r; });
        reader.Read<bool>("isAttacking", r => { isAttacking = r; });



    }

}
