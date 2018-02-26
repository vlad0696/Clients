using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clients.Models;
namespace Clients.Controllers
{
    public class BankController : Controller
    {
        PersonContext context = new PersonContext();
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult CreateNewCredit(int id)
        {
            ViewBag.Client = id;
            return View();

        }
        [HttpPost]
        public ActionResult CreateNewCredit(int id, int Credit, int Ammount)
        {
            Credit credit = context.Credit.Where(c => c.CreditID == Credit).FirstOrDefault();
            ClientsCredit lastDeposit = context.ClientsCredit.ToList().LastOrDefault();
            String num = lastDeposit.ClientCreditNumber.Substring(lastDeposit.ClientCreditNumber.Length - 9);
            int depNum = int.Parse(num);
            depNum++;
            num = depNum.ToString();
            while (num.Length != 9)
            {
                num = "0" + num;
            }

            ClientsCredit newCredit = new ClientsCredit();
            newCredit.ClientID = id;
            newCredit.Active = true;
            newCredit.CreditID = Credit;
            newCredit.DateStart = DateTime.Today;
            newCredit.DateEnd = DateTime.Today.AddMonths(credit.Period);
            newCredit.Period = credit.Period;
            newCredit.Amount = Ammount;
            newCredit.Diff = credit.Diff;
            newCredit.ClientCreditNumber = credit.BalanceId.ToString() + num; ;
            newCredit.Period = credit.Period;
            context.ClientsCredit.Add(newCredit);

            Currency currency = context.Currency.Where(c => c.CurrencyID == credit.CurrencyID).FirstOrDefault();
            ClientsDeposit Fond = context.ClientsDeposits.Where(d => d.ClientID == 0).FirstOrDefault();
            ClientsDeposit fond = Fond;
            fond.Amount = Fond.Amount - newCredit.Amount * currency.Value;
            context.Entry(Fond).CurrentValues.SetValues(fond);

            InterestCredit interestCredit = new InterestCredit
            {
                ClientsCreditID = newCredit.ClientsCreditID,
                InterestCreditNumber = "6660" + num,
                Active = true,
                Amount = newCredit.Amount * (credit.Percent * credit.Period / 12) / 100 + newCredit.Amount,
                PayMonths = 0,
                Period= credit.Period
        };

            if (newCredit.Diff)
            {
                interestCredit.MonthlyPayment = (interestCredit.Amount - newCredit.Amount) / (interestCredit.Period - 1);
                interestCredit.LastMonthlyPayment = newCredit.Amount;
            }
            else
            {
                interestCredit.MonthlyPayment = interestCredit.Amount / interestCredit.Period;
                interestCredit.LastMonthlyPayment = interestCredit.MonthlyPayment;

            }
            context.InterestCredit.Add(interestCredit);
            context.SaveChanges();
            return Json(new AjaxResponse(new AjaxResponse()));

        }
        #region credit view
        [HttpGet]
        public JsonResult getCrediits()
        {

            var credits = context.Credit.ToList();
            List<DropdownValues> list = new List<DropdownValues>();
            foreach (Models.Credit obj in credits)
            {
                String str;
                if (obj.Diff)
                {
                    str = "Дифференцированный";
                }
                else
                {
                    str = "Аннуитетный";

                }
               list.Add(new DropdownValues(obj.CreditID, str + " кредит \"" + obj.DepositName + "\" под " + obj.Percent.ToString() + "% на " + obj.Period + " месяцев"));
            }
            DropDown dd = new DropDown(list);

            return Json(dd, JsonRequestBehavior.AllowGet);
        }
     
