[toc]

# Windows PowerShell

## 1.PowerShell的执行策略

在Windows操作系统中，PowerShell的执行策略决定了哪些类型的脚本可以被执行。执行策略可以是以下几种之一：

- **Restricted**：不允许任何脚本执行。
- **AllSigned**：只允许执行已签名的脚本。
- **RemoteSigned**：本地脚本可以执行，但来自互联网的脚本必须已签名。
- **Unrestricted**：允许执行所有脚本。

如果你想要关闭远程脚本执行权限，可以将执行策略设置为 **Restricted**。以下是关闭远程脚本执行权限的步骤：

**打开Windows PowerShell作为管理员**：

- 在开始菜单中搜索“PowerShell”。
- 右键点击“Windows PowerShell”，选择“以管理员身份运行”。

**查看当前的执行策略**：

- 在PowerShell窗口中输入以下命令并回车：

  ```powershell
  Get-ExecutionPolicy
  ```

- 这将显示当前的执行策略。

**更改执行策略**：

- 如果当前执行策略为“RemoteSigned”或“Unrestricted”，你可以通过以下命令将执行策略设置为“Restricted”：

  ```powershell
  Set-ExecutionPolicy Restricted
  ```

- 系统将提示你确认是否要更改执行策略。输入“Y”然后按 Enter 确认。

**确认更改**：

- 如果你确定要更改执行策略，输入“Y”然后按 Enter 确认。

更改执行策略后，只有本地脚本文件可以执行，而来自互联网的脚本将被阻止执行。这有助于提高系统的安全性，防止潜在的恶意脚本执行。

请注意，更改执行策略可能会影响某些脚本的执行，特别是那些需要远程执行的脚本。在更改执行策略之前，请确保你了解可能的影响，并且只在必要时更改执行策略。如果你需要执行远程脚本，可以考虑将执行策略更改为“RemoteSigned”或“AllSigned”，并确保你信任的脚本都已签名。

# Git_Api

## 1.初始化仓库

```
 git init     在当前目录创建一个新的Git仓库。 
```



## 2.设置全局邮箱和用户名

```bash
git config --global user.name “你在GitHub上的用户名”
git config --global user.email “你的邮箱”
```



## 3.ssh相关操作

### 3.1.检查是否存在ssh

```bash
cd ~/.ssh
```



### 3.2.生成ssh

```bash
ssh-keygen -t rsa -C "你的邮箱"
```



### 3.3.测试和仓库的ssh连接

```bash
ssh -T git@github.com
```



## 4.与远程仓库的操作



### 4.1.连接远程仓库

```bash
git remote add origin "你的仓库SSH地址"
```



### 4.2.取消连接

```bash
git remote remove <remote-name>
git remote remove origin
```



### 4.3.拉取代码

```bash
git pull origin master
```



### 4.4.提交相关

```bash
# 检查暂存区文件
git status

# 添加到暂存区
git add .

# 提交到本地仓库 
git commit -m "你的备注信息"

# 提交到远程仓库
git push -u origin master
```



## 5.分支操作

### 5.1.修改要提交的分支

```bash
git checkout <branch-name>
```



### 5.2.合并分支到主分支（前提条件：你现在是主分支）

```bash
git merge "你要合并的分支名"
```



# Unity_Api

## 1.Input [输入类]

### 1.1.获取鼠标按键&位置

```c#
/*获取鼠标按键三种状态.[0:左键  1:右键  2:中键]*/

[s][bool] GetMouseButtonDown(int)  //按下某键的一瞬间,返回true.

[s][bool] GetMouseButton(int)    //按下某键后,持续返回true.

[s][bool] GetMouseButtonUp(int)   //抬起某键的一瞬间,返回true.
    
[s][Vector3] mousePosition          //只读属性,鼠标在屏幕上的位置.
```



### 1.2.获取键盘按键

```c#
/*获取键盘按键三种状态.*/
[s][bool] GetKeyDown(KeyCode)       //按下某键的一瞬间,返回true.
[s][bool] GetKey(KeyCode)           //按下某键后,持续返回true.
[s][bool] GetKeyUp(KeyCode)         //抬起某键的一瞬间,返回true.
```



