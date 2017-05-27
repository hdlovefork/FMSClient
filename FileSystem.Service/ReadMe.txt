本类库提供给前台使用，包含以下功能：
1、用户权限验证

引用DLL：
	FileSystem.BG.DAL.dll
	FileSystem.BG.Entity.dll
	FileSystem.Service.dll
	

方法原型：
		/// <summary>
        /// 判断用户是否具有指定权限操作
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="fileID">文件ID</param>
        /// <param name="access">访问动作</param>
        /// <returns></returns>
        public static bool Auth(int uid,int fileID,FilePermission access)

使用方法：
	1）认证小明（UID为1）对 会议文件1（FileID为12） 是否有可读权限
		if(AuthPermission.Auth(1，12，FilePermission.Read)){
			//小明拥有可读权限
		}else{
			//小明没有可读权限
		}

	2）认证小明（UID为1）对 会议文件2（FileID为13） 是否有可写权限
	if(AuthPermission.Auth(1，13，FilePermission.Read)){
		//小明拥有可读权限
	}else{
		//小明没有可读权限
	}

		