        public ActionResult CreditsList(int id)
        {
            Client client = context.Clients.Where(c => c.ClientID == id).FirstOrDefault();
            ViewBag.client = client;
            List<ClientsCredit> clientsCreditList = context.ClientsCredit.Where(c => c.ClientID == id).ToList();
            List<CreditView> creditViewList = new List<CreditView>();
            foreach (ClientsCredit cc in clientsCreditList)
            {
                creditViewList.Add(new CreditView
                {
                    ClientsCredittID = cc.ClientsCreditID,
                    CreditID = cc.CreditID,
                    CreditNumber = cc.ClientCreditNumber,
                    DateStart = cc.DateStart,
                    Amount = cc.Amount,
                    Active = cc.Active

                });

            }
            List<Credit> credits = context.Credit.ToList();
            int i =0;
            foreach (CreditView cc in creditViewList)
            {
                foreach (Credit c in credits)
                {
                    if (cc.CreditID == c.CreditID)
                    {
                        creditViewList[i].CreditName = c.DepositName;
                        creditViewList[i].Percent = c.Percent;
                    }
                }
                i++;
            }
            ViewBag.credits = creditViewList;
            return View();
        }
        public class CreditView
        {
            public int CreditID { get; set; }
            public int ClientsCredittID { get; set; }
            public string CreditName { get; set; }
            public string CreditNumber { get; set; }
            public int Percent { get; set; }
            public DateTime DateStart { get; set; }
            public int Period { get; set; }
            public double Amount { get; set; }
            public bool Active { get; set; }

        }
        #endregion

        #region Deposits
        public ActionResult DepositList(int Id)
        {
            Client client = context.Clients.Where(c => c.ClientID == Id).FirstOrDefault();
            ViewBag.client = client;
            List<ClientsDeposit> clientDeposits = context.ClientsDeposits.Where(d => d.ClientID == client.ClientID).ToList();
            List<Deposits> deposits = new List<Deposits>();
            foreach (ClientsDeposit deposit in clientDeposits)
            {
                deposits.Add(new Deposits
                {
                    DepositID = deposit.DepositID,
                    DepositNumber = deposit.ClientDepositNumber,
                    DateStart = deposit.DateStart,
                    Period = deposit.Period,
                    Amount = deposit.Amount,
                    ClientsDepositID = deposit.ClientsDepositID,
                    Active = deposit.Active

                });
            }
            List<Deposit> Deposit = context.Deposits.ToList();
            List<Currency> Currency = context.Currency.ToList();
            List<InterestDeposit> InterestDeposit = context.InterestDeposits.ToList();
            int i = 0;
            foreach (Deposits dep in deposits)
            {
                foreach(Deposit d in Deposit)
                {
                    if (dep.DepositID == d.DepositID)
                    {
                        deposits[i].DepositName = d.DepositName;
                        deposits[i].Percent = d.Percent;
                        deposits[i].CurrencyID = d.CurrencyID;
                        deposits[i].Revocable = d.Revocable;
                    }
                }
                foreach (Currency c in Currency)
                {
                    if (dep.CurrencyID == c.CurrencyID)
                    {
                        deposits[i].Currency = c.Name;
                    }
                }
                foreach (InterestDeposit c in InterestDeposit)
                {
                    if (dep.ClientsDepositID == c.ClientsDepositID)
                    {
                        deposits[i].InterestAmount = c.Amount;
                    }
                }
                i++;
            }
            ViewBag.deposits = deposits;
            
            return View();
        }

        public class Deposits
        {

            public int DepositID { get; set; }
            public int ClientsDepositID { get; set; }
            public int CurrencyID { get; set; }
            public string DepositName { get; set; }
            public string DepositNumber { get; set; }
            public string Currency { get; set; }
            public int Percent { get; set; }
            public DateTime DateStart { get; set; }
            public int Period { get; set; }
            public double Amount { get; set; }
            public double InterestAmount { get; set; }
            public bool Active { get; set; }
            public bool Revocable { get; set; }

        }