## 2.MonoBehaviour[Mono行为类]

### 2.1.一些生命周期函数

```c#
[void] Awake()                        //对象被创建时,执行一次.
[void] OnEnable()                     //脚本组件启用时,执行一次[多次].
[void] Start()                        //项目运行之后,执行一次.
[void] FixedUpdate()                 //固定更新,0.02秒执行一次.
[void] Update()                       //每帧执行一次,一秒钟大约60次.
[void] LateUpdate()                  //在Update之后,延迟执行.
[void] OnDisable()                   //脚本组件禁用时,执行一次[多次].
[void] OnDestroy()                   //脚本组件被销毁时,执行一次.
```



### 2.2.碰撞函数

```c#
[void] OnCollisionEnter(Collision)	 //碰撞开始，执行一次.
[void] OnCollisionStay(Collision)	 //碰撞进行中，每帧都会执行.
[void] OnCollisionExit(Collision)	 //碰撞结束，执行一次.
```



### 2.3.触发函数

```c#
[void] OnTriggerEnter(Collder)	    //触发开始，执行一次.
[void] OnTriggerStay(Collder)	    //触发进行中，每帧都会执行.
[void] OnTriggerExit(Collder)	    //触发结束，执行一次.
```



### 2.4.GameObject对象

```c#
[GameObject] gameObject  //只读属性,当前脚本组件所挂载到的游戏物体对象.
```



### 2.5.组件启用和禁用

```c#
[bool] 组件对象.enabled   //读写属性,控制组件启用[true]与禁用[false].
```



### 2.6.延迟调用 Invoke()

```c#
[void] Invoke(string, float)	    //延迟调用,延迟x秒,调用某方法.
[void] InvokeRepeating(string, float, float)	 //延迟并重复调用.
[void] CancelInvoke()	          //取消当前脚本中所有的延迟调用.
[void] CancelInvoke(string)	    //取消当前脚本中指定的延迟调用.
```



### 2.7.协程方法

```c#
IEnumerator   //迭代器接口,协程方法的返回值类型.
yield return  //协程方法返回.
new WaitForSeconds(float)   //延迟等待x秒.
[Coroutine] StartCoroutine(string)	        //开启指定协程方法.
[Coroutine] StartCoroutine(string, object) //开启协程,并传递参数.
[void] StopCoroutine(string)	      //停止指定协程方法.
[void] StopAllCoroutines()	      //停止当前脚本中所有协程方法.
```



### 2.8.发送消息

```c#
[void] SendMessage(string)	            //给自身游戏物体发送消息.
[void] SendMessage(string, object)        //方法名 + 参数.
[void] BroadcastMessage(string)	         //给自身和子物体发送消息.
[void] BroadcastMessage(string, object)  //方法名 + 参数.
[void] SendMessageUpwards(string)	      //给父物体发送消息.
[void] SendMessageUpwards(string, object)	//方法名 + 参数.
```



## 3.GameObject[游戏物体类]

### 3.1.[string] name 名字字段

```c#
[string] name        //读写属性,获取当前游戏物体的名称,修改游戏物体名称.
```



### 3.2.查找GameObject对象的函数

```c#
[s][GameObject] Find(string)   //通过名称查找获取场景内的游戏物体对象.
[s][GameObject[]] FindGameObjectsWithTag(string)   //Tag标签查找.
[s][void] Destroy(Object)         //销毁游戏物体,组件.
[s][void] Destroy(Object, float) //定时销毁游戏物体,组件.
```



### 3.3.获取当前游戏物体上的某个组件对象

```c#
[T] GetComponent<T>()          //获取当前游戏物体上的某个组件对象.
[T] AddComponent<T>()          //给当前游戏物体添加某个组件对象.
```



### 3.4.控制游戏物体显示

```c#
[void] SetActive(bool)          //控制游戏物体显示[true]与隐藏[false].
```



### 3.5.实例化生成

```c#
[s][T]Instantiate<T>(GameObject, Vector3, Quaternion) //实例化.
[s][T]Instantiate<T>(GameObject, Vector3, Quaternion, Transform) //实例化.最后一个参数指定父物体
```



