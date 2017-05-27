/**************************************************************** 
 * 作    者：顾挺
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2017-05-11 14:13:04 
 * 当前版本：1.0.0.0
 *  
 * 描述说明： 
 * IList<UserInfo> users = ModelConvertHelper<UserInfo>.ConvertToModel(dt);
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ guting 2017 All rights reserved 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace FileSystem.Data
{
    public class ModelConvertHelper<T> where T : new()
    {
        public static IList<T> ConvertToModel(DataTable dt)    
        {    
            // 定义集合    
            var ts = new List<T>(); 
    
            // 获得此模型的类型   
            var type = typeof(T);      
            var tempName = "";      
            foreach (DataRow dr in dt.Rows)      
            {    
                var t = new T();     
                // 获得此模型的公共属性      
                var propertys = t.GetType().GetProperties(); 
                foreach (var pi in propertys)      
                {      
                    tempName = pi.Name;  // 检查DataTable是否包含此列    
                    if (dt.Columns.Contains(tempName))      
                    {      
                        // 判断此属性是否有Setter      
                        if (!pi.CanWrite) continue;         
                        var value = dr[tempName];      
                        if (value != DBNull.Value)      
                             pi.SetValue(t, value, null);  
                     }     
                 }      
                 ts.Add(t);      
             }     
            return ts;     
         }     
     }    
}
