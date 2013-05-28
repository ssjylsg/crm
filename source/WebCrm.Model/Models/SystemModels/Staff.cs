using System;
using System.Collections;

namespace WebCrm.Model
{
    #region HRRSStaff

    /// <summary>
    /// 员工信息表
    /// </summary>
    public class Staff : CrmEntity
    {



        #region Public Properties


        public virtual string Code { get; set; }

        public virtual string RealName { get; set; }

        public virtual string CardNO { get; set; }

        public virtual string EnglishName
        {
            get;

            set;
        }

        public virtual int WageBooksId
        {
            get;

            set;
        }

        public virtual int AccountNature
        {
            get;

            set;
        }

        public virtual Sex Sex
        {
            get;

            set;
        }

        public virtual string Photo
        {
            get;

            set;
        }

        public virtual DateTime? Birthday
        {
            get;

            set;
        }

        public virtual string Nation
        {
            get;

            set;
        }

        public virtual string Hometown
        {
            get;

            set;
        }

        public virtual string Political
        {
            get;

            set;
        }

        public virtual string Phone
        {
            get;

            set;
        }

        public virtual string Tel
        {
            get;

            set;
        }

        public virtual string Fax
        {
            get;

            set;
        }

        public virtual string Email
        {
            get;

            set;
        }

        public virtual string QQ
        {
            get;

            set;
        }

        public virtual string MSN
        {
            get;

            set;
        }

        public virtual string Address
        {
            get;

            set;
        }

        public virtual string OtherAddress
        {
            get;

            set;
        }

        public virtual string ZipCode
        {
            get;

            set;
        }

        public virtual int HouseInfo
        {
            get;

            set;
        }

        public virtual int IsZanZhu
        {
            get;

            set;
        }

        public virtual string ZanZhuZheng
        {
            get;

            set;
        }

        public virtual int AreaID
        {
            get;

            set;
        }

        public virtual string IDCard
        {
            get;

            set;
        }

        public virtual int IsMarried
        {
            get;

            set;
        }

        public virtual string GraduateSchool
        {
            get;

            set;
        }

        public virtual DateTime? GraduationTime
        {
            get;

            set;
        }

        public virtual string Professional
        {
            get;

            set;
        }

        public virtual string Degree
        {
            get;

            set;
        }

        public virtual string SecondDegree
        {
            get;

            set;
        }

        public virtual string Titles
        {
            get;

            set;
        }

        public virtual DateTime? GetTitlesTime
        {
            get;

            set;
        }

        public virtual string ForeignLanguage
        {
            get;

            set;
        }

        public virtual Department Department
        {
            get;

            set;
        }

        public virtual Post Post
        {
            get;

            set;
        }

        public virtual DateTime? WorkTime
        {
            get;

            set;
        }

        public virtual int WorkAge
        {
            get;

            set;
        }

        public virtual int EmployType
        {
            get;

            set;
        }

        public virtual DateTime? EntryTime
        {
            get;

            set;
        }

        public virtual int ProbationaryPeriod
        {
            get;

            set;
        }

        public virtual DateTime? ForecastPositiveTime
        {
            get;

            set;
        }

        public virtual string PositiveTime
        {
            get;

            set;
        }

        public virtual int EnterprisesAge
        {
            get;

            set;
        }

        public virtual string RetireesDate
        {
            get;

            set;
        }

        public virtual int JobStatus
        {
            get;

            set;
        }

        public virtual string Hobby
        {
            get;

            set;
        }

        public virtual string Motto
        {
            get;

            set;
        }

        public virtual string Specialty
        {
            get;

            set;
        }

        public virtual string Col1
        {
            get;

            set;
        }

        public virtual string Col2
        {
            get;

            set;
        }

        public virtual string Col3
        {
            get;

            set;
        }

        public virtual string Col4
        {
            get;

            set;
        }

        public virtual string Col5
        {
            get;

            set;
        }

        public virtual string Col6
        {
            get;

            set;
        }

        public virtual int Col7
        {
            get;

            set;
        }

        public virtual int Col8
        {
            get;

            set;
        }

        public virtual byte[] Col9
        {
            get;

            set;
        }
 
        public virtual string OptorName
        {
            get;

            set;
        }

        public virtual string Remark
        {
            get;

            set;
        }

        public virtual bool Deleted
        {
            get;

            set;
        }

        public virtual Company Company { get; set; }



        #endregion
    }
    #endregion
}