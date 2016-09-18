操作步骤。


一.创建默认的资源文件。

【项目】， 【属性】中， 选择 【资源】。
没有【资源】的话，根据提示，创建。
完毕后， 在界面上，输入 【资源】的 【名称】与【值】
保存。



上面的步骤完成之后，在 Properties 目录下，将有一个 Resources.resx 文件。




二.创建其他语言的资源。

将 Resources.resx 多次复制粘贴，分别命名为 
Resources.en-US.resx
Resources.fr-FR.resx
Resources.de-DE.resx
Resources.zh-CN.resx
Resources.ja-JP.resx

然后，将这些文件，包含到项目中，修改 【名称】的【值】。


保存之后，编译项目。
观察 bin\Debug 目录， 是否有相应的 语言的目录， 目录下有 资源的  dll 文件。


三. 编写测试代码。
通过修改 Resources.Culture，输出资源中的数据。




四.注意事项。

理论上，开发过程中，仅仅使用一个 Resources.resx
在项目基本完成，不会再对 Resources.resx 进行新增【名称】的情况下， 对 Resources.resx 进行复制/粘贴/修改 的工作。
否则开发过程中，同时维护多个语言的 Resources.resx，成本略高。


