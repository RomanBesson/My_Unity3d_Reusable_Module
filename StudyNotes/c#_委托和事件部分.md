# 委托和事件

## 1.委托

### 1.1.基本介绍和使用

委托是一种可以把方法当做(方法的)参数来传递的函数形式，使用修饰符`delegate`修饰。类似于把这个方法交给委托代理执行。

**用法如下：**

```csharp
public delegate void CalcDelegate(int a, int b);
```

委托要和要绑定的方法的**返回值类型**，以及**参数列表**的类型保持一致。

**示例如下：**

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate int AndroidDelegate(string name);
public delegate string IOSDelegate(int price);


public class Phone : MonoBehaviour {

	void Start () {

        MyAndroid("华为", Android6);

        MyIOS(7890, IOS5);

        
    }

    private void MyAndroid(string name, AndroidDelegate ad)
    {
        ad(name);
    }

    private void MyIOS(int price, IOSDelegate ios)
    {
        string temp = ios(price);
        Debug.Log(temp);
    }


    private int Android6(string name)
    {
        Debug.Log("Android6版本的手机" + name);
        return 6;
    }


    private string IOS5(int price)
    {
        return "IOS5手机的价格是" + price;
    }


}

```

### 1.2.多播委托

实际上，同参数同返回值的委托对象是可以绑定多个参数的，并且可以让绑定的函数按照添加顺序调用，这就是多播委托。

多播委托对象使用 `=`来初始化， `+=` 来添加方法， `-=` 来减少方法。

**示例：**

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void WebInfoDelegate();

/// <summary>
/// 多播委托.
/// </summary>
public class WebInfo : MonoBehaviour {

	void Start () {

        //添加方法
        WebInfoDelegate webInfoDel;
        webInfoDel = MKCode;
        webInfoDel += Taobao;
        webInfoDel += YouKu;
        webInfoDel += Baidu;

        //删除方法
        //webInfoDel -= Taobao;

        webInfoDel();
    }


    private void Baidu()
    {
        Debug.Log("www.baidu.com");
    }

    private void Taobao()
    {
        Debug.Log("www.taobao.com");
    }

    private void YouKu()
    {
        Debug.Log("www.youku.com");
    }

    private void MKCode()
    {
        Debug.Log("www.mkcode.net");
    }
}

```

#### DLC：多播存在的问题

如果，多播不只是存在于一个类里，而是多个类调用的话，就会出现重复初始化的问题，导致数据丢失。

- 主委托方法

  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
     //委托
  public delegate void EatDelegate();
  
  public class Master : MonoBehaviour {
  
      //单例
      public static Master Instance;
  
      void Awake()
      {
          Instance = this;
      }
  
  	void Update () {
  		if(Input.GetKeyDown(KeyCode.Space))
          {
              ChiFan();
          }
  	}
  
      private void ChiFan()
      {
          Debug.Log("吃饭时间到!!都过来吃饭~~");
          //调用委托
          EatDelegate();
      }
  }
  
  ```

- 委托的调用的方法类

  ```csharp
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  public class Cat : MonoBehaviour {
  
  	void Start () {
          //添加进委托
          Master.Instance.eatDelegate = CatEat;
  	}
  
  	private void CatEat()
      {
          Debug.Log("主人喊吃饭啦!!去吃饭,喵喵喵~~");
      }
  }
  
  ```

  

此时，我们会发现，在其他类使用`=`也是被允许的（也可以写`+=`），但是这样会存在安全性问题，如果多个委托接受类存在，就会导致委托对象一直被初始化，出现数据丢失问题。此时，我们需要只允许添加，只能使用`+=` 和 `-=`的形式委托。

事件由此诞生！

```csharp
public Event void EatDelegate();
```

## 2.匿名方法

#### 2.1.格式如下

委托类型 变量 = delegate（[类型列表]）

{

​     方法体；

}；



**示例：**

``` csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ShowDelegate();        //无参.
public delegate void NameDelegate(string name);     //有参.

