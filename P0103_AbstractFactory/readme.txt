本项目是“抽象工厂”模式的 例子代码


抽象工厂，是工厂方法的进一步推广。

工厂方法由四部分组成。

1、抽象工厂(Creator) 
本例子中是 
P0103_AbstractFactory.AbstractFactory.IGardener


2、具体工厂(Concrete Creator)
本例子中是 
P0103_AbstractFactory.AbstractFactoryImpl.NorthernGardener
P0103_AbstractFactory.AbstractFactoryImpl.TropicalGardener


3、抽象产品(Product)
本例子中是
P0103_AbstractFactory.Service.IFruit
P0103_AbstractFactory.Service.IVeggie



4、具体产品(Concrete Product)
本例子中是
P0103_AbstractFactory.ServiceImpl.NorthernFruit
P0103_AbstractFactory.ServiceImpl.NorthernVeggie
P0103_AbstractFactory.ServiceImpl.TropicalFruit
P0103_AbstractFactory.ServiceImpl.TropicalVeggie




什么情况下，应该使用抽象工厂模式

一个系统不应当依赖于产品类实例如何被创建、组合和表达的细节，这对所有形态的工厂模式都是重要的。

这个系统的产品有多于一个的产品族，而系统只消费其中某一族的产品 
（这个是抽象工厂模式的原始用意： 例如 Windows UI  与  Unix  UI）

同属于同一个产品族的产品，是在一起使用的。

系统提供一个产品类的库，所有的产品以同样的接口出现，从而使客户端不依赖于实现。

