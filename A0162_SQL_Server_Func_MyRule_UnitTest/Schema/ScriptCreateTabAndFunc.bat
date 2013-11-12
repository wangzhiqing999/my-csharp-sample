sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "MyRule_SQLServerTable_DropAll.sql" 

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "MyRule_SQLServerTable.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "MyRule_SQLServerFunc_DeptUserModelAction.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "MyRule_SQLServerFunc_RoleUserModelAction.sql"

sqlcmd -E -S "localhost\SQLEXPRESS" -i "000_SelectDatabase.sql" "MyRule_SQLServerFunc_AllUserModelAction.sql"



pause

