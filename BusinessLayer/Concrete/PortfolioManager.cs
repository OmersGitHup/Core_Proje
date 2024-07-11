using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void TAdd(Portfolio t)
        {
            _portfolioDal.Insert(t);
        }
        //a

        public void TDelete(Portfolio t)
        {
            throw new NotImplementedException();
        }

        public Portfolio TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Portfolio> TGetList()
        {
           return _portfolioDal.GetList();
        }

        public void TUpdate(Portfolio t)
        {
            throw new NotImplementedException();
        }
    }
}
