[toc]

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
ssh-keygen -t rsa -C “你的邮箱”
```

### 3.3.测试和仓库的ssh连接

```bash
ssh -T git@github.com
```

## 4.与远程仓库的操作

### 4.1.连接远程仓库

```bash
git remote add origin “你的仓库SSH地址”
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
git commit -m “你的备注信息”

# 提交到远程仓库
git push -u origin master
```



# Unity_Api

## 1.Input [输入类]

### 1.1.获取鼠标按键

```c#
/*获取鼠标按键三种状态.[0:左键  1:右键  2:中键]*/

[s][bool] GetMouseButtonDown(int)  //按下某键的一瞬间,返回true.

[s][bool] GetMouseButton(int)    //按下某键后,持续返回true.

[s][bool] GetMouseButtonUp(int)   //抬起某键的一瞬间,返回true.
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
[void] Start()                        //项目运行之后,自动执行一次.
[void] Update()                       //每帧执行一次,一秒钟大约60次.
[void] FixedUpdate()                 //固定更新,0.02秒执行一次.
```

### 2.2.GameObject对象

```c#
[GameObject] gameObject  //只读属性,当前脚本组件所挂载到的游戏物体对象.
```

## 3.GameObject[游戏物体类]

