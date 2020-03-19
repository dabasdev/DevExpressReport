using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T871027.VM;

namespace T871027
{
    public partial class Form1 : Form
    {
        private readonly SalaryAppContext _db = new SalaryAppContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var report = new XtraReport1();

            var data = _db.AccountStatement
                .Select(x => new AccountForDto()
                {
                    EmployeeName = x.Employee.EmployeeName,
                    OperationName = x.Operation.OperationName,
                    SumOfCredit = x.Credit,
                    SumOfDebit = x.Debit,
                }).ToList();

            report.DataSource = new BindingSource(data , "");

            var tool = new ReportPrintTool(report);

            tool.ShowPreview();
        }
    }


    public class Source : List<Item>
    {
        public Source()
        {
            for (int i = 0; i < 5; i++)
            {
                Add(new Item() { EmployeeName = "Name1", OperationName = "OperationName" + i.ToString(), SumOfCredit = (i + 1) * 2, SumOfDebit = (i + 1) * 20 });
            }            
            this[2].SumOfDebit = 0;
            this[3].SumOfCredit = 0;


            for (int i = 5; i < 8; i++)
            {
                Add(new Item() { EmployeeName = "Name2", OperationName = "OperationName" + i.ToString(), SumOfCredit = (i + 1) * 2, SumOfDebit = (i + 1) * 20 });
            }
            this[5].SumOfDebit = 0;
            this[7].SumOfCredit = 0;
        }
    }


    public class Item 
    {
        public string OperationName { get; set; }
        public string EmployeeName { get; set; }
        public float? SumOfDebit { get; set; }
        public float? SumOfCredit { get; set; }
    }

}
