using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyRule.EF;
using MyRule.Service;



namespace MyRule.ServiceImpl
{

    /// <summary>
    /// 权限体系的 管理接口实现.
    /// </summary>
    public class MyRuleServiceImpl : IMyRuleService
    {

        #region 仅仅基于用户的 查询方法.




        /// <summary>
        /// 获取 指定 用户的 "可访问部门" 列表.
        /// 可访问部门包含 用户当前部门 与 用户当前部门的下属部门.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        public List<MR_DEPT> GetUserAccessAbleDeptList(string userCode)
        {
            // 预期要返回的结果.
            List<MR_DEPT> resultList = new List<MR_DEPT>();

            // 开始查询处理.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                // 首先查询用户.
                MR_USER mrUser = context.MR_USER.FirstOrDefault(p => p.USER_CODE == userCode);


                if (mrUser == null)
                {
                    // 用户不存在.
                    return resultList;
                }


                // 延迟查询 用户的 直属部门.
                foreach (MR_DEPT mrDept in mrUser.MR_DEPT)
                {
                    // 如果结果列表中没有数据， 那么加入结果列表.
                    if (resultList.Count(p => p.DEPT_CODE == mrDept.DEPT_CODE) == 0)
                    {
                        // 加入 用户的 直属部门.
                        resultList.Add(mrDept);

                        // 查询这个部门的下属部门.
                        List<MR_DEPT> allSubDeptList = mrDept.GetAllSubMrDeptList();

                        foreach (MR_DEPT subDept in allSubDeptList)
                        {
                             // 如果结果列表中没有数据， 那么加入结果列表.
                            if (resultList.Count(p => p.DEPT_CODE == subDept.DEPT_CODE) == 0)
                            {
                                // 加入 用户的 直属部门 的  下属部门.
                                resultList.Add(subDept);
                            }
                        }
                    }
                }
            }

            // 返回结果列表.
            return resultList;
        }




