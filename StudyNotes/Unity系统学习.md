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



## 1.3.游戏物体和组件的显示和禁用

### 1.3.1.界面上的操作

- 显示与隐藏游戏物体：选中某个游戏物体，Inspector 视图最上方，游戏物体名称的左边有一个复选框；
- 启用与禁用组件：选中某个游戏物体，Inspector 视图可以看到该游戏物体所有的组件，组件标题栏的前边有一个复选框；
- 组件禁用之后，该组件就处于无效状态； [关闭房间内的灯，灯就处于无效状态。]
- 游戏物体隐藏后，该游戏物体同样处于无效状态。

### 1.3.2.代码上的操作

```c#
[void] gameObject.SetActive(bool)
```

- 设置游戏物体是显示还是隐藏，true 是显示，false 是隐藏；
- 所有的游戏物体都可以进行 SetActive（）操作。

```c#
[bool] 组件对象.enabled 
```

- //可读写属性

- 设置组件是启用还是禁用，true 是启用，false 是禁用；

- 大部分组件对象都可以进行 enabled 属性操作，但是一些核心组件除外。

  

## 1.4.网格组件

- **什么是 Mesh[网格]？**

网格就是三维模型的数据文件，美术人员三维建模，主要就是完成模型的网格制作；

三维模型由点，线，面组成，最终形成一个网格的形态。

- **Mesh Filter**

Mesh Filter [网格过滤器]组件：用于指定当前模型游戏物体的网格数据。

Mesh [网格]：持有网格数据文件的引用。

- **Mesh Renderer**

**Mesh Renderer** [网格渲染器]组件：用于完成当前模型游戏物体的网格渲染。

网格过滤器组件和网格渲染器组件需要配合使用，一个组件持有网格数据，另外一个组件负责网格数据的渲染。

**组件核心控制参数：**

①**Materials** [材质球引用]：往游戏物体上拖拽挂载的材质球资源，其实就是拖拽

赋值给了该属性。 [见图 1, 2]

②**Cast** **Shadows** [投射阴影]：On 开启阴影投射，Off 关闭阴影投射。

[该属性可以控制单个模型物体的阴影，Light 组件可以控制整个场景内的阴影。]

③**Receive Shadows** [接收阴影]：是否接收另外的游戏物体投射的阴影。

# ![2.资源关系图](../Img/2.%E8%B5%84%E6%BA%90%E5%85%B3%E7%B3%BB%E5%9B%BE.jpg)

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



### 2.2.碰撞体和碰撞

#### 2.2.1.组合效果

在模型游戏物体上使用物理组件，有四种常见的组合方式：

![1.四种组合方式](../Img/1.%E5%9B%9B%E7%A7%8D%E7%BB%84%E5%90%88%E6%96%B9%E5%BC%8F.png)

**组合 A: 网格 + 刚体 + 碰撞体**

最常用的一种组合方式，游戏内的玩家角色，各种小怪，Boss 都是这种组合方式；

角色游戏物体可以推着“组合 A”移动。

**组合 B: 网格 + 碰撞体**

游戏场景相关元素，大多使用这种组合方式，比如场景内的各种建筑，墙壁，石头；

角色游戏物体可以和“组合 B”发生碰撞，但是“组合 B”无法移动。

**组合 C: 网格**

这种组合方式没有使用任何物理相关的组件；

角色游戏物体可以直接穿透“组合 C”，在物理运算角度，“组合 C”不存在。

**组合 D: 网格 + 刚体**

这种组合方式没有使用碰撞体组件，也就意味着项目运行之后，“组合 D”不会停

留在“地面”上，而是直接穿透地面进行自由落体运动
