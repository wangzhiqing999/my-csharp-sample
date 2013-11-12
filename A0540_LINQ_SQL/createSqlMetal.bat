path C:\Program Files\Microsoft SDKs\Windows\v6.0A\bin

REM 对于本机的 sqlexpress 服务器上的 test 数据库 输出 代码 , 源代码为 C#, 命名空间为 A0540_LINQ_SQL.Sample
sqlmetal /server:.\sqlexpress /database:test /map:Test.map /code:Test.cs /language:C# /namespace:A0540_LINQ_SQL.Sample