        /// <summary>
        /// 获取 指定 用户的 "可访问模块" 列表.
        /// 可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        public List<MR_MODULE> GetUserAccessAbleModuleList(string userCode)
        {
            // 开始查询处理并返回.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                return GetUserAccessAbleModuleList(context, userCode);
            }
        }



        /// <summary>
        /// 获取 指定用户 对指定模块 的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <param name="moduleCode"> 模块代码 </param>
        /// <returns></returns>
        public List<MR_ACTION> GetUserAccessAbleActionList(string userCode, string moduleCode)
        {
            // 开始查询处理， 并返回.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                return GetUserAccessAbleActionList(context, userCode, moduleCode);
            }


        }



        #endregion







        #region  仅仅基于 角色 的查询方法.


        /// <summary>
        /// 获取 指定 角色的 "可访问模块" 列表.
        /// 可访问模块包含 角色直接可访问模块 与 角色直接可访问模块的下属模块.
        /// </summary>
        /// <param name="roleCode"> 角色代码 </param>
        /// <returns></returns>
        public List<MR_MODULE> GetRoleAccessAbleModuleList(string roleCode)
        {
            // 开始查询处理 并返回.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                return GetRoleAccessAbleModuleList(context, roleCode);
            }
        }



        /// <summary>
        /// 获取 指定角色 对指定模块 的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对角色授权了的动作.
        /// </summary>
        /// <param name="roleCode"> 角色代码 </param>
        /// <param name="moduleCode"> 模块代码 </param>
        /// <returns></returns>
        public List<MR_ACTION> GetRoleAccessAbleActionList(string roleCode, string moduleCode)
        {
            // 开始查询处理. 并返回.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                return GetRoleAccessAbleActionList(context, roleCode, moduleCode);
            }
        }





        #endregion









        #region 结合 用户与角色 的查询方法.



        /// <summary>
        /// 获取 指定 用户的 全部的 "可访问模块" 列表.
        /// 可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
        /// 以及 用户的角色 直接可访问模块 与 用户的角色直接可访问模块的下属模块.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        public List<MR_MODULE> GetAllUserAccessAbleModuleList(string userCode)
        {
            // 开始查询处理 并返回.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                return GetAllUserAccessAbleModuleList(context, userCode);
            }
        }



        /// <summary>
        /// 获取 指定用户 对指定模块 全部的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
        /// 以及针对 用户的角色授权了的动作.
        /// </summary>
        /// <param name="userCode"> 用户代码 </param>
        /// <param name="moduleCode"> 模块代码 </param>
        /// <returns></returns>
        public List<MR_ACTION> GetAllUserAccessAbleActionList(string userCode, string moduleCode)
        {
            // 预期结果.
            List<MR_ACTION> resultList = new List<MR_ACTION>();

            // 开始查询处理.
            using (MyRuleEntities context = new MyRuleEntities())
            {
                // 首先查询用户.
                MR_USER mrUser = context.MR_USER.FirstOrDefault(p => p.USER_CODE == userCode);
                if (mrUser == null)
                {
                    // 用户不存在.
                    return resultList;
                }

                // 然后从 用户所拥有的所有模块的列表中， 查询有没有参数指定的模块.
                MR_MODULE mrModule = GetAllUserAccessAbleModuleList(context, userCode).FirstOrDefault(p => p.MODULE_CODE == moduleCode);

                if (mrModule == null)
                {
                    // 模块不存在 或者 用户 与  用户的角色 没有访问此模块的权限.
                    return resultList;
                }


                // 首先加入 用户可访问的 动作.
                resultList.AddRange( GetUserAccessAbleActionList(context, userCode, moduleCode) );


                // 然后 遍历 用户的角色.
                foreach (MR_ROLE mrRole in mrUser.MR_ROLE)
                {
                    // 将 用户的角色 的 可访问的 动作列表， 加入结果列表. （重复的不加入）
                    foreach (MR_ACTION oneAction in GetRoleAccessAbleActionList(context, mrRole.ROLE_CODE, moduleCode))
                    {
                        if (resultList.Count(p => p.ACTION_CODE == oneAction.ACTION_CODE) == 0)
                        {
                            resultList.Add(oneAction);
                        }
                    }
                }


            }



            // 返回.
            return resultList;

        }


        #endregion







        #region  私有方法.



        /// <summary>
        /// 获取 指定 用户的 "可访问模块" 列表.
        /// 可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userCode"> 用户代码 </param>
        /// <returns></returns>
        private List<MR_MODULE> GetUserAccessAbleModuleList(MyRuleEntities context, string userCode)
        {
            // 预期要返回的结果.
            List<MR_MODULE> resultList = new List<MR_MODULE>();

            // 首先查询用户.
            MR_USER mrUser = context.MR_USER.FirstOrDefault(p => p.USER_CODE == userCode);


            if (mrUser == null)
            {
                // 用户不存在.
                return resultList;
            }



            // 延迟查询 用户的 直接可访问模块.
            foreach (MR_MODULE mrModule in mrUser.MR_MODULE)
            {
                // 如果结果列表中没有数据， 那么加入结果列表.
                if (resultList.Count(p => p.MODULE_CODE == mrModule.MODULE_CODE) == 0)
                {
                    // 加入 用户的 直接可访问模块.
                    resultList.Add(mrModule);

                    // 查询这个部门的下属部门.
                    List<MR_MODULE> allSubModuleList = mrModule.GetAllSubMrModuleList();

                    foreach (MR_MODULE subModule in allSubModuleList)
                    {
                        // 如果结果列表中没有数据， 那么加入结果列表.
                        if (resultList.Count(p => p.MODULE_CODE == subModule.MODULE_CODE) == 0)
                        {
                            // 加入 用户的 直属部门 的  下属部门.
                            resultList.Add(subModule);
                        }
                    }
                }
            }


            // 返回结果列表.
            return resultList;
        }



        /// <summary>
        /// 获取 指定用户 对指定模块 的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对用户授权了的动作.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userCode"></param>
        /// <param name="moduleCode"></param>
        /// <returns></returns>
        private List<MR_ACTION> GetUserAccessAbleActionList(MyRuleEntities context, string userCode, string moduleCode)
        {
            // 预期结果.
            List<MR_ACTION> resultList = new List<MR_ACTION>();

            // 首先查询用户.
            MR_USER mrUser = context.MR_USER.FirstOrDefault(p => p.USER_CODE == userCode);

            if (mrUser == null)
            {
                // 用户不存在.
                return resultList;
            }


            // 然后从 用户所拥有的所有模块的列表中， 查询有没有参数指定的模块.
            MR_MODULE mrModule = GetUserAccessAbleModuleList(context, userCode).FirstOrDefault(p => p.MODULE_CODE == moduleCode);

            if (mrModule == null)
            {
                // 模块不存在 或者 用户 没有访问此模块的权限.
                return resultList;
            }

            // 遍历模块下的 动作.
            foreach (MR_ACTION mrAction in mrModule.MR_ACTION)
            {
                if (mrAction.DEFAULT_RULE == 1)
                {
                    // 默认动作， 自动拥有权限.
                    resultList.Add(mrAction);
                }
                else
                {
                    // 非默认动作，需要 用户有相应的授权.
                    if (mrUser.MR_ACTION.Count(p => p.ACTION_CODE == mrAction.ACTION_CODE) > 0)
                    {
                        // 用户 有这个动作的 授权.
                        resultList.Add(mrAction);
                    }
                }
            }

            // 返回.
            return resultList;
        }





        /// <summary>
        /// 获取 指定 角色的 "可访问模块" 列表.
        /// 可访问模块包含 角色直接可访问模块 与 角色直接可访问模块的下属模块.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        private List<MR_MODULE> GetRoleAccessAbleModuleList(MyRuleEntities context, string roleCode)
        {
            // 预期要返回的结果.
            List<MR_MODULE> resultList = new List<MR_MODULE>();
            // 首先查询角色.
            MR_ROLE mrRole = context.MR_ROLE.FirstOrDefault(p => p.ROLE_CODE == roleCode);


            if (mrRole == null)
            {
                // 角色不存在.
                return resultList;
            }



            // 延迟查询 角色的 直接可访问模块.
            foreach (MR_MODULE mrModule in mrRole.MR_MODULE)
            {
                // 如果结果列表中没有数据， 那么加入结果列表.
                if (resultList.Count(p => p.MODULE_CODE == mrModule.MODULE_CODE) == 0)
                {
                    // 加入 用户的 直接可访问模块.
                    resultList.Add(mrModule);

                    // 查询这个部门的下属部门.
                    List<MR_MODULE> allSubModuleList = mrModule.GetAllSubMrModuleList();

                    foreach (MR_MODULE subModule in allSubModuleList)
                    {
                        // 如果结果列表中没有数据， 那么加入结果列表.
                        if (resultList.Count(p => p.MODULE_CODE == subModule.MODULE_CODE) == 0)
                        {
                            // 加入 用户的 直属部门 的  下属部门.
                            resultList.Add(subModule);
                        }
                    }
                }
            }

            // 返回结果列表.
            return resultList;

        }



        /// <summary>
        /// 获取 指定角色 对指定模块 的 "可访问动作" 列表.
        /// 可访问动作，包含 当前模块的 默认可用动作 与 针对角色授权了的动作.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleCode"></param>
        /// <param name="moduleCode"></param>
        /// <returns></returns>
        private List<MR_ACTION> GetRoleAccessAbleActionList(MyRuleEntities context, string roleCode, string moduleCode)
        {
            // 预期结果.
            List<MR_ACTION> resultList = new List<MR_ACTION>();


            // 首先查询角色.
            MR_ROLE mrRole = context.MR_ROLE.FirstOrDefault(p => p.ROLE_CODE == roleCode);

            if (mrRole == null)
            {
                // 角色不存在.
                return resultList;
            }


            // 然后从 用户所拥有的所有模块的列表中， 查询有没有参数指定的模块.
            MR_MODULE mrModule = GetRoleAccessAbleModuleList(context, roleCode).FirstOrDefault(p => p.MODULE_CODE == moduleCode);

            if (mrModule == null)
            {
                // 模块不存在 或者 角色 没有访问此模块的权限.
                return resultList;
            }

            // 遍历模块下的 动作.
            foreach (MR_ACTION mrAction in mrModule.MR_ACTION)
            {
                if (mrAction.DEFAULT_RULE == 1)
                {
                    // 默认动作， 自动拥有权限.
                    resultList.Add(mrAction);
                }
                else
                {
                    // 非默认动作，需要 角色有相应的授权.
                    if (mrRole.MR_ACTION.Count(p => p.ACTION_CODE == mrAction.ACTION_CODE) > 0)
                    {
                        // 用户 有这个动作的 授权.
                        resultList.Add(mrAction);
                    }
                }
            }


            // 返回.
            return resultList;
        }




        /// <summary>
        /// 获取 指定 用户的 全部的 "可访问模块" 列表.
        /// 可访问模块包含 用户直接可访问模块 与 用户直接可访问模块的下属模块.
        /// 以及 用户的角色 直接可访问模块 与 用户的角色直接可访问模块的下属模块.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        private List<MR_MODULE> GetAllUserAccessAbleModuleList(MyRuleEntities context, string userCode)
        {
            // 预期要返回的结果.
            List<MR_MODULE> resultList = new List<MR_MODULE>();

            // 首先查询用户.
            MR_USER mrUser = context.MR_USER.FirstOrDefault(p => p.USER_CODE == userCode);
            if (mrUser == null)
            {
                // 用户不存在.
                return resultList;
            }

            // 将 用户 直接 可访问的 模块列表， 加入结果列表.
            resultList.AddRange( GetUserAccessAbleModuleList(context, userCode));


            // 然后 遍历 用户的角色.
            foreach (MR_ROLE mrRole in mrUser.MR_ROLE)
            {
                // 将 用户的角色 的 可访问的 模块列表， 加入结果列表. （重复的不加入）
                foreach (MR_MODULE oneModule in GetRoleAccessAbleModuleList(context, mrRole.ROLE_CODE))
                {
                    if (resultList.Count(p => p.MODULE_CODE == oneModule.MODULE_CODE) == 0)
                    {
                        resultList.Add(oneModule);
                    }
                }
            }

            // 返回.
            return resultList;
        }







        #endregion

    }
}
