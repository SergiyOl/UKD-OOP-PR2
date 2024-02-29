using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Finance
    {
        public List<FinancialArticle> financialArticles = new();

        public void addFinancialArticle(string _name, double _cost, DateTime _creationDate)
        {
            financialArticles.Add(new FinancialArticle(_name, _cost, _creationDate));
        }

        public double CalculateSpentMoneyPerMonth(int searshedMonth, int searshedYear)
        {
            double spentMoney = 0;
            foreach(var article in financialArticles.Where(x => x.creationDate >= new DateTime(searshedYear, searshedMonth, 1) && 
                                                             x.creationDate < new DateTime(searshedYear, searshedMonth+1, 1))) 
            {
                spentMoney = spentMoney + article.cost;
            }
            return spentMoney;
        }
    }
}
