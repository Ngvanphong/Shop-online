using ShopOnline.Data.Inframestructure;
using ShopOnline.Data.Reponsitories;
using ShopOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Service
{
    public interface IAboutService
    {
        About GetSingle();       
        void Update(About about);
        void Create(About about);
        void Delete(int id);
        void SaveChange();

    }
    public class AboutService : IAboutService
    {
        IAboutRepository _aboutRepository;
        IUnitOfWork _unitOfWork;
        public AboutService(IAboutRepository aboutRepository, IUnitOfWork unitOfWowk)
        {
            this._aboutRepository = aboutRepository;          
        }
        public void Create(About about)
        {
            _aboutRepository.Add(about);          
        }

        public void Delete(int id)
        {
            About about = _aboutRepository.GetSingleById(id);
            _aboutRepository.Delete(about);
        }

        public About GetSingle()
        {
            return _aboutRepository.GetAll().SingleOrDefault();
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(About about)
        {
            _aboutRepository.Update(about);
        }
    }
}