        [HttpGet]
        public JsonResult getDeposits()
        {

            var deposits = context.Deposits.ToList();
            List<DropdownValues> list = new List<DropdownValues>();
            foreach (Models.Deposit obj in deposits)
            {
                String str;
                if (obj.Revocable)
                {
                    str = "Отзывной";
                }
                else
                {
                    str = "Безотзывной";

                }
                if (obj.DepositID != 2)
                {
                    list.Add(new DropdownValues(obj.DepositID, str + " депозит \"" + obj.DepositName + "\" под " + obj.Percent.ToString() + "% на " + obj.Period + " месяцев"));
                }
            }
            DropDown dd = new DropDown(list);

            return Json(dd, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateNew(int id)
        {
            ViewBag.client = id;
            return View();
        }
        #endregion

        [HttpPost]
        public ActionResult CreateNew(NewDeposit newDeposit)
        {
            Deposit deposit = context.Deposits.Where(d => d.DepositID == newDeposit.Deposit).FirstOrDefault();
            ClientsDeposit lastDeposit = context.ClientsDeposits.ToList().LastOrDefault();
            String num = lastDeposit.ClientDepositNumber.Substring(lastDeposit.ClientDepositNumber.Length - 9);
            int depNum = int.Parse(num);
            depNum++;
            num = depNum.ToString();
            while (num.Length != 9)
            {
                num = "0" + num;
            }
            ClientsDeposit clientsDeposit = new ClientsDeposit();
            clientsDeposit.ClientID = newDeposit.id;
            clientsDeposit.DepositID = newDeposit.Deposit;
            clientsDeposit.Amount = newDeposit.Ammount;
            clientsDeposit.DateStart = DateTime.Today;
            clientsDeposit.DateEnd = DateTime.Today.AddMonths(deposit.Period);
            clientsDeposit.Period = deposit.Period;
            clientsDeposit.ClientDepositNumber = deposit.BalanceId.ToString() + num;
            clientsDeposit.Revocable = deposit.Revocable;
            clientsDeposit.Active = true;
            context.ClientsDeposits.Add(clientsDeposit);
            context.SaveChanges();
            Currency currency = context.Currency.Where(c => c.CurrencyID == deposit.CurrencyID).FirstOrDefault();

            ClientsDeposit Fond = context.ClientsDeposits.Where(d => d.ClientID == 0).FirstOrDefault();
            ClientsDeposit fond = Fond;
            fond.Amount = Fond.Amount+ clientsDeposit.Amount * currency.Value;
            context.Entry(Fond).CurrentValues.SetValues(fond);

            InterestDeposit interestDeposit = new InterestDeposit();
            interestDeposit.ClientsDepositID = clientsDeposit.ClientsDepositID;
            interestDeposit.InterestDepositNumber = clientsDeposit.ClientDepositNumber = "7770" + num;
            interestDeposit.InitialAmount = clientsDeposit.Amount;
            interestDeposit.Percent = deposit.Percent;
            interestDeposit.Amount = 0;
            interestDeposit.Active = true;
            context.InterestDeposits.Add(interestDeposit);
            context.SaveChanges();
            return Json(new AjaxResponse(new AjaxResponse()));
        }

        
        public class NewDeposit
        {
            public int id { get; set; }
            public int Deposit { get; set; }
            public int Ammount { get; set; }
        }

        public ActionResult EndDay()
        {
            List<InterestDeposit> listInterestDepostis = context.InterestDeposits.ToList();
            ClientsDeposit Fond = context.ClientsDeposits.Where(c => c.ClientID == 0).FirstOrDefault();
            Double fondAmmount = Fond.Amount;
            InterestDeposit temp;
            foreach (InterestDeposit deposit in listInterestDepostis)
            {
                if (deposit.Active)
                {
                    temp = deposit;
                    temp.Amount += ((temp.InitialAmount * temp.Percent) / 100) / 365;
                    fondAmmount-= ((temp.InitialAmount * temp.Percent) / 100) / 365;
                    context.Entry(deposit).CurrentValues.SetValues(temp);
                }
            }
            
            ClientsDeposit tempFond = Fond;
            tempFond.Amount = fondAmmount;
            context.Entry(Fond).CurrentValues.SetValues(tempFond);
            context.SaveChanges();
            return Json(new AjaxResponse(new  AjaxResponse()));
        }
        public ActionResult Revocable(int id)
        {
            InterestDeposit interestDeposit = context.InterestDeposits.Where(i=>i.ClientsDepositID==id).FirstOrDefault();
            InterestDeposit tempInterest = interestDeposit;
            tempInterest.Active = false;
            context.Entry(interestDeposit).CurrentValues.SetValues(tempInterest);
            ClientsDeposit clientDeposit = context.ClientsDeposits.Where(c => c.ClientsDepositID ==id).FirstOrDefault();
            ClientsDeposit tempDeposit = clientDeposit;
            tempDeposit.Active = false;
            context.Entry(clientDeposit).CurrentValues.SetValues(tempDeposit);
            ClientsDeposit Fond = context.ClientsDeposits.Where(c => c.ClientID == 0).FirstOrDefault();
            ClientsDeposit tempFond = Fond;
            tempFond.Amount -= clientDeposit.Amount;
            context.Entry(Fond).CurrentValues.SetValues(tempFond);
            context.SaveChanges();
            return RedirectToAction("/DepositList/"+clientDeposit.ClientID.ToString());
        }
    }
}