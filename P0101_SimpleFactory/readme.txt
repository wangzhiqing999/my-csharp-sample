本项目是“简单工厂”模式的 例子代码


简单工厂由三部分组成。

1、工厂类(Creator) 
本例子中是 
P0101_SimpleFactory.SimpleFactory.FruitGardener


2、抽象产品(Product)
本例子中是
P0101_SimpleFactory.Service.IFruit


3、具体产品(Concrete Product)
本例子中是
P0101_SimpleFactory.ServiceImpl.Apple
P0101_SimpleFactory.ServiceImpl.Grape
P0101_SimpleFactory.ServiceImpl.Strawberry



简单工厂模式的优点：
模式的核心是工厂类、这个类含有必要的逻辑判断，可以决定什么时候，创建哪一个产品类的实例。
客户端可以免除直接创建产品对象的责任，仅仅负责“消费”产品。


简单工厂模式的缺点：
如果产品类有复杂的 多层次等级结构时，工厂类必须包含所有的处理逻辑。
如果新增一种产品， 必须去修改工厂类。
简单工厂模式使用静态方法作为工厂方法。
