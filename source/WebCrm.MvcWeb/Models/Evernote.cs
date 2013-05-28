using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebCrm.Framework;
using WebCrm.Model.Services;

namespace WebCrm.MvcWeb.Models
{
    public class EvernoteModel
    {
        public string ID { get; set; }
        [Display(Name = "内容")]
        public string Content { get; set; }
        [Display(Name = "创建人")]
        public int CreateUser { get; set; }
        [Display(Name = "标题")]
        public string Title { get; set; }

        public string DisplayName { get; set; }
        public EvernoteModel(EvernoteEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            this.ID = entity.Id.ToString();
            this.Content = entity.Content;
            this.CreateUser = entity.CreateUser != null ? entity.CreateUser.Id : 0;
            this.Title = entity.Title;
            DisplayName = entity.CreateUser != null ? entity.CreateUser.OperatorName : string.Empty;
        }

        public EvernoteModel()
        {

        }

        public EvernoteEntity ConvertToEntity()
        {
            if (string.IsNullOrEmpty(ID))
            {
                ID = "-1";
            }
            var entity = ModelReposity.FindById(int.Parse(ID)) ?? new EvernoteEntity();

            entity.Title = this.Title;
            entity.CreateUser = DependencyResolver.Resolver<IUserInfoService>().FindById(this.CreateUser);
            entity.Content = this.Content;
            return entity;
        }
    }
    public class EvernoteEntity : WebCrm.Model.CrmEntity
    {
        public string Group { get; set; }
        public string Title { get; set; }
        public WebCrm.Model.OperatorUser CreateUser { get; set; }
        public string Content { get; set; }
    }

    public class ModelReposity
    {
        private static IList<EvernoteEntity> _models;
        private static int _id = 1;
        public static int GenerateId()
        {
            System.Threading.Interlocked.Add(ref _id, 1);
            return _id;
        }
        static ModelReposity()
        {
            _models = new List<EvernoteEntity>();
            for (int i = 0; i < 20; i++)
            {
                var model = new EvernoteEntity() { Content = i.ToString(), Group = i.ToString(), Title = string.Format("第{0}个", i) };
                model.CreateUser = DependencyResolver.Resolver<IUserInfoService>().FindByUserName("LISG");
                model.SetId(GenerateId());
                _models.Add(model);
            }
        }
        public static EvernoteEntity FindById(int id)
        {
            return _models.FirstOrDefault(m => m.Id == id);
        }
        public static void Save(EvernoteEntity entity)
        {
            var model = FindById(entity.Id);
            if (model == null)
            {
                entity.SetId(GenerateId());
                _models.Add(entity);
            }
            else
            {
                _models.Remove(model);
                _models.Add(entity);
            }
        }
        public static void Delete(int id)
        {
            var mode = FindById(id);
            if(mode != null)
            {
                _models.Remove(mode);
            }
        }
        internal static IList<EvernoteEntity> FindAll()
        {
            return _models;
        }

        internal static void RemoveAll()
        {
            _models.Clear();
        }
    }

}