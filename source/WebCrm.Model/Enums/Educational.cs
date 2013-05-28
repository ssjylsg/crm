using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebCrm.Model
{
    /// <summary>
    /// 学历
    /// </summary>
    public enum Educational
    {
        [Description("请选择")]
        Default = 0,
        [Description("小学")]
        PrimarySchool,
        [Description("初中")]
        JuniorHighSchool,
        [Description("高职")]
        Vocational,
        [Description("中专")]
        Secondary,
        [Description("高中")]
        SeniorMiddleSchool,
        [Description("大专")]
        College,
        [Description("本科/学士")]
        UndergraduateCourse,
        [Description("硕士")]
        Master,
        [Description("博士")]
        Doctor,
        [Description("博士后")]
        Postdoctoral
    }
    /// <summary>
    /// 身体状态
    /// </summary>
    public enum HealthState
    {
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 良好
        /// </summary>
        [Description("良好")]
        Fine = 1,
        /// <summary>
        /// 体弱
        /// </summary>
        [Description("体弱")]
        Frail,
        /// <summary>
        /// 优秀
        /// </summary>
        [Description("优秀")]
        Good
    }
    /// <summary>
    /// 专业
    /// </summary>
    public enum Field
    {
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 一般职员
        /// </summary>
        [Description("一般职员")]
        Normal,
        /// <summary>
        /// 专业人员
        /// </summary>
        [Description("专业人员")]
        Professionals,
        [Description("专业工程师")]
        ProfessionalEngineer,
        /// <summary>
        /// 专业高工
        /// </summary>
        [Description("专业高工")]
        ProfessionalEngineering,
        /// <summary>
        /// 中级管理人员
        /// </summary>
        [Description("中级管理人员")]
        MidlevelManagers,
        /// <summary>
        /// 高级管理人员
        /// </summary>
        [Description("高级管理人员")]
        SeniorManagement
    }
    /// <summary>
    /// 性别
    /// </summary>
    public enum Sex
    {
        [Description("")]
        Default = 0,
        /// <summary>
        /// 男性
        /// </summary>
        [Description("男性")]
        Male,
        /// <summary>
        /// 女性
        /// </summary>
        [Description("女性")]
        Female,
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown
    }
    /// <summary>
    /// 广告状态
    /// </summary>
    public enum AdvertisingState
    {
        /// <summary>
        /// 未投放
        /// </summary>
        [Description("未投放")]
        UnPut = 0,
        /// <summary>
        /// 已投放
        /// </summary>
        [Description("已投放")]
        Puted = 1
    }
    /// <summary>
    /// 客户标识
    /// </summary>
    public enum CustomerIdentification
    {
        /// <summary>
        /// 个人
        /// </summary>
        [Description("个人")]
        Person = 0,
        /// <summary>
        /// 企业
        /// </summary>
        [Description("企业")]
        Enterprise
    }
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserInfoState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 禁止
        /// </summary>
        Banned,
        /// <summary>
        /// 离职
        /// </summary>
        Leaved,
        /// <summary>
        /// 特殊帐号
        /// </summary>
        Special,
        /// <summary>
        /// 临时帐号
        /// </summary>
        Temp
    }
    /// <summary>
    /// 体型
    /// </summary>
    public enum BodyType
    {
        /// <summary>
        /// 请选择
        /// </summary>
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 偏胖
        /// </summary>
        [Description("偏胖")]
        Overweight,
        /// <summary>
        /// 偏瘦
        /// </summary>
        [Description("偏瘦")]
        Slim,
        /// <summary>
        /// 中等身材
        /// </summary>
        [Description("中等身材")]
        MediumBuild,
        /// <summary>
        /// 身材高大
        /// </summary>
        [Description("身材高大")]
        MediumTall,
        /// <summary>
        /// 身材瘦小
        /// </summary>
        [Description("身材瘦小")]
        Petite
    }
    /// <summary>
    /// 喝酒程度
    /// </summary>
    public enum DrinkingLevel
    {
        /// <summary>
        /// 请选择
        /// </summary>
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 喝酒
        /// </summary>
        [Description("喝酒")]
        Drinking,
        /// <summary>
        /// 不喝酒
        /// </summary>
        [Description("不喝酒")]
        NoDrinking,
        /// <summary>
        /// 少量酒
        /// </summary>
        [Description("少量酒")]
        SmallDirinking
    }
    /// <summary>
    /// 客户重要程度
    /// </summary>
    public enum ImportantLevel
    {
        /// <summary>
        /// 请选择
        /// </summary>
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 非常重要
        /// </summary>
        [Description("非常重要")]
        VeryImportant,
        /// <summary>
        /// 重要
        /// </summary>
        [Description("重要")]
        Important,
        /// <summary>
        /// 一般
        /// </summary>
        [Description("一般")]
        Normal,
        /// <summary>
        /// 较弱
        /// </summary>
        [Description("较弱")]
        Weak
    }
    /// <summary>
    /// 属相
    /// </summary>
    public enum AnimalSign
    {
        [Description("请选择")]
        Default = 0,
        [Description("鼠")]
        Rat,
        [Description("牛")]
        Ox,
        [Description("虎")]
        Tiger,
        [Description("兔")]
        Hare,
        [Description("龙")]
        Dragon,
        [Description("蛇")]
        Snake,
        [Description("马")]
        Horse,
        [Description("羊")]
        Sheep,
        [Description("猴")]
        Monkey,
        [Description("鸡")]
        Cock,
        [Description("狗")]
        Dog,
        [Description("猪")]
        Boar
    }
    /// <summary>
    /// 星座
    /// </summary>
    public enum Constellation
    {
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 牡羊座
        /// </summary>
        [Description("牡羊座")]
        Aries,
        /// <summary>
        /// 金牛座
        /// </summary>
        [Description("金牛座")]
        Taurus,
        /// <summary>
        /// 双子座
        /// </summary>
        [Description("双子座")]
        Gemini,
        /// <summary>
        /// 巨蟹座
        /// </summary>
        [Description("巨蟹座")]
        Cancer,
        /// <summary>
        /// 狮子座
        /// </summary>
        [Description("狮子座")]
        Leo,
        /// <summary>
        /// 处女座
        /// </summary>
        [Description("处女座")]
        Virgo,
        /// <summary>
        ///天秤座 
        /// </summary>
        [Description("天秤座")]
        Libra,
        /// <summary>
        /// 天蝎座
        /// </summary>
        [Description("天蝎座")]
        Scorpio,
        /// <summary>
        /// 射手座
        /// </summary>
        [Description("射手座")]
        Sagittarius,
        /// <summary>
        /// 魔羯座
        /// </summary>
        [Description("魔羯座")]
        Capricorn,
        /// <summary>
        /// 水瓶座
        /// </summary>
        [Description("水瓶座")]
        Aquarius,
        /// <summary>
        /// 双鱼座
        /// </summary>
        [Description("双鱼座")]
        Pisces,

    }
    /// <summary>
    /// 洽谈状态
    /// </summary>
    public enum DiscussState
    {
        /// <summary>
        /// 洽谈中
        /// </summary>
        Running = 0,

    }
    /// <summary>
    /// 结算状态
    /// </summary>
    public enum SettleState
    {
        [Description("请选择")]
        Default = 0,
        /// <summary>
        /// 未结算
        /// </summary>
        [Description("未结算")]
        NoSettle,
        /// <summary>
        /// 已经结算
        /// </summary>
        [Description("已经结算")]
        Settled,
    }
    /// <summary>
    /// 投诉/建议
    /// </summary>
    public enum SuggestComplaints
    {
        /// <summary>
        /// 建议
        /// </summary>
        Suggest = 0,
        /// <summary>
        /// 投诉
        /// </summary>
        Complaints,

    }
    /// <summary>
    /// 财务类别
    /// </summary>
    public enum FinancialType
    {
        /// <summary>
        /// 收款
        /// </summary>
        Receive,
        /// <summary>
        /// 付款
        /// </summary>
        Pay
    }
   
}
