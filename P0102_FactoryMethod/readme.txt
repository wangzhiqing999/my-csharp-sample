本项目是“工厂方法”模式的 例子代码


工厂方法由四部分组成。

1、抽象工厂(Creator) 
本例子中是 
P0102_FactoryMethod.FactoryMethod.IFruitGardener

2、具体工厂(Concrete Creator)
本例子中是 
P0102_FactoryMethod.FactoryMethodImpl.AppleGardener
P0102_FactoryMethod.FactoryMethodImpl.GrapeGardener
P0102_FactoryMethod.FactoryMethodImpl.StrawberryFruitGardener


3、抽象产品(Product)
本例子中是
P0101_SimpleFactory.Service.IFruit
(使用前面的 简单工厂的类)

4、具体产品(Concrete Product)
本例子中是
P0101_SimpleFactory.ServiceImpl.Apple
P0101_SimpleFactory.ServiceImpl.Grape
P0101_SimpleFactory.ServiceImpl.Strawberry
(使用前面的 简单工厂的类)



工厂方法 与 简单工厂的 区别.

简单工厂中，工厂类 是一个 全能的，无所不知的类。
这个类需要知道所有的产品。
当新增产品的时候，需要修改这个 工厂类。


工厂方法中，用户需要先创建一个 具体工厂 ， 然后用这个 具体工厂， 再去创建产品。
当新增产品的时候，需要相应的 新增一个 具体工厂类。