## 4.Debug

### 4.1.在控制台输出信息.

```C#
[s][void] Log(object)                  //在控制台输出信息.
```

### 4.2.两点之间画线 DrawLine()

```c#
[s][void] DrawLine(Vector3, Vector3, Color, float)//两点之间画线
```



## 5.Transform[变换组件]

### 5.1.位置

```c#
[Vector3] position              //读写属性,获取位置,修改位置.
```



### 5.2.旋转

```c#
[Quaternion] rotation           //读写属性,获取旋转数据,修改旋转数据.
```



### 5.3.获取物体自身坐标系的三个正方向

```c#
[Vector3] forward, right, up   //读写属性,正前方,右方向,正上方.
```



### 5.4.旋转和移动的函数

```c#
[void] Translate(Vector3, Space)    //选择坐标系,按指定的方向移动. space(wprld/self)代表参考世界/自身坐标系
[void] Rotate(Vector3, float)       //沿固定轴向旋转固定角度.
```



### 5.5.获取子物体

```c#
[Transform] Find(string)             //在子物体中查找指定物体.
[T[]] GetComponentsInChildren<T>()  //在子物体中查找指定组件
```

> **注意**：GetComponentsInChildren 会将父物体的 Transform 也一同获取。

### 5.6.更改角色面部朝向

```csharp
[void] LookAt(Vector3); //看向输入位置
```



## 6.Rigidbody[刚体组件]

```c#
[void] MovePosition(Vector3)      //移动到指定位置[当前位置+方向].
[void] AddForce(Vector3)          //世界坐标系方向添加力[方向*力度].
[void] AddRelativeForce(Vector3) //物体坐标系方向添加力[方向*力度].
```



## 7.Vector3[三维向量]

```c#
[float]x, y, z                 //公开字段,可以单个读取,不可以单个修改.
/*获取世界坐标系的六个方向*/
[s][Vector3] forward, right, up   //只读属性,前,右,上.
[s][Vector3] back, left, down     //只读属性,后,左,下.
[s][Vector3] zero                  //只读属性,世界原点位置[0,0,0].
[s][Vector3] Lerp(a, b, float t)  //在两个Vector3数据之间插值.
```



## 8.Quaternion

```c#
[Vector3] eulerAngles      //读写属性,将当前四元数转换成向Vector3.
[s][Quaternion] identity   //只读属性,表示无旋转,对应欧拉角[0,0,0].
[s][Quaternion] Euler(Vector3)    //将Vector3转换成四元数.
[s][Quaternion] Lerp(a, b, float t) //在两个Quaternion数据之间插值.
```



## 9.Collision

```c#
[GameObject] gameObject           //只读属性,物理碰撞到的游戏物体.
```



## 10.Collider

```c#
[GameObject] gameObject           //只读属性,物理触发到的游戏物体.
```



## 11.Text & TMP_Text

```c#
/*UGUI组件命名空间:using UnityEngine.UI;  TMP命名空间:using TMPro;*/
[string] text          //读写属性,可以读取以及修改文本组件的显示内容.
[Color] color          //读写属性,获取和修改组件的颜色.
```



## 12.Button

### 12.1.点击绑定事件

```c#
/*事件处理方法的格式:私有,无参,无返回值*/
[void] onClick.AddListener(事件处理方法) //按钮点击绑定事件处理方法.
```



## 13.Color

```c#
[s][Color] red, green, blue  //只读属性,返回对应的颜色.
[Color] Color(r, g, b, a)    //构造方法,参数取值范围是0~1,float类型.
```



## 14.Color32

```c#
[Color32] Color32(r, g, b, a) //构造方法,参数取值范围是0~255,byte类型.
```



## 15.LineRenderer

```c#
[int] positionCount                //读写属性,获取和修改位置点的个数.
[void] SetPosition(int, Vector3) //给位置数组对应下标的元素赋值.
```



## 16.AudioSource

### 1.播放和停止

```c#
[void] Play()                      //播放音频.
[void] Stop()                      //停止播放.

```



