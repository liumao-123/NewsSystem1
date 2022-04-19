using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem1.Models
{
    /// <summary>
    /// 数据库的操作接口
    /// </summary>
    public interface IProvider<T> where T:class
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        List<T> Select();
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int insert(T t);
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        int Delete(T t);


    }
}