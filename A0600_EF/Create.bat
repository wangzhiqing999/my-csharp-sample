path C:\WINDOWS\Microsoft.NET\Framework\v3.5

REM 生成完整 Entity Model

EdmGen /mode:FullGeneration /project:Test /namespace:A0600_EF.Sample /language:CSharp /provider:System.Data.SqlClient /connectionstring:"server=.\sqlexpress;integrated security=true;database=test"