### 2.在某个地方播放

```csharp
[s][void] PlayClipAtPoint(AudioClip, Vector3) //在指定位置播放音效.
```



## 17.Resources

```c#
[s][T] Load<T>(string)            //指定文件路径,加载单个资源.
[s][T[]] LoadAll<T>(string)       //指定文件夹路径,加载多个资源.
```



## 18.Camera

```c#
[s][Camera] main          //只读属性,获取“主摄像机”的Camera组件对象.
[Ray] ScreenPointToRay(Vector3) //使用屏幕上的一个位置点创建射线对象.
```



## 19.物理射线

```c#
Ray                                //结构体,物理射线.
RaycastHit                        //结构体,存放物理射线碰撞信息.
[Collider] collider  //RaycastHit对象只读属性,射线碰撞到的碰撞体组件.
[Vector3] point       //RaycastHit对象读写属性,获取碰撞位置点.
[s][bool] Physics.Raycast(Ray, out RaycastHit) //物理射线检测方法.
[s][float] Random.Range(float, float)   //在最小值最大值之间取随机数.
```



## 20.Time

```c#
[s][float] time         //只读属性,时间,项目从开始运行到现在的总时长.
[s][float] deltaTime   //只读属性,增量时间,渲染完一帧所需要的时长.
[s][float] timeScale   //读写属性,时间缩放,控制虚拟时间中的时间流速.
```



## 21.Mathf

```c#
[float] Deg2Rad        //角度转弧度常量. 值:0.0174.
[float] Rad2Deg        //弧度转角度常量. 值:57.295.
[s][float] Lerp(float a, float b, float t)  //数学类插值运算.
```

## 22.Character Controller

### 移动

```c#
 SimpleMove（Vector3）：//简单移动
 Move（Vector3）：移动 //更为复杂的一种运动，每次都绝对运动，不会应用重力。
```

## 23.Iput控制面板上的操作

```c#
[float]Input.GetAxis（“轴向名称”）; //取得轴向的值
```

## 24.Animator动画控制面板

### 1.过度条件的获取和赋值

```csharp
Animator.Set。。。（name, value）; //通过 Animator 给过渡条件赋值
Animator.Get。。。（name, value）; //获取某过渡条件的值
```



### 2.Ik

```csharp
[void] OnAnimatorIK（int index）//类似于我们之前的 start（） OnTriggerEnter（），都是 Unity 内置的事件函数，由引擎自己维护和调用，这个函数主要用于处理 IK 相关的逻辑
//设置权重
Animator.SetIKPostionWeight（AvatarIKGoal，int）；
Animator.SetIKRotationWeight（AvatarIKGoal，int）；
//绑定要Ik的物体的位置
Animator.SetIKPosition（AvatarIKGoal，Vector3）；
Animator.SetIKRotation（AvatarIKGoal，Quaternion）；
```



### 3.转换成哈希码

```csharp
[int]Animator.StringToHash(string);  //Unity引擎中Animator组件的一个方法，它用于将一个字符串转换为一个整数哈希值。这个哈希值是基于字符串内容的，用于在动画系统中唯一标识一个动画状态或参数。
```

在Unity中，当你使用Animator组件来控制角色动画时，你通常会引用动画状态机中的状态或参数。这些状态和参数在Animator组件中是以字符串形式定义的。为了提高性能和效率，Unity内部会将这些字符串转换为整数哈希值，因为整数比较比字符串比较要快得多。

当你使用 `Animator.StringToHash(string)` 方法时，你需要传入一个字符串参数，该方法会返回一个整数哈希值。这个哈希值可以用于以下场景：

```csharp
Animator animator;
string stateName = "Walk"; // 假设这是动画状态机中的一个状态名称

// 获取状态的哈希值
int stateHash = Animator.StringToHash(stateName);

// 触发状态
animator.SetTrigger(stateHash);
```

## 25.Unity的特性

