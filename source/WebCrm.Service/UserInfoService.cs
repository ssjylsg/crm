using System.Linq;
using System.Collections.Generic;
using WebCrm.Model;
using WebCrm.Model.Repositories;
using WebCrm.Model.Services;
using System.Data;

namespace WebCrm.Service
{
    public class UserInfoService : BaseRequestService<OperatorUser>, IUserInfoService
    {
        private IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }


        public void SaveOrUpdate(OperatorUser operatorUser)
        {
            this._userInfoRepository.SaveOrUpdate(operatorUser);
        }

        public OperatorUser FindByUserName(string userName)
        {
            return this._userInfoRepository.FindByUserName(userName);
        }

        public void SaveStaff(Staff staff)
        {
            _userInfoRepository.SaveObject(staff);
        }

        public void UpdateStaff(Staff staff)
        {
            _commonRepository.Update(staff);
        }
        public Staff FindStaffById(int id)
        {
            return this._userInfoRepository.FindStaffById(id);
        }

        public void Query(PageQuery<IDictionary<string, object>, OperatorUser> pageQuery)
        {
            _userInfoRepository.Query(pageQuery);
        }

        public bool ExistName(string name, int id)
        {
            return
                this._userInfoRepository.Query(string.Format(
                    "From  OperatorUser Where OperatorCode = '{0}' And Id != {1}", name, id)).ToList().Count > 0;

        }

        public IList<OperatorUser> FindListByIds(int[] ids)
        {
            return this._userInfoRepository.GetByIds<OperatorUser>(ids).ToList();
        }

        public void QueryStaff(PageQuery<IDictionary<string, object>, Staff> pageQuery)
        {
            this._userInfoRepository.QueryStaff(pageQuery);
        }

        public IList<Staff> GetNotOperater(OperatorUser operatorUser)
        {
            return _userInfoRepository.GetNotOperater(operatorUser);
        }
        public DataTable GetByCondition(Dictionary<string, object> dict, string selectFields = "*")
        {
            return _userInfoRepository.GetByCondition(dict, selectFields);
        }

        public void AddAdmin()
        {

            var admin = FindByUserName("ADMIN");

            if (admin == null)
            {
                // 员工信息基本信息
                Staff staff = new Staff();
                staff.Sex = Sex.Male;
                staff.Specialty = "admin";
                staff.Tel = "0571-";
                staff.Titles = " ";
                staff.WageBooksId = 0;
                staff.WorkAge = 25;

                this.SaveStaff(staff);


                OperatorUser operatorUser = new OperatorUser();
                operatorUser.OperatorName = "管理员";
                operatorUser.OperatorCode = "ADMIN";
                operatorUser.OperatorPass = ("admin").Md5();
                operatorUser.IsCrm = true;
                operatorUser.SetId(staff.Id);
                Save(operatorUser);
                Save(operatorUser);
            }
            else
            {
                admin.IsCrm = true;
                admin.UseFlag = 1;
                this.Update(admin);
            }
        }
    }
}
