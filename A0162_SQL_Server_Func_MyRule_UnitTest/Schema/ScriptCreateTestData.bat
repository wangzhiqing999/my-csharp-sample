sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "001_MyRule_TestData_ClealAll.sql" 

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "002_MyRule_TestData_DeptUser.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "003_MyRule_TestData_ModelAction.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "004_MyRule_TestData_UserModelAction.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "005_MyRule_TestData_RoleUser.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "006_MyRule_TestData_RoleModelAction.sql"



sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "007_MyRule_TestData_Demo.sql"



pause