```csharp

[HideInInspector] //这个特性用于隐藏字段或属性，使其在Unity编辑器的Inspector面板中不可见。这对于不想让某些字段被编辑器直接访问的私有变量非常有用。

[SerializeField] //这个特性用于将私有字段序列化并显示在Inspector面板中，即使它是私有的。这允许开发者在不公开字段的情况下，仍然可以在编辑器中修改它的值。

[Header] //这个特性用于在Inspector面板中为字段添加一个标题，以提高代码的可读性。

[Range(min, max)] //这个特性用于限制一个浮点数或整数字段的值在指定的最小值和最大值之间。

[Tooltip] //这个特性用于为字段添加一个工具提示，当鼠标悬停在Inspector面板中的字段上时显示。

[Space] //这个特性用于在Inspector面板中添加垂直空间，以分隔不同的字段。

[ContextMenu] //这个特性用于为字段或方法添加一个上下文菜单项，可以在编辑器中通过右键点击来调用。

[ExecuteInEditMode] //这个特性用于在编辑模式下执行脚本，允许在编辑器中测试脚本的行为。

[RequireComponent] //这个特性用于确保GameObject在添加脚本时，也自动添加所需的组件。

[AddComponentMenu] //这个特性用于将自定义组件添加到Unity编辑器的组件菜单中。

[CreateAssetMenu] //这个特性用于创建自定义的Asset菜单项，允许用户通过Unity编辑器创建自定义的资源。
```



## 26.导航_NavMeshAgent

### 1.设置目的地

```csharp
[void] SetDestination(Vector)
```

### 2.目的地属性

```csharp
[Vector3] destination //读写属性，物体最终导航到的目的地
```

### 3.距离目标点剩余距离

```csharp
[float]remainingDistance
```

### 4.到距离目标点多远的距离停止

```csharp
[float]stoppingDistance
```

## UGUI

### 1.通过拖拽事件改变图片位置

```csharp
[Vector3]RectTransformUtility.ScreenPointToWorldPointInRectangle(m_RectTransform,eventData.position,eventData.enterEventCamera,out pos); //屏幕坐标点转化为世界坐标点；
```

>**其中：**
>
>`m_RectTransform`   //游戏物体的 RectTransform ;
>
>`eventData.position`  //当前坐标位置点；
>
>`eventData.enterEventCamera`  //事件摄像机；
>
>`out pos`  //最终计算得到的世界坐标位置；

### 2.Image

#### 填充属性

```csharp
[float]fillAmount
```

### 3.RectTransform

#### 将小怪的位置（3D 位置）转换为屏幕位置（2D 位置）；

```csharp
[Vecteo2]RectTransformUtility.WorldToScreenPoint(Camera.main, cubePos);//WorldToScreenPoint:世界位置转换为屏幕位置. 
```

#### UGUI 更改图片的宽和高

API：

```csharp
[void]RectTransform.SetSizeWithCurrentAnchors(轴向,值);
```

> 参数：RectTransform.Axis.Horizontal/Vertical ：对应宽和高.



### 4.Button

#### 不同状态的按钮图片

```csharp
[SpriteState]GetComponent<Button>().spriteState.xxxxx
//Button 组件的 spriteState 属性中，可以找到按钮的不同状态图片
```

### 5.eventData

#### 注意:必须导入命名空间`using UnityEngine.EventSystems;`改属性是对应接口的参数（IBeginDragHandler, IDragHandler, IEndDragHandler）

#### 得到鼠标指针最终停留所在的游戏物体

```csharp
[GameObject]eventData.pointerEnter
//该属性会返回一个 GameObject，这个对象就是目标游戏物体。但最终“碰撞”到的就是我们拖拽中的物品
```

### 6.CanvasGroup 组件

#### 以控制当前的 UI 游戏物体是否接收射线的碰撞

```csharp
[bool]m_CanvasGroup.blocksRaycasts
```



## Socket

### 服务器端客户端通用方法

#### 创建socket对象

```csharp
Socket socket = new Socket(地址类型，Socket 类型，协议类型);
```

参数介绍：

地址类型：使用 IPv4 地址协议，AddressFamily.InterNetwork

Socket 类型：使用流式类型，SocketType.Stream

协议类型：使用 TCP 协议类型，ProtocolType.Tcp
