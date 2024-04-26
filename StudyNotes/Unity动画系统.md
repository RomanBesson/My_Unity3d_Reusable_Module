# 动画系统进阶

## 一些注意事项

### 1.使用其他动作库但是没办法做到像动作库里演示的位移

![1713777559920](../Img/1713777559920.png)

在Animator里把这个勾上。

### 2.角色应用别的动作库出现肢体扭曲

更换该动作库的Avatar

### 3.角色启动后处于悬浮状态

说明骨骼绑定正常，但是没有初始动画。

### 4.不是播放完毕之后才播放下一个动画，马上过渡的方法

将过渡线上的 Has Exit Time 复选框勾掉。

### 5.没有默认循环播放的动画如何循环播放？

1. 点击模型的动画选项卡

   ![1713862146583](../Img/1713862146583.png)

2. 选择想循环的动作

   ![1713862409876](../Img/1713862409876.png)

3. 勾选`Loop Time` 和 `Loop Pose`

   ![1713862450009](../Img/1713862450009.png)

### 6.如何关闭模型自带的位移，旋转？

在模型设置的动画选项卡里，把图示的勾上就行，分别对应旋转 ，y轴 ，xz轴。

![1713870991884](../Img/1713870991884.png)

### 7.实现人物移动和转向的代码

```csharp
using UnityEngine;
using System.Collections;

public class KnightPlayer : MonoBehaviour {

    private Transform m_Transform;
    private CharacterController m_CC;
    private Animator m_Animator;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_CC = gameObject.GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        //判断当前是否走路
        if(Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            m_CC.SimpleMove(dir);
            //控制人物朝向
            m_Transform.LookAt(m_Transform.position + dir);
            m_Animator.SetBool("walk", true);
        }else{
            m_Animator.SetBool("walk", false);
        }


	}
}

```



### 8.摄像机跟随

```csharp
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform m_Transform;
    private Transform m_PlayerTransform;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        //获取人物的位置
        m_PlayerTransform = GameObject.Find("RoyalKnight").GetComponent<Transform>();
	}
	
	void Update () {
        //合适的距离加上人物的位置（距离通过挂载在人物上测试的相对坐标得出）
        Vector3 targetPos = new Vector3(0.18f, 3.06f, -2.94f) + m_PlayerTransform.position;
        //插值运算
        m_Transform.position = Vector3.Lerp(m_Transform.position, targetPos, Time.deltaTime * 5);
	}
}

```



### 9.如何动画分层

创建动画遮罩，把需要遮住的动画控制套上遮罩。

## 1.Mecanim 动画系统

### 1.1.创建人形 Avatar

**Avatar**：阿凡达，对模型本身的骨骼节点进行映射。

**Animation Type**：Humanoid（人形）

**Avatar Definition**：Create From This Model



## 2.IK（反向动力学的使用）

### 2.1.介绍

通过确定子骨骼的位置，然后推导出所在骨骼链上所有其他的父级骨骼位置，从而形成一个新的动作。（就是固定好某个部分和定好的物体交互，其他部分继续按原来，接近固定肢体的肢体会受到影响。）

### 2.2.使用

1. Animator 当前动作层勾选 IK Pass 选项；
2. 编写相应的 IK 控制代码。

```csharp
using UnityEngine;
using System.Collections;

public class KnightPlayer : MonoBehaviour {


    private Animator m_Animator;
    //IK绑定的物体
    public Transform IKTarget;

	void Start () {
        m_Animator = gameObject.GetComponent<Animator>();
	}
	
    void OnAnimatorIK(int index)
    {
        //权重
        m_Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        m_Animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        //位置
        m_Animator.SetIKPosition(AvatarIKGoal.LeftHand, IKTarget.position);
        m_Animator.SetIKRotation(AvatarIKGoal.LeftHand, IKTarget.rotation);
    }

}

```

