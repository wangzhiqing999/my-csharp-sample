using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyRule.EF;


namespace MyRule.Service
{

    /// <summary>
    /// 权限体系的 管理接口.
    /// </summary>
    public interface IMyRuleService
    {


        #region 仅仅基于用户的 查询方法.

        /// <summary>
        /// 获取 指定 用户的 "可访问部门" 列表.
        /// 可访问部门包含 用户当前部门 与 用户当前部门的下属部门.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        List<MR_DEPT> GetUserAccessAbleDeptList(string userCode);



        /// <summary>
        /// 获取 指定 用户的 "可访问模块" 列表.
        /// 可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        List<MR_MODULE> GetUserAccessAbleModuleList(string userCode);



        /// <summary>
        /// 获取 指定用户 对指定模块 的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <param name="moduleCode"> 模块代码 </param>
        /// <returns></returns>
        List<MR_ACTION> GetUserAccessAbleActionList(string userCode, string moduleCode);


        #endregion







        #region  仅仅基于 角色 的查询方法.




        /// <summary>
        /// 获取 指定 角色的 "可访问模块" 列表.
        /// 可访问模块包含 角色直接可访问模块 与 角色直接可访问模块的下属模块.
        /// </summary>
        /// <param name="roleCode"> 角色代码 </param>
        /// <returns></returns>
        List<MR_MODULE> GetRoleAccessAbleModuleList(string roleCode);



        /// <summary>
        /// 获取 指定角色 对指定模块 的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对角色授权了的动作.
        /// </summary>
        /// <param name="roleCode"> 角色代码 </param>
        /// <param name="moduleCode"> 模块代码 </param>
        /// <returns></returns>
        List<MR_ACTION> GetRoleAccessAbleActionList(string roleCode, string moduleCode);




        #endregion









        #region 结合 用户与角色 的查询方法.





        /// <summary>
        /// 获取 指定 用户的 全部的 "可访问模块" 列表.
        /// 可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
        /// 以及 用户的角色 直接可访问模块 与 用户的角色直接可访问模块的下属模块.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        List<MR_MODULE> GetAllUserAccessAbleModuleList(string userCode);



        /// <summary>
        /// 获取 指定用户 对指定模块 全部的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
        /// 以及针对 用户的角色授权了的动作.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <param name="moduleCode"> 模块代码 </param>
        /// <returns></returns>
        List<MR_ACTION> GetAllUserAccessAbleActionList(string userCode, string moduleCode);



        #endregion



    }



}
