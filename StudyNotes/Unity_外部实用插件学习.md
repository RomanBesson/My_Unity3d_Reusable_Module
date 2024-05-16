[toc]

# EasyTouch

## 1.EasyTouch 介绍

在手游项目开发中，所有的操作就是基于用户对屏幕的触摸，比如：点击，滑动。关于点击交互，一般都是基于 UI 的，我们点击 UI 界面上的按钮元素，来实现场景的跳转，UI 界面的切换，技能的释放...... 

另外还有一些交互是普通的 UI 界面不方便实现的。比如：

**①对摄像机的旋转控制； ②对角色的位移控制；**

这些操作不单单是单击，还需要滑动。这类效果的实现，在企业项目开发中，很多时候会选择使用 EasyTouch 这款插件来搞定。

### EasyTouch 资源结构

EasyTouchBundle [插件的根目录]

- EasyTouch [插件核心，核心功能的实现，偏向底层]

- |EasyTouchControls [插件控制器，高级功能效果，偏向具体应用]

- Install [PlayMaker 可视化开发环境的支持库]

- Readme.txt [插件的版本更新信息]

## 2.Joystick 虚拟摇杆

### Joystick 介绍

Joystick：操纵杆，虚拟摇杆；EasyTouch 插件中最关键最核心的一个功能。

### 创建 Joystick 游戏物体

Hierarchy 右键 --> EasyTouch Controls --> Joystick

点击创建 Joystick 游戏物体后，EasyTouch 会自动创建一个 UGUI 的渲染环

境，另外场景中还会出现一个 InputManager 游戏物体。

### Joystick 组成分析

ECTJoystick Image [ 虚拟摇杆功能组件，虚拟摇杆的背景图 ]

-  Image [ 虚拟摇杆的操纵钮 ]

ECTJoystick 位置：EasyTouchControls/Plugins/ETCJoystick.cs

### Joystick 组件基本属性

**JoystickName**：虚拟摇杆游戏物体的名字；

**Activated**：虚拟摇杆是否激活可用；

**Visible**：虚拟摇杆是否可见；

**UseFixedUpdate**：使用 FixedUpdate 函数更新摇杆信息；

**Unregister at disabling time**：注销时禁用虚拟摇杆；



**Position&Size [位置和大小]**

这一组属性用于控制 Joystick 的位置和大小，Joystick 的锚点定位不需要操作RectTransform 组件，而是控制该区域的属性。



**Axes Properties [轴向属性]**

虚拟摇杆本质还是键盘上的 WASD 方向键的原理，两个轴向的数据获取。该属性区域就是控制横轴，纵轴相关细节属性的；一般情况下保持默认即可。



**Sprites [摇杆图片]**

用于选择 Joystick 所需要使用到的图片资源，该区域的修改，会直接影响 Image组件上的图片属性。



**Joystick 组件事件**：具体见属性栏，没啥好说的。



其他的组件看看就会了。



# DoTween

## 1.DoTween 介绍

DoTween 是一个“动画插件”；在 Unity 当中动画主要有两类：

①在 3Dmaxs 之类的软件中制作的动画；

②在 unity 环境中通过代码控制 Transform 之类的组件实现的动画。

代码控制实现的动画，需求量也是很大的，比如说：

UI 面板的从大到小，透明到不透明，UI 面板的弹跳效果.... 

3D 模型的位移，曲线，抛物线效果.... 

在实际开发中，这类的功能我们只能用代码来实现，因为代码灵活。但是这类效

果如果我们在项目中需求量比较大，我们就需要自己封装相应的功能类。

而 DoTween 就是这样的一个现成的“功能类”，它里面已经封装了大量的动画效果，我们只需要调用它的方法，传递下参数就可以实现很多代码动画效果。

### **DoTween 插件导入与设置**

①将 DoTween 资源包拖拽导入 Unity 项目中；

②Tools-->Demigiant-->DoTween Utility Panel 进行插件设置。（注意，必须要设置，否则没法使用）

### **DoTween 资源结构**

Demigiant [插件的根目录，也是该插件的公司名]

​	|---DemiLib [插件核心类库]

​	|---DOTween [插件基础版资源]

​	|---DOTweenPro [插件专业版资源，在基础版之上扩展出高级功能]

​	|---DOTweenPro Examples [插件专业版实例工程]

### Dotween的使用方式

**Dotween有两种使用方式：**注入使用和静态调用。

- **注入使用**

  就是直接用一些原有的组件去使用`DO`开头的函数。

- **使用静态**(通用式动画控制)

  1.语法格式

  **DOTween.To(() => myValue, x => myValue = x, 100, 1);**

  **格式分析：**

  DOTween.To（）：DoTween 插件中功能类的一个静态方法；

  ()=>myValue：获取对象元素 Lambda 表达式；

  x=>myValue=x：赋值对象元素 Lambda 表达式；

  100：最终的目标值；

  1：动画持续的时间。

  

## 2.DoTween Pro :Animation

DoTween Pro 版本将动画控制封装成了两个组件：Animation，Path。

### 游戏物体添加 Animation 组件

①选中你需要添加 DoTween Animaton 组件的游戏物体；

②Component-->DOTween-->DOTweenAnimation。

### 动画相关属性

通过下拉菜单选择“动画效果”，然后会出现和该动画对应的可控制属性。

**Duration**：持续时间；

**Delay**：延迟；

**Ignore** **TimeScale**：忽略时间缩放；

**Ease**：动画曲线；

**Loops**：循环；配套设置循环的类型；

**TO**：目的地；可以设置一个 Vector3，也可以指定一个 Transform。

### 常用事件

OnStart：动画开始事件，执行一次；

OnPlay：动画播放事件，执行一次；[先开始，再播放]

OnUpdate：动画更新事件，在动画播放的过程中，持续执行 N 次；

OnComplete：动画播放完成事件，执行一次。



## 2.DoTween Pro : Path

### 组件介绍

使用 Path 路径组件，可以在场景内创建 N 个点，由点自动连接成线，然后游戏物体就可以沿这根线，进行路径运动。

Path 路径效果同样也可以用代码实现，但是代码会比较繁琐且麻烦，因为你需要用代码设置每个路径点的位置，操作性很差，所以说路径用 Path 组件。

### 组件用途

1.游戏模型路径运动（塔防小怪行走路线，马路上的汽车运动）

2.摄像机运动动画（建筑场景漫游，游戏过场动画，VR 过山车）

其实本质就是事先规划好一个路径，然后让游戏物体在该路径上运动。

### Path 组件操作

首先选中需要设置路径的游戏物体，然后给它添加 Path 路径组件。

Shift+Ctrl+鼠标左键单击：添加一个新的路径点；

Shift+Alt+鼠标左键点击：移除一个路径点；

鼠标左键单击：调整路径点的位置。

#### Tween Options [动画选项]

这一部分属性和 Animation 动画控制属性几乎一样。

#### Path Tween Options [路径动画选项]

**PathType**：路径类型，设置路径点的两端是直线还是弧度；

**ClosePath**：关闭路径，模型最终会回到起点位置；

**PathMode**：路径模式，保持默认；

**Orientation**：方向，最常用的是 ToPath，模型沿路径正方向移动；

**LookAhead**：0 正方向。

这个方向在摄像机漫游动画中很关键，因为你需要沿路径一直看着前方。



#### Path Editor Options [路径编辑选项]

**Relative**：路径相对于模型移动；

**Color**：路径线的颜色；

**ShowIndexes**：显示路径点的位置索引；

#### Extras [额外属性]

**ResetPath**：路径重置；

**Waypoints**：路径点集合，可以在这里对每个点的位置进行精准调节。