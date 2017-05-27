/****************************************************************
*	作者：顾挺
*	CLR版本：$1.0$
*	创建时间：$2017-05-10$
*	$year$
*	描述说明：
*       通用数据库枚举
*	修改历史：
*       
*
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.DAL
{
    public enum DbProviderType
    {
        SqlServer,
        MySql,
        SQLite,
        Oracle,
        ODBC,
        OleDb,
        Firebird,
        PostgreSql,
        DB2,
        Informix,
        SqlServerCe
    }
}
