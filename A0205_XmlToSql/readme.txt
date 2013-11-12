有 省，市，区 3个 XML 文件。
旧有系统是 C/S 的， Client 直接读取这3个 XML 文件。

新系统是 B/S 的。 需要把这些数据，存储在数据库表中。

处理的步骤：
1. 按照 XML 文件的格式， 定义 Model 类。
2. 使用 System.Xml.Serialization 进行读取。
3. 代码中 输出 INSERT 语句。
4. 通过重定向，产生 .sql 文件    D:\A0205_XmlToSql\bin\Debug>A0205_XmlToSql.exe >> test.sql
5. 在目标数据库，执行该 SQL 语句。
