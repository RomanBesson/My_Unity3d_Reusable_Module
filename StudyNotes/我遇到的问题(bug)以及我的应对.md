[toc]



# UI

## 1.从Resources加载图片：路径没错却加载为空？

```csharp
private Image item_Image;       //物品图标.
item_Image.sprite = Resources.Load<Sprite>("Demo/SignPanel/TexTures/item/" + itemName);
```

一定要查找Sprite，赋值给sprite属性，别弄错了。否则会出现查找为空。

还有别忘了写末尾的`/`;

## 2.滚动页面想让他只在纵向或者横向滚动怎么办？

![1716116558312](../Img/1716116558312.png)

勾下这俩。