public class LambdaTest : MonoBehaviour {

    public ShowDelegate showDel;
    public NameDelegate nameDel;

	void Start () {
        showDel = Hello;

        showDel += delegate()
        {
            Debug.Log("MKCODE");
        };


        showDel();

	}



    private void Hello()
    {
        Debug.Log("Monkey");
    }
}

```

**将他再简化一下：**

## 3.Lamda表达式

### 3.1.格式

委托类型 变量 = （[参数列表]）=> { 方法体; };

①=> 是 Lambda 表达式特有符号，读音是：goes to

②如果没有参数列表，（）也不能省略，如：（）=>

③如果参数列表中只有一个参数，（）可以省略

④如果方法体内只有一句代码，可以省略代码块符号，也就是不用写{ }

**示例：**

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ShowDelegate();        //无参.
public delegate void NameDelegate(string name);     //有参.

public class LambdaTest : MonoBehaviour {

    public ShowDelegate showDel;
    public NameDelegate nameDel;

	void Start () {
        showDel = Hello;

        //原始委托形式
        showDel += delegate()
        {
            Debug.Log("MKCODE");
        };

        //Lamda表达式形式
        showDel += () => { Debug.Log("擅码网"); };

        showDel();

        //-------------------------------------------------

        //加了参数的形式
        nameDel = (string name) =>
        {
            Debug.Log("我的名字是:" + name);
        };

        
        nameDel += (string name) => { Debug.Log("My Name Is" + name); };

        //简写形式
        nameDel += name => { Debug.Log("你是:" + name); };

        nameDel += info => Debug.Log("Hello:" + info);
        
        nameDel("LKK");

	}



    private void Hello()
    {
        Debug.Log("Monkey");
    }
}

```



### 3.2.需要将函数作为参数的lamda表达式写法

如`string`类的`FindAll()`

```csharp
using System.Collections;juli
using System.Collections.Generic;
using UnityEngine;

public class LambdaDemo : MonoBehaviour {

    private List<string> names = new List<string>();

	void Start () {
        names.Add("李小龙");
        names.Add("李国豪");
        names.Add("马云");
        names.Add("马化腾");

        //查找以李开头的
        List<string> tempName = names.FindAll(name => name.StartsWith("李"));

        for (int i = 0; i < tempName.Count; i++)
        {
            Debug.Log("Lambda:" + tempName[i]);
        }

	}
	

 
}

```



## 4.委托之内置委托

### 4.1.Action

Action 是一个无返回值的内置委托类型；

**使用示例：**

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void MonkeyDelegate();

public class ActionDemo : MonoBehaviour {

    private MonkeyDelegate monkeyDel;
    //无参
    private Action nameDel;
    //有参
    private Action<int, int> myCalc;

	void Start () {
        monkeyDel = () => Debug.Log("MK");
        monkeyDel += () => { Debug.Log("MKCODE"); };
        monkeyDel();

        nameDel = () => { Debug.Log("Action"); };
        nameDel();

        myCalc = (int a, int b) => Debug.Log(string.Format("{0} + {1} = {2}", a, b, a + b));
        myCalc += (a, b) => Debug.Log(string.Format("{0} * {1} = {2}", a, b, a * b));

        myCalc(2, 5);
	}
	
}

```



### 4.2.Action

Action 是一个有返回值的内置委托类型；

**使用示例：**

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FuncDemo : MonoBehaviour {

    public Func<int> funcDel;
    public Func<int, int, int> funcCalc;

    void Start () {
        funcDel = () => { return 550; };
        funcDel = () => 666;
        funcDel = () =>
        {
            Debug.Log("大家晚上好");
            return 1000;
        };
        int temp = funcDel();
        Debug.Log(temp);

        funcCalc = (int a, int b) => { return a + b; };
        Debug.Log(funcCalc(10, 5));

    }
	
}

```

