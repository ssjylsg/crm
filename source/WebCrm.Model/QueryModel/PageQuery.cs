using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    public class Pager
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
    }
    public class PageQuery<Q, T>
        where T : CrmEntity
    {
        public int RecordCount { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        ///排序方式
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public Q Condition { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public IList<T> Result { get; set; }
        /// <summary>
        /// 当前操作人
        /// </summary>
        public OperatorUser OperatorUser { get; private set; }

        public Pager Pager
        {
            get
            {
                return new Pager() { CurrentPageIndex = this.CurrentPageIndex, PageSize = this.PageSize, };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorUser">当前操作人</param>
        public PageQuery(OperatorUser operatorUser)
        {
            this.OperatorUser = operatorUser;
            PageSize = 20;
            CurrentPageIndex = 1;
            this.Order = " Order By CreateTime desc ";
        }
        /// <summary>
        /// 设置PageSize 为Int.MaxValue 和当前也为1
        /// </summary>
        public void SetQueryAll()
        {
            CurrentPageIndex = 1;
            PageSize = int.MaxValue;

        }
    }
}
