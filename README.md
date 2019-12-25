# NewScrollRect
实现无限滑动列表，自适应高度，树状结构等
在loopscroolRect的基础上，进行了调整，使更适合项目的使用。

* 滑动列表的逻辑使用了LoopScrollRect，[源码地址](https://github.com/qiankanglai/LoopScrollRect)，它的基本的原理，就是复用item的prefab，建立一个prefab的对象池，以viewBound，和ContentBound为判断依据，来决定是否开始删除和增加。

* 脚本上的数据的绑定利用的是UIControlBinding, [https://github.com/Misaka-Mikoto-Tech/UIControlBinding](https://github.com/Misaka-Mikoto-Tech/UIControlBinding "源码地址")
，需要Xlua的支持。不过如果只用c#开发，也不需要用到xlua，不过这个插件是需要xlua的代码的一些引用，所以需要添加进去，在实际的项目中可以考虑使用ControlBinding来实现脚本的数据绑定。

#### 基本的使用
可以参考Scenes下的基本场景。

1. CommonScrollTest, 为基本的滑动的列表。

2. ChatTest， 为简单的聊天列表，支持聊天气泡的自适应。基本的原理：text的自适应，在text上添加了contentsizeFitter组件，来自动调整高度。也可以用代码来动态调整，不过需要计算文字数量，直到当前的linecount， 行高，自己动态调整text的hight。然后利用text的高度来调整聊天气泡的高度，最后再利用item的节点的高度之和，来计算出当前的item的hight，然后修改item上的LayoutElement的hight值，从而实现自适应。 
1. 树状结构，待补充

#### 注意点
在使用LoopScrollRect时，item的prefab上必须要有LayoutElemnet组件，它是列表计算size的基础。也是动态调整item的尺寸，支持不等长item的基础。如果item需要动态调整，要注意要动态调整的节点的轴心，一般都是（0.5， 1）。

ScrollRect上添加， LoopVerticalScrollRect或者LoopHorizontalscrollrect组件，和RectMask2D。

Content上添加VertiacalLayoutGroup（Horizontal）和ContentSizeFitter。
并且要注意content的轴心和锚点位置。

在unity2018中使用，要注意调整player setting中的Scripting runtime version, 因为xlua中使用了sysytem.Reflection.Emit，发现在.net4.x中无法使用，所以需要调整到Stable(.Net 3.5),具体的原因不知道，自己发现的解决办法。肯定有其他的原因，后续再查找吧

#### 后续的补充和讨论
复用item的方案，LoopScrollRect中是使用prefab为载体，复用prefab，我在prafab中添加了loopitem的脚本，在复用prefab的同时，也复用了Loopitem。 可以改为以loopitem为载体，通过复用loopitem对象，来实现复用。

现在制定prefab的方式，是通过name，这样在初始的item构建时，就需要多次的调用resourceLoad方法。其实是没必要的，我们可以调整为传入item的prefab， 初始时，只是调用实例化方法，这样就不能用prefab为对象池了，后续需要修改。

消息机制，在项目中需要构建独立的message的结构，在LoopScrollRect中就是简单的使用了unity自带的message，性能比较差，而且使用起来不方便。

没有考虑UI的结构的继承，只是简单的继承了IbindableUI,根据自己的UI框架，进行调整。

