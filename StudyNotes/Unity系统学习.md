[toc]

# 1.基础组件的认识



## 1.1.项目工程文件结构，各个文件夹都是做什么的？

- **Assets** [资产]：存放项目开发过程中所用到的资源（模型, UI, 声音, 特效...）；

  (在 Unity 项目开发中，Assets 文件夹是需要程序员手动管理的文件夹。)

- **Library [库]**：存放项目核心库，扩展库，以及动态生成的缓存文件；

- **Logs [日志]**：存放项目日志文件；

- **Packages [包]**：存放当前项目扩展库的引用目录；

- **ProjectSettings [项目设置]**：存放当前项目的设置文件（输入,导航,编辑器...）；

- Temp [临时]：存放当前项目的临时资源；

- **UserSettings [用户设置]**：存放当前项目用户相关的自定义设置。



## 1.2.物体变化组件

### 1.2.3.三维向量表示方向

1. 在 Unity 场景视图中，主要有两个坐标系：**世界坐标系**，**物体自身坐标系**；

2. 这两个坐标系都有六个方向：前-后-左-右-上-下；

3. 在 `Vector3` 结构体内，有**六个静态只读属性，用于表示世界坐标系六个方向**，这六个属性分别是：`forward`，`back`，`right`，`left`，`up`，`down`；

4. 在 Transform 类中，有**三个对象可读可写属性，用于表示三个“箭头方向”**，这三个属性分别是：`forward`，`right`，`up`。

5. `position` 是读写属性，直接 new 一个新的 Vector3 数据赋值；

6. Vector3 有三个公开的字段：x，y，z，我们可以分别获取使用；

   

```c#
    //查找持有对象引用.
    m_Transform = gameObject.GetComponent<Transform>();

    //打印输出位置信息.
    Debug.Log("Cube的位置:" + m_Transform.position);

    //修改位置信息.
    m_Transform.position = new Vector3(5, 5, 5);

    //单独打印x轴向位置数据.
    Debug.Log("x:" + m_Transform.position.x);

    //Vector3 三个字段不可以单独赋值，你的游戏物体只需要在单个轴向发生位置改变，你也需要构造一个 Vector3 数据进行整体赋值
    m_Transform.position.x = 10; //不能这样用.

    m_Transform.position = new Vector3(10, m_Transform.position.y, m_Transform.position.z); //应该这样用.

    //向前方移动.
    m_Transform.Translate(Vector3.forward, Space.Self);
```



### 1.2.4.移动物体位置

```c#
[void] m_Transform.Translate(Vector3, Space)
```

对象方法 `Translate( )`可以控制游戏物体往指定的方向移动。	

> 参数说明

- `Vector3` 参数指的是移动方向；

- `Space `参数是一个枚举类型，`World`[世界坐标系空间]，`Self`[自身坐标系空间]。

  

### 附录：使用变换组件实现物体WASD移动

```c#
    //向前.
    if (Input.GetKey(KeyCode.W))
    {
    m_Transform.Translate(Vector3.forward * 0.02f, Space.Self);
    }

    //向后.
    if (Input.GetKey(KeyCode.S))
    {
    m_Transform.Translate(Vector3.back * 0.02f, Space.Self);
    }

    //向左.
    if (Input.GetKey(KeyCode.A))
    {
    m_Transform.Translate(Vector3.left * 0.02f, Space.Self);
    }

    //向右.
    if (Input.GetKey(KeyCode.D))
    {
    m_Transform.Translate(Vector3.right * 0.02f, Space.Self);
    }
```

# 2.物理系统的初步认识

Unity 引擎内有两套内置的物理系统组件，菜单路径位置如下：

- 3D 物理组件：Component --> Physics [基于 PhysX 引擎]
- 2D 物理组件：Component --> Physics 2D [基于 Box2D 引擎]

## 2.1.刚体组件

### 2.1.1.刚体的几个属性

- **Mass [质量]**
  1. 控制物体的质量，默认值为 1，单位是千克；
  2. 两个物体的质量差距很大，但是下落速度是一样的； [“两个铁球同时着地”]
  3. 两个物体的质量差距很大，在发生碰撞时，会有明显效果。 [各种交通事故]

- **Drag [阻力]**
  1. 控制空气阻力，默认值为 0，表示没有空气阻力；
  2. 将该参数值调大，可以降低物体的下落速度。

- **Angular Drag [角阻力]**
  1. 当物体发生旋转时的空气阻力，默认值为 0.05；

- **Use Gravity [使用重力]**
  1. 当前刚体组件是否开启重力效果，默认是勾选，重力开启状态；
  2. 如果取消勾选，则当前游戏物体关闭重力效果。

- **Is Kinematic [运动学]**
  1. 在物理运动和“运动学”运动[Transform]之间切换，默认是不勾选状态；
  2. 勾选该属性，运行之后，物体同样没有重力效果。

### 2.1.2.刚体的移动

#### 无动力情况

```c#
    //刚体组件对象方法 MovePosition（）控制当前物体移动到指定位置,Vector3 参数指的是目标位置。
    [void] m_Rigidbody.MovePosition(Vector3)
```

#### 有动力情况

- 使用刚体组件控制游戏物体，主要目的是进行两种运动：平稳运动，剧烈运动。

  - 平稳运动：游戏角色行走，奔跑； 

  - 剧烈运动：枪械武器发射子弹，炮弹

这里指的就是剧烈运动。

```c#
    //给刚体组件添加力，让刚体组件所在的游戏物体，向某个方向发射出去。
    Vector3 参数指的是目标方向的力度。
    [void] m_Rigidbody.AddForce(Vector3) //世界坐标系方向
    [void] m_Rigidbody.AddRelativeForce(Vector3) //物体坐标系方向
```



#### 例子

```c#
    m_Transform = gameObject.GetComponent<Transform>();
    m_Rigidbody = gameObject.GetComponent<Rigidbody>();

    //向上移动位置.
    m_Rigidbody.MovePosition(new Vector3(0, 5, 0));

    //向上方发射.[世界方向.]
    m_Rigidbody.AddForce(Vector3.up * 1000);

    //向上方发射.[物体自身方向.]
    m_Rigidbody.AddRelativeForce(Vector3.up * 1000);
```



#### WASD移动

```c#
    /// <summary>
    /// 世界坐标系四方向移动.
    /// </summary>
    private void WorldDirMove()
    {
        //向前.
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.forward * 0.2f);
        }
        //向后.
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.back * 0.2f);
        }
        //向左.
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.left * 0.2f);
        }
        //向右.
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.right * 0.2f);
        }
    }

    /// <summary>
    /// 自身坐标系四方向移动.
    /// </summary>
    private void SelfDirMove()
    {
        //向前.
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.MovePosition(m_Transform.position + m_Transform.forward * 0.2f);
        }
        //向后.
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.MovePosition(m_Transform.position - m_Transform.forward * 0.2f);
        }
        //向左.
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.MovePosition(m_Transform.position - m_Transform.right * 0.2f);
        }
        //向右.
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.MovePosition(m_Transform.position + m_Transform.right * 0.2f);
        }
    }